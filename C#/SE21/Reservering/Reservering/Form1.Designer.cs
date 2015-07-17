namespace Reservering
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
            this.btnPlaceReservation = new System.Windows.Forms.Button();
            this.btnModifyReservation = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPersons = new System.Windows.Forms.TabPage();
            this.btnConfirmPerson = new System.Windows.Forms.Button();
            this.btnRemovePerson = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.tabControlPerson = new System.Windows.Forms.TabControl();
            this.tabCampingSpot = new System.Windows.Forms.TabPage();
            this.lbSelectedCampsitePrice = new System.Windows.Forms.Label();
            this.lbSelectedCampsiteType = new System.Windows.Forms.Label();
            this.lbSelectedCampsiteNumber = new System.Windows.Forms.Label();
            this.lbSelectedCampsiteTypeText = new System.Windows.Forms.Label();
            this.lbSelectedCampsitePriceText = new System.Windows.Forms.Label();
            this.lbSelectedCampsiteNumberText = new System.Windows.Forms.Label();
            this.btnConfirmCampsite = new System.Windows.Forms.Button();
            this.lbAvailableCampsites = new System.Windows.Forms.Label();
            this.lboxAvailableCampsites = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabExtraMaterial = new System.Windows.Forms.TabPage();
            this.lbTotalPriceRentalObjects = new System.Windows.Forms.Label();
            this.lboxReservedItems = new System.Windows.Forms.ListBox();
            this.lbStock = new System.Windows.Forms.Label();
            this.lbStockText = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbPriceText = new System.Windows.Forms.Label();
            this.lboxAvailableItems = new System.Windows.Forms.ListBox();
            this.lbAmountToMove = new System.Windows.Forms.Label();
            this.lbReservedItems = new System.Windows.Forms.Label();
            this.lbAvailable = new System.Windows.Forms.Label();
            this.btnRemoveRentalObjectFromReservation = new System.Windows.Forms.Button();
            this.nudAmountToMove = new System.Windows.Forms.NumericUpDown();
            this.btnRentalObjectAddToReservation = new System.Windows.Forms.Button();
            this.tabPayment = new System.Windows.Forms.TabPage();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbRFID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabPersons.SuspendLayout();
            this.tabCampingSpot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabExtraMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountToMove)).BeginInit();
            this.tabPayment.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlaceReservation
            // 
            this.btnPlaceReservation.Location = new System.Drawing.Point(300, 141);
            this.btnPlaceReservation.Name = "btnPlaceReservation";
            this.btnPlaceReservation.Size = new System.Drawing.Size(88, 54);
            this.btnPlaceReservation.TabIndex = 0;
            this.btnPlaceReservation.Text = "Place Reservation";
            this.btnPlaceReservation.UseVisualStyleBackColor = true;
            this.btnPlaceReservation.Click += new System.EventHandler(this.btnPlaceReservation_Click);
            // 
            // btnModifyReservation
            // 
            this.btnModifyReservation.Location = new System.Drawing.Point(543, 141);
            this.btnModifyReservation.Name = "btnModifyReservation";
            this.btnModifyReservation.Size = new System.Drawing.Size(88, 54);
            this.btnModifyReservation.TabIndex = 1;
            this.btnModifyReservation.Text = "Modify Reservation";
            this.btnModifyReservation.UseVisualStyleBackColor = true;
            this.btnModifyReservation.Click += new System.EventHandler(this.btnModifyReservation_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPersons);
            this.tabControl.Controls.Add(this.tabCampingSpot);
            this.tabControl.Controls.Add(this.tabExtraMaterial);
            this.tabControl.Controls.Add(this.tabPayment);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(895, 593);
            this.tabControl.TabIndex = 2;
            this.tabControl.Visible = false;
            // 
            // tabPersons
            // 
            this.tabPersons.Controls.Add(this.btnConfirmPerson);
            this.tabPersons.Controls.Add(this.btnRemovePerson);
            this.tabPersons.Controls.Add(this.btnAddPerson);
            this.tabPersons.Controls.Add(this.tabControlPerson);
            this.tabPersons.Location = new System.Drawing.Point(4, 22);
            this.tabPersons.Name = "tabPersons";
            this.tabPersons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersons.Size = new System.Drawing.Size(887, 567);
            this.tabPersons.TabIndex = 0;
            this.tabPersons.Text = "Persons";
            this.tabPersons.UseVisualStyleBackColor = true;
            // 
            // btnConfirmPerson
            // 
            this.btnConfirmPerson.Location = new System.Drawing.Point(220, 6);
            this.btnConfirmPerson.Name = "btnConfirmPerson";
            this.btnConfirmPerson.Size = new System.Drawing.Size(124, 23);
            this.btnConfirmPerson.TabIndex = 3;
            this.btnConfirmPerson.Text = "Confirm All Persons";
            this.btnConfirmPerson.UseVisualStyleBackColor = true;
            this.btnConfirmPerson.Click += new System.EventHandler(this.btnConfirmPerson_Click);
            // 
            // btnRemovePerson
            // 
            this.btnRemovePerson.Location = new System.Drawing.Point(113, 6);
            this.btnRemovePerson.Name = "btnRemovePerson";
            this.btnRemovePerson.Size = new System.Drawing.Size(101, 23);
            this.btnRemovePerson.TabIndex = 2;
            this.btnRemovePerson.Text = "Remove Person";
            this.btnRemovePerson.UseVisualStyleBackColor = true;
            this.btnRemovePerson.Click += new System.EventHandler(this.btnRemovePerson_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(6, 6);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(101, 23);
            this.btnAddPerson.TabIndex = 1;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // tabControlPerson
            // 
            this.tabControlPerson.Location = new System.Drawing.Point(6, 35);
            this.tabControlPerson.Name = "tabControlPerson";
            this.tabControlPerson.SelectedIndex = 0;
            this.tabControlPerson.Size = new System.Drawing.Size(875, 432);
            this.tabControlPerson.TabIndex = 0;
            // 
            // tabCampingSpot
            // 
            this.tabCampingSpot.Controls.Add(this.lbSelectedCampsitePrice);
            this.tabCampingSpot.Controls.Add(this.lbSelectedCampsiteType);
            this.tabCampingSpot.Controls.Add(this.lbSelectedCampsiteNumber);
            this.tabCampingSpot.Controls.Add(this.lbSelectedCampsiteTypeText);
            this.tabCampingSpot.Controls.Add(this.lbSelectedCampsitePriceText);
            this.tabCampingSpot.Controls.Add(this.lbSelectedCampsiteNumberText);
            this.tabCampingSpot.Controls.Add(this.btnConfirmCampsite);
            this.tabCampingSpot.Controls.Add(this.lbAvailableCampsites);
            this.tabCampingSpot.Controls.Add(this.lboxAvailableCampsites);
            this.tabCampingSpot.Controls.Add(this.pictureBox1);
            this.tabCampingSpot.Location = new System.Drawing.Point(4, 22);
            this.tabCampingSpot.Name = "tabCampingSpot";
            this.tabCampingSpot.Padding = new System.Windows.Forms.Padding(3);
            this.tabCampingSpot.Size = new System.Drawing.Size(887, 567);
            this.tabCampingSpot.TabIndex = 1;
            this.tabCampingSpot.Text = "Camping Spot";
            this.tabCampingSpot.UseVisualStyleBackColor = true;
            // 
            // lbSelectedCampsitePrice
            // 
            this.lbSelectedCampsitePrice.AutoSize = true;
            this.lbSelectedCampsitePrice.Location = new System.Drawing.Point(737, 196);
            this.lbSelectedCampsitePrice.Name = "lbSelectedCampsitePrice";
            this.lbSelectedCampsitePrice.Size = new System.Drawing.Size(34, 13);
            this.lbSelectedCampsitePrice.TabIndex = 9;
            this.lbSelectedCampsitePrice.Text = "Price:";
            this.lbSelectedCampsitePrice.Visible = false;
            // 
            // lbSelectedCampsiteType
            // 
            this.lbSelectedCampsiteType.AutoSize = true;
            this.lbSelectedCampsiteType.Location = new System.Drawing.Point(737, 139);
            this.lbSelectedCampsiteType.Name = "lbSelectedCampsiteType";
            this.lbSelectedCampsiteType.Size = new System.Drawing.Size(34, 13);
            this.lbSelectedCampsiteType.TabIndex = 8;
            this.lbSelectedCampsiteType.Text = "Type:";
            this.lbSelectedCampsiteType.Visible = false;
            // 
            // lbSelectedCampsiteNumber
            // 
            this.lbSelectedCampsiteNumber.AutoSize = true;
            this.lbSelectedCampsiteNumber.Location = new System.Drawing.Point(737, 79);
            this.lbSelectedCampsiteNumber.Name = "lbSelectedCampsiteNumber";
            this.lbSelectedCampsiteNumber.Size = new System.Drawing.Size(98, 13);
            this.lbSelectedCampsiteNumber.TabIndex = 7;
            this.lbSelectedCampsiteNumber.Text = "Selected Campsite:";
            this.lbSelectedCampsiteNumber.Visible = false;
            // 
            // lbSelectedCampsiteTypeText
            // 
            this.lbSelectedCampsiteTypeText.AutoSize = true;
            this.lbSelectedCampsiteTypeText.Location = new System.Drawing.Point(737, 117);
            this.lbSelectedCampsiteTypeText.Name = "lbSelectedCampsiteTypeText";
            this.lbSelectedCampsiteTypeText.Size = new System.Drawing.Size(34, 13);
            this.lbSelectedCampsiteTypeText.TabIndex = 6;
            this.lbSelectedCampsiteTypeText.Text = "Type:";
            this.lbSelectedCampsiteTypeText.Visible = false;
            // 
            // lbSelectedCampsitePriceText
            // 
            this.lbSelectedCampsitePriceText.AutoSize = true;
            this.lbSelectedCampsitePriceText.Location = new System.Drawing.Point(737, 174);
            this.lbSelectedCampsitePriceText.Name = "lbSelectedCampsitePriceText";
            this.lbSelectedCampsitePriceText.Size = new System.Drawing.Size(34, 13);
            this.lbSelectedCampsitePriceText.TabIndex = 5;
            this.lbSelectedCampsitePriceText.Text = "Price:";
            this.lbSelectedCampsitePriceText.Visible = false;
            // 
            // lbSelectedCampsiteNumberText
            // 
            this.lbSelectedCampsiteNumberText.AutoSize = true;
            this.lbSelectedCampsiteNumberText.Location = new System.Drawing.Point(737, 57);
            this.lbSelectedCampsiteNumberText.Name = "lbSelectedCampsiteNumberText";
            this.lbSelectedCampsiteNumberText.Size = new System.Drawing.Size(98, 13);
            this.lbSelectedCampsiteNumberText.TabIndex = 4;
            this.lbSelectedCampsiteNumberText.Text = "Selected Campsite:";
            this.lbSelectedCampsiteNumberText.Visible = false;
            // 
            // btnConfirmCampsite
            // 
            this.btnConfirmCampsite.Location = new System.Drawing.Point(740, 22);
            this.btnConfirmCampsite.Name = "btnConfirmCampsite";
            this.btnConfirmCampsite.Size = new System.Drawing.Size(131, 23);
            this.btnConfirmCampsite.TabIndex = 3;
            this.btnConfirmCampsite.Text = "Confirm Campsite";
            this.btnConfirmCampsite.UseVisualStyleBackColor = true;
            this.btnConfirmCampsite.Click += new System.EventHandler(this.btnConfirmCampsite_Click);
            // 
            // lbAvailableCampsites
            // 
            this.lbAvailableCampsites.AutoSize = true;
            this.lbAvailableCampsites.Location = new System.Drawing.Point(456, 6);
            this.lbAvailableCampsites.Name = "lbAvailableCampsites";
            this.lbAvailableCampsites.Size = new System.Drawing.Size(101, 13);
            this.lbAvailableCampsites.TabIndex = 2;
            this.lbAvailableCampsites.Text = "Available Campsites";
            // 
            // lboxAvailableCampsites
            // 
            this.lboxAvailableCampsites.FormattingEnabled = true;
            this.lboxAvailableCampsites.Location = new System.Drawing.Point(455, 22);
            this.lboxAvailableCampsites.Name = "lboxAvailableCampsites";
            this.lboxAvailableCampsites.Size = new System.Drawing.Size(268, 537);
            this.lboxAvailableCampsites.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Reservering.Properties.Resources.PLATTEGROND_DE_VALKENHOF2;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(443, 558);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabExtraMaterial
            // 
            this.tabExtraMaterial.Controls.Add(this.lbTotalPriceRentalObjects);
            this.tabExtraMaterial.Controls.Add(this.lboxReservedItems);
            this.tabExtraMaterial.Controls.Add(this.lbStock);
            this.tabExtraMaterial.Controls.Add(this.lbStockText);
            this.tabExtraMaterial.Controls.Add(this.lbPrice);
            this.tabExtraMaterial.Controls.Add(this.lbPriceText);
            this.tabExtraMaterial.Controls.Add(this.lboxAvailableItems);
            this.tabExtraMaterial.Controls.Add(this.lbAmountToMove);
            this.tabExtraMaterial.Controls.Add(this.lbReservedItems);
            this.tabExtraMaterial.Controls.Add(this.lbAvailable);
            this.tabExtraMaterial.Controls.Add(this.btnRemoveRentalObjectFromReservation);
            this.tabExtraMaterial.Controls.Add(this.nudAmountToMove);
            this.tabExtraMaterial.Controls.Add(this.btnRentalObjectAddToReservation);
            this.tabExtraMaterial.Location = new System.Drawing.Point(4, 22);
            this.tabExtraMaterial.Name = "tabExtraMaterial";
            this.tabExtraMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtraMaterial.Size = new System.Drawing.Size(887, 567);
            this.tabExtraMaterial.TabIndex = 2;
            this.tabExtraMaterial.Text = "Extra Material";
            this.tabExtraMaterial.UseVisualStyleBackColor = true;
            // 
            // lbTotalPriceRentalObjects
            // 
            this.lbTotalPriceRentalObjects.AutoSize = true;
            this.lbTotalPriceRentalObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPriceRentalObjects.Location = new System.Drawing.Point(501, 454);
            this.lbTotalPriceRentalObjects.Name = "lbTotalPriceRentalObjects";
            this.lbTotalPriceRentalObjects.Size = new System.Drawing.Size(328, 25);
            this.lbTotalPriceRentalObjects.TabIndex = 16;
            this.lbTotalPriceRentalObjects.Text = "Total Price Rental Objects: €0.00";
            // 
            // lboxReservedItems
            // 
            this.lboxReservedItems.FormattingEnabled = true;
            this.lboxReservedItems.Location = new System.Drawing.Point(506, 22);
            this.lboxReservedItems.Name = "lboxReservedItems";
            this.lboxReservedItems.Size = new System.Drawing.Size(360, 420);
            this.lboxReservedItems.TabIndex = 15;
            this.lboxReservedItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lboxReservedItems_MouseClick);
            this.lboxReservedItems.SelectedIndexChanged += new System.EventHandler(this.lboxReservedItems_SelectedIndexChanged);
            // 
            // lbStock
            // 
            this.lbStock.AutoSize = true;
            this.lbStock.Location = new System.Drawing.Point(400, 74);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(0, 13);
            this.lbStock.TabIndex = 14;
            // 
            // lbStockText
            // 
            this.lbStockText.AutoSize = true;
            this.lbStockText.Location = new System.Drawing.Point(400, 57);
            this.lbStockText.Name = "lbStockText";
            this.lbStockText.Size = new System.Drawing.Size(35, 13);
            this.lbStockText.TabIndex = 13;
            this.lbStockText.Text = "Stock";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(400, 35);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(0, 13);
            this.lbPrice.TabIndex = 12;
            // 
            // lbPriceText
            // 
            this.lbPriceText.AutoSize = true;
            this.lbPriceText.Location = new System.Drawing.Point(400, 22);
            this.lbPriceText.Name = "lbPriceText";
            this.lbPriceText.Size = new System.Drawing.Size(73, 13);
            this.lbPriceText.TabIndex = 11;
            this.lbPriceText.Text = "Price Per Item";
            // 
            // lboxAvailableItems
            // 
            this.lboxAvailableItems.FormattingEnabled = true;
            this.lboxAvailableItems.Location = new System.Drawing.Point(15, 22);
            this.lboxAvailableItems.Name = "lboxAvailableItems";
            this.lboxAvailableItems.Size = new System.Drawing.Size(360, 420);
            this.lboxAvailableItems.TabIndex = 10;
            this.lboxAvailableItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lboxAvailableItems_MouseClick);
            this.lboxAvailableItems.SelectedIndexChanged += new System.EventHandler(this.lboxAvailableItems_SelectedIndexChanged);
            // 
            // lbAmountToMove
            // 
            this.lbAmountToMove.AutoSize = true;
            this.lbAmountToMove.Location = new System.Drawing.Point(400, 228);
            this.lbAmountToMove.Name = "lbAmountToMove";
            this.lbAmountToMove.Size = new System.Drawing.Size(82, 13);
            this.lbAmountToMove.TabIndex = 7;
            this.lbAmountToMove.Text = "Amount of items";
            // 
            // lbReservedItems
            // 
            this.lbReservedItems.AutoSize = true;
            this.lbReservedItems.Location = new System.Drawing.Point(503, 6);
            this.lbReservedItems.Name = "lbReservedItems";
            this.lbReservedItems.Size = new System.Drawing.Size(126, 13);
            this.lbReservedItems.TabIndex = 6;
            this.lbReservedItems.Text = "Reserved Items (Amount)";
            // 
            // lbAvailable
            // 
            this.lbAvailable.AutoSize = true;
            this.lbAvailable.Location = new System.Drawing.Point(12, 6);
            this.lbAvailable.Name = "lbAvailable";
            this.lbAvailable.Size = new System.Drawing.Size(78, 13);
            this.lbAvailable.TabIndex = 5;
            this.lbAvailable.Text = "Available Items";
            // 
            // btnRemoveRentalObjectFromReservation
            // 
            this.btnRemoveRentalObjectFromReservation.Location = new System.Drawing.Point(386, 172);
            this.btnRemoveRentalObjectFromReservation.Name = "btnRemoveRentalObjectFromReservation";
            this.btnRemoveRentalObjectFromReservation.Size = new System.Drawing.Size(114, 39);
            this.btnRemoveRentalObjectFromReservation.TabIndex = 4;
            this.btnRemoveRentalObjectFromReservation.Text = "Remove Selected Items From Reservation";
            this.btnRemoveRentalObjectFromReservation.UseVisualStyleBackColor = true;
            this.btnRemoveRentalObjectFromReservation.Click += new System.EventHandler(this.btnRemoveRentalObjectFromReservation_Click);
            // 
            // nudAmountToMove
            // 
            this.nudAmountToMove.Location = new System.Drawing.Point(403, 244);
            this.nudAmountToMove.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAmountToMove.Name = "nudAmountToMove";
            this.nudAmountToMove.Size = new System.Drawing.Size(79, 20);
            this.nudAmountToMove.TabIndex = 3;
            this.nudAmountToMove.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRentalObjectAddToReservation
            // 
            this.btnRentalObjectAddToReservation.Location = new System.Drawing.Point(386, 127);
            this.btnRentalObjectAddToReservation.Name = "btnRentalObjectAddToReservation";
            this.btnRentalObjectAddToReservation.Size = new System.Drawing.Size(114, 39);
            this.btnRentalObjectAddToReservation.TabIndex = 2;
            this.btnRentalObjectAddToReservation.Text = "Add Selected Item To Reservation";
            this.btnRentalObjectAddToReservation.UseVisualStyleBackColor = true;
            this.btnRentalObjectAddToReservation.Click += new System.EventHandler(this.btnAddRentalObjectToReservation_Click);
            // 
            // tabPayment
            // 
            this.tabPayment.Controls.Add(this.btnConfirm);
            this.tabPayment.Location = new System.Drawing.Point(4, 22);
            this.tabPayment.Name = "tabPayment";
            this.tabPayment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPayment.Size = new System.Drawing.Size(887, 567);
            this.tabPayment.TabIndex = 3;
            this.tabPayment.Text = "Payment";
            this.tabPayment.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(6, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(147, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm Reservstion";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(77, 40);
            this.tbPassword.MaxLength = 15;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // tbRFID
            // 
            this.tbRFID.Location = new System.Drawing.Point(77, 14);
            this.tbRFID.Name = "tbRFID";
            this.tbRFID.Size = new System.Drawing.Size(100, 20);
            this.tbRFID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "RFID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(77, 66);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.tbRFID);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.tbPassword);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Location = new System.Drawing.Point(374, 113);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(189, 100);
            this.panelLogin.TabIndex = 8;
            this.panelLogin.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 617);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.btnModifyReservation);
            this.Controls.Add(this.btnPlaceReservation);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabPersons.ResumeLayout(false);
            this.tabCampingSpot.ResumeLayout(false);
            this.tabCampingSpot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabExtraMaterial.ResumeLayout(false);
            this.tabExtraMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountToMove)).EndInit();
            this.tabPayment.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlaceReservation;
        private System.Windows.Forms.Button btnModifyReservation;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPersons;
        private System.Windows.Forms.TabPage tabCampingSpot;
        private System.Windows.Forms.TabControl tabControlPerson;
        private System.Windows.Forms.TabPage tabExtraMaterial;
        private System.Windows.Forms.TabPage tabPayment;
        private System.Windows.Forms.Button btnRemovePerson;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnConfirmPerson;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRemoveRentalObjectFromReservation;
        private System.Windows.Forms.NumericUpDown nudAmountToMove;
        private System.Windows.Forms.Button btnRentalObjectAddToReservation;
        private System.Windows.Forms.Label lbReservedItems;
        private System.Windows.Forms.Label lbAvailable;
        private System.Windows.Forms.Label lbAmountToMove;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbPriceText;
        private System.Windows.Forms.ListBox lboxAvailableItems;
        private System.Windows.Forms.Label lbStock;
        private System.Windows.Forms.Label lbStockText;
        private System.Windows.Forms.ListBox lboxReservedItems;
        private System.Windows.Forms.Label lbTotalPriceRentalObjects;
        private System.Windows.Forms.ListBox lboxAvailableCampsites;
        private System.Windows.Forms.Label lbAvailableCampsites;
        private System.Windows.Forms.Button btnConfirmCampsite;
        private System.Windows.Forms.Label lbSelectedCampsitePrice;
        private System.Windows.Forms.Label lbSelectedCampsiteType;
        private System.Windows.Forms.Label lbSelectedCampsiteNumber;
        private System.Windows.Forms.Label lbSelectedCampsiteTypeText;
        private System.Windows.Forms.Label lbSelectedCampsitePriceText;
        private System.Windows.Forms.Label lbSelectedCampsiteNumberText;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbRFID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panelLogin;
    }
}

