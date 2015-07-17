namespace SE12_Week2_Lab_ADayAtTheRaces
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbRaceTrack = new System.Windows.Forms.PictureBox();
            this.pbDog1 = new System.Windows.Forms.PictureBox();
            this.pbDog2 = new System.Windows.Forms.PictureBox();
            this.pbDog3 = new System.Windows.Forms.PictureBox();
            this.pbDog4 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bRace = new System.Windows.Forms.Button();
            this.numDogs = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numBucks = new System.Windows.Forms.NumericUpDown();
            this.bBet = new System.Windows.Forms.Button();
            this.lCurrentBidder = new System.Windows.Forms.Label();
            this.lAlsBet = new System.Windows.Forms.Label();
            this.lBobsBet = new System.Windows.Forms.Label();
            this.lJoesBet = new System.Windows.Forms.Label();
            this.rbAl = new System.Windows.Forms.RadioButton();
            this.rbBob = new System.Windows.Forms.RadioButton();
            this.rbJoe = new System.Windows.Forms.RadioButton();
            this.lBets = new System.Windows.Forms.Label();
            this.lMinimumBet = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbRaceTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDog2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDog3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDog4)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucks)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRaceTrack
            // 
            this.pbRaceTrack.Image = ((System.Drawing.Image)(resources.GetObject("pbRaceTrack.Image")));
            this.pbRaceTrack.Location = new System.Drawing.Point(13, 13);
            this.pbRaceTrack.Name = "pbRaceTrack";
            this.pbRaceTrack.Size = new System.Drawing.Size(600, 200);
            this.pbRaceTrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRaceTrack.TabIndex = 0;
            this.pbRaceTrack.TabStop = false;
            // 
            // pbDog1
            // 
            this.pbDog1.Image = global::SE12_Week2_Lab_ADayAtTheRaces.Properties.Resources.dog;
            this.pbDog1.Location = new System.Drawing.Point(30, 22);
            this.pbDog1.Name = "pbDog1";
            this.pbDog1.Size = new System.Drawing.Size(75, 20);
            this.pbDog1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDog1.TabIndex = 1;
            this.pbDog1.TabStop = false;
            // 
            // pbDog2
            // 
            this.pbDog2.Image = global::SE12_Week2_Lab_ADayAtTheRaces.Properties.Resources.dog;
            this.pbDog2.Location = new System.Drawing.Point(30, 71);
            this.pbDog2.Name = "pbDog2";
            this.pbDog2.Size = new System.Drawing.Size(75, 20);
            this.pbDog2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDog2.TabIndex = 2;
            this.pbDog2.TabStop = false;
            // 
            // pbDog3
            // 
            this.pbDog3.Image = global::SE12_Week2_Lab_ADayAtTheRaces.Properties.Resources.dog;
            this.pbDog3.Location = new System.Drawing.Point(30, 125);
            this.pbDog3.Name = "pbDog3";
            this.pbDog3.Size = new System.Drawing.Size(75, 20);
            this.pbDog3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDog3.TabIndex = 3;
            this.pbDog3.TabStop = false;
            // 
            // pbDog4
            // 
            this.pbDog4.Image = global::SE12_Week2_Lab_ADayAtTheRaces.Properties.Resources.dog;
            this.pbDog4.Location = new System.Drawing.Point(30, 177);
            this.pbDog4.Name = "pbDog4";
            this.pbDog4.Size = new System.Drawing.Size(75, 20);
            this.pbDog4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDog4.TabIndex = 4;
            this.pbDog4.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bRace);
            this.groupBox1.Controls.Add(this.numDogs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numBucks);
            this.groupBox1.Controls.Add(this.bBet);
            this.groupBox1.Controls.Add(this.lCurrentBidder);
            this.groupBox1.Controls.Add(this.lAlsBet);
            this.groupBox1.Controls.Add(this.lBobsBet);
            this.groupBox1.Controls.Add(this.lJoesBet);
            this.groupBox1.Controls.Add(this.rbAl);
            this.groupBox1.Controls.Add(this.rbBob);
            this.groupBox1.Controls.Add(this.rbJoe);
            this.groupBox1.Controls.Add(this.lBets);
            this.groupBox1.Controls.Add(this.lMinimumBet);
            this.groupBox1.Location = new System.Drawing.Point(12, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 158);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Betting Parlor";
            // 
            // bRace
            // 
            this.bRace.Location = new System.Drawing.Point(520, 126);
            this.bRace.Name = "bRace";
            this.bRace.Size = new System.Drawing.Size(75, 23);
            this.bRace.TabIndex = 13;
            this.bRace.Text = "Race!";
            this.bRace.UseVisualStyleBackColor = true;
            this.bRace.Click += new System.EventHandler(this.bRace_Click);
            // 
            // numDogs
            // 
            this.numDogs.Location = new System.Drawing.Point(339, 129);
            this.numDogs.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numDogs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDogs.Name = "numDogs";
            this.numDogs.Size = new System.Drawing.Size(70, 20);
            this.numDogs.TabIndex = 12;
            this.numDogs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "bucks on dog number";
            // 
            // numBucks
            // 
            this.numBucks.Location = new System.Drawing.Point(147, 129);
            this.numBucks.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numBucks.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numBucks.Name = "numBucks";
            this.numBucks.Size = new System.Drawing.Size(70, 20);
            this.numBucks.TabIndex = 10;
            this.numBucks.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // bBet
            // 
            this.bBet.Location = new System.Drawing.Point(66, 126);
            this.bBet.Name = "bBet";
            this.bBet.Size = new System.Drawing.Size(75, 23);
            this.bBet.TabIndex = 9;
            this.bBet.Text = "Bets";
            this.bBet.UseVisualStyleBackColor = true;
            this.bBet.Click += new System.EventHandler(this.bBet_Click);
            // 
            // lCurrentBidder
            // 
            this.lCurrentBidder.AutoSize = true;
            this.lCurrentBidder.Location = new System.Drawing.Point(15, 131);
            this.lCurrentBidder.Name = "lCurrentBidder";
            this.lCurrentBidder.Size = new System.Drawing.Size(24, 13);
            this.lCurrentBidder.TabIndex = 8;
            this.lCurrentBidder.Text = "Joe";
            // 
            // lAlsBet
            // 
            this.lAlsBet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lAlsBet.Location = new System.Drawing.Point(339, 94);
            this.lAlsBet.Name = "lAlsBet";
            this.lAlsBet.Size = new System.Drawing.Size(256, 17);
            this.lAlsBet.TabIndex = 7;
            this.lAlsBet.Text = "Al hasn\'t placed a bet";
            // 
            // lBobsBet
            // 
            this.lBobsBet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lBobsBet.Location = new System.Drawing.Point(339, 71);
            this.lBobsBet.Name = "lBobsBet";
            this.lBobsBet.Size = new System.Drawing.Size(256, 17);
            this.lBobsBet.TabIndex = 6;
            this.lBobsBet.Text = "Bob hasn\'t placed a bet";
            // 
            // lJoesBet
            // 
            this.lJoesBet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lJoesBet.Location = new System.Drawing.Point(339, 48);
            this.lJoesBet.Name = "lJoesBet";
            this.lJoesBet.Size = new System.Drawing.Size(256, 17);
            this.lJoesBet.TabIndex = 5;
            this.lJoesBet.Text = "Joe hasn\'t placed a bet";
            // 
            // rbAl
            // 
            this.rbAl.AutoSize = true;
            this.rbAl.Location = new System.Drawing.Point(18, 94);
            this.rbAl.Name = "rbAl";
            this.rbAl.Size = new System.Drawing.Size(104, 17);
            this.rbAl.TabIndex = 4;
            this.rbAl.TabStop = true;
            this.rbAl.Text = "Al has 45 bucks.";
            this.rbAl.UseVisualStyleBackColor = true;
            this.rbAl.CheckedChanged += new System.EventHandler(this.rbAl_CheckedChanged);
            // 
            // rbBob
            // 
            this.rbBob.AutoSize = true;
            this.rbBob.Location = new System.Drawing.Point(18, 71);
            this.rbBob.Name = "rbBob";
            this.rbBob.Size = new System.Drawing.Size(114, 17);
            this.rbBob.TabIndex = 3;
            this.rbBob.TabStop = true;
            this.rbBob.Text = "Bob has 75 bucks.";
            this.rbBob.UseVisualStyleBackColor = true;
            this.rbBob.CheckedChanged += new System.EventHandler(this.rbBob_CheckedChanged);
            // 
            // rbJoe
            // 
            this.rbJoe.AutoSize = true;
            this.rbJoe.Location = new System.Drawing.Point(19, 48);
            this.rbJoe.Name = "rbJoe";
            this.rbJoe.Size = new System.Drawing.Size(112, 17);
            this.rbJoe.TabIndex = 2;
            this.rbJoe.TabStop = true;
            this.rbJoe.Text = "Joe has 50 bucks.";
            this.rbJoe.UseVisualStyleBackColor = true;
            this.rbJoe.CheckedChanged += new System.EventHandler(this.rbJoe_CheckedChanged);
            // 
            // lBets
            // 
            this.lBets.AutoSize = true;
            this.lBets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBets.Location = new System.Drawing.Point(335, 25);
            this.lBets.Name = "lBets";
            this.lBets.Size = new System.Drawing.Size(46, 20);
            this.lBets.TabIndex = 1;
            this.lBets.Text = "Bets";
            // 
            // lMinimumBet
            // 
            this.lMinimumBet.AutoSize = true;
            this.lMinimumBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMinimumBet.Location = new System.Drawing.Point(15, 25);
            this.lMinimumBet.Name = "lMinimumBet";
            this.lMinimumBet.Size = new System.Drawing.Size(110, 20);
            this.lMinimumBet.TabIndex = 0;
            this.lMinimumBet.Text = "Minimum bet";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 384);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbDog4);
            this.Controls.Add(this.pbDog3);
            this.Controls.Add(this.pbDog2);
            this.Controls.Add(this.pbDog1);
            this.Controls.Add(this.pbRaceTrack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbRaceTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDog2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDog3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDog4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRaceTrack;
        private System.Windows.Forms.PictureBox pbDog1;
        private System.Windows.Forms.PictureBox pbDog2;
        private System.Windows.Forms.PictureBox pbDog3;
        private System.Windows.Forms.PictureBox pbDog4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bRace;
        private System.Windows.Forms.NumericUpDown numDogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numBucks;
        private System.Windows.Forms.Button bBet;
        private System.Windows.Forms.Label lCurrentBidder;
        private System.Windows.Forms.Label lAlsBet;
        private System.Windows.Forms.Label lBobsBet;
        private System.Windows.Forms.Label lJoesBet;
        private System.Windows.Forms.RadioButton rbAl;
        private System.Windows.Forms.RadioButton rbBob;
        private System.Windows.Forms.RadioButton rbJoe;
        private System.Windows.Forms.Label lBets;
        private System.Windows.Forms.Label lMinimumBet;
        private System.Windows.Forms.Timer timer1;
    }
}

