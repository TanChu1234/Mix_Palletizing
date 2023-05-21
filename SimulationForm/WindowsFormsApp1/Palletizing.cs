using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers;
using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace WindowsFormsApp1
{
    public partial class Palletizing : Form
    {
        Controller controller = null;

        [Obsolete]
        public Palletizing()
        {
            InitializeComponent();
            controller = ConnectionForm.controller;
            
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            FormMain.activeForm.Hide();
        }

        private void Paletizing_Load(object sender, EventArgs e)
        {
            
        }
        private int[] width_value = FormData.width_value;
        private int[] height_value = FormData.height_value;
        private int[] depth_value = FormData.depth_value;
        private int[] weight_value = FormData.weight_value;
        private int[] n = FormData.n;
        static int totalBox = 0;
        static dynamic l1;
        static dynamic l2;
        static dynamic l3;
        static dynamic l4;
        //dynamic ListPosOnPallet = null;
        [Obsolete]
        private void Solve_Click(object sender, EventArgs e)
        {
            var engine = Python.CreateEngine();
            var searchPaths = engine.GetSearchPaths();
            //searchPaths.Add(@"C:\Users\USER\.vscode\extensions\ms-python.python-2022.4.1\pythonFiles\lib\jedilsp\jedi\third_party\typeshed\stdlib\3\random.pyi"); // add your path to the stdlib here
            searchPaths.Add(@"C:\Program Files\IronPython 3.4\Lib");
            searchPaths.Add(@"C:\Program Files\IronPython 3.4\Lib\random.py");
            engine.SetSearchPaths(searchPaths);
            dynamic py = engine.ExecuteFile(@"PackbyWDH.py");
            dynamic ListPosOnPallet = py.run(width_value[0], depth_value[0], height_value[0], weight_value[0], n[0], width_value[1], depth_value[1], height_value[1], weight_value[1], n[1], width_value[2], depth_value[2], height_value[2], weight_value[2], n[2], width_value[3], depth_value[3], height_value[3], weight_value[3], n[3]);
            //var list = Enumerable.ToList(ListPosOnPallet);
            l1 = ListPosOnPallet[0];
            l2 = ListPosOnPallet[1];
            l3 = ListPosOnPallet[2];
            l4 = ListPosOnPallet[3];
            totalBox = n[0] + n[1] + n[2] + n[3];
            //Console.WriteLine(ListPosOnPallet);

            // VOLUME IN EXCESS
            if (l1 != null)
            {
                ListViewItem item = new ListViewItem("COG Priority");
                item.SubItems.Add(l1[-7].ToString());
                item.SubItems.Add(l1[-8].ToString());
                item.SubItems.Add(l1[-5].ToString());
                listView3.Items.Add(item);      

            }
            if (l2 != null)
            {
                ListViewItem item = new ListViewItem("Balance");
                item.SubItems.Add(l2[-7].ToString());
                item.SubItems.Add(l2[-8].ToString());
                item.SubItems.Add(l2[-5].ToString());
                listView3.Items.Add(item);

            }
            if (l3 != null)
            {
                ListViewItem item = new ListViewItem("Volume Priority");
                item.SubItems.Add(l3[-7].ToString());
                item.SubItems.Add(l3[-8].ToString());
                item.SubItems.Add(l3[-5].ToString());
                listView3.Items.Add(item);

            }
            if (l4 != null)
            {
                ListViewItem item = new ListViewItem("Totalbox Priority");
                item.SubItems.Add(l4[-7].ToString());
                item.SubItems.Add(l4[-8].ToString());
                item.SubItems.Add(l4[-5].ToString());
                listView3.Items.Add(item);

            }

            // GET TARGET FROM LISTPOSONPALLET TO ROBOT STUDIO
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMain.Palletizing_Form = null;
        }

        [Obsolete]
        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                for (int i = 0; i < Convert.ToInt64(l1[-8]); i++)   // ListPosOnPallet[-1] TOTAL BOXES THAT FIT 
                {
                    Pos rt = new Pos();
                    Pos off = new Pos();
                    Num no = new Num();
                    Num numBox;
                    //Num config = new Num();
                    RapidData rd_targets = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("tgPos");
                    RapidData offset = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("offset");
                    RapidData No = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("no");
                    RapidData fittedBox = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("fittedBox");
                    //RapidData Config = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("config");

                    rt.X = Convert.ToInt64(l1[i][1]);
                    rt.Y = Convert.ToInt64(l1[i][2]);
                    rt.Z = Convert.ToInt64(l1[i][3]);

                    off.X = Convert.ToInt64(l1[i][1]);
                    off.Y = Convert.ToInt64(l1[i][2]);
                    off.Z = Convert.ToInt64(l1[i][3]) + 500;

                    no.FillFromNum(Convert.ToInt64(l1[i][0]));
                    //config.FillFromNum(Convert.ToInt64(ListPosOnPallet[i][4]));
                    Debug.WriteLine(rt.ToString());
                    //Debug.WriteLine(off.ToString());
                    Debug.WriteLine(no.ToString());
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        numBox = (Num)fittedBox.Value;
                        numBox.FillFromNum(Convert.ToInt64(l1[-8]));
                        fittedBox.Value = numBox;
                        rd_targets.WriteItem(rt, i);
                        offset.WriteItem(off, i);
                        No.WriteItem(no, i);
                        //Config.WriteItem(config, i);
                    }
                }
                return;
            }

            else if (radioButton2.Checked == true)
            {
                for (int i = 0; i < Convert.ToInt64(l2[-8]); i++)   // ListPosOnPallet[-1] TOTAL BOXES THAT FIT 
                {
                    Pos rt = new Pos();
                    Pos off = new Pos();
                    Num no = new Num();
                    Num numBox;
                    //Num config = new Num();
                    RapidData rd_targets = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("tgPos");
                    RapidData offset = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("offset");
                    RapidData No = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("no");
                    RapidData fittedBox = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("fittedBox");
                    //RapidData Config = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("config");

                    rt.X = Convert.ToInt64(l2[i][1]);
                    rt.Y = Convert.ToInt64(l2[i][2]);
                    rt.Z = Convert.ToInt64(l2[i][3]);

                    off.X = Convert.ToInt64(l2[i][1]);
                    off.Y = Convert.ToInt64(l2[i][2]);
                    off.Z = Convert.ToInt64(l2[i][3]) + 500;

                    no.FillFromNum(Convert.ToInt64(l2[i][0]));
                    //config.FillFromNum(Convert.ToInt64(ListPosOnPallet[i][4]));
                    Debug.WriteLine(rt.ToString());
                    //Debug.WriteLine(off.ToString());
                    Debug.WriteLine(no.ToString());
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        numBox = (Num)fittedBox.Value;
                        numBox.FillFromNum(Convert.ToInt64(l2[-8]));
                        fittedBox.Value = numBox;
                        rd_targets.WriteItem(rt, i);
                        offset.WriteItem(off, i);
                        No.WriteItem(no, i);
                        //Config.WriteItem(config, i);
                    }
                }
                return;

            }

            else if (radioButton3.Checked == true)
            {
                for (int i = 0; i < Convert.ToInt64(l3[-8]); i++)   // ListPosOnPallet[-1] TOTAL BOXES THAT FIT 
                {
                    Pos rt = new Pos();
                    Pos off = new Pos();
                    Num no = new Num();
                    Num numBox;
                    //Num config = new Num();
                    RapidData rd_targets = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("tgPos");
                    RapidData offset = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("offset");
                    RapidData No = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("no");
                    RapidData fittedBox = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("fittedBox");
                    //RapidData Config = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("config");

                    rt.X = Convert.ToInt64(l3[i][1]);
                    rt.Y = Convert.ToInt64(l3[i][2]);
                    rt.Z = Convert.ToInt64(l3[i][3]);

                    off.X = Convert.ToInt64(l3[i][1]);
                    off.Y = Convert.ToInt64(l3[i][2]);
                    off.Z = Convert.ToInt64(l3[i][3]) + 500;

                    no.FillFromNum(Convert.ToInt64(l3[i][0]));
                    //config.FillFromNum(Convert.ToInt64(ListPosOnPallet[i][4]));
                    Debug.WriteLine(rt.ToString());
                    //Debug.WriteLine(off.ToString());
                    Debug.WriteLine(no.ToString());
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        numBox = (Num)fittedBox.Value;
                        numBox.FillFromNum(Convert.ToInt64(l3[-8]));
                        fittedBox.Value = numBox;
                        rd_targets.WriteItem(rt, i);
                        offset.WriteItem(off, i);
                        No.WriteItem(no, i);
                        //Config.WriteItem(config, i);
                    }
                }
                return;

            }

            else if (radioButton4.Checked == true)
            {
                for (int i = 0; i < Convert.ToInt64(l4[-8]); i++)   // ListPosOnPallet[-1] TOTAL BOXES THAT FIT 
                {
                    Pos rt = new Pos();
                    Pos off = new Pos();
                    Num no = new Num();
                    Num numBox;
                    //Num config = new Num();
                    RapidData rd_targets = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("tgPos");
                    RapidData offset = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("offset");
                    RapidData No = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("no");
                    RapidData fittedBox = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("fittedBox");
                    //RapidData Config = controller.Rapid.GetTask("T_ROB1").GetModule("Module1").GetRapidData("config");

                    rt.X = Convert.ToInt64(l4[i][1]);
                    rt.Y = Convert.ToInt64(l4[i][2]);
                    rt.Z = Convert.ToInt64(l4[i][3]);

                    off.X = Convert.ToInt64(l4[i][1]);
                    off.Y = Convert.ToInt64(l4[i][2]);
                    off.Z = Convert.ToInt64(l4[i][3]) + 500;

                    no.FillFromNum(Convert.ToInt64(l4[i][0]));
                    //config.FillFromNum(Convert.ToInt64(ListPosOnPallet[i][4]));
                    Debug.WriteLine(rt.ToString());
                    //Debug.WriteLine(off.ToString());
                    Debug.WriteLine(no.ToString());
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        numBox = (Num)fittedBox.Value;
                        numBox.FillFromNum(Convert.ToInt64(l4[-8]));
                        fittedBox.Value = numBox;
                        rd_targets.WriteItem(rt, i);
                        offset.WriteItem(off, i);
                        No.WriteItem(no, i);
                        //Config.WriteItem(config, i);
                    }
                }
                return;

            }
        }
        int k = 0;
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(l1[-7]);
            textBox1.Text = Math.Round(l1[-7], 2).ToString() + "%";
            //Console.WriteLine(totalBox.ToString());
            k = Convert.ToInt32(l1[-8]);
            //Console.WriteLine(k.ToString());
            progressBar2.Value = k*100/totalBox;
            textBox2.Text = progressBar2.Value.ToString() + "%";
            progressBar3.Value = Convert.ToInt32(l1[-5]);
            textBox3.Text = Math.Round(l1[-5],2).ToString() + "%";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(l2[-7]);
            textBox1.Text = Math.Round(l2[-7],2).ToString() + "%";
            k = Convert.ToInt32(l2[-8]);
            progressBar2.Value = k*100/totalBox;
            textBox2.Text = progressBar2.Value.ToString() + "%";
            progressBar3.Value = Convert.ToInt32(l2[-5]);
            textBox3.Text = Math.Round(l2[-5],2).ToString() + "%";
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(l3[-7]);
            textBox1.Text = Math.Round(l3[-7],2).ToString() + "%";
            k = Convert.ToInt32(l3[-8]);
            progressBar2.Value = k * 100 / totalBox;
            textBox2.Text = progressBar2.Value.ToString() + "%";
            progressBar3.Value = Convert.ToInt32(l3[-5]);
            textBox3.Text = Math.Round(l3[-5], 2).ToString() + "%";
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(l4[-7]);
            textBox1.Text = Math.Round(l4[-7], 2).ToString() + "%";
            k = Convert.ToInt32(l4[-8]);
            progressBar2.Value = k * 100 / totalBox;
            textBox2.Text = progressBar2.Value.ToString() + "%";
            progressBar3.Value = Convert.ToInt32(l4[-5]);
            textBox3.Text = Math.Round(l4[-5], 2).ToString() + "%";
        }
    }
}
