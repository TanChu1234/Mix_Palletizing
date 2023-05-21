using System.ComponentModel;

namespace WindowsFormsApp1
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Obsolete]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.IPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Availability = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Virtual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ControllerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Z_Coordinate = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Y_Coordinate = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.X_Coordinate = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StartRAPID_Button = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectToController_Button = new System.Windows.Forms.Button();
            this.StopRAPID_Button = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.MotorOn_Off = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IPAddress,
            this.ID,
            this.Availability,
            this.Virtual,
            this.ControllerName,
            this.Status});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(70, 60);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(710, 217);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // IPAddress
            // 
            this.IPAddress.Text = "IPAddress";
            this.IPAddress.Width = 100;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ID.Width = 100;
            // 
            // Availability
            // 
            this.Availability.Text = "Availability";
            this.Availability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Availability.Width = 150;
            // 
            // Virtual
            // 
            this.Virtual.Text = "Virtual";
            this.Virtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Virtual.Width = 100;
            // 
            // ControllerName
            // 
            this.ControllerName.Text = "ControllerName";
            this.ControllerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ControllerName.Width = 150;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Status.Width = 110;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.Z_Coordinate);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.Y_Coordinate);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.X_Coordinate);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(24, 311);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 162);
            this.panel1.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(76, 4);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(55, 24);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "TCP";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Z_Coordinate
            // 
            this.Z_Coordinate.AutoSize = true;
            this.Z_Coordinate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z_Coordinate.Location = new System.Drawing.Point(13, 118);
            this.Z_Coordinate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Z_Coordinate.Name = "Z_Coordinate";
            this.Z_Coordinate.Size = new System.Drawing.Size(23, 23);
            this.Z_Coordinate.TabIndex = 4;
            this.Z_Coordinate.Text = "Z";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(44, 120);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(148, 27);
            this.textBox3.TabIndex = 4;
            // 
            // Y_Coordinate
            // 
            this.Y_Coordinate.AutoSize = true;
            this.Y_Coordinate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y_Coordinate.Location = new System.Drawing.Point(14, 84);
            this.Y_Coordinate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y_Coordinate.Name = "Y_Coordinate";
            this.Y_Coordinate.Size = new System.Drawing.Size(22, 23);
            this.Y_Coordinate.TabIndex = 4;
            this.Y_Coordinate.Text = "Y";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(44, 85);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(148, 27);
            this.textBox2.TabIndex = 4;
            // 
            // X_Coordinate
            // 
            this.X_Coordinate.AutoSize = true;
            this.X_Coordinate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X_Coordinate.Location = new System.Drawing.Point(13, 48);
            this.X_Coordinate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X_Coordinate.Name = "X_Coordinate";
            this.X_Coordinate.Size = new System.Drawing.Size(23, 23);
            this.X_Coordinate.TabIndex = 4;
            this.X_Coordinate.Text = "X";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(44, 49);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(148, 27);
            this.textBox1.TabIndex = 4;
            // 
            // StartRAPID_Button
            // 
            this.StartRAPID_Button.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartRAPID_Button.Location = new System.Drawing.Point(250, 376);
            this.StartRAPID_Button.Margin = new System.Windows.Forms.Padding(4);
            this.StartRAPID_Button.Name = "StartRAPID_Button";
            this.StartRAPID_Button.Size = new System.Drawing.Size(158, 57);
            this.StartRAPID_Button.TabIndex = 0;
            this.StartRAPID_Button.Text = "Start RAPID Program";
            this.StartRAPID_Button.UseVisualStyleBackColor = true;
            this.StartRAPID_Button.Click += new System.EventHandler(this.StartRAPID_Button_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.Location = new System.Drawing.Point(250, 311);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(158, 57);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect to Controller";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectToController_Button
            // 
            this.DisconnectToController_Button.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectToController_Button.Location = new System.Drawing.Point(416, 311);
            this.DisconnectToController_Button.Margin = new System.Windows.Forms.Padding(4);
            this.DisconnectToController_Button.Name = "DisconnectToController_Button";
            this.DisconnectToController_Button.Size = new System.Drawing.Size(158, 57);
            this.DisconnectToController_Button.TabIndex = 5;
            this.DisconnectToController_Button.Text = "Disconnect to Controller";
            this.DisconnectToController_Button.UseVisualStyleBackColor = true;
            this.DisconnectToController_Button.Click += new System.EventHandler(this.DisconnectToController_Button_Click);
            // 
            // StopRAPID_Button
            // 
            this.StopRAPID_Button.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopRAPID_Button.Location = new System.Drawing.Point(416, 376);
            this.StopRAPID_Button.Margin = new System.Windows.Forms.Padding(4);
            this.StopRAPID_Button.Name = "StopRAPID_Button";
            this.StopRAPID_Button.Size = new System.Drawing.Size(158, 57);
            this.StopRAPID_Button.TabIndex = 6;
            this.StopRAPID_Button.Text = "Stop RAPID Program";
            this.StopRAPID_Button.UseVisualStyleBackColor = true;
            this.StopRAPID_Button.Click += new System.EventHandler(this.StopRAPID_Button_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.Image = ((System.Drawing.Image)(resources.GetObject("HomeButton.Image")));
            this.HomeButton.Location = new System.Drawing.Point(730, 484);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(2);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(50, 50);
            this.HomeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HomeButton.TabIndex = 7;
            this.HomeButton.TabStop = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.SystemColors.Control;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.Location = new System.Drawing.Point(785, 484);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(50, 50);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 9;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox14
            // 
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox14.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(250, 12);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(353, 26);
            this.textBox14.TabIndex = 10;
            this.textBox14.Text = "Connection";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MotorOn_Off
            // 
            this.MotorOn_Off.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MotorOn_Off.Location = new System.Drawing.Point(600, 344);
            this.MotorOn_Off.Name = "MotorOn_Off";
            this.MotorOn_Off.Size = new System.Drawing.Size(125, 57);
            this.MotorOn_Off.TabIndex = 11;
            this.MotorOn_Off.Text = "Motor On/Off";
            this.MotorOn_Off.UseVisualStyleBackColor = true;
            this.MotorOn_Off.Click += new System.EventHandler(this.MotorOn_Off_Click);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 546);
            this.Controls.Add(this.MotorOn_Off);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.StopRAPID_Button);
            this.Controls.Add(this.DisconnectToController_Button);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StartRAPID_Button);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConnectionForm";
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader IPAddress;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Availability;
        private System.Windows.Forms.ColumnHeader Virtual;
        private System.Windows.Forms.ColumnHeader ControllerName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StartRAPID_Button;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label Z_Coordinate;
        private System.Windows.Forms.Label Y_Coordinate;
        private System.Windows.Forms.Label X_Coordinate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button DisconnectToController_Button;
        private System.Windows.Forms.Button StopRAPID_Button;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.PictureBox HomeButton;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Button MotorOn_Off;
    }
}

