using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers.MotionDomain;
using ABB.Robotics.Controllers.IOSystemDomain;
using System.Diagnostics;
using System.IO;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using static System.Net.WebRequestMethods;
using static RobotStudio.Services.RobApi.Transport.RWS.RobFileTransferLegacyRWS;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        public static Form activeForm = null;
        public static FormData Data_Form = null;
        public static Palletizing Palletizing_Form = null;
        public static ConnectionForm Connection_Form = null;
        private bool connected = false;
        private readonly Timer timer = new Timer();

        [Obsolete]
        public FormMain()
        {
            InitializeComponent();
            timer.Interval = 400;
            timer.Tick += TimerTick;
            timer.Enabled = true;
        }

        void TimerTick(object sender, EventArgs e)
        {
            connected = ConnectionForm.connected;
            if (connected == false)
            {
                pictureBox1.BackColor = Color.LightCoral;
            }
            else
            {
                pictureBox1.BackColor = Color.LightGreen;
            }
        }

        [Obsolete]
        private void ConnectionPanel_Click(object sender, EventArgs e)
        {
            if (Connection_Form != null) {OpenChildFormInPanel(Connection_Form);}
            else 
            {
                Connection_Form = new ConnectionForm();
                OpenChildFormInPanel(Connection_Form);
            }
        }


        [Obsolete]
        private void EnterDataPanel_Click(object sender, EventArgs e)
        {
            if (Data_Form != null)
            {
                OpenChildFormInPanel(Data_Form);
            }
            else
            {
                Data_Form = new FormData();
                OpenChildFormInPanel(Data_Form);
            }
        }

        [Obsolete]
        private void Palletizing_Button_Click(object sender, EventArgs e)
        {
            if (Palletizing_Form != null)
            {
                OpenChildFormInPanel(Palletizing_Form);
            }
            else
            {
                Palletizing_Form = new Palletizing();
                OpenChildFormInPanel(Palletizing_Form);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void OpenChildFormInPanel(Form childForm)
        {
            if (activeForm != null) {panelChildForm.Controls.Remove(activeForm);}
            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(activeForm);
            panelChildForm.Tag = activeForm;
            activeForm.BringToFront();
            activeForm.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Data_Form != null)
            {
                Data_Form.Close();
            }

            if (Palletizing_Form != null)
            {
                Palletizing_Form.Close();
            }

            if (Connection_Form != null)
            {
                Connection_Form.Close();
            }
        }
    }
}
