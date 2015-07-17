namespace GiraffenApp
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
            this.btVulMetTestGegevens = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btKenVaderToe = new System.Windows.Forms.Button();
            this.btZoekOpNaam = new System.Windows.Forms.Button();
            this.btVoegToe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNaamVader = new System.Windows.Forms.TextBox();
            this.tbGeboortejaar = new System.Windows.Forms.TextBox();
            this.tbNaam = new System.Windows.Forms.TextBox();
            this.btToonMoederlijn = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.btToonStamboom = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btVulMetTestGegevens
            // 
            this.btVulMetTestGegevens.BackColor = System.Drawing.Color.Yellow;
            this.btVulMetTestGegevens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVulMetTestGegevens.Location = new System.Drawing.Point(12, 9);
            this.btVulMetTestGegevens.Name = "btVulMetTestGegevens";
            this.btVulMetTestGegevens.Size = new System.Drawing.Size(382, 35);
            this.btVulMetTestGegevens.TabIndex = 0;
            this.btVulMetTestGegevens.Text = "vul met test-gegevens";
            this.btVulMetTestGegevens.UseVisualStyleBackColor = false;
            this.btVulMetTestGegevens.Click += new System.EventHandler(this.btVulMetTestGegevens_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Moccasin;
            this.groupBox1.Controls.Add(this.btToonMoederlijn);
            this.groupBox1.Controls.Add(this.btKenVaderToe);
            this.groupBox1.Controls.Add(this.btZoekOpNaam);
            this.groupBox1.Controls.Add(this.btVoegToe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNaamVader);
            this.groupBox1.Controls.Add(this.tbGeboortejaar);
            this.groupBox1.Controls.Add(this.tbNaam);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 274);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btKenVaderToe
            // 
            this.btKenVaderToe.BackColor = System.Drawing.Color.Lime;
            this.btKenVaderToe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btKenVaderToe.Location = new System.Drawing.Point(185, 165);
            this.btKenVaderToe.Name = "btKenVaderToe";
            this.btKenVaderToe.Size = new System.Drawing.Size(163, 32);
            this.btKenVaderToe.TabIndex = 12;
            this.btKenVaderToe.Text = "Ken vader toe";
            this.btKenVaderToe.UseVisualStyleBackColor = false;
            this.btKenVaderToe.Click += new System.EventHandler(this.btKenVaderToe_Click);
            // 
            // btZoekOpNaam
            // 
            this.btZoekOpNaam.BackColor = System.Drawing.Color.Lime;
            this.btZoekOpNaam.Location = new System.Drawing.Point(119, 57);
            this.btZoekOpNaam.Name = "btZoekOpNaam";
            this.btZoekOpNaam.Size = new System.Drawing.Size(136, 37);
            this.btZoekOpNaam.TabIndex = 9;
            this.btZoekOpNaam.Text = "Zoek op naam";
            this.btZoekOpNaam.UseVisualStyleBackColor = false;
            this.btZoekOpNaam.Click += new System.EventHandler(this.btZoekOpNaam_Click);
            // 
            // btVoegToe
            // 
            this.btVoegToe.BackColor = System.Drawing.Color.Lime;
            this.btVoegToe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVoegToe.Location = new System.Drawing.Point(119, 100);
            this.btVoegToe.Name = "btVoegToe";
            this.btVoegToe.Size = new System.Drawing.Size(136, 37);
            this.btVoegToe.TabIndex = 8;
            this.btVoegToe.Text = "Voeg toe";
            this.btVoegToe.UseVisualStyleBackColor = false;
            this.btVoegToe.Click += new System.EventHandler(this.btVoegToe_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "geb. jaar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "naam";
            // 
            // tbNaamVader
            // 
            this.tbNaamVader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNaamVader.Location = new System.Drawing.Point(20, 165);
            this.tbNaamVader.Name = "tbNaamVader";
            this.tbNaamVader.Size = new System.Drawing.Size(147, 26);
            this.tbNaamVader.TabIndex = 2;
            // 
            // tbGeboortejaar
            // 
            this.tbGeboortejaar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGeboortejaar.Location = new System.Drawing.Point(311, 25);
            this.tbGeboortejaar.Name = "tbGeboortejaar";
            this.tbGeboortejaar.Size = new System.Drawing.Size(65, 26);
            this.tbGeboortejaar.TabIndex = 1;
            // 
            // tbNaam
            // 
            this.tbNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNaam.Location = new System.Drawing.Point(72, 25);
            this.tbNaam.Name = "tbNaam";
            this.tbNaam.Size = new System.Drawing.Size(126, 26);
            this.tbNaam.TabIndex = 0;
            // 
            // btToonMoederlijn
            // 
            this.btToonMoederlijn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btToonMoederlijn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btToonMoederlijn.Location = new System.Drawing.Point(21, 223);
            this.btToonMoederlijn.Name = "btToonMoederlijn";
            this.btToonMoederlijn.Size = new System.Drawing.Size(328, 37);
            this.btToonMoederlijn.TabIndex = 8;
            this.btToonMoederlijn.Text = "Toon moederlijn";
            this.btToonMoederlijn.UseVisualStyleBackColor = false;
            this.btToonMoederlijn.Click += new System.EventHandler(this.btToonMoederlijn_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.ItemHeight = 20;
            this.lbInfo.Location = new System.Drawing.Point(413, 22);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(423, 364);
            this.lbInfo.TabIndex = 3;
            // 
            // btToonStamboom
            // 
            this.btToonStamboom.BackColor = System.Drawing.Color.Lime;
            this.btToonStamboom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btToonStamboom.Location = new System.Drawing.Point(12, 50);
            this.btToonStamboom.Name = "btToonStamboom";
            this.btToonStamboom.Size = new System.Drawing.Size(382, 35);
            this.btToonStamboom.TabIndex = 4;
            this.btToonStamboom.Text = "Toon stamboom";
            this.btToonStamboom.UseVisualStyleBackColor = false;
            this.btToonStamboom.Click += new System.EventHandler(this.btToonStamboom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 463);
            this.Controls.Add(this.btToonStamboom);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btVulMetTestGegevens);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btVulMetTestGegevens;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btVoegToe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNaamVader;
        private System.Windows.Forms.TextBox tbGeboortejaar;
        private System.Windows.Forms.TextBox tbNaam;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Button btToonStamboom;
        private System.Windows.Forms.Button btToonMoederlijn;
        private System.Windows.Forms.Button btZoekOpNaam;
        private System.Windows.Forms.Button btKenVaderToe;
    }
}

