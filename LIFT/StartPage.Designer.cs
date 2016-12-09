﻿namespace LIFT
{
    partial class StartPage
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

            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusPanelMoving = new System.Windows.Forms.StatusBarPanel();
            this.statusPanelPaused = new System.Windows.Forms.StatusBarPanel();
            this.statusPanelPassengersNumber = new System.Windows.Forms.StatusBarPanel();
            this.statusPanelWorkingTime = new System.Windows.Forms.StatusBarPanel();
            this.timerWorkingTime = new System.Windows.Forms.Timer(this.components);

            this.panel1 = new System.Windows.Forms.Panel();
            this.errorMessageNecFloor = new System.Windows.Forms.TextBox();
            this.OutPutinformation = new System.Windows.Forms.Label();
            this.MSExelButton = new System.Windows.Forms.Button();
            this.MsWord = new System.Windows.Forms.Button();
            this.toScreen = new System.Windows.Forms.Button();
            this.errorMessageCurrentFloor = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StartParam = new System.Windows.Forms.TextBox();
            this.errorMessageWeight = new System.Windows.Forms.TextBox();
            this.errorMessageLift = new System.Windows.Forms.TextBox();
            this.errorMessageNumFloor = new System.Windows.Forms.TextBox();
            this.NeccesaryFloorLab = new System.Windows.Forms.Label();
            this.CurrentFloorlab = new System.Windows.Forms.Label();
            this.Weight = new System.Windows.Forms.Label();
            this.NecessaryFloorButton = new System.Windows.Forms.TextBox();
            this.NumOfLiftsLabel = new System.Windows.Forms.Label();
            this.NumFloorLabel = new System.Windows.Forms.Label();
            this.StopButtoon = new System.Windows.Forms.Button();
            this.CreatePersonButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CurrentFloorButton = new System.Windows.Forms.TextBox();
            this.WeightButton = new System.Windows.Forms.TextBox();
            this.NumOfLifts = new System.Windows.Forms.TextBox();
            this.NumberOfFloorsButton = new System.Windows.Forms.TextBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.statusPanelMoving)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelPaused)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelPassengersNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelWorkingTime)).BeginInit();

            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();

            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 

            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(20, 432);

            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusPanelMoving,
            this.statusPanelPaused,
            this.statusPanelPassengersNumber,
            this.statusPanelWorkingTime});
            this.statusBar1.ShowPanels = true;

            this.statusBar1.Size = new System.Drawing.Size(991, 22);

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

            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.errorMessageNecFloor);
            this.panel1.Controls.Add(this.OutPutinformation);
            this.panel1.Controls.Add(this.MSExelButton);
            this.panel1.Controls.Add(this.MsWord);
            this.panel1.Controls.Add(this.toScreen);
            this.panel1.Controls.Add(this.errorMessageCurrentFloor);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.StartParam);
            this.panel1.Controls.Add(this.errorMessageWeight);
            this.panel1.Controls.Add(this.errorMessageLift);
            this.panel1.Controls.Add(this.errorMessageNumFloor);
            this.panel1.Controls.Add(this.NeccesaryFloorLab);
            this.panel1.Controls.Add(this.CurrentFloorlab);
            this.panel1.Controls.Add(this.Weight);
            this.panel1.Controls.Add(this.NecessaryFloorButton);
            this.panel1.Controls.Add(this.NumOfLiftsLabel);
            this.panel1.Controls.Add(this.NumFloorLabel);
            this.panel1.Controls.Add(this.StopButtoon);
            this.panel1.Controls.Add(this.CreatePersonButton);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.CurrentFloorButton);
            this.panel1.Controls.Add(this.WeightButton);
            this.panel1.Controls.Add(this.NumOfLifts);
            this.panel1.Controls.Add(this.NumberOfFloorsButton);
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 372);
            this.panel1.TabIndex = 8;
            // 
            // errorMessageNecFloor
            // 
            this.errorMessageNecFloor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorMessageNecFloor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.errorMessageNecFloor.Location = new System.Drawing.Point(9, 284);
            this.errorMessageNecFloor.Name = "errorMessageNecFloor";
            this.errorMessageNecFloor.Size = new System.Drawing.Size(181, 13);
            this.errorMessageNecFloor.TabIndex = 24;
            // 
            // OutPutinformation
            // 
            this.OutPutinformation.AutoSize = true;
            this.OutPutinformation.Location = new System.Drawing.Point(58, 324);
            this.OutPutinformation.Name = "OutPutinformation";
            this.OutPutinformation.Size = new System.Drawing.Size(93, 13);
            this.OutPutinformation.TabIndex = 23;
            this.OutPutinformation.Text = "Output information";
            // 
            // MSExelButton
            // 
            this.MSExelButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MSExelButton.Location = new System.Drawing.Point(136, 339);
            this.MSExelButton.Name = "MSExelButton";
            this.MSExelButton.Size = new System.Drawing.Size(56, 23);
            this.MSExelButton.TabIndex = 22;
            this.MSExelButton.Text = "Exel";
            this.MSExelButton.UseVisualStyleBackColor = false;
            // 
            // MsWord
            // 
            this.MsWord.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MsWord.Location = new System.Drawing.Point(68, 339);
            this.MsWord.Name = "MsWord";
            this.MsWord.Size = new System.Drawing.Size(53, 23);
            this.MsWord.TabIndex = 21;
            this.MsWord.Text = "Word";
            this.MsWord.UseVisualStyleBackColor = false;
            // 
            // toScreen
            // 
            this.toScreen.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toScreen.Location = new System.Drawing.Point(3, 339);
            this.toScreen.Name = "toScreen";
            this.toScreen.Size = new System.Drawing.Size(49, 23);
            this.toScreen.TabIndex = 20;
            this.toScreen.Text = "Screen";
            this.toScreen.UseVisualStyleBackColor = false;
            // 
            // errorMessageCurrentFloor
            // 
            this.errorMessageCurrentFloor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorMessageCurrentFloor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.errorMessageCurrentFloor.Location = new System.Drawing.Point(8, 239);
            this.errorMessageCurrentFloor.Name = "errorMessageCurrentFloor";
            this.errorMessageCurrentFloor.Size = new System.Drawing.Size(181, 13);
            this.errorMessageCurrentFloor.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(40, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "Person Parametres";
            // 
            // StartParam
            // 
            this.StartParam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StartParam.Location = new System.Drawing.Point(40, 3);
            this.StartParam.Name = "StartParam";
            this.StartParam.Size = new System.Drawing.Size(100, 13);
            this.StartParam.TabIndex = 17;
            this.StartParam.Text = "Starting Parametres";
            // 
            // errorMessageWeight
            // 
            this.errorMessageWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorMessageWeight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.errorMessageWeight.Location = new System.Drawing.Point(6, 194);
            this.errorMessageWeight.Name = "errorMessageWeight";
            this.errorMessageWeight.Size = new System.Drawing.Size(180, 13);
            this.errorMessageWeight.TabIndex = 16;
            // 
            // errorMessageLift
            // 
            this.errorMessageLift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorMessageLift.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.errorMessageLift.Location = new System.Drawing.Point(9, 97);
            this.errorMessageLift.Name = "errorMessageLift";
            this.errorMessageLift.Size = new System.Drawing.Size(175, 13);
            this.errorMessageLift.TabIndex = 15;
            // 
            // errorMessageNumFloor
            // 
            this.errorMessageNumFloor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorMessageNumFloor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.errorMessageNumFloor.Location = new System.Drawing.Point(9, 52);
            this.errorMessageNumFloor.Name = "errorMessageNumFloor";
            this.errorMessageNumFloor.Size = new System.Drawing.Size(175, 13);
            this.errorMessageNumFloor.TabIndex = 14;
            // 
            // NeccesaryFloorLab
            // 
            this.NeccesaryFloorLab.AutoSize = true;
            this.NeccesaryFloorLab.Location = new System.Drawing.Point(21, 261);
            this.NeccesaryFloorLab.Name = "NeccesaryFloorLab";
            this.NeccesaryFloorLab.Size = new System.Drawing.Size(83, 13);
            this.NeccesaryFloorLab.TabIndex = 13;
            this.NeccesaryFloorLab.Text = "Necessary Floor";
            // 
            // CurrentFloorlab
            // 
            this.CurrentFloorlab.AutoSize = true;
            this.CurrentFloorlab.Location = new System.Drawing.Point(23, 216);
            this.CurrentFloorlab.Name = "CurrentFloorlab";
            this.CurrentFloorlab.Size = new System.Drawing.Size(67, 13);
            this.CurrentFloorlab.TabIndex = 12;
            this.CurrentFloorlab.Text = "Current Floor";
            // 
            // Weight
            // 
            this.Weight.AutoSize = true;
            this.Weight.Location = new System.Drawing.Point(25, 171);
            this.Weight.Name = "Weight";
            this.Weight.Size = new System.Drawing.Size(65, 13);
            this.Weight.TabIndex = 11;
            this.Weight.Text = "Weight  (kg)";
            // 
            // NecessaryFloorButton
            // 
            this.NecessaryFloorButton.Location = new System.Drawing.Point(126, 258);
            this.NecessaryFloorButton.Name = "NecessaryFloorButton";
            this.NecessaryFloorButton.Size = new System.Drawing.Size(58, 20);
            this.NecessaryFloorButton.TabIndex = 10;
            // 
            // NumOfLiftsLabel
            // 
            this.NumOfLiftsLabel.AutoSize = true;
            this.NumOfLiftsLabel.Location = new System.Drawing.Point(3, 74);
            this.NumOfLiftsLabel.Name = "NumOfLiftsLabel";
            this.NumOfLiftsLabel.Size = new System.Drawing.Size(105, 13);
            this.NumOfLiftsLabel.TabIndex = 9;
            this.NumOfLiftsLabel.Text = "Number of Lifts (1 -3)";
            // 
            // NumFloorLabel
            // 
            this.NumFloorLabel.AutoSize = true;
            this.NumFloorLabel.Location = new System.Drawing.Point(3, 29);
            this.NumFloorLabel.Name = "NumFloorLabel";
            this.NumFloorLabel.Size = new System.Drawing.Size(117, 13);
            this.NumFloorLabel.TabIndex = 8;
            this.NumFloorLabel.Text = "Number Of Foors (2-10)";
            // 
            // StopButtoon
            // 
            this.StopButtoon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StopButtoon.Location = new System.Drawing.Point(15, 298);
            this.StopButtoon.Name = "StopButtoon";
            this.StopButtoon.Size = new System.Drawing.Size(75, 23);
            this.StopButtoon.TabIndex = 7;
            this.StopButtoon.Text = "Stop";
            this.StopButtoon.UseVisualStyleBackColor = false;
            // 
            // CreatePersonButton
            // 
            this.CreatePersonButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CreatePersonButton.Location = new System.Drawing.Point(101, 298);
            this.CreatePersonButton.Name = "CreatePersonButton";
            this.CreatePersonButton.Size = new System.Drawing.Size(75, 23);
            this.CreatePersonButton.TabIndex = 6;
            this.CreatePersonButton.Text = "Create";
            this.CreatePersonButton.UseVisualStyleBackColor = false;
            this.CreatePersonButton.Click += new System.EventHandler(this.CreatePersonButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StartButton.Location = new System.Drawing.Point(101, 116);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SaveButton.Location = new System.Drawing.Point(9, 116);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CurrentFloorButton
            // 
            this.CurrentFloorButton.Location = new System.Drawing.Point(126, 213);
            this.CurrentFloorButton.Name = "CurrentFloorButton";
            this.CurrentFloorButton.Size = new System.Drawing.Size(58, 20);
            this.CurrentFloorButton.TabIndex = 3;
            // 
            // WeightButton
            // 
            this.WeightButton.Location = new System.Drawing.Point(126, 168);
            this.WeightButton.Name = "WeightButton";
            this.WeightButton.Size = new System.Drawing.Size(58, 20);
            this.WeightButton.TabIndex = 2;
            // 
            // NumOfLifts
            // 
            this.NumOfLifts.Location = new System.Drawing.Point(126, 71);
            this.NumOfLifts.Name = "NumOfLifts";
            this.NumOfLifts.Size = new System.Drawing.Size(58, 20);
            this.NumOfLifts.TabIndex = 1;
            // 
            // NumberOfFloorsButton
            // 
            this.NumberOfFloorsButton.Location = new System.Drawing.Point(126, 29);
            this.NumberOfFloorsButton.Name = "NumberOfFloorsButton";
            this.NumberOfFloorsButton.Size = new System.Drawing.Size(58, 20);
            this.NumberOfFloorsButton.TabIndex = 0;
            this.NumberOfFloorsButton.TextChanged += new System.EventHandler(this.TextChangeNumFloor);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(795, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(10, 398);
            this.vScrollBar1.TabIndex = 9;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.vScrollBar1);
            this.panel2.Location = new System.Drawing.Point(215, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(805, 401);
            this.panel2.TabIndex = 10;
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 474);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Name = "StartPage";
            this.Text = "Elevator Simulator";

            ((System.ComponentModel.ISupportInitialize)(this.statusPanelMoving)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelPaused)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelPassengersNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanelWorkingTime)).EndInit();

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);


        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ImageList imageList1;

        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusPanelMoving;
        private System.Windows.Forms.StatusBarPanel statusPanelPaused;
        private System.Windows.Forms.StatusBarPanel statusPanelPassengersNumber;
        private System.Windows.Forms.StatusBarPanel statusPanelWorkingTime;
        private System.Windows.Forms.Timer timerWorkingTime;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button StopButtoon;
        private System.Windows.Forms.Button CreatePersonButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox CurrentFloorButton;
        private System.Windows.Forms.TextBox WeightButton;
        private System.Windows.Forms.TextBox NumOfLifts;
        private System.Windows.Forms.TextBox NumberOfFloorsButton;
        private System.Windows.Forms.Label NumFloorLabel;
        private System.Windows.Forms.Label NumOfLiftsLabel;
        private System.Windows.Forms.TextBox NecessaryFloorButton;
        private System.Windows.Forms.TextBox errorMessageNumFloor;
        private System.Windows.Forms.Label NeccesaryFloorLab;
        private System.Windows.Forms.Label CurrentFloorlab;
        private System.Windows.Forms.Label Weight;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox errorMessageLift;
        private System.Windows.Forms.TextBox StartParam;
        private System.Windows.Forms.TextBox errorMessageWeight;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox errorMessageCurrentFloor;
        private System.Windows.Forms.TextBox errorMessageNecFloor;
        private System.Windows.Forms.Label OutPutinformation;
        private System.Windows.Forms.Button MSExelButton;
        private System.Windows.Forms.Button MsWord;
        private System.Windows.Forms.Button toScreen;
        private System.Windows.Forms.Panel panel2;

    }
}

