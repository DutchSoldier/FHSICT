namespace ArdDangerCom
{
    partial class ArDangerComMainForm
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
            this.readMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.connectionGroupBox = new System.Windows.Forms.GroupBox();
            this.serialPortSelectionBox = new System.Windows.Forms.ComboBox();
            this.refreshSerialPortsButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.receivedRawDataGroupBox = new System.Windows.Forms.GroupBox();
            this.receivedRawDataTextBox = new System.Windows.Forms.TextBox();
            this.bVolgende = new System.Windows.Forms.Button();
            this.bControleer = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.lSom1 = new System.Windows.Forms.Label();
            this.lSom2 = new System.Windows.Forms.Label();
            this.lSom3 = new System.Windows.Forms.Label();
            this.lSom4 = new System.Windows.Forms.Label();
            this.lSom5 = new System.Windows.Forms.Label();
            this.lSom6 = new System.Windows.Forms.Label();
            this.lSom7 = new System.Windows.Forms.Label();
            this.lSom8 = new System.Windows.Forms.Label();
            this.lAntwoord1 = new System.Windows.Forms.Label();
            this.lAntwoord2 = new System.Windows.Forms.Label();
            this.lAntwoord3 = new System.Windows.Forms.Label();
            this.lAntwoord4 = new System.Windows.Forms.Label();
            this.lAntwoord5 = new System.Windows.Forms.Label();
            this.lAntwoord6 = new System.Windows.Forms.Label();
            this.lAntwoord7 = new System.Windows.Forms.Label();
            this.lAntwoord8 = new System.Windows.Forms.Label();
            this.bClear = new System.Windows.Forms.Button();
            this.bVorige = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.connectionGroupBox.SuspendLayout();
            this.receivedRawDataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // readMessageTimer
            // 
            this.readMessageTimer.Interval = 150;
            this.readMessageTimer.Tick += new System.EventHandler(this.messageReceiveTimer_Tick);
            // 
            // connectionGroupBox
            // 
            this.connectionGroupBox.Controls.Add(this.serialPortSelectionBox);
            this.connectionGroupBox.Controls.Add(this.refreshSerialPortsButton);
            this.connectionGroupBox.Controls.Add(this.connectButton);
            this.connectionGroupBox.Location = new System.Drawing.Point(425, 12);
            this.connectionGroupBox.Name = "connectionGroupBox";
            this.connectionGroupBox.Size = new System.Drawing.Size(296, 55);
            this.connectionGroupBox.TabIndex = 5;
            this.connectionGroupBox.TabStop = false;
            this.connectionGroupBox.Text = "Connection";
            // 
            // serialPortSelectionBox
            // 
            this.serialPortSelectionBox.FormattingEnabled = true;
            this.serialPortSelectionBox.Location = new System.Drawing.Point(112, 21);
            this.serialPortSelectionBox.Name = "serialPortSelectionBox";
            this.serialPortSelectionBox.Size = new System.Drawing.Size(77, 21);
            this.serialPortSelectionBox.TabIndex = 1;
            this.serialPortSelectionBox.Leave += new System.EventHandler(this.serialPortSelectionBox_Leave);
            // 
            // refreshSerialPortsButton
            // 
            this.refreshSerialPortsButton.Location = new System.Drawing.Point(27, 19);
            this.refreshSerialPortsButton.Name = "refreshSerialPortsButton";
            this.refreshSerialPortsButton.Size = new System.Drawing.Size(79, 23);
            this.refreshSerialPortsButton.TabIndex = 0;
            this.refreshSerialPortsButton.Text = "Rescan ports";
            this.refreshSerialPortsButton.UseVisualStyleBackColor = true;
            this.refreshSerialPortsButton.Click += new System.EventHandler(this.refreshSerialPortsButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(195, 19);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // receivedRawDataGroupBox
            // 
            this.receivedRawDataGroupBox.Controls.Add(this.receivedRawDataTextBox);
            this.receivedRawDataGroupBox.Location = new System.Drawing.Point(425, 84);
            this.receivedRawDataGroupBox.Name = "receivedRawDataGroupBox";
            this.receivedRawDataGroupBox.Size = new System.Drawing.Size(296, 71);
            this.receivedRawDataGroupBox.TabIndex = 5;
            this.receivedRawDataGroupBox.TabStop = false;
            this.receivedRawDataGroupBox.Text = "Antwoord:";
            // 
            // receivedRawDataTextBox
            // 
            this.receivedRawDataTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.receivedRawDataTextBox.Location = new System.Drawing.Point(7, 20);
            this.receivedRawDataTextBox.Multiline = true;
            this.receivedRawDataTextBox.Name = "receivedRawDataTextBox";
            this.receivedRawDataTextBox.ReadOnly = true;
            this.receivedRawDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receivedRawDataTextBox.Size = new System.Drawing.Size(283, 37);
            this.receivedRawDataTextBox.TabIndex = 0;
            // 
            // bVolgende
            // 
            this.bVolgende.Location = new System.Drawing.Point(344, 31);
            this.bVolgende.Name = "bVolgende";
            this.bVolgende.Size = new System.Drawing.Size(75, 23);
            this.bVolgende.TabIndex = 6;
            this.bVolgende.Text = "Volgende";
            this.bVolgende.UseVisualStyleBackColor = true;
            this.bVolgende.Click += new System.EventHandler(this.bVolgende_Click);
            // 
            // bControleer
            // 
            this.bControleer.Location = new System.Drawing.Point(186, 31);
            this.bControleer.Name = "bControleer";
            this.bControleer.Size = new System.Drawing.Size(75, 23);
            this.bControleer.TabIndex = 7;
            this.bControleer.Text = "Controleer";
            this.bControleer.UseVisualStyleBackColor = true;
            this.bControleer.Click += new System.EventHandler(this.bControleer_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 31);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 8;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lSom1
            // 
            this.lSom1.AutoSize = true;
            this.lSom1.Enabled = false;
            this.lSom1.Location = new System.Drawing.Point(27, 93);
            this.lSom1.Name = "lSom1";
            this.lSom1.Size = new System.Drawing.Size(52, 13);
            this.lSom1.TabIndex = 9;
            this.lSom1.Text = "22 + 37 =";
            // 
            // lSom2
            // 
            this.lSom2.AutoSize = true;
            this.lSom2.Enabled = false;
            this.lSom2.Location = new System.Drawing.Point(27, 128);
            this.lSom2.Name = "lSom2";
            this.lSom2.Size = new System.Drawing.Size(57, 13);
            this.lSom2.TabIndex = 10;
            this.lSom2.Text = "144 / 12 =";
            // 
            // lSom3
            // 
            this.lSom3.AutoSize = true;
            this.lSom3.Enabled = false;
            this.lSom3.Location = new System.Drawing.Point(27, 164);
            this.lSom3.Name = "lSom3";
            this.lSom3.Size = new System.Drawing.Size(75, 13);
            this.lSom3.TabIndex = 11;
            this.lSom3.Text = "(15 x 3) + 18 =";
            // 
            // lSom4
            // 
            this.lSom4.AutoSize = true;
            this.lSom4.Enabled = false;
            this.lSom4.Location = new System.Drawing.Point(27, 199);
            this.lSom4.Name = "lSom4";
            this.lSom4.Size = new System.Drawing.Size(61, 13);
            this.lSom4.TabIndex = 12;
            this.lSom4.Text = "753 -231 = ";
            // 
            // lSom5
            // 
            this.lSom5.AutoSize = true;
            this.lSom5.Enabled = false;
            this.lSom5.Location = new System.Drawing.Point(27, 232);
            this.lSom5.Name = "lSom5";
            this.lSom5.Size = new System.Drawing.Size(135, 13);
            this.lSom5.TabIndex = 13;
            this.lSom5.Text = "21 x 83 x 44 x 5,3 x 0 + 1 =";
            // 
            // lSom6
            // 
            this.lSom6.AutoSize = true;
            this.lSom6.Enabled = false;
            this.lSom6.Location = new System.Drawing.Point(27, 264);
            this.lSom6.Name = "lSom6";
            this.lSom6.Size = new System.Drawing.Size(63, 13);
            this.lSom6.TabIndex = 14;
            this.lSom6.Text = "0,5 / 0,25 =";
            // 
            // lSom7
            // 
            this.lSom7.AutoSize = true;
            this.lSom7.Enabled = false;
            this.lSom7.Location = new System.Drawing.Point(27, 296);
            this.lSom7.Name = "lSom7";
            this.lSom7.Size = new System.Drawing.Size(86, 13);
            this.lSom7.TabIndex = 15;
            this.lSom7.Text = "(13 x 13) / 169 =";
            // 
            // lSom8
            // 
            this.lSom8.AutoSize = true;
            this.lSom8.Enabled = false;
            this.lSom8.Location = new System.Drawing.Point(28, 327);
            this.lSom8.Name = "lSom8";
            this.lSom8.Size = new System.Drawing.Size(51, 13);
            this.lSom8.TabIndex = 16;
            this.lSom8.Text = "432 / 6 =";
            // 
            // lAntwoord1
            // 
            this.lAntwoord1.AutoSize = true;
            this.lAntwoord1.Location = new System.Drawing.Point(223, 93);
            this.lAntwoord1.Name = "lAntwoord1";
            this.lAntwoord1.Size = new System.Drawing.Size(19, 13);
            this.lAntwoord1.TabIndex = 17;
            this.lAntwoord1.Text = "59";
            this.lAntwoord1.Visible = false;
            // 
            // lAntwoord2
            // 
            this.lAntwoord2.AutoSize = true;
            this.lAntwoord2.Location = new System.Drawing.Point(223, 128);
            this.lAntwoord2.Name = "lAntwoord2";
            this.lAntwoord2.Size = new System.Drawing.Size(19, 13);
            this.lAntwoord2.TabIndex = 18;
            this.lAntwoord2.Text = "12";
            this.lAntwoord2.Visible = false;
            // 
            // lAntwoord3
            // 
            this.lAntwoord3.AutoSize = true;
            this.lAntwoord3.Location = new System.Drawing.Point(223, 164);
            this.lAntwoord3.Name = "lAntwoord3";
            this.lAntwoord3.Size = new System.Drawing.Size(19, 13);
            this.lAntwoord3.TabIndex = 19;
            this.lAntwoord3.Text = "63";
            this.lAntwoord3.Visible = false;
            // 
            // lAntwoord4
            // 
            this.lAntwoord4.AutoSize = true;
            this.lAntwoord4.Location = new System.Drawing.Point(223, 199);
            this.lAntwoord4.Name = "lAntwoord4";
            this.lAntwoord4.Size = new System.Drawing.Size(25, 13);
            this.lAntwoord4.TabIndex = 20;
            this.lAntwoord4.Text = "522";
            this.lAntwoord4.Visible = false;
            // 
            // lAntwoord5
            // 
            this.lAntwoord5.AutoSize = true;
            this.lAntwoord5.Location = new System.Drawing.Point(223, 232);
            this.lAntwoord5.Name = "lAntwoord5";
            this.lAntwoord5.Size = new System.Drawing.Size(13, 13);
            this.lAntwoord5.TabIndex = 21;
            this.lAntwoord5.Text = "1";
            this.lAntwoord5.Visible = false;
            // 
            // lAntwoord6
            // 
            this.lAntwoord6.AutoSize = true;
            this.lAntwoord6.Location = new System.Drawing.Point(223, 264);
            this.lAntwoord6.Name = "lAntwoord6";
            this.lAntwoord6.Size = new System.Drawing.Size(13, 13);
            this.lAntwoord6.TabIndex = 22;
            this.lAntwoord6.Text = "2";
            this.lAntwoord6.Visible = false;
            // 
            // lAntwoord7
            // 
            this.lAntwoord7.AutoSize = true;
            this.lAntwoord7.Location = new System.Drawing.Point(223, 296);
            this.lAntwoord7.Name = "lAntwoord7";
            this.lAntwoord7.Size = new System.Drawing.Size(13, 13);
            this.lAntwoord7.TabIndex = 23;
            this.lAntwoord7.Text = "1";
            this.lAntwoord7.Visible = false;
            // 
            // lAntwoord8
            // 
            this.lAntwoord8.AutoSize = true;
            this.lAntwoord8.Location = new System.Drawing.Point(223, 327);
            this.lAntwoord8.Name = "lAntwoord8";
            this.lAntwoord8.Size = new System.Drawing.Size(19, 13);
            this.lAntwoord8.TabIndex = 24;
            this.lAntwoord8.Text = "72";
            this.lAntwoord8.Visible = false;
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(93, 31);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(87, 23);
            this.bClear.TabIndex = 25;
            this.bClear.Text = "Wis antwoord";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bVorige
            // 
            this.bVorige.Location = new System.Drawing.Point(267, 31);
            this.bVorige.Name = "bVorige";
            this.bVorige.Size = new System.Drawing.Size(75, 23);
            this.bVorige.TabIndex = 26;
            this.bVorige.Text = "Vorige";
            this.bVorige.UseVisualStyleBackColor = true;
            this.bVorige.Click += new System.EventHandler(this.bVorige_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "7:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "6:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "5:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "4:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "3:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "2:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "8:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(432, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Huidige som:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(497, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 36;
            // 
            // ArDangerComMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 388);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bVorige);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.lAntwoord8);
            this.Controls.Add(this.lAntwoord7);
            this.Controls.Add(this.lAntwoord6);
            this.Controls.Add(this.lAntwoord5);
            this.Controls.Add(this.lAntwoord4);
            this.Controls.Add(this.lAntwoord3);
            this.Controls.Add(this.lAntwoord2);
            this.Controls.Add(this.lAntwoord1);
            this.Controls.Add(this.lSom8);
            this.Controls.Add(this.lSom7);
            this.Controls.Add(this.lSom6);
            this.Controls.Add(this.lSom5);
            this.Controls.Add(this.lSom4);
            this.Controls.Add(this.lSom3);
            this.Controls.Add(this.lSom2);
            this.Controls.Add(this.lSom1);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.bControleer);
            this.Controls.Add(this.bVolgende);
            this.Controls.Add(this.receivedRawDataGroupBox);
            this.Controls.Add(this.connectionGroupBox);
            this.Location = new System.Drawing.Point(100, 0);
            this.Name = "ArDangerComMainForm";
            this.Text = "ArDangerCom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ArDangerComMainForm_FormClosed);
            this.connectionGroupBox.ResumeLayout(false);
            this.receivedRawDataGroupBox.ResumeLayout(false);
            this.receivedRawDataGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer readMessageTimer;
        private System.Windows.Forms.GroupBox connectionGroupBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button refreshSerialPortsButton;
        private System.Windows.Forms.ComboBox serialPortSelectionBox;
        private System.Windows.Forms.GroupBox receivedRawDataGroupBox;
        private System.Windows.Forms.TextBox receivedRawDataTextBox;
        private System.Windows.Forms.Button bVolgende;
        private System.Windows.Forms.Button bControleer;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label lSom1;
        private System.Windows.Forms.Label lSom2;
        private System.Windows.Forms.Label lSom3;
        private System.Windows.Forms.Label lSom4;
        private System.Windows.Forms.Label lSom5;
        private System.Windows.Forms.Label lSom6;
        private System.Windows.Forms.Label lSom7;
        private System.Windows.Forms.Label lSom8;
        private System.Windows.Forms.Label lAntwoord1;
        private System.Windows.Forms.Label lAntwoord2;
        private System.Windows.Forms.Label lAntwoord3;
        private System.Windows.Forms.Label lAntwoord4;
        private System.Windows.Forms.Label lAntwoord5;
        private System.Windows.Forms.Label lAntwoord6;
        private System.Windows.Forms.Label lAntwoord7;
        private System.Windows.Forms.Label lAntwoord8;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bVorige;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

