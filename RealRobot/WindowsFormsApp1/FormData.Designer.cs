namespace WindowsFormsApp1
{
    partial class FormData
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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "t",
            "1",
            "225",
            "250",
            "150",
            "1",
            "3"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "t1",
            "2",
            "250",
            "300",
            "150",
            "1",
            "3"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "t2",
            "3",
            "300",
            "350",
            "250",
            "1",
            "3"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormData));
            this.panel3 = new System.Windows.Forms.Panel();
            this.PropertiesSubmit_Button = new System.Windows.Forms.Button();
            this.DeleteItem_Button = new System.Windows.Forms.Button();
            this.CreateBoxButton = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.Width_Texbox = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.Height_Texbox = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.Depth_Texbox = new System.Windows.Forms.TextBox();
            this.Name_Textbox = new System.Windows.Forms.TextBox();
            this.NumofBox_Textbox = new System.Windows.Forms.TextBox();
            this.Weight_Texbox = new System.Windows.Forms.TextBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.NameOfBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Width = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Depth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Height = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Weight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantities = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HomeButton = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.PropertiesSubmit_Button);
            this.panel3.Controls.Add(this.DeleteItem_Button);
            this.panel3.Controls.Add(this.CreateBoxButton);
            this.panel3.Controls.Add(this.textBox14);
            this.panel3.Controls.Add(this.textBox9);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.textBox16);
            this.panel3.Controls.Add(this.textBox13);
            this.panel3.Controls.Add(this.Width_Texbox);
            this.panel3.Controls.Add(this.textBox11);
            this.panel3.Controls.Add(this.Height_Texbox);
            this.panel3.Controls.Add(this.textBox10);
            this.panel3.Controls.Add(this.Depth_Texbox);
            this.panel3.Controls.Add(this.Name_Textbox);
            this.panel3.Controls.Add(this.NumofBox_Textbox);
            this.panel3.Controls.Add(this.Weight_Texbox);
            this.panel3.Location = new System.Drawing.Point(158, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(519, 257);
            this.panel3.TabIndex = 10;
            // 
            // PropertiesSubmit_Button
            // 
            this.PropertiesSubmit_Button.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertiesSubmit_Button.Location = new System.Drawing.Point(338, 66);
            this.PropertiesSubmit_Button.Name = "PropertiesSubmit_Button";
            this.PropertiesSubmit_Button.Size = new System.Drawing.Size(130, 40);
            this.PropertiesSubmit_Button.TabIndex = 10;
            this.PropertiesSubmit_Button.Text = "Submit";
            this.PropertiesSubmit_Button.UseVisualStyleBackColor = true;
            this.PropertiesSubmit_Button.Click += new System.EventHandler(this.PropertiesSubmit_Button_Click);
            // 
            // DeleteItem_Button
            // 
            this.DeleteItem_Button.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteItem_Button.Location = new System.Drawing.Point(338, 119);
            this.DeleteItem_Button.Name = "DeleteItem_Button";
            this.DeleteItem_Button.Size = new System.Drawing.Size(130, 40);
            this.DeleteItem_Button.TabIndex = 11;
            this.DeleteItem_Button.Text = "Delete Items";
            this.DeleteItem_Button.UseVisualStyleBackColor = true;
            this.DeleteItem_Button.Click += new System.EventHandler(this.DeleteItem_Button_Click_1);
            // 
            // CreateBoxButton
            // 
            this.CreateBoxButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateBoxButton.Location = new System.Drawing.Point(338, 177);
            this.CreateBoxButton.Name = "CreateBoxButton";
            this.CreateBoxButton.Size = new System.Drawing.Size(130, 52);
            this.CreateBoxButton.TabIndex = 12;
            this.CreateBoxButton.Text = "Confirm Boxes";
            this.CreateBoxButton.UseVisualStyleBackColor = true;
            this.CreateBoxButton.Click += new System.EventHandler(this.CreateBoxButton_Click);
            // 
            // textBox14
            // 
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox14.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(94, 3);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(353, 26);
            this.textBox14.TabIndex = 9;
            this.textBox14.Text = "Input Box Properties (Max 4)";
            // 
            // textBox9
            // 
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(3, 86);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(145, 20);
            this.textBox9.TabIndex = 8;
            this.textBox9.Text = "Width (mm)";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(3, 53);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(145, 20);
            this.textBox7.TabIndex = 8;
            this.textBox7.Text = "Name";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox16
            // 
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox16.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(3, 218);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(145, 20);
            this.textBox16.TabIndex = 8;
            this.textBox16.Text = "Number of Box";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(3, 185);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(145, 20);
            this.textBox13.TabIndex = 8;
            this.textBox13.Text = "Weight (kg)";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Width_Texbox
            // 
            this.Width_Texbox.BackColor = System.Drawing.SystemColors.Control;
            this.Width_Texbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Width_Texbox.Location = new System.Drawing.Point(154, 86);
            this.Width_Texbox.Name = "Width_Texbox";
            this.Width_Texbox.Size = new System.Drawing.Size(100, 27);
            this.Width_Texbox.TabIndex = 7;
            this.Width_Texbox.Text = "200";
            this.Width_Texbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(3, 119);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(145, 20);
            this.textBox11.TabIndex = 8;
            this.textBox11.Text = "Depth (mm)";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Height_Texbox
            // 
            this.Height_Texbox.BackColor = System.Drawing.SystemColors.Control;
            this.Height_Texbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Height_Texbox.Location = new System.Drawing.Point(154, 152);
            this.Height_Texbox.Name = "Height_Texbox";
            this.Height_Texbox.Size = new System.Drawing.Size(100, 27);
            this.Height_Texbox.TabIndex = 7;
            this.Height_Texbox.Text = "400";
            this.Height_Texbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(3, 152);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(145, 20);
            this.textBox10.TabIndex = 8;
            this.textBox10.Text = "Height (mm)";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Depth_Texbox
            // 
            this.Depth_Texbox.BackColor = System.Drawing.SystemColors.Control;
            this.Depth_Texbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Depth_Texbox.Location = new System.Drawing.Point(154, 119);
            this.Depth_Texbox.Name = "Depth_Texbox";
            this.Depth_Texbox.Size = new System.Drawing.Size(100, 27);
            this.Depth_Texbox.TabIndex = 7;
            this.Depth_Texbox.Text = "200";
            this.Depth_Texbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Name_Textbox
            // 
            this.Name_Textbox.BackColor = System.Drawing.SystemColors.Control;
            this.Name_Textbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_Textbox.Location = new System.Drawing.Point(154, 53);
            this.Name_Textbox.Name = "Name_Textbox";
            this.Name_Textbox.Size = new System.Drawing.Size(100, 27);
            this.Name_Textbox.TabIndex = 7;
            this.Name_Textbox.Text = "t";
            this.Name_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NumofBox_Textbox
            // 
            this.NumofBox_Textbox.BackColor = System.Drawing.SystemColors.Control;
            this.NumofBox_Textbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumofBox_Textbox.Location = new System.Drawing.Point(154, 218);
            this.NumofBox_Textbox.Name = "NumofBox_Textbox";
            this.NumofBox_Textbox.Size = new System.Drawing.Size(100, 27);
            this.NumofBox_Textbox.TabIndex = 7;
            this.NumofBox_Textbox.Text = "1";
            this.NumofBox_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Weight_Texbox
            // 
            this.Weight_Texbox.BackColor = System.Drawing.SystemColors.Control;
            this.Weight_Texbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Weight_Texbox.Location = new System.Drawing.Point(154, 185);
            this.Weight_Texbox.Name = "Weight_Texbox";
            this.Weight_Texbox.Size = new System.Drawing.Size(100, 27);
            this.Weight_Texbox.TabIndex = 7;
            this.Weight_Texbox.Text = "5";
            this.Weight_Texbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listView2
            // 
            this.listView2.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameOfBox,
            this.No,
            this.Width,
            this.Depth,
            this.Height,
            this.Weight,
            this.Quantities});
            this.listView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            listViewItem4.Tag = "t";
            listViewItem5.Tag = "t1";
            listViewItem6.Tag = "t2";
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listView2.Location = new System.Drawing.Point(123, 355);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(584, 140);
            this.listView2.TabIndex = 11;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // NameOfBox
            // 
            this.NameOfBox.Text = "Name";
            this.NameOfBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameOfBox.Width = 120;
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 40;
            // 
            // Width
            // 
            this.Width.Text = "Width";
            this.Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Width.Width = 80;
            // 
            // Depth
            // 
            this.Depth.Text = "Depth";
            this.Depth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Depth.Width = 80;
            // 
            // Height
            // 
            this.Height.Text = "Height";
            this.Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Height.Width = 80;
            // 
            // Weight
            // 
            this.Weight.Text = "Weight";
            this.Weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Weight.Width = 80;
            // 
            // Quantities
            // 
            this.Quantities.Text = "Quantities";
            this.Quantities.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantities.Width = 100;
            // 
            // HomeButton
            // 
            this.HomeButton.Image = ((System.Drawing.Image)(resources.GetObject("HomeButton.Image")));
            this.HomeButton.Location = new System.Drawing.Point(730, 484);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(2);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(50, 50);
            this.HomeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HomeButton.TabIndex = 13;
            this.HomeButton.TabStop = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.Location = new System.Drawing.Point(785, 484);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(50, 50);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 14;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 546);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormData";
            this.Text = "FormData";
            this.Load += new System.EventHandler(this.FormData_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button PropertiesSubmit_Button;
        private System.Windows.Forms.Button DeleteItem_Button;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox Width_Texbox;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox Height_Texbox;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox Depth_Texbox;
        private System.Windows.Forms.TextBox Name_Textbox;
        private System.Windows.Forms.TextBox NumofBox_Textbox;
        private System.Windows.Forms.TextBox Weight_Texbox;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader NameOfBox;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Width;
        private System.Windows.Forms.ColumnHeader Depth;
        private System.Windows.Forms.ColumnHeader Height;
        private System.Windows.Forms.ColumnHeader Weight;
        private System.Windows.Forms.ColumnHeader Quantities;
        private System.Windows.Forms.Button CreateBoxButton;
        private System.Windows.Forms.PictureBox HomeButton;
        private System.Windows.Forms.PictureBox CloseButton;
    }
}