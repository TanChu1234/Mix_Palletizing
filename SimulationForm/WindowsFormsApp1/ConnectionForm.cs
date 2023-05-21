﻿using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers.MotionDomain;
using ABB.Robotics.Controllers.IOSystemDomain;
using System.Drawing;
using System.ComponentModel;
//using RobotStudio.Services.RobApi;
//using System.Diagnostics;
//using System.IO;
//using IronPython.Hosting;
//using Microsoft.Scripting.Hosting;
//using Microsoft.Scripting;
//using static System.Net.WebRequestMethods;
//using static RobotStudio.Services.RobApi.Transport.RWS.RobFileTransferLegacyRWS;
//using System.Security.Cryptography;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class ConnectionForm : Form
    {
        private NetworkScanner scanner = null;
        public static Controller controller = null;
        private NetworkWatcher networkwatcher = null;
        private readonly Timer timer = new Timer();
        public static bool connected = false;

        [Obsolete]
        public ConnectionForm()
        {
            InitializeComponent();
            timer.Interval = 200;
            timer.Tick += TimerTick;
            timer.Enabled = true;
        }
        void TimerTick(object sender, EventArgs e)
        {
            if (controller != null)
            {
                MechanicalUnit aMechUnit = controller.MotionSystem.ActiveMechanicalUnit;
                RobTarget aRobTarget = aMechUnit.GetPosition(CoordinateSystemType.World);
                this.textBox1.Text = aRobTarget.Trans.X.ToString();
                this.textBox2.Text = aRobTarget.Trans.Y.ToString();
                this.textBox3.Text = aRobTarget.Trans.Z.ToString();
            }
            else
            {
                this.textBox1.Text = null;
                this.textBox2.Text = null;
                this.textBox3.Text = null;
            }
        }
        //Add new network to ListView when network found
        void HandleFoundEvent(object sender, NetworkWatcherEventArgs e)
        {
            this.Invoke(new
            EventHandler<NetworkWatcherEventArgs>(AddControllerToListView),
            new Object[] { this, e });
        }
        private void AddControllerToListView(object sender, NetworkWatcherEventArgs e)
        {
            ControllerInfo controllerInfo = e.Controller;
            ListViewItem item = new ListViewItem(controllerInfo.IPAddress.ToString());
            item.SubItems.Add(controllerInfo.Id);
            item.SubItems.Add(controllerInfo.Availability.ToString());
            item.SubItems.Add(controllerInfo.IsVirtual.ToString());
            item.SubItems.Add(controllerInfo.ControllerName);
            item.SubItems.Add("Disconnected");
            this.listView1.Items.Add(item);
            item.Tag = controllerInfo;
        }

        //Remove network from ListView when network disappears
        void HandleLostEvent(object sender, NetworkWatcherEventArgs e)
        {
           this.Invoke(new
           EventHandler<NetworkWatcherEventArgs>(RemoveControllerFromListView),
           new Object[] { this, e });
        }
        private void RemoveControllerFromListView(object sender, NetworkWatcherEventArgs e)
        {
            foreach (ListViewItem item in this.listView1.Items)
            {
                if ((ControllerInfo)item.Tag == e.Controller)
                {
                    this.listView1.Items.Remove(item);
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.scanner = new NetworkScanner();
            this.scanner.Scan();
            ControllerInfoCollection controllers = scanner.Controllers;
            ListViewItem item = null;
            foreach (ControllerInfo controllerInfo in controllers)
            {
                item = new ListViewItem(controllerInfo.IPAddress.ToString());
                item.SubItems.Add(controllerInfo.Id);
                item.SubItems.Add(controllerInfo.Availability.ToString());
                item.SubItems.Add(controllerInfo.IsVirtual.ToString());
                item.SubItems.Add(controllerInfo.ControllerName);
                item.SubItems.Add("Disconnected");
                this.listView1.Items.Add(item);
                item.Tag = controllerInfo;
            }
            this.networkwatcher = new NetworkWatcher(scanner.Controllers);
            this.networkwatcher.Found += new EventHandler<NetworkWatcherEventArgs>(HandleFoundEvent);
            this.networkwatcher.Lost += new EventHandler<NetworkWatcherEventArgs>(HandleLostEvent);
            this.networkwatcher.EnableRaisingEvents = true;
        }

      
        //Removing event handlers, disconnecting to controller when the form is closed
        
        
        private void StartRAPID_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    using (Mastership m = Mastership.Request(controller))
                    {
                        //ABB.Robotics.Controllers.RapidDomain.Task T_ROB1 = controller.Rapid.GetTask("T_ROB1");
                        //T_ROB1.Start(true);
                        
                        controller.Rapid.Start(true);
                    }
                }
                else MessageBox.Show("Automatic mode is required to start execution from a remote client.");
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Mastership is held by another client." + ex.Message);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Unexpected error occurred: " + ex.Message);
            }
        }

        [Obsolete]
        private void StopRAPID_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (controller.Rapid.ExecutionStatus == ExecutionStatus.Running)
                {
        
                    using (Mastership m = Mastership.Request(controller))
                    {
                        //ABB.Robotics.Controllers.RapidDomain.Task T_ROB1 = controller.Rapid.GetTask("T_ROB1");
                        //T_ROB1.Start(true);
                        //controller.Rapid.Start(false);
                        controller.Rapid.Stop(StopMode.Cycle);
                    }
                }
                else MessageBox.Show("The RAPID has stopped");
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Mastership is held by another client." + ex.Message);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Unexpected error occurred: " + ex.Message);
            }
        }
        
        //Connect to the controller - event
        [Obsolete]
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.listView1.SelectedItems[0];
            if (item.Tag != null)
            {
                ControllerInfo controllerInfo = (ControllerInfo)item.Tag;
                if (controllerInfo.Availability == ABB.Robotics.Controllers.Availability.Available)
                {
                    if (controller != null)
                    {
                        controller.Logoff();
                        controller.Dispose();
                        controller = null;
                    }
                    controller = ControllerFactory.CreateFrom(controllerInfo,ControllerFactoryProperty.SystemId,false);
                    controller.Logon(UserInfo.DefaultUser);
                    listView1.SelectedItems[0].SubItems[5].Text = "Connected";
                    connected = true;
                }
                else MessageBox.Show("Selected controller not available.");
            }
            else MessageBox.Show("Please select controller to connect");
        }

        private void DisconnectToController_Button_Click(object sender, EventArgs e)
        {
            if (controller != null)
            {
                controller.State = ABB.Robotics.Controllers.ControllerState.MotorsOff;
                controller.Logoff();
                controller.Dispose();
                controller = null;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[5].Text == "Connected")
                    {
                        listView1.Items[i].SubItems[5].Text = "Disconnected";
                    }
                }
                this.textBox1.Text = null;
                this.textBox2.Text = null;
                this.textBox3.Text = null;
                connected = false;

            }
            else MessageBox.Show("Controller has been disconnected");
        }


        private void HomeButton_Click(object sender, EventArgs e)
        {
            FormMain.activeForm.Hide();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (controller != null)
            {
                controller.State = ABB.Robotics.Controllers.ControllerState.MotorsOff;
                controller.Logoff();
                controller.Dispose();
                controller = null;
            }
            this.networkwatcher.Lost -= new EventHandler<NetworkWatcherEventArgs>(HandleLostEvent);
            this.networkwatcher.Found -= new EventHandler<NetworkWatcherEventArgs>(HandleFoundEvent);
            this.Close();
            FormMain.Connection_Form = null;
        }

        private void MotorOn_Off_Click(object sender, EventArgs e)
        {
                if (controller.State == ABB.Robotics.Controllers.ControllerState.MotorsOn)
                {
                    controller.State = ABB.Robotics.Controllers.ControllerState.MotorsOff;
                }
                else
                {
                    controller.State = ABB.Robotics.Controllers.ControllerState.MotorsOn;
                } 
        }

        private void ConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (controller != null)
            {
                controller.State = ABB.Robotics.Controllers.ControllerState.MotorsOff;
                controller.Logoff();
                controller.Dispose();
                controller = null;
            }
            this.networkwatcher.Lost -= new EventHandler<NetworkWatcherEventArgs>(HandleLostEvent);
            this.networkwatcher.Found -= new EventHandler<NetworkWatcherEventArgs>(HandleFoundEvent);
        }
        private void ConnectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }
    }
}
