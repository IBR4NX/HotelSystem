namespace Hotel.Reservations
{
    partial class frmListManageReservation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReservation = new System.Windows.Forms.DataGridView();
            this.cmsReservations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtbDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.userControl11 = new Hotel.UserControl1();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).BeginInit();
            this.cmsReservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "All",
            "Confirmed",
            "Cancelled",
            "Completed"});
            this.cmbStatus.Location = new System.Drawing.Point(397, 275);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(138, 24);
            this.cmbStatus.TabIndex = 122;
            this.cmbStatus.Visible = false;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(890, 208);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 53);
            this.lblTitle.TabIndex = 120;
            this.lblTitle.Text = "ادارة الحجوزات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Reservation ID",
            "Guest ID",
            "Guest Name",
            "Room ID",
            "Name Room",
            "User ID",
            "User name",
            "Check In Date",
            "Check Out Date",
            "Number Of Guests",
            "Status",
            "Created At",
            "Total Amount"});
            this.cbFilterBy.Location = new System.Drawing.Point(149, 276);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(239, 24);
            this.cbFilterBy.TabIndex = 118;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(397, 276);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(292, 22);
            this.txtFilterValue.TabIndex = 117;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 116;
            this.label1.Text = "Filter By:";
            // 
            // dgvReservation
            // 
            this.dgvReservation.AllowUserToAddRows = false;
            this.dgvReservation.AllowUserToDeleteRows = false;
            this.dgvReservation.AllowUserToResizeRows = false;
            this.dgvReservation.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservation.ContextMenuStrip = this.cmsReservations;
            this.dgvReservation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReservation.Location = new System.Drawing.Point(38, 312);
            this.dgvReservation.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvReservation.MultiSelect = false;
            this.dgvReservation.Name = "dgvReservation";
            this.dgvReservation.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservation.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReservation.RowHeadersWidth = 51;
            this.dgvReservation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservation.Size = new System.Drawing.Size(1682, 427);
            this.dgvReservation.TabIndex = 115;
            this.dgvReservation.TabStop = false;
            // 
            // cmsReservations
            // 
            this.cmsReservations.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsReservations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1});
            this.cmsReservations.Name = "contextMenuStrip1";
            this.cmsReservations.Size = new System.Drawing.Size(181, 168);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::Hotel.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(180, 38);
            this.showDetailsToolStripMenuItem.Text = "&Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Hotel.Properties.Resources.sign_add_icon1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 38);
            this.toolStripMenuItem1.Text = "Add";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Hotel.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 38);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Hotel.Properties.Resources.Delete_32_2;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 38);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(163, 789);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(21, 16);
            this.lblRecordsCount.TabIndex = 124;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 782);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 123;
            this.label2.Text = "# Records:";
            // 
            // dtbDate
            // 
            this.dtbDate.Location = new System.Drawing.Point(397, 273);
            this.dtbDate.Name = "dtbDate";
            this.dtbDate.Size = new System.Drawing.Size(228, 22);
            this.dtbDate.TabIndex = 194;
            this.dtbDate.Visible = false;
            this.dtbDate.ValueChanged += new System.EventHandler(this.dtbDate_ValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Hotel.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1566, 758);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 36);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Image = global::Hotel.Properties.Resources.hotel_bell_5698230__2_;
            this.btnAddUser.Location = new System.Drawing.Point(1595, 225);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(125, 79);
            this.btnAddUser.TabIndex = 121;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::Hotel.Properties.Resources.reservation;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(951, 14);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(251, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 119;
            this.pbPersonImage.TabStop = false;
            // 
            // userControl11
            // 
            this.userControl11.BackColor = System.Drawing.Color.White;
            this.userControl11.Location = new System.Drawing.Point(14, 14);
            this.userControl11.Name = "userControl11";
            this.userControl11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userControl11.Size = new System.Drawing.Size(334, 83);
            this.userControl11.TabIndex = 195;
            // 
            // frmListManageReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1745, 816);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.dtbDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReservation);
            this.Name = "frmListManageReservation";
            this.Text = "frmListManageReservation";
            this.Load += new System.EventHandler(this.frmListManageReservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).EndInit();
            this.cmsReservations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReservation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsReservations;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DateTimePicker dtbDate;
        private UserControl1 userControl11;
    }
}