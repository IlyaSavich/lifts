namespace LIFT
{
    partial class Form1
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMenuSubitem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMenuSubitem = new System.Windows.Forms.ToolStripMenuItem();
            this.initMenuSubitem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatPassengerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputParametresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outPutToMSWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToMSExelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusPanelMoving = new System.Windows.Forms.StatusBarPanel();
            this.statusPanelPaused = new System.Windows.Forms.StatusBarPanel();
            this.statusPanelPassengersNumber = new System.Windows.Forms.StatusBarPanel();
            this.statusPanelWorkingTime = new System.Windows.Forms.StatusBarPanel();
            this.timerWorkingTime = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelMoving)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelPaused)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelPassengersNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelWorkingTime)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.creatPassengerToolStripMenuItem,
            this.informationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMenuSubitem,
            this.stopMenuSubitem,
            this.initMenuSubitem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // startMenuSubitem
            // 
            this.startMenuSubitem.Name = "startMenuSubitem";
            this.startMenuSubitem.Size = new System.Drawing.Size(152, 22);
            this.startMenuSubitem.Text = "Start";
            this.startMenuSubitem.Click += new System.EventHandler(this.startMenuSubitem_Click);
            // 
            // stopMenuSubitem
            // 
            this.stopMenuSubitem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stopMenuSubitem.Name = "stopMenuSubitem";
            this.stopMenuSubitem.Size = new System.Drawing.Size(152, 22);
            this.stopMenuSubitem.Text = "Stop";
            this.stopMenuSubitem.Click += new System.EventHandler(this.stopMenuSubitem_Click);
            // 
            // initMenuSubitem
            // 
            this.initMenuSubitem.Name = "initMenuSubitem";
            this.initMenuSubitem.Size = new System.Drawing.Size(152, 22);
            this.initMenuSubitem.Text = "Initialization";
            this.initMenuSubitem.Click += new System.EventHandler(this.initMenuSubitem_Click);
            // 
            // creatPassengerToolStripMenuItem
            // 
            this.creatPassengerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomToolStripMenuItem,
            this.inputParametresToolStripMenuItem});
            this.creatPassengerToolStripMenuItem.Name = "creatPassengerToolStripMenuItem";
            this.creatPassengerToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.creatPassengerToolStripMenuItem.Text = "CreatPassenger";
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.randomToolStripMenuItem.Text = "Random";
            // 
            // inputParametresToolStripMenuItem
            // 
            this.inputParametresToolStripMenuItem.Name = "inputParametresToolStripMenuItem";
            this.inputParametresToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.inputParametresToolStripMenuItem.Text = "Input Parametres";
            this.inputParametresToolStripMenuItem.Click += new System.EventHandler(this.inputParametresToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputToScreenToolStripMenuItem,
            this.outPutToMSWordToolStripMenuItem,
            this.outputToMSExelToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.informationToolStripMenuItem.Text = "Information";
            // 
            // outputToScreenToolStripMenuItem
            // 
            this.outputToScreenToolStripMenuItem.Name = "outputToScreenToolStripMenuItem";
            this.outputToScreenToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.outputToScreenToolStripMenuItem.Text = "Output to screen";
            // 
            // outPutToMSWordToolStripMenuItem
            // 
            this.outPutToMSWordToolStripMenuItem.Name = "outPutToMSWordToolStripMenuItem";
            this.outPutToMSWordToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.outPutToMSWordToolStripMenuItem.Text = "OutPut to MSWord";
            // 
            // outputToMSExelToolStripMenuItem
            // 
            this.outputToMSExelToolStripMenuItem.Name = "outputToMSExelToolStripMenuItem";
            this.outputToMSExelToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.outputToMSExelToolStripMenuItem.Text = "Output to MSExel";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusPanelMoving,
            this.statusPanelPaused,
            this.statusPanelPassengersNumber,
            this.statusPanelWorkingTime});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1006, 22);
            this.statusBar1.TabIndex = 7;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusPanelMoving
            // 
            this.statusPanelMoving.Name = "statusPanelMoving";
            this.statusPanelMoving.Text = "Moving Lifts:";
            // 
            // statusPanelPaused
            // 
            this.statusPanelPaused.Name = "statusPanelPaused";
            this.statusPanelPaused.Text = "Paused Lifts:";
            // 
            // statusPanelPassengersNumber
            // 
            this.statusPanelPassengersNumber.Name = "statusPanelPassengersNumber";
            this.statusPanelPassengersNumber.Text = "Passengers Number:";
            this.statusPanelPassengersNumber.Width = 120;
            // 
            // statusPanelWorkingTime
            // 
            this.statusPanelWorkingTime.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusPanelWorkingTime.Name = "statusPanelWorkingTime";
            // 
            // timerWorkingTime
            // 
            this.timerWorkingTime.Enabled = true;
            this.timerWorkingTime.Tick += new System.EventHandler(this.timerWorkingTime_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 524);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelMoving)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelPaused)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelPassengersNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelWorkingTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outPutToMSWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToMSExelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creatPassengerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputParametresToolStripMenuItem;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusPanelMoving;
        private System.Windows.Forms.StatusBarPanel statusPanelPaused;
        private System.Windows.Forms.StatusBarPanel statusPanelPassengersNumber;
        private System.Windows.Forms.StatusBarPanel statusPanelWorkingTime;
        private System.Windows.Forms.Timer timerWorkingTime;
        private System.Windows.Forms.ToolStripMenuItem startMenuSubitem;
        private System.Windows.Forms.ToolStripMenuItem stopMenuSubitem;
        private System.Windows.Forms.ToolStripMenuItem initMenuSubitem;
    }
}

