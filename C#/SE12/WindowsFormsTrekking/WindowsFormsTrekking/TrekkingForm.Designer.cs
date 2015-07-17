namespace WindowsFormsTrekking
{
    partial class TrekkingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrekkingForm));
            this.pTrekking = new System.Windows.Forms.PictureBox();
            this.bStop = new System.Windows.Forms.Button();
            this.bLaatzien = new System.Windows.Forms.Button();
            this.bSorteer = new System.Windows.Forms.Button();
            this.bSerie = new System.Windows.Forms.Button();
            this.bTrek = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tMaxwaarde = new System.Windows.Forms.TextBox();
            this.tAantalgewenst = new System.Windows.Forms.TextBox();
            this.lTrekking = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pTrekking)).BeginInit();
            this.SuspendLayout();
            // 
            // pTrekking
            // 
            this.pTrekking.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pTrekking.BackgroundImage")));
            this.pTrekking.InitialImage = ((System.Drawing.Image)(resources.GetObject("pTrekking.InitialImage")));
            this.pTrekking.Location = new System.Drawing.Point(12, 151);
            this.pTrekking.Name = "pTrekking";
            this.pTrekking.Size = new System.Drawing.Size(256, 256);
            this.pTrekking.TabIndex = 0;
            this.pTrekking.TabStop = false;
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(1000, 203);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 1;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bLaatzien
            // 
            this.bLaatzien.Location = new System.Drawing.Point(1000, 232);
            this.bLaatzien.Name = "bLaatzien";
            this.bLaatzien.Size = new System.Drawing.Size(75, 23);
            this.bLaatzien.TabIndex = 2;
            this.bLaatzien.Text = "Laat zien";
            this.bLaatzien.UseVisualStyleBackColor = true;
            this.bLaatzien.Click += new System.EventHandler(this.bLaatzien_Click);
            // 
            // bSorteer
            // 
            this.bSorteer.Location = new System.Drawing.Point(1000, 261);
            this.bSorteer.Name = "bSorteer";
            this.bSorteer.Size = new System.Drawing.Size(75, 23);
            this.bSorteer.TabIndex = 3;
            this.bSorteer.Text = "Sorteer";
            this.bSorteer.UseVisualStyleBackColor = true;
            this.bSorteer.Click += new System.EventHandler(this.bSorteer_Click);
            // 
            // bSerie
            // 
            this.bSerie.Location = new System.Drawing.Point(1000, 290);
            this.bSerie.Name = "bSerie";
            this.bSerie.Size = new System.Drawing.Size(75, 23);
            this.bSerie.TabIndex = 4;
            this.bSerie.Text = "Serie";
            this.bSerie.UseVisualStyleBackColor = true;
            this.bSerie.Click += new System.EventHandler(this.bSerie_Click);
            // 
            // bTrek
            // 
            this.bTrek.Location = new System.Drawing.Point(1000, 319);
            this.bTrek.Name = "bTrek";
            this.bTrek.Size = new System.Drawing.Size(75, 23);
            this.bTrek.TabIndex = 5;
            this.bTrek.Text = "Trek";
            this.bTrek.UseVisualStyleBackColor = true;
            this.bTrek.Click += new System.EventHandler(this.bTrek_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(1000, 348);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 6;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(729, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Maxwaarde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(729, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "AantalGewenst:";
            // 
            // tMaxwaarde
            // 
            this.tMaxwaarde.Location = new System.Drawing.Point(836, 325);
            this.tMaxwaarde.Name = "tMaxwaarde";
            this.tMaxwaarde.Size = new System.Drawing.Size(100, 20);
            this.tMaxwaarde.TabIndex = 9;
            this.tMaxwaarde.Text = "2";
            // 
            // tAantalgewenst
            // 
            this.tAantalgewenst.Location = new System.Drawing.Point(836, 351);
            this.tAantalgewenst.Name = "tAantalgewenst";
            this.tAantalgewenst.Size = new System.Drawing.Size(100, 20);
            this.tAantalgewenst.TabIndex = 10;
            this.tAantalgewenst.Text = "1";
            // 
            // lTrekking
            // 
            this.lTrekking.FormattingEnabled = true;
            this.lTrekking.Location = new System.Drawing.Point(12, 12);
            this.lTrekking.Name = "lTrekking";
            this.lTrekking.Size = new System.Drawing.Size(256, 108);
            this.lTrekking.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "P00.png");
            this.imageList1.Images.SetKeyName(1, "P01.png");
            this.imageList1.Images.SetKeyName(2, "P02.png");
            this.imageList1.Images.SetKeyName(3, "P03.png");
            this.imageList1.Images.SetKeyName(4, "P04.png");
            this.imageList1.Images.SetKeyName(5, "P05.png");
            this.imageList1.Images.SetKeyName(6, "P06.png");
            this.imageList1.Images.SetKeyName(7, "P07.png");
            this.imageList1.Images.SetKeyName(8, "P08.png");
            this.imageList1.Images.SetKeyName(9, "P09.png");
            this.imageList1.Images.SetKeyName(10, "P10.png");
            this.imageList1.Images.SetKeyName(11, "P11.png");
            this.imageList1.Images.SetKeyName(12, "P12.png");
            this.imageList1.Images.SetKeyName(13, "P13.png");
            this.imageList1.Images.SetKeyName(14, "P14.png");
            this.imageList1.Images.SetKeyName(15, "P15.png");
            this.imageList1.Images.SetKeyName(16, "P16.png");
            this.imageList1.Images.SetKeyName(17, "P17.png");
            this.imageList1.Images.SetKeyName(18, "P18.png");
            this.imageList1.Images.SetKeyName(19, "P19.png");
            this.imageList1.Images.SetKeyName(20, "P20.png");
            this.imageList1.Images.SetKeyName(21, "P21.png");
            this.imageList1.Images.SetKeyName(22, "P22.png");
            this.imageList1.Images.SetKeyName(23, "P23.png");
            this.imageList1.Images.SetKeyName(24, "P24.png");
            this.imageList1.Images.SetKeyName(25, "P25.png");
            this.imageList1.Images.SetKeyName(26, "P26.png");
            this.imageList1.Images.SetKeyName(27, "P27.png");
            this.imageList1.Images.SetKeyName(28, "P28.png");
            this.imageList1.Images.SetKeyName(29, "P29.png");
            this.imageList1.Images.SetKeyName(30, "P30.png");
            this.imageList1.Images.SetKeyName(31, "P31.png");
            this.imageList1.Images.SetKeyName(32, "P32.png");
            this.imageList1.Images.SetKeyName(33, "P33.png");
            this.imageList1.Images.SetKeyName(34, "P34.png");
            this.imageList1.Images.SetKeyName(35, "P35.png");
            this.imageList1.Images.SetKeyName(36, "P36.png");
            this.imageList1.Images.SetKeyName(37, "P37.png");
            this.imageList1.Images.SetKeyName(38, "P38.png");
            this.imageList1.Images.SetKeyName(39, "P39.png");
            this.imageList1.Images.SetKeyName(40, "P40.png");
            this.imageList1.Images.SetKeyName(41, "P41.png");
            this.imageList1.Images.SetKeyName(42, "P42.png");
            this.imageList1.Images.SetKeyName(43, "P43.png");
            this.imageList1.Images.SetKeyName(44, "P44.png");
            this.imageList1.Images.SetKeyName(45, "P45.png");
            this.imageList1.Images.SetKeyName(46, "P46.png");
            this.imageList1.Images.SetKeyName(47, "P47.png");
            this.imageList1.Images.SetKeyName(48, "P48.png");
            this.imageList1.Images.SetKeyName(49, "P49.png");
            this.imageList1.Images.SetKeyName(50, "P50.png");
            this.imageList1.Images.SetKeyName(51, "P51.png");
            this.imageList1.Images.SetKeyName(52, "P52.png");
            this.imageList1.Images.SetKeyName(53, "P53.png");
            this.imageList1.Images.SetKeyName(54, "P54.png");
            this.imageList1.Images.SetKeyName(55, "P55.png");
            this.imageList1.Images.SetKeyName(56, "P56.png");
            this.imageList1.Images.SetKeyName(57, "P57.png");
            this.imageList1.Images.SetKeyName(58, "P58.png");
            this.imageList1.Images.SetKeyName(59, "P59.png");
            this.imageList1.Images.SetKeyName(60, "P60.png");
            this.imageList1.Images.SetKeyName(61, "P61.png");
            this.imageList1.Images.SetKeyName(62, "P62.png");
            this.imageList1.Images.SetKeyName(63, "P63.png");
            this.imageList1.Images.SetKeyName(64, "P64.png");
            this.imageList1.Images.SetKeyName(65, "P65.png");
            this.imageList1.Images.SetKeyName(66, "P66.png");
            this.imageList1.Images.SetKeyName(67, "P67.png");
            this.imageList1.Images.SetKeyName(68, "P68.png");
            this.imageList1.Images.SetKeyName(69, "P69.png");
            this.imageList1.Images.SetKeyName(70, "P70.png");
            this.imageList1.Images.SetKeyName(71, "P71.png");
            this.imageList1.Images.SetKeyName(72, "P72.png");
            this.imageList1.Images.SetKeyName(73, "P73.png");
            this.imageList1.Images.SetKeyName(74, "P74.png");
            this.imageList1.Images.SetKeyName(75, "P75.png");
            this.imageList1.Images.SetKeyName(76, "P76.png");
            this.imageList1.Images.SetKeyName(77, "P77.png");
            this.imageList1.Images.SetKeyName(78, "P78.png");
            this.imageList1.Images.SetKeyName(79, "P79.png");
            this.imageList1.Images.SetKeyName(80, "P80.png");
            this.imageList1.Images.SetKeyName(81, "P81.png");
            this.imageList1.Images.SetKeyName(82, "P82.png");
            this.imageList1.Images.SetKeyName(83, "P83.png");
            this.imageList1.Images.SetKeyName(84, "P84.png");
            this.imageList1.Images.SetKeyName(85, "P85.png");
            this.imageList1.Images.SetKeyName(86, "P86.png");
            this.imageList1.Images.SetKeyName(87, "P87.png");
            this.imageList1.Images.SetKeyName(88, "P88.png");
            this.imageList1.Images.SetKeyName(89, "P89.png");
            this.imageList1.Images.SetKeyName(90, "P90.png");
            this.imageList1.Images.SetKeyName(91, "P91.png");
            this.imageList1.Images.SetKeyName(92, "P92.png");
            this.imageList1.Images.SetKeyName(93, "P93.png");
            this.imageList1.Images.SetKeyName(94, "P94.png");
            this.imageList1.Images.SetKeyName(95, "P95.png");
            this.imageList1.Images.SetKeyName(96, "P96.png");
            this.imageList1.Images.SetKeyName(97, "P97.png");
            this.imageList1.Images.SetKeyName(98, "P98.png");
            this.imageList1.Images.SetKeyName(99, "P99.png");
            // 
            // TrekkingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1087, 447);
            this.Controls.Add(this.lTrekking);
            this.Controls.Add(this.tAantalgewenst);
            this.Controls.Add(this.tMaxwaarde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.bTrek);
            this.Controls.Add(this.bSerie);
            this.Controls.Add(this.bSorteer);
            this.Controls.Add(this.bLaatzien);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.pTrekking);
            this.Name = "TrekkingForm";
            this.Text = "Trekking Loterij";
            ((System.ComponentModel.ISupportInitialize)(this.pTrekking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pTrekking;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bLaatzien;
        private System.Windows.Forms.Button bSorteer;
        private System.Windows.Forms.Button bSerie;
        private System.Windows.Forms.Button bTrek;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tMaxwaarde;
        private System.Windows.Forms.TextBox tAantalgewenst;
        private System.Windows.Forms.ListBox lTrekking;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

