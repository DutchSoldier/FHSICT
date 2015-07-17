namespace RentalCarAdmin
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
            this.btMaakCars = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.lbCars = new System.Windows.Forms.ListBox();
            this.btLoad = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCarKilometers = new System.Windows.Forms.Button();
            this.tbResultaat = new System.Windows.Forms.TextBox();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btHire = new System.Windows.Forms.Button();
            this.btReturnCar = new System.Windows.Forms.Button();
            this.tbKm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btMaakCars
            // 
            this.btMaakCars.Location = new System.Drawing.Point(74, 38);
            this.btMaakCars.Name = "btMaakCars";
            this.btMaakCars.Size = new System.Drawing.Size(75, 23);
            this.btMaakCars.TabIndex = 0;
            this.btMaakCars.Text = "Maak cars";
            this.btMaakCars.UseVisualStyleBackColor = true;
            this.btMaakCars.Click += new System.EventHandler(this.btMaakCars_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(74, 80);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbCars
            // 
            this.lbCars.FormattingEnabled = true;
            this.lbCars.Location = new System.Drawing.Point(247, 38);
            this.lbCars.Name = "lbCars";
            this.lbCars.Size = new System.Drawing.Size(232, 186);
            this.lbCars.TabIndex = 2;
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(74, 128);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 23);
            this.btLoad.TabIndex = 3;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(46, 239);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(48, 20);
            this.tbId.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Id";
            // 
            // btCarKilometers
            // 
            this.btCarKilometers.Location = new System.Drawing.Point(109, 236);
            this.btCarKilometers.Name = "btCarKilometers";
            this.btCarKilometers.Size = new System.Drawing.Size(113, 23);
            this.btCarKilometers.TabIndex = 6;
            this.btCarKilometers.Text = "Car Kilometers";
            this.btCarKilometers.UseVisualStyleBackColor = true;
            this.btCarKilometers.Click += new System.EventHandler(this.btCarKilometers_Click);
            // 
            // tbResultaat
            // 
            this.tbResultaat.Location = new System.Drawing.Point(247, 238);
            this.tbResultaat.Name = "tbResultaat";
            this.tbResultaat.Size = new System.Drawing.Size(100, 20);
            this.tbResultaat.TabIndex = 7;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(402, 239);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 8;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btHire
            // 
            this.btHire.Location = new System.Drawing.Point(113, 268);
            this.btHire.Name = "btHire";
            this.btHire.Size = new System.Drawing.Size(75, 23);
            this.btHire.TabIndex = 9;
            this.btHire.Text = "Hire Car";
            this.btHire.UseVisualStyleBackColor = true;
            this.btHire.Click += new System.EventHandler(this.btHire_Click);
            // 
            // btReturnCar
            // 
            this.btReturnCar.Location = new System.Drawing.Point(118, 303);
            this.btReturnCar.Name = "btReturnCar";
            this.btReturnCar.Size = new System.Drawing.Size(75, 23);
            this.btReturnCar.TabIndex = 10;
            this.btReturnCar.Text = "Return Car";
            this.btReturnCar.UseVisualStyleBackColor = true;
            this.btReturnCar.Click += new System.EventHandler(this.btReturnCar_Click);
            // 
            // tbKm
            // 
            this.tbKm.Location = new System.Drawing.Point(12, 306);
            this.tbKm.Name = "tbKm";
            this.tbKm.Size = new System.Drawing.Size(100, 20);
            this.tbKm.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "km:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 331);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbKm);
            this.Controls.Add(this.btReturnCar);
            this.Controls.Add(this.btHire);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.tbResultaat);
            this.Controls.Add(this.btCarKilometers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.lbCars);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btMaakCars);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btMaakCars;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.ListBox lbCars;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCarKilometers;
        private System.Windows.Forms.TextBox tbResultaat;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btHire;
        private System.Windows.Forms.Button btReturnCar;
        private System.Windows.Forms.TextBox tbKm;
        private System.Windows.Forms.Label label2;
    }
}

