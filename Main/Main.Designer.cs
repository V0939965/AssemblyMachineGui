namespace Main
{
    partial class Main
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.g_imShow = new System.Windows.Forms.GroupBox();
            this.log = new System.Windows.Forms.RichTextBox();
            this.lStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.p_imShow = new System.Windows.Forms.PictureBox();
            this.G_setting = new System.Windows.Forms.GroupBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Reload_Button = new System.Windows.Forms.Button();
            this.comboCamera = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.iLink = new System.Windows.Forms.RichTextBox();
            this.iChooseLink = new System.Windows.Forms.Button();
            this.modeFolder = new System.Windows.Forms.RadioButton();
            this.modeCamera = new System.Windows.Forms.RadioButton();
            this.Start = new System.Windows.Forms.Button();
            this.Serial_Light = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getCenterRotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getOriginImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterPLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Serial_Scanner = new System.IO.Ports.SerialPort(this.components);
            this.status = new System.Windows.Forms.Label();
            this.IT = new System.IO.Ports.SerialPort(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ResetStatus = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_imShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_imShow)).BeginInit();
            this.G_setting.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // g_imShow
            // 
            this.g_imShow.Controls.Add(this.label4);
            this.g_imShow.Controls.Add(this.label3);
            this.g_imShow.Controls.Add(this.log);
            this.g_imShow.Controls.Add(this.lStatus);
            this.g_imShow.Controls.Add(this.label2);
            this.g_imShow.Controls.Add(this.label1);
            this.g_imShow.Controls.Add(this.p_imShow);
            this.g_imShow.Controls.Add(this.G_setting);
            this.g_imShow.Controls.Add(this.Start);
            this.g_imShow.Location = new System.Drawing.Point(12, 27);
            this.g_imShow.Name = "g_imShow";
            this.g_imShow.Size = new System.Drawing.Size(860, 503);
            this.g_imShow.TabIndex = 0;
            this.g_imShow.TabStop = false;
            this.g_imShow.Text = "Interface";
            this.g_imShow.Enter += new System.EventHandler(this.g_imShow_Enter);
            // 
            // log
            // 
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.log.ContextMenuStrip = this.contextMenuStrip1;
            this.log.Location = new System.Drawing.Point(6, 436);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.log.ShowSelectionMargin = true;
            this.log.Size = new System.Drawing.Size(572, 61);
            this.log.TabIndex = 6;
            this.log.TabStop = false;
            this.log.Text = "";
            this.log.TextChanged += new System.EventHandler(this.log_TextChanged);
            // 
            // lStatus
            // 
            this.lStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStatus.Location = new System.Drawing.Point(587, 310);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(267, 120);
            this.lStatus.TabIndex = 5;
            this.lStatus.Text = "FII-Department";
            this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(587, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 60);
            this.label2.TabIndex = 4;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(587, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 60);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_imShow
            // 
            this.p_imShow.BackColor = System.Drawing.SystemColors.ControlDark;
            this.p_imShow.Location = new System.Drawing.Point(6, 19);
            this.p_imShow.Name = "p_imShow";
            this.p_imShow.Size = new System.Drawing.Size(572, 411);
            this.p_imShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p_imShow.TabIndex = 0;
            this.p_imShow.TabStop = false;
            // 
            // G_setting
            // 
            this.G_setting.Controls.Add(this.panel8);
            this.G_setting.Controls.Add(this.panel9);
            this.G_setting.Location = new System.Drawing.Point(584, 9);
            this.G_setting.Name = "G_setting";
            this.G_setting.Size = new System.Drawing.Size(270, 130);
            this.G_setting.TabIndex = 1;
            this.G_setting.TabStop = false;
            this.G_setting.Text = "Basic Setting";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.Reload_Button);
            this.panel8.Controls.Add(this.comboCamera);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(3, 19);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(261, 27);
            this.panel8.TabIndex = 2;
            // 
            // Reload_Button
            // 
            this.Reload_Button.Image = ((System.Drawing.Image)(resources.GetObject("Reload_Button.Image")));
            this.Reload_Button.Location = new System.Drawing.Point(238, 3);
            this.Reload_Button.Name = "Reload_Button";
            this.Reload_Button.Size = new System.Drawing.Size(20, 20);
            this.Reload_Button.TabIndex = 5;
            this.Reload_Button.Tag = "Find Camera";
            this.Reload_Button.UseVisualStyleBackColor = true;
            this.Reload_Button.Click += new System.EventHandler(this.Reload_Button_Click);
            // 
            // comboCamera
            // 
            this.comboCamera.FormattingEnabled = true;
            this.comboCamera.Location = new System.Drawing.Point(55, 3);
            this.comboCamera.Name = "comboCamera";
            this.comboCamera.Size = new System.Drawing.Size(180, 21);
            this.comboCamera.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Camera:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.iLink);
            this.panel9.Controls.Add(this.iChooseLink);
            this.panel9.Controls.Add(this.modeFolder);
            this.panel9.Controls.Add(this.modeCamera);
            this.panel9.Location = new System.Drawing.Point(3, 52);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(258, 69);
            this.panel9.TabIndex = 21;
            // 
            // iLink
            // 
            this.iLink.Location = new System.Drawing.Point(6, 45);
            this.iLink.Multiline = false;
            this.iLink.Name = "iLink";
            this.iLink.Size = new System.Drawing.Size(213, 19);
            this.iLink.TabIndex = 24;
            this.iLink.Text = "";
            // 
            // iChooseLink
            // 
            this.iChooseLink.Location = new System.Drawing.Point(225, 40);
            this.iChooseLink.Name = "iChooseLink";
            this.iChooseLink.Size = new System.Drawing.Size(30, 24);
            this.iChooseLink.TabIndex = 23;
            this.iChooseLink.Text = "...";
            this.iChooseLink.UseVisualStyleBackColor = true;
            this.iChooseLink.Click += new System.EventHandler(this.iChooseLink_Click);
            // 
            // modeFolder
            // 
            this.modeFolder.AutoSize = true;
            this.modeFolder.Location = new System.Drawing.Point(6, 22);
            this.modeFolder.Name = "modeFolder";
            this.modeFolder.Size = new System.Drawing.Size(80, 17);
            this.modeFolder.TabIndex = 20;
            this.modeFolder.Text = "From Folder";
            this.modeFolder.UseVisualStyleBackColor = true;
            // 
            // modeCamera
            // 
            this.modeCamera.AutoSize = true;
            this.modeCamera.Checked = true;
            this.modeCamera.Location = new System.Drawing.Point(6, 3);
            this.modeCamera.Name = "modeCamera";
            this.modeCamera.Size = new System.Drawing.Size(87, 17);
            this.modeCamera.TabIndex = 19;
            this.modeCamera.TabStop = true;
            this.modeCamera.Text = "From Camera";
            this.modeCamera.UseVisualStyleBackColor = true;
            this.modeCamera.CheckedChanged += new System.EventHandler(this.modeCamera_CheckedChanged);
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.Location = new System.Drawing.Point(587, 440);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(267, 57);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Serial_Light
            // 
            this.Serial_Light.BaudRate = 19200;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraCaptureToolStripMenuItem,
            this.rOIToolStripMenuItem,
            this.rotationCenterToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.viewToolStripMenuItem.Text = "Tools";
            // 
            // cameraCaptureToolStripMenuItem
            // 
            this.cameraCaptureToolStripMenuItem.Image = global::Main.Properties.Resources.capture;
            this.cameraCaptureToolStripMenuItem.Name = "cameraCaptureToolStripMenuItem";
            this.cameraCaptureToolStripMenuItem.ShowShortcutKeys = false;
            this.cameraCaptureToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.cameraCaptureToolStripMenuItem.Text = "Camera Capture";
            this.cameraCaptureToolStripMenuItem.Click += new System.EventHandler(this.cameraCaptureToolStripMenuItem_Click);
            // 
            // rOIToolStripMenuItem
            // 
            this.rOIToolStripMenuItem.Image = global::Main.Properties.Resources.testroi1;
            this.rOIToolStripMenuItem.Name = "rOIToolStripMenuItem";
            this.rOIToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.rOIToolStripMenuItem.Text = "ROI";
            this.rOIToolStripMenuItem.Click += new System.EventHandler(this.rOIToolStripMenuItem_Click);
            // 
            // rotationCenterToolStripMenuItem
            // 
            this.rotationCenterToolStripMenuItem.Image = global::Main.Properties.Resources.cencter;
            this.rotationCenterToolStripMenuItem.Name = "rotationCenterToolStripMenuItem";
            this.rotationCenterToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.rotationCenterToolStripMenuItem.Text = "Rotation Center";
            this.rotationCenterToolStripMenuItem.Click += new System.EventHandler(this.rotationCenterToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getCenterRotationToolStripMenuItem,
            this.getOriginImageToolStripMenuItem,
            this.parameterCameraToolStripMenuItem,
            this.parameterPLCToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.toolsToolStripMenuItem.Text = "Setting";
            // 
            // getCenterRotationToolStripMenuItem
            // 
            this.getCenterRotationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("getCenterRotationToolStripMenuItem.Image")));
            this.getCenterRotationToolStripMenuItem.Name = "getCenterRotationToolStripMenuItem";
            this.getCenterRotationToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.getCenterRotationToolStripMenuItem.Text = "Get Rotation Center";
            this.getCenterRotationToolStripMenuItem.Click += new System.EventHandler(this.getCenterRotationToolStripMenuItem_Click);
            // 
            // getOriginImageToolStripMenuItem
            // 
            this.getOriginImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("getOriginImageToolStripMenuItem.Image")));
            this.getOriginImageToolStripMenuItem.Name = "getOriginImageToolStripMenuItem";
            this.getOriginImageToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.getOriginImageToolStripMenuItem.Text = "Get Origin Image";
            this.getOriginImageToolStripMenuItem.Click += new System.EventHandler(this.getOriginImageToolStripMenuItem_Click);
            // 
            // parameterCameraToolStripMenuItem
            // 
            this.parameterCameraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("parameterCameraToolStripMenuItem.Image")));
            this.parameterCameraToolStripMenuItem.Name = "parameterCameraToolStripMenuItem";
            this.parameterCameraToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.parameterCameraToolStripMenuItem.Text = "Parameter Camera";
            this.parameterCameraToolStripMenuItem.Click += new System.EventHandler(this.parameterCameraToolStripMenuItem_Click);
            // 
            // parameterPLCToolStripMenuItem
            // 
            this.parameterPLCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("parameterPLCToolStripMenuItem.Image")));
            this.parameterPLCToolStripMenuItem.Name = "parameterPLCToolStripMenuItem";
            this.parameterPLCToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.parameterPLCToolStripMenuItem.Text = "Parameter PLC";
            // 
            // Serial_Scanner
            // 
            this.Serial_Scanner.BaudRate = 115200;
            this.Serial_Scanner.PortName = "COM10";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(15, 533);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(857, 19);
            this.status.TabIndex = 24;
            // 
            // IT
            // 
            this.IT.PortName = "COM2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(601, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Label PCBA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(601, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Label Housing";
            // 
            // ResetStatus
            // 
            this.ResetStatus.Interval = 3000;
            this.ResetStatus.Tick += new System.EventHandler(this.ResetStatus_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.g_imShow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Tag = "Connet to Camera";
            this.Text = "Locate Label For Assembly Machine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.g_imShow.ResumeLayout(false);
            this.g_imShow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_imShow)).EndInit();
            this.G_setting.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox g_imShow;
        private System.Windows.Forms.PictureBox p_imShow;
        private System.Windows.Forms.GroupBox G_setting;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ComboBox comboCamera;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton modeCamera;
        private System.Windows.Forms.RadioButton modeFolder;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getCenterRotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getOriginImageToolStripMenuItem;
        private System.Windows.Forms.RichTextBox iLink;
        private System.Windows.Forms.Button iChooseLink;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.ToolStripMenuItem parameterCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parameterPLCToolStripMenuItem;
        private System.Windows.Forms.Button Reload_Button;
        public System.IO.Ports.SerialPort Serial_Light;
        public System.IO.Ports.SerialPort Serial_Scanner;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox log;
        public System.IO.Ports.SerialPort IT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer ResetStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}

