namespace KKCControlApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPort = new GroupBox();
            btnConnect = new Button();
            cmbBaud = new ComboBox();
            lblBaud = new Label();
            btnRefresh = new Button();
            cmbPorts = new ComboBox();
            label1 = new Label();
            grpQuick = new GroupBox();
            btnSM = new Button();
            atxtRawCmd = new TextBox();
            btnSendRaw = new Button();
            btnFM = new Button();
            btnRST = new Button();
            btnStop = new Button();
            btnOff = new Button();
            btnModeQuery = new Button();
            btnPhaseQuery = new Button();
            tabMain = new TabControl();
            tabPhase = new TabPage();
            groupBox3 = new GroupBox();
            pbEastGreen = new PictureBox();
            pbEastYellow = new PictureBox();
            pbEastRed = new PictureBox();
            pbWestGreen = new PictureBox();
            pbWestYellow = new PictureBox();
            pbWestRed = new PictureBox();
            pbNorthGreen = new PictureBox();
            pbNorthYellow = new PictureBox();
            pbNorthRed = new PictureBox();
            pbSouthGreen = new PictureBox();
            pbSouthYellow = new PictureBox();
            pbSouthRed = new PictureBox();
            btnPhaseEast = new Button();
            btnPhaseSouth = new Button();
            btnPhaseWest = new Button();
            btnPhaseNorth = new Button();
            tabDelays = new TabPage();
            btnResetDelays = new Button();
            btnApplyTransition = new Button();
            btnApplyEast = new Button();
            btnApplyWest = new Button();
            btnApplySouth = new Button();
            label13 = new Label();
            label15 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            btnApplyNorth = new Button();
            numTransition = new NumericUpDown();
            numEast = new NumericUpDown();
            numWest = new NumericUpDown();
            numSouth = new NumericUpDown();
            numNorth = new NumericUpDown();
            tabTimeDate = new TabPage();
            label2 = new Label();
            lblTime = new Label();
            lblTimeZone = new Label();
            btnLearnTZ = new Button();
            lblDate = new Label();
            btnLearnD = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnSetTime = new Button();
            btnSetTZ = new Button();
            btnSetDate = new Button();
            cmbTimeZone = new ComboBox();
            dtpSetTime = new DateTimePicker();
            dtpSetDate = new DateTimePicker();
            tabPage1 = new TabPage();
            groupBox1 = new GroupBox();
            btnPhaseAllGroupInfo = new Button();
            btnSigInfo = new Button();
            cmbSig = new ComboBox();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            btnClearLog = new Button();
            txtLog = new RichTextBox();
            lblPort.SuspendLayout();
            grpQuick.SuspendLayout();
            tabMain.SuspendLayout();
            tabPhase.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbEastGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEastYellow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEastRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWestGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWestYellow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWestRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNorthGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNorthYellow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNorthRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSouthGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSouthYellow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSouthRed).BeginInit();
            tabDelays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTransition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSouth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNorth).BeginInit();
            tabTimeDate.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // lblPort
            // 
            lblPort.Controls.Add(btnConnect);
            lblPort.Controls.Add(cmbBaud);
            lblPort.Controls.Add(lblBaud);
            lblPort.Controls.Add(btnRefresh);
            lblPort.Controls.Add(cmbPorts);
            lblPort.Controls.Add(label1);
            lblPort.Dock = DockStyle.Top;
            lblPort.Location = new Point(0, 0);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(1048, 56);
            lblPort.TabIndex = 0;
            lblPort.TabStop = false;
            lblPort.Text = "Connection";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(576, 18);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(178, 29);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cmbBaud
            // 
            cmbBaud.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBaud.FormattingEnabled = true;
            cmbBaud.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            cmbBaud.Location = new Point(419, 19);
            cmbBaud.Name = "cmbBaud";
            cmbBaud.Size = new Size(151, 28);
            cmbBaud.TabIndex = 4;
            // 
            // lblBaud
            // 
            lblBaud.AutoSize = true;
            lblBaud.Location = new Point(367, 23);
            lblBaud.Name = "lblBaud";
            lblBaud.Size = new Size(46, 20);
            lblBaud.TabIndex = 3;
            lblBaud.Text = "Baud:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(213, 18);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // cmbPorts
            // 
            cmbPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPorts.FormattingEnabled = true;
            cmbPorts.Location = new Point(56, 19);
            cmbPorts.Name = "cmbPorts";
            cmbPorts.Size = new Size(151, 28);
            cmbPorts.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Port:";
            // 
            // grpQuick
            // 
            grpQuick.Controls.Add(btnSM);
            grpQuick.Controls.Add(atxtRawCmd);
            grpQuick.Controls.Add(btnSendRaw);
            grpQuick.Controls.Add(btnFM);
            grpQuick.Controls.Add(btnRST);
            grpQuick.Controls.Add(btnStop);
            grpQuick.Controls.Add(btnOff);
            grpQuick.Controls.Add(btnModeQuery);
            grpQuick.Controls.Add(btnPhaseQuery);
            grpQuick.Dock = DockStyle.Left;
            grpQuick.Location = new Point(0, 56);
            grpQuick.Name = "grpQuick";
            grpQuick.Size = new Size(213, 537);
            grpQuick.TabIndex = 1;
            grpQuick.TabStop = false;
            grpQuick.Text = "Quick Commands";
            // 
            // btnSM
            // 
            btnSM.Location = new Point(12, 49);
            btnSM.Name = "btnSM";
            btnSM.Size = new Size(125, 29);
            btnSM.TabIndex = 9;
            btnSM.Text = "Sequence Mode";
            btnSM.UseVisualStyleBackColor = true;
            // 
            // atxtRawCmd
            // 
            atxtRawCmd.Location = new Point(12, 417);
            atxtRawCmd.Name = "atxtRawCmd";
            atxtRawCmd.Size = new Size(125, 27);
            atxtRawCmd.TabIndex = 4;
            // 
            // btnSendRaw
            // 
            btnSendRaw.Location = new Point(12, 450);
            btnSendRaw.Name = "btnSendRaw";
            btnSendRaw.Size = new Size(125, 29);
            btnSendRaw.TabIndex = 6;
            btnSendRaw.Text = "Send";
            btnSendRaw.UseVisualStyleBackColor = true;
            btnSendRaw.Click += btnSendRaw_Click;
            // 
            // btnFM
            // 
            btnFM.Location = new Point(12, 84);
            btnFM.Name = "btnFM";
            btnFM.Size = new Size(125, 29);
            btnFM.TabIndex = 8;
            btnFM.Text = "Flash Mode";
            btnFM.UseVisualStyleBackColor = true;
            // 
            // btnRST
            // 
            btnRST.Location = new Point(12, 119);
            btnRST.Name = "btnRST";
            btnRST.Size = new Size(125, 29);
            btnRST.TabIndex = 7;
            btnRST.Text = "System Reset";
            btnRST.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(12, 155);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(125, 29);
            btnStop.TabIndex = 6;
            btnStop.Text = "STOP";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // btnOff
            // 
            btnOff.Location = new Point(12, 190);
            btnOff.Name = "btnOff";
            btnOff.Size = new Size(125, 29);
            btnOff.TabIndex = 5;
            btnOff.Text = "OFF";
            btnOff.UseVisualStyleBackColor = true;
            // 
            // btnModeQuery
            // 
            btnModeQuery.Location = new Point(12, 225);
            btnModeQuery.Name = "btnModeQuery";
            btnModeQuery.Size = new Size(125, 29);
            btnModeQuery.TabIndex = 4;
            btnModeQuery.Text = "LEARN MODE";
            btnModeQuery.UseVisualStyleBackColor = true;
            // 
            // btnPhaseQuery
            // 
            btnPhaseQuery.Location = new Point(12, 260);
            btnPhaseQuery.Name = "btnPhaseQuery";
            btnPhaseQuery.Size = new Size(125, 29);
            btnPhaseQuery.TabIndex = 3;
            btnPhaseQuery.Text = "LEARN PHASE";
            btnPhaseQuery.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabPhase);
            tabMain.Controls.Add(tabDelays);
            tabMain.Controls.Add(tabTimeDate);
            tabMain.Controls.Add(tabPage1);
            tabMain.Location = new Point(213, 56);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(611, 537);
            tabMain.TabIndex = 2;
            // 
            // tabPhase
            // 
            tabPhase.Controls.Add(groupBox3);
            tabPhase.Location = new Point(4, 29);
            tabPhase.Name = "tabPhase";
            tabPhase.Padding = new Padding(3);
            tabPhase.Size = new Size(603, 504);
            tabPhase.TabIndex = 0;
            tabPhase.Text = "Phase";
            tabPhase.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pbEastGreen);
            groupBox3.Controls.Add(pbEastYellow);
            groupBox3.Controls.Add(pbEastRed);
            groupBox3.Controls.Add(pbWestGreen);
            groupBox3.Controls.Add(pbWestYellow);
            groupBox3.Controls.Add(pbWestRed);
            groupBox3.Controls.Add(pbNorthGreen);
            groupBox3.Controls.Add(pbNorthYellow);
            groupBox3.Controls.Add(pbNorthRed);
            groupBox3.Controls.Add(pbSouthGreen);
            groupBox3.Controls.Add(pbSouthYellow);
            groupBox3.Controls.Add(pbSouthRed);
            groupBox3.Controls.Add(btnPhaseEast);
            groupBox3.Controls.Add(btnPhaseSouth);
            groupBox3.Controls.Add(btnPhaseWest);
            groupBox3.Controls.Add(btnPhaseNorth);
            groupBox3.Location = new Point(6, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(443, 299);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Signal Group Info";
            // 
            // pbEastGreen
            // 
            pbEastGreen.Location = new Point(253, 170);
            pbEastGreen.Name = "pbEastGreen";
            pbEastGreen.Size = new Size(38, 37);
            pbEastGreen.TabIndex = 25;
            pbEastGreen.TabStop = false;
            // 
            // pbEastYellow
            // 
            pbEastYellow.Location = new Point(253, 127);
            pbEastYellow.Name = "pbEastYellow";
            pbEastYellow.Size = new Size(38, 37);
            pbEastYellow.TabIndex = 24;
            pbEastYellow.TabStop = false;
            // 
            // pbEastRed
            // 
            pbEastRed.Location = new Point(253, 84);
            pbEastRed.Name = "pbEastRed";
            pbEastRed.Size = new Size(38, 37);
            pbEastRed.TabIndex = 23;
            pbEastRed.TabStop = false;
            // 
            // pbWestGreen
            // 
            pbWestGreen.Location = new Point(350, 170);
            pbWestGreen.Name = "pbWestGreen";
            pbWestGreen.Size = new Size(38, 37);
            pbWestGreen.TabIndex = 22;
            pbWestGreen.TabStop = false;
            // 
            // pbWestYellow
            // 
            pbWestYellow.Location = new Point(350, 127);
            pbWestYellow.Name = "pbWestYellow";
            pbWestYellow.Size = new Size(38, 37);
            pbWestYellow.TabIndex = 21;
            pbWestYellow.TabStop = false;
            // 
            // pbWestRed
            // 
            pbWestRed.Location = new Point(350, 84);
            pbWestRed.Name = "pbWestRed";
            pbWestRed.Size = new Size(38, 37);
            pbWestRed.TabIndex = 20;
            pbWestRed.TabStop = false;
            // 
            // pbNorthGreen
            // 
            pbNorthGreen.Location = new Point(44, 170);
            pbNorthGreen.Name = "pbNorthGreen";
            pbNorthGreen.Size = new Size(38, 37);
            pbNorthGreen.TabIndex = 19;
            pbNorthGreen.TabStop = false;
            // 
            // pbNorthYellow
            // 
            pbNorthYellow.Location = new Point(44, 127);
            pbNorthYellow.Name = "pbNorthYellow";
            pbNorthYellow.Size = new Size(38, 37);
            pbNorthYellow.TabIndex = 18;
            pbNorthYellow.TabStop = false;
            // 
            // pbNorthRed
            // 
            pbNorthRed.Location = new Point(44, 84);
            pbNorthRed.Name = "pbNorthRed";
            pbNorthRed.Size = new Size(38, 37);
            pbNorthRed.TabIndex = 17;
            pbNorthRed.TabStop = false;
            // 
            // pbSouthGreen
            // 
            pbSouthGreen.Location = new Point(146, 170);
            pbSouthGreen.Name = "pbSouthGreen";
            pbSouthGreen.Size = new Size(38, 37);
            pbSouthGreen.TabIndex = 16;
            pbSouthGreen.TabStop = false;
            // 
            // pbSouthYellow
            // 
            pbSouthYellow.Location = new Point(146, 127);
            pbSouthYellow.Name = "pbSouthYellow";
            pbSouthYellow.Size = new Size(38, 37);
            pbSouthYellow.TabIndex = 15;
            pbSouthYellow.TabStop = false;
            // 
            // pbSouthRed
            // 
            pbSouthRed.Location = new Point(146, 84);
            pbSouthRed.Name = "pbSouthRed";
            pbSouthRed.Size = new Size(38, 37);
            pbSouthRed.TabIndex = 14;
            pbSouthRed.TabStop = false;
            // 
            // btnPhaseEast
            // 
            btnPhaseEast.Location = new Point(222, 49);
            btnPhaseEast.Name = "btnPhaseEast";
            btnPhaseEast.Size = new Size(94, 29);
            btnPhaseEast.TabIndex = 13;
            btnPhaseEast.Text = "East";
            btnPhaseEast.UseVisualStyleBackColor = true;
            // 
            // btnPhaseSouth
            // 
            btnPhaseSouth.Location = new Point(122, 49);
            btnPhaseSouth.Name = "btnPhaseSouth";
            btnPhaseSouth.Size = new Size(94, 29);
            btnPhaseSouth.TabIndex = 12;
            btnPhaseSouth.Text = "South";
            btnPhaseSouth.UseVisualStyleBackColor = true;
            // 
            // btnPhaseWest
            // 
            btnPhaseWest.Location = new Point(322, 49);
            btnPhaseWest.Name = "btnPhaseWest";
            btnPhaseWest.Size = new Size(94, 29);
            btnPhaseWest.TabIndex = 11;
            btnPhaseWest.Text = "West";
            btnPhaseWest.UseVisualStyleBackColor = true;
            // 
            // btnPhaseNorth
            // 
            btnPhaseNorth.Location = new Point(22, 49);
            btnPhaseNorth.Name = "btnPhaseNorth";
            btnPhaseNorth.Size = new Size(94, 29);
            btnPhaseNorth.TabIndex = 10;
            btnPhaseNorth.Text = "North";
            btnPhaseNorth.UseVisualStyleBackColor = true;
            // 
            // tabDelays
            // 
            tabDelays.Controls.Add(btnResetDelays);
            tabDelays.Controls.Add(btnApplyTransition);
            tabDelays.Controls.Add(btnApplyEast);
            tabDelays.Controls.Add(btnApplyWest);
            tabDelays.Controls.Add(btnApplySouth);
            tabDelays.Controls.Add(label13);
            tabDelays.Controls.Add(label15);
            tabDelays.Controls.Add(label12);
            tabDelays.Controls.Add(label11);
            tabDelays.Controls.Add(label10);
            tabDelays.Controls.Add(btnApplyNorth);
            tabDelays.Controls.Add(numTransition);
            tabDelays.Controls.Add(numEast);
            tabDelays.Controls.Add(numWest);
            tabDelays.Controls.Add(numSouth);
            tabDelays.Controls.Add(numNorth);
            tabDelays.Location = new Point(4, 29);
            tabDelays.Name = "tabDelays";
            tabDelays.Padding = new Padding(3);
            tabDelays.Size = new Size(603, 504);
            tabDelays.TabIndex = 1;
            tabDelays.Text = "Delays";
            tabDelays.UseVisualStyleBackColor = true;
            // 
            // btnResetDelays
            // 
            btnResetDelays.Location = new Point(183, 260);
            btnResetDelays.Name = "btnResetDelays";
            btnResetDelays.Size = new Size(148, 65);
            btnResetDelays.TabIndex = 19;
            btnResetDelays.Text = "Reset All Delays";
            btnResetDelays.UseVisualStyleBackColor = true;
            btnResetDelays.Click += btnResetDelays_Click;
            // 
            // btnApplyTransition
            // 
            btnApplyTransition.Location = new Point(325, 154);
            btnApplyTransition.Name = "btnApplyTransition";
            btnApplyTransition.Size = new Size(125, 29);
            btnApplyTransition.TabIndex = 18;
            btnApplyTransition.Text = "Apply Transition";
            btnApplyTransition.UseVisualStyleBackColor = true;
            btnApplyTransition.Click += btnApplyTransition_Click;
            // 
            // btnApplyEast
            // 
            btnApplyEast.Location = new Point(325, 119);
            btnApplyEast.Name = "btnApplyEast";
            btnApplyEast.Size = new Size(125, 29);
            btnApplyEast.TabIndex = 17;
            btnApplyEast.Text = "Apply East";
            btnApplyEast.UseVisualStyleBackColor = true;
            btnApplyEast.Click += btnApplyEast_Click;
            // 
            // btnApplyWest
            // 
            btnApplyWest.Location = new Point(325, 84);
            btnApplyWest.Name = "btnApplyWest";
            btnApplyWest.Size = new Size(125, 29);
            btnApplyWest.TabIndex = 16;
            btnApplyWest.Text = "Apply West";
            btnApplyWest.UseVisualStyleBackColor = true;
            btnApplyWest.Click += btnApplyWest_Click;
            // 
            // btnApplySouth
            // 
            btnApplySouth.Location = new Point(325, 49);
            btnApplySouth.Name = "btnApplySouth";
            btnApplySouth.Size = new Size(125, 29);
            btnApplySouth.TabIndex = 15;
            btnApplySouth.Text = "Apply South";
            btnApplySouth.UseVisualStyleBackColor = true;
            btnApplySouth.Click += btnApplySouth_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(183, 152);
            label13.Name = "label13";
            label13.Size = new Size(106, 20);
            label13.TabIndex = 14;
            label13.Text = "Transition (ms)";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(183, 119);
            label15.Name = "label15";
            label15.Size = new Size(69, 20);
            label15.TabIndex = 12;
            label15.Text = "East (ms)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(183, 53);
            label12.Name = "label12";
            label12.Size = new Size(80, 20);
            label12.TabIndex = 11;
            label12.Text = "South (ms)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(183, 86);
            label11.Name = "label11";
            label11.Size = new Size(74, 20);
            label11.TabIndex = 10;
            label11.Text = "West (ms)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(183, 18);
            label10.Name = "label10";
            label10.Size = new Size(80, 20);
            label10.TabIndex = 9;
            label10.Text = "North (ms)";
            // 
            // btnApplyNorth
            // 
            btnApplyNorth.Location = new Point(325, 14);
            btnApplyNorth.Name = "btnApplyNorth";
            btnApplyNorth.Size = new Size(125, 29);
            btnApplyNorth.TabIndex = 8;
            btnApplyNorth.Text = "Apply North";
            btnApplyNorth.UseVisualStyleBackColor = true;
            btnApplyNorth.Click += btnApplyNorth_Click;
            // 
            // numTransition
            // 
            numTransition.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numTransition.Location = new Point(29, 152);
            numTransition.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            numTransition.Name = "numTransition";
            numTransition.Size = new Size(126, 27);
            numTransition.TabIndex = 4;
            // 
            // numEast
            // 
            numEast.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numEast.Location = new Point(29, 119);
            numEast.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            numEast.Name = "numEast";
            numEast.Size = new Size(126, 27);
            numEast.TabIndex = 3;
            // 
            // numWest
            // 
            numWest.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numWest.Location = new Point(29, 86);
            numWest.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            numWest.Name = "numWest";
            numWest.Size = new Size(126, 27);
            numWest.TabIndex = 2;
            // 
            // numSouth
            // 
            numSouth.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numSouth.Location = new Point(29, 53);
            numSouth.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            numSouth.Name = "numSouth";
            numSouth.Size = new Size(126, 27);
            numSouth.TabIndex = 1;
            // 
            // numNorth
            // 
            numNorth.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numNorth.Location = new Point(29, 18);
            numNorth.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            numNorth.Name = "numNorth";
            numNorth.Size = new Size(126, 27);
            numNorth.TabIndex = 0;
            // 
            // tabTimeDate
            // 
            tabTimeDate.Controls.Add(label2);
            tabTimeDate.Controls.Add(lblTime);
            tabTimeDate.Controls.Add(lblTimeZone);
            tabTimeDate.Controls.Add(btnLearnTZ);
            tabTimeDate.Controls.Add(lblDate);
            tabTimeDate.Controls.Add(btnLearnD);
            tabTimeDate.Controls.Add(label5);
            tabTimeDate.Controls.Add(label4);
            tabTimeDate.Controls.Add(label3);
            tabTimeDate.Controls.Add(btnSetTime);
            tabTimeDate.Controls.Add(btnSetTZ);
            tabTimeDate.Controls.Add(btnSetDate);
            tabTimeDate.Controls.Add(cmbTimeZone);
            tabTimeDate.Controls.Add(dtpSetTime);
            tabTimeDate.Controls.Add(dtpSetDate);
            tabTimeDate.Font = new Font("Segoe UI", 9F);
            tabTimeDate.Location = new Point(4, 29);
            tabTimeDate.Name = "tabTimeDate";
            tabTimeDate.Padding = new Padding(3);
            tabTimeDate.Size = new Size(603, 504);
            tabTimeDate.TabIndex = 2;
            tabTimeDate.Text = "Time / Date";
            tabTimeDate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.5F);
            label2.Location = new Point(46, 228);
            label2.Name = "label2";
            label2.Size = new Size(133, 28);
            label2.TabIndex = 17;
            label2.Text = "Current Time: ";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 18F);
            lblTime.Location = new Point(185, 221);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(128, 41);
            lblTime.TabIndex = 6;
            lblTime.Text = "00:00:00";
            // 
            // lblTimeZone
            // 
            lblTimeZone.AutoSize = true;
            lblTimeZone.Font = new Font("Segoe UI", 18F);
            lblTimeZone.Location = new Point(217, 377);
            lblTimeZone.Name = "lblTimeZone";
            lblTimeZone.Size = new Size(81, 41);
            lblTimeZone.TabIndex = 15;
            lblTimeZone.Text = "UTC ";
            // 
            // btnLearnTZ
            // 
            btnLearnTZ.Location = new Point(37, 375);
            btnLearnTZ.Name = "btnLearnTZ";
            btnLearnTZ.Size = new Size(142, 48);
            btnLearnTZ.TabIndex = 16;
            btnLearnTZ.Text = "Learn Time Zone";
            btnLearnTZ.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 18F);
            lblDate.Location = new Point(185, 294);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(138, 41);
            lblDate.TabIndex = 13;
            lblDate.Text = "00/00/00";
            // 
            // btnLearnD
            // 
            btnLearnD.Location = new Point(37, 292);
            btnLearnD.Name = "btnLearnD";
            btnLearnD.Size = new Size(142, 48);
            btnLearnD.TabIndex = 14;
            btnLearnD.Text = "Learn Date";
            btnLearnD.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(135, 69);
            label5.Name = "label5";
            label5.Size = new Size(44, 20);
            label5.TabIndex = 11;
            label5.Text = "Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(134, 113);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 10;
            label4.Text = "Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 24);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 9;
            label3.Text = "Time Zone:";
            // 
            // btnSetTime
            // 
            btnSetTime.Location = new Point(300, 109);
            btnSetTime.Name = "btnSetTime";
            btnSetTime.Size = new Size(116, 29);
            btnSetTime.TabIndex = 8;
            btnSetTime.Text = "Set Time";
            btnSetTime.UseVisualStyleBackColor = true;
            btnSetTime.Click += button12_Click;
            // 
            // btnSetTZ
            // 
            btnSetTZ.Location = new Point(300, 20);
            btnSetTZ.Name = "btnSetTZ";
            btnSetTZ.Size = new Size(116, 29);
            btnSetTZ.TabIndex = 7;
            btnSetTZ.Text = "Set Time Zone";
            btnSetTZ.UseVisualStyleBackColor = true;
            // 
            // btnSetDate
            // 
            btnSetDate.Location = new Point(300, 65);
            btnSetDate.Name = "btnSetDate";
            btnSetDate.Size = new Size(116, 29);
            btnSetDate.TabIndex = 6;
            btnSetDate.Text = "Set Date";
            btnSetDate.UseVisualStyleBackColor = true;
            // 
            // cmbTimeZone
            // 
            cmbTimeZone.FormattingEnabled = true;
            cmbTimeZone.Items.AddRange(new object[] { "-12", "-11", "-10", "-9", "-8", "-7", "-6", "-5", "-4", "-3", "-2", "-1", "0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12" });
            cmbTimeZone.Location = new Point(185, 21);
            cmbTimeZone.Name = "cmbTimeZone";
            cmbTimeZone.Size = new Size(109, 28);
            cmbTimeZone.TabIndex = 2;
            cmbTimeZone.SelectedIndexChanged += cmbTimeZone_SelectedIndexChanged;
            // 
            // dtpSetTime
            // 
            dtpSetTime.Format = DateTimePickerFormat.Time;
            dtpSetTime.Location = new Point(185, 108);
            dtpSetTime.Name = "dtpSetTime";
            dtpSetTime.ShowUpDown = true;
            dtpSetTime.Size = new Size(109, 27);
            dtpSetTime.TabIndex = 1;
            // 
            // dtpSetDate
            // 
            dtpSetDate.Format = DateTimePickerFormat.Short;
            dtpSetDate.Location = new Point(185, 67);
            dtpSetDate.Name = "dtpSetDate";
            dtpSetDate.Size = new Size(109, 27);
            dtpSetDate.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(603, 504);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Signal Info";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPhaseAllGroupInfo);
            groupBox1.Controls.Add(btnSigInfo);
            groupBox1.Controls.Add(cmbSig);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(389, 235);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Signal Group Info";
            // 
            // btnPhaseAllGroupInfo
            // 
            btnPhaseAllGroupInfo.Location = new Point(213, 179);
            btnPhaseAllGroupInfo.Name = "btnPhaseAllGroupInfo";
            btnPhaseAllGroupInfo.Size = new Size(94, 29);
            btnPhaseAllGroupInfo.TabIndex = 18;
            btnPhaseAllGroupInfo.Text = "All Group";
            btnPhaseAllGroupInfo.UseVisualStyleBackColor = true;
            // 
            // btnSigInfo
            // 
            btnSigInfo.Location = new Point(213, 62);
            btnSigInfo.Name = "btnSigInfo";
            btnSigInfo.Size = new Size(94, 29);
            btnSigInfo.TabIndex = 16;
            btnSigInfo.Text = "SIG=X";
            btnSigInfo.UseVisualStyleBackColor = true;
            btnSigInfo.Click += btnSigInfo_Click;
            // 
            // cmbSig
            // 
            cmbSig.FormattingEnabled = true;
            cmbSig.Items.AddRange(new object[] { "1", "2", "3", "4" });
            cmbSig.Location = new Point(56, 63);
            cmbSig.Name = "cmbSig";
            cmbSig.Size = new Size(151, 28);
            cmbSig.TabIndex = 15;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(213, 567);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(835, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(99, 20);
            lblStatus.Text = "Disconnected";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Right;
            splitContainer1.Location = new Point(752, 56);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.WhiteSmoke;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Control;
            splitContainer1.Panel2.Controls.Add(btnClearLog);
            splitContainer1.Panel2.Controls.Add(txtLog);
            splitContainer1.Size = new Size(296, 511);
            splitContainer1.SplitterDistance = 168;
            splitContainer1.TabIndex = 7;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(55, 278);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(122, 29);
            btnClearLog.TabIndex = 11;
            btnClearLog.Text = "Clear Log";
            btnClearLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            txtLog.Dock = DockStyle.Fill;
            txtLog.Location = new Point(0, 0);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(296, 339);
            txtLog.TabIndex = 0;
            txtLog.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 593);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(tabMain);
            Controls.Add(grpQuick);
            Controls.Add(lblPort);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            lblPort.ResumeLayout(false);
            lblPort.PerformLayout();
            grpQuick.ResumeLayout(false);
            grpQuick.PerformLayout();
            tabMain.ResumeLayout(false);
            tabPhase.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbEastGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEastYellow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEastRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWestGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWestYellow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWestRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNorthGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNorthYellow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNorthRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSouthGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSouthYellow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSouthRed).EndInit();
            tabDelays.ResumeLayout(false);
            tabDelays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTransition).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEast).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWest).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSouth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNorth).EndInit();
            tabTimeDate.ResumeLayout(false);
            tabTimeDate.PerformLayout();
            tabPage1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox lblPort;
        private Label label1;
        private Button btnConnect;
        private ComboBox cmbBaud;
        private Label lblBaud;
        private Button btnRefresh;
        private ComboBox cmbPorts;
        private GroupBox grpQuick;
        private Button btnSM;
        private Button btnFM;
        private Button btnRST;
        private Button btnStop;
        private Button btnOff;
        private Button btnModeQuery;
        private Button btnPhaseQuery;
        private TabControl tabMain;
        private TabPage tabPhase;
        private TabPage tabTimeDate;
        private DateTimePicker dtpSetDate;
        private ComboBox cmbTimeZone;
        private DateTimePicker dtpSetTime;
        private Button btnSetTime;
        private Button btnSetTZ;
        private Button btnSetDate;
        private Label lblTimeZone;
        private Button btnLearnTZ;
        private Label lblDate;
        private Button btnLearnD;
        private Label lblTime;
        private Label label5;
        private Label label4;
        private Label label3;
        private GroupBox groupBox3;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private TextBox atxtRawCmd;
        private Button btnSendRaw;
        private Button btnPhaseSouth;
        private Button btnPhaseWest;
        private Button btnPhaseNorth;
        private Button btnPhaseEast;
        private SplitContainer splitContainer1;
        private RichTextBox txtLog;
        private Button btnClearLog;
        private TabPage tabDelays;
        private Button btnApplyNorth;
        private NumericUpDown numTransition;
        private NumericUpDown numEast;
        private NumericUpDown numWest;
        private NumericUpDown numSouth;
        private NumericUpDown numNorth;
        private Label label13;
        private Label label15;
        private Label label12;
        private Label label11;
        private Label label10;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private Button btnPhaseAllGroupInfo;
        private Button btnSigInfo;
        private ComboBox cmbSig;
        private TabPage tabInfo;
        private Button btnApplyTransition;
        private Button btnApplyEast;
        private Button btnApplyWest;
        private Button btnApplySouth;
        private Button btnResetDelays;
        private PictureBox pbEastGreen;
        private PictureBox pbEastYellow;
        private PictureBox pbEastRed;
        private PictureBox pbWestGreen;
        private PictureBox pbWestYellow;
        private PictureBox pbWestRed;
        private PictureBox pbNorthGreen;
        private PictureBox pbNorthYellow;
        private PictureBox pbNorthRed;
        private PictureBox pbSouthGreen;
        private PictureBox pbSouthYellow;
        private PictureBox pbSouthRed;
        private Label label2;
    }
}
