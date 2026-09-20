namespace Hotel.Reservations
{
    partial class AddUpdateReservation
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
            this.dtbCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.dtbCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudNumberOfGuests = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numNumberOfNights = new System.Windows.Forms.NumericUpDown();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblReservationID = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCancellationReservation = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrRoomCardWithFilter1 = new Hotel.Rooms.ctrRoomCardWithFilter();
            this.ctrlGuestCardWithFilter1 = new Hotel.Guests.ctrlGuestCardWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfGuests)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfNights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtbCheckInDate
            // 
            this.dtbCheckInDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtbCheckInDate.Location = new System.Drawing.Point(38, 87);
            this.dtbCheckInDate.Name = "dtbCheckInDate";
            this.dtbCheckInDate.Size = new System.Drawing.Size(200, 28);
            this.dtbCheckInDate.TabIndex = 2;
            this.dtbCheckInDate.ValueChanged += new System.EventHandler(this.dtbCheckInDate_ValueChanged);
            // 
            // dtbCheckOutDate
            // 
            this.dtbCheckOutDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtbCheckOutDate.Location = new System.Drawing.Point(38, 134);
            this.dtbCheckOutDate.Name = "dtbCheckOutDate";
            this.dtbCheckOutDate.Size = new System.Drawing.Size(200, 28);
            this.dtbCheckOutDate.TabIndex = 167;
            this.dtbCheckOutDate.ValueChanged += new System.EventHandler(this.dtbCheckOutDate_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(352, 87);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 25);
            this.label7.TabIndex = 168;
            this.label7.Text = "تاريخ الدخول:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 170;
            this.label1.Text = "تاريخ الخروج:";
            // 
            // nudNumberOfGuests
            // 
            this.nudNumberOfGuests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudNumberOfGuests.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumberOfGuests.Location = new System.Drawing.Point(84, 180);
            this.nudNumberOfGuests.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNumberOfGuests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfGuests.Name = "nudNumberOfGuests";
            this.nudNumberOfGuests.Size = new System.Drawing.Size(157, 24);
            this.nudNumberOfGuests.TabIndex = 174;
            this.nudNumberOfGuests.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfGuests.ValueChanged += new System.EventHandler(this.nudNumberOfGuests_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(367, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 172;
            this.label3.Text = "عدد النزلاء:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 272);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 25);
            this.label2.TabIndex = 175;
            this.label2.Text = "السعر الاجمالي للحجز:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(148, 271);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(74, 25);
            this.lblTotalAmount.TabIndex = 177;
            this.lblTotalAmount.Text = "[????]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numNumberOfNights);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblReservationID);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.cmbPaymentStatus);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lblTotalAmount);
            this.groupBox1.Controls.Add(this.dtbCheckInDate);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.dtbCheckOutDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.nudNumberOfGuests);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(900, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 375);
            this.groupBox1.TabIndex = 178;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات  الحجز";
            // 
            // numNumberOfNights
            // 
            this.numNumberOfNights.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numNumberOfNights.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNumberOfNights.Location = new System.Drawing.Point(84, 221);
            this.numNumberOfNights.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numNumberOfNights.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumberOfNights.Name = "numNumberOfNights";
            this.numNumberOfNights.Size = new System.Drawing.Size(157, 24);
            this.numNumberOfNights.TabIndex = 193;
            this.numNumberOfNights.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumberOfNights.ValueChanged += new System.EventHandler(this.numNumberOfNights_ValueChanged);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Hotel.Properties.Resources.Number_32;
            this.pictureBox7.Location = new System.Drawing.Point(256, 216);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(31, 26);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 192;
            this.pictureBox7.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(367, 217);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 191;
            this.label6.Text = "عدد الليالي:";
            // 
            // lblReservationID
            // 
            this.lblReservationID.AutoSize = true;
            this.lblReservationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationID.ForeColor = System.Drawing.Color.Red;
            this.lblReservationID.Location = new System.Drawing.Point(148, 45);
            this.lblReservationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReservationID.Name = "lblReservationID";
            this.lblReservationID.Size = new System.Drawing.Size(74, 25);
            this.lblReservationID.TabIndex = 190;
            this.lblReservationID.Text = "[????]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Hotel.Properties.Resources.Calendar_32;
            this.pictureBox5.Location = new System.Drawing.Point(256, 44);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 26);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 189;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(352, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 188;
            this.label5.Text = "رقم الحجز:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(369, 326);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 187;
            this.label4.Text = "طرقة الدفع";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Hotel.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(256, 326);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 186;
            this.pictureBox4.TabStop = false;
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Items.AddRange(new object[] {
            "Cash",
            "Credit Card",
            "Online"});
            this.cmbPaymentStatus.Location = new System.Drawing.Point(63, 322);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(167, 29);
            this.cmbPaymentStatus.TabIndex = 185;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hotel.Properties.Resources.Calendar_32;
            this.pictureBox1.Location = new System.Drawing.Point(256, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 171;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Hotel.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(256, 272);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 176;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Hotel.Properties.Resources.Calendar_32;
            this.pictureBox6.Location = new System.Drawing.Point(256, 86);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(31, 26);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 169;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Hotel.Properties.Resources.Number_32;
            this.pictureBox2.Location = new System.Drawing.Point(256, 179);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 173;
            this.pictureBox2.TabStop = false;
            // 
            // btnCancellationReservation
            // 
            this.btnCancellationReservation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancellationReservation.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancellationReservation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancellationReservation.Location = new System.Drawing.Point(1167, 554);
            this.btnCancellationReservation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancellationReservation.Name = "btnCancellationReservation";
            this.btnCancellationReservation.Size = new System.Drawing.Size(194, 47);
            this.btnCancellationReservation.TabIndex = 184;
            this.btnCancellationReservation.Text = "الغاء الحجز";
            this.btnCancellationReservation.UseVisualStyleBackColor = true;
            this.btnCancellationReservation.Visible = false;
            this.btnCancellationReservation.Click += new System.EventHandler(this.btnCancellationReservation_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1395, 108);
            this.lblTitle.TabIndex = 185;
            this.lblTitle.Text = "اضافة حجز";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Enabled = false;
            this.btnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInvoice.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.Image = global::Hotel.Properties.Resources.Retake_Test_32;
            this.btnInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.Location = new System.Drawing.Point(1033, 494);
            this.btnInvoice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(126, 50);
            this.btnInvoice.TabIndex = 183;
            this.btnInvoice.Text = "الفاتورة";
            this.btnInvoice.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheckOut.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.Image = global::Hotel.Properties.Resources.Sign_Out_32;
            this.btnCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckOut.Location = new System.Drawing.Point(1167, 494);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(197, 50);
            this.btnCheckOut.TabIndex = 180;
            this.btnCheckOut.Text = "تسجيل المغادرة";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Visible = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Hotel.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1061, 631);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 179;
            this.btnClose.Text = "اغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Hotel.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1197, 631);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 178;
            this.btnSave.Text = "حجز";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrRoomCardWithFilter1
            // 
            this.ctrRoomCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrRoomCardWithFilter1.Location = new System.Drawing.Point(50, 462);
            this.ctrRoomCardWithFilter1.Name = "ctrRoomCardWithFilter1";
            this.ctrRoomCardWithFilter1.Size = new System.Drawing.Size(775, 476);
            this.ctrRoomCardWithFilter1.TabIndex = 186;
            this.ctrRoomCardWithFilter1.OnRoomSelected += new System.Action<int>(this.ctrRoomCardWithFilter1_OnRoomSelected);
            // 
            // ctrlGuestCardWithFilter1
            // 
            this.ctrlGuestCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlGuestCardWithFilter1.Location = new System.Drawing.Point(12, 105);
            this.ctrlGuestCardWithFilter1.Name = "ctrlGuestCardWithFilter1";
            this.ctrlGuestCardWithFilter1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlGuestCardWithFilter1.Size = new System.Drawing.Size(882, 351);
            this.ctrlGuestCardWithFilter1.TabIndex = 179;
            this.ctrlGuestCardWithFilter1.OnGuestSelected += new System.Action<int>(this.ctrlGuestCardWithFilter1_OnGuestSelected);
            // 
            // AddUpdateReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1395, 1038);
            this.Controls.Add(this.ctrRoomCardWithFilter1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancellationReservation);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlGuestCardWithFilter1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddUpdateReservation";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "AddUpdateReservation";
            this.Load += new System.EventHandler(this.AddUpdateReservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfGuests)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfNights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtbCheckInDate;
        private System.Windows.Forms.DateTimePicker dtbCheckOutDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown nudNumberOfGuests;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guests.ctrlGuestCardWithFilter ctrlGuestCardWithFilter1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnCancellationReservation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReservationID;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private Rooms.ctrRoomCardWithFilter ctrRoomCardWithFilter1;
        private System.Windows.Forms.NumericUpDown numNumberOfNights;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label6;
        //   private Rooms.ctrlRoomCardWithFilter ctrlRoomCardWithFilter1;
        //  private Rooms.ctrlRoomCardWithFilter ctrlRoomCardWithFilter2;
    }
}