using ABB.Robotics.Controllers.IOSystemDomain;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using IronPython.Hosting;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class FormData : Form
    {
        private Controller controller = ConnectionForm.controller;
        public static int[] width_value = { 0, 0, 0, 0 };
        public static int[] height_value = { 0, 0, 0, 0 };
        public static int[] depth_value = { 0, 0, 0, 0 };
        public static int[] weight_value = { 0, 0, 0, 0 };
        public static int[] n = { 0, 0, 0, 0 };
        [Obsolete]
        public FormData()
        {
            InitializeComponent();
        }

        int ItemCount = 0;
        private void PropertiesSubmit_Button_Click(object sender, EventArgs e)
        {
            //check if the textbox has value
            if (Width_Texbox.Text != null && Height_Texbox.Text != null && Weight_Texbox.Text != null && Depth_Texbox.Text != null && NumofBox_Textbox.Text != null)
            {
                //check if there are existing items
                if (listView2.Items.Count > 0)
                {
                    int AddItemCheck = 0;   //variable to check if items were added
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        //if items have the same name then add more quantities to the existing item
                        if (Name_Textbox.Text == listView2.Items[i].Tag.ToString())
                        {
                            AddItemCheck++;
                            int a = int.Parse(listView2.Items[i].SubItems[6].Text);
                            int b = int.Parse(NumofBox_Textbox.Text);
                            listView2.Items[i].SubItems[6].Text = (a + b).ToString();
                            break;
                        }
                    }
                    //if item isn't added then add new item
                    if (AddItemCheck == 0)
                    {
                        ItemCount++;
                        ListViewItem item = new ListViewItem(Name_Textbox.Text);
                        item.SubItems.Add(ItemCount.ToString());
                        item.SubItems.Add(Width_Texbox.Text);
                        item.SubItems.Add(Depth_Texbox.Text);
                        item.SubItems.Add(Height_Texbox.Text);
                        item.SubItems.Add(Weight_Texbox.Text);
                        item.SubItems.Add(NumofBox_Textbox.Text);
                        listView2.Items.Add(item);
                        item.Tag = Name_Textbox.Text;
                    }
                }
                //if the listview has no item then add new item
                if (listView2.Items.Count == 0)
                {
                    ItemCount++;
                    ListViewItem item = new ListViewItem(Name_Textbox.Text);
                    item.SubItems.Add(ItemCount.ToString());
                    item.SubItems.Add(Width_Texbox.Text);
                    item.SubItems.Add(Depth_Texbox.Text);
                    item.SubItems.Add(Height_Texbox.Text);
                    item.SubItems.Add(Weight_Texbox.Text);
                    item.SubItems.Add(NumofBox_Textbox.Text);
                    listView2.Items.Add(item);
                    item.Tag = Name_Textbox.Text;
                }
            }
        }

        //Method that sends boxes sizes to Robot studio
        [Obsolete]
        private void AddBox(DigitalSignal digitalSignal, RapidData N, int n, float widthTextValue, float depthTextValue, float heightTextValue, RapidData width, RapidData depth, RapidData height)
        {
            using (Mastership m = Mastership.Request(controller))
            {
                Num widthValue;
                Num depthValue;
                Num heightValue;
                Num nBox;

                widthValue = (Num)width.Value;
                widthValue.FillFromNum(widthTextValue);
                width.Value = widthValue;

                depthValue = (Num)depth.Value;
                depthValue.FillFromNum(depthTextValue);
                depth.Value = depthValue;

                heightValue = (Num)height.Value;
                heightValue.FillFromNum(heightTextValue);
                height.Value = heightValue;

                nBox = (Num)N.Value;
                nBox.FillFromNum(n);
                N.Value = nBox;

                digitalSignal.Set();
                digitalSignal.Reset();
            }
        }
        //Method that add Box's target at the end of conveyor base on box's size
        private void AddTargetOnConveyor(RapidData target, float widthTextValue, float depthTextValue, float heightTextValue)
        {
            RobTarget rt = new RobTarget();
            float XPos = depthTextValue / 2;
            float YPos = widthTextValue / 2;
            float ZPos = heightTextValue;
            using (Mastership m = Mastership.Request(controller))
            {
                rt = (RobTarget)target.Value;
                rt.Trans.X = XPos;
                rt.Trans.Y = YPos;
                rt.Trans.Z = ZPos;
                target.Value = rt;
            }
        }

        [Obsolete]
        private void CreateBoxButton_Click(object sender, EventArgs e)
        {
            //declare box's sizes
            RapidData width = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("widthBox");
            RapidData depth = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("depthBox");
            RapidData height = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("heightBox");
            RapidData N = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("N");
            //declare box's target at the end of conveyor
            RapidData GripA = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("GripA");
            RapidData GripB = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("GripB");
            RapidData GripC = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("GripC");
            RapidData GripD = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("GripD");

            try
            {
                if (controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        float widthTextValue = float.Parse(listView2.Items[i].SubItems[2].Text);
                        float depthTextValue = float.Parse(listView2.Items[i].SubItems[3].Text);
                        float heightTextValue = float.Parse(listView2.Items[i].SubItems[4].Text);
                        int n = int.Parse(listView2.Items[i].SubItems[6].Text);
                        //create 5 boxes with the specified sizes in listview and targets of them at the end of the conveyor
                        switch (i)
                        {
                            case 0:
                                DigitalSignal DoSizeBoxA = (DigitalSignal)controller.IOSystem.GetSignal("DoSizeBoxA");
                                AddBox(DoSizeBoxA, N, n, widthTextValue, depthTextValue, heightTextValue, width, depth, height);
                                AddTargetOnConveyor(GripA, widthTextValue, depthTextValue, heightTextValue);
                                break;
                            case 1:
                                DigitalSignal DoSizeBoxB = (DigitalSignal)controller.IOSystem.GetSignal("DoSizeBoxB");
                                AddBox(DoSizeBoxB, N, n, widthTextValue, depthTextValue, heightTextValue, width, depth, height);
                                AddTargetOnConveyor(GripB, widthTextValue, depthTextValue, heightTextValue);
                                break;
                            case 2:
                                DigitalSignal DoSizeBoxC = (DigitalSignal)controller.IOSystem.GetSignal("DoSizeBoxC");
                                AddBox(DoSizeBoxC, N, n, widthTextValue, depthTextValue, heightTextValue, width, depth, height);
                                AddTargetOnConveyor(GripC, widthTextValue, depthTextValue, heightTextValue);
                                break;
                            case 3:
                                DigitalSignal DoSizeBoxD = (DigitalSignal)controller.IOSystem.GetSignal("DoSizeBoxD");
                                AddBox(DoSizeBoxD, N, n, widthTextValue, depthTextValue, heightTextValue, width, depth, height);
                                AddTargetOnConveyor(GripD, widthTextValue, depthTextValue, heightTextValue);
                                break;

                        }
                    }
                        int a = 0;
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        width_value[i] = int.Parse(listView2.Items[i].SubItems[2].Text);
                        depth_value[i] = int.Parse(listView2.Items[i].SubItems[3].Text);
                        height_value[i] = int.Parse(listView2.Items[i].SubItems[4].Text);
                        weight_value[i] = int.Parse(listView2.Items[i].SubItems[5].Text);
                        n[i] = int.Parse(listView2.Items[i].SubItems[6].Text);
                        a = a + n[i];
                    }
                   
                }
                else MessageBox.Show("Automatic mode is required.");
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Mastership is held by another client. " + ex.Message);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Unexpected error occurred: " + ex.Message);
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            FormMain.activeForm.Hide();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMain.Data_Form = null;
        }

        private void DeleteItem_Button_Click_1(object sender, EventArgs e)
        {
            if (listView2.SelectedItems != null)
            {
                //foreach loop to delete every items in SelectedItems
                foreach (ListViewItem item in listView2.SelectedItems)
                {
                    listView2.Items.Remove(item);
                    ItemCount--;
                    //change the 'No' according to existing items in correct order
                    for (int i = 0; i < ItemCount; i++)
                    {
                        listView2.Items[i].SubItems[1].Text = (i + 1).ToString();
                    }
                }
            }
            else MessageBox.Show("Choose item to remove");
        }

        private void FormData_Load(object sender, EventArgs e)
        {

        }
    }
}
