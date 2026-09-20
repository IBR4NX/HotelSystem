namespace Hotel
{
    partial class frmMain
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
            this.msMainMenue = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.op1 = new System.Windows.Forms.ToolStripMenuItem();
            this.للابالToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.لبابلاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.op2 = new System.Windows.Forms.ToolStripMenuItem();
            this.الحجوزاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ادارةالحجوزاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.op3 = new System.Windows.Forms.ToolStripMenuItem();
            this.op4 = new System.Windows.Forms.ToolStripMenuItem();
            this.op5 = new System.Windows.Forms.ToolStripMenuItem();
            this.op6 = new System.Windows.Forms.ToolStripMenuItem();
            this.op7 = new System.Windows.Forms.ToolStripMenuItem();
            this.op8 = new System.Windows.Forms.ToolStripMenuItem();
            this.الحسابToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.معلوماتالمستخدمالحاليةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تغييركلمةالمرورToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تسجيلالخروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userControl11 = new Hotel.UserControl1();
            this.msMainMenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenue
            // 
            this.msMainMenue.BackColor = System.Drawing.Color.White;
            this.msMainMenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMainMenue.ImageScalingSize = new System.Drawing.Size(10, 20);
            this.msMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.op1,
            this.op2,
            this.op3,
            this.op4,
            this.op5,
            this.op6,
            this.op7,
            this.op8,
            this.الحسابToolStripMenuItem});
            this.msMainMenue.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.msMainMenue.Location = new System.Drawing.Point(0, 0);
            this.msMainMenue.Name = "msMainMenue";
            this.msMainMenue.Size = new System.Drawing.Size(1924, 72);
            this.msMainMenue.TabIndex = 2;
            this.msMainMenue.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 4);
            // 
            // op1
            // 
            this.op1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.للابالToolStripMenuItem,
            this.لبابلاToolStripMenuItem});
            this.op1.Image = global::Hotel.Properties.Resources.Graphicloads_Colorful_Long_Shadow_Group_48;
            this.op1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.op1.Name = "op1";
            this.op1.Size = new System.Drawing.Size(119, 52);
            this.op1.Text = "النزلاء";
            this.op1.Click += new System.EventHandler(this.op1_Click);
            // 
            // للابالToolStripMenuItem
            // 
            this.للابالToolStripMenuItem.Name = "للابالToolStripMenuItem";
            this.للابالToolStripMenuItem.Size = new System.Drawing.Size(142, 32);
            this.للابالToolStripMenuItem.Text = "للابال";
            // 
            // لبابلاToolStripMenuItem
            // 
            this.لبابلاToolStripMenuItem.Name = "لبابلاToolStripMenuItem";
            this.لبابلاToolStripMenuItem.Size = new System.Drawing.Size(142, 32);
            this.لبابلاToolStripMenuItem.Text = "لبابلا";
            // 
            // op2
            // 
            this.op2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.الحجوزاتToolStripMenuItem,
            this.ادارةالحجوزاتToolStripMenuItem});
            this.op2.Image = global::Hotel.Properties.Resources.reservation__1_;
            this.op2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.op2.Name = "op2";
            this.op2.Size = new System.Drawing.Size(165, 68);
            this.op2.Text = "الحجوزات";
            this.op2.Click += new System.EventHandler(this.op2_Click);
            // 
            // الحجوزاتToolStripMenuItem
            // 
            this.الحجوزاتToolStripMenuItem.Name = "الحجوزاتToolStripMenuItem";
            this.الحجوزاتToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.الحجوزاتToolStripMenuItem.Text = "اضافة الحجوزات ";
            this.الحجوزاتToolStripMenuItem.Click += new System.EventHandler(this.الحجوزاتToolStripMenuItem_Click);
            // 
            // ادارةالحجوزاتToolStripMenuItem
            // 
            this.ادارةالحجوزاتToolStripMenuItem.Name = "ادارةالحجوزاتToolStripMenuItem";
            this.ادارةالحجوزاتToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.ادارةالحجوزاتToolStripMenuItem.Text = "ادارة الحجوزات";
            this.ادارةالحجوزاتToolStripMenuItem.Click += new System.EventHandler(this.ادارةالحجوزاتToolStripMenuItem_Click);
            // 
            // op3
            // 
            this.op3.Image = global::Hotel.Properties.Resources.Graphicloads_Colorful_Long_Shadow_Bed_64;
            this.op3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.op3.Name = "op3";
            this.op3.Size = new System.Drawing.Size(140, 68);
            this.op3.Text = "الغرف";
            this.op3.Click += new System.EventHandler(this.op3_Click);
            // 
            // op4
            // 
            this.op4.Image = global::Hotel.Properties.Resources.billing__3_;
            this.op4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.op4.Name = "op4";
            this.op4.Size = new System.Drawing.Size(149, 68);
            this.op4.Text = "الفواتير";
            this.op4.Click += new System.EventHandler(this.op4_Click);
            // 
            // op5
            // 
            this.op5.Image = global::Hotel.Properties.Resources.invoice__1_;
            this.op5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.op5.Name = "op5";
            this.op5.Size = new System.Drawing.Size(179, 68);
            this.op5.Text = "المدفوعات";
            this.op5.Click += new System.EventHandler(this.op5_Click);
            // 
            // op6
            // 
            this.op6.Image = global::Hotel.Properties.Resources.seo_report__1_;
            this.op6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.op6.Name = "op6";
            this.op6.Size = new System.Drawing.Size(149, 68);
            this.op6.Text = "التقارير";
            this.op6.Click += new System.EventHandler(this.op6_Click);
            // 
            // op7
            // 
            this.op7.Image = global::Hotel.Properties.Resources.gear;
            this.op7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.op7.Name = "op7";
            this.op7.Size = new System.Drawing.Size(167, 68);
            this.op7.Text = "الإعدادات";
            // 
            // op8
            // 
            this.op8.Image = global::Hotel.Properties.Resources.Users_2_64;
            this.op8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.op8.Name = "op8";
            this.op8.Size = new System.Drawing.Size(192, 68);
            this.op8.Text = "المستخدمين";
            this.op8.Click += new System.EventHandler(this.op8_Click);
            // 
            // الحسابToolStripMenuItem
            // 
            this.الحسابToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.معلوماتالمستخدمالحاليةToolStripMenuItem,
            this.تغييركلمةالمرورToolStripMenuItem,
            this.تسجيلالخروجToolStripMenuItem});
            this.الحسابToolStripMenuItem.Image = global::Hotel.Properties.Resources.account_settings_64;
            this.الحسابToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.الحسابToolStripMenuItem.Name = "الحسابToolStripMenuItem";
            this.الحسابToolStripMenuItem.Size = new System.Drawing.Size(154, 68);
            this.الحسابToolStripMenuItem.Text = "الحساب";
            // 
            // معلوماتالمستخدمالحاليةToolStripMenuItem
            // 
            this.معلوماتالمستخدمالحاليةToolStripMenuItem.Image = global::Hotel.Properties.Resources.PersonDetails_32;
            this.معلوماتالمستخدمالحاليةToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.معلوماتالمستخدمالحاليةToolStripMenuItem.Name = "معلوماتالمستخدمالحاليةToolStripMenuItem";
            this.معلوماتالمستخدمالحاليةToolStripMenuItem.Size = new System.Drawing.Size(333, 38);
            this.معلوماتالمستخدمالحاليةToolStripMenuItem.Text = "معلومات المستخدم الحالية";
            this.معلوماتالمستخدمالحاليةToolStripMenuItem.Click += new System.EventHandler(this.معلوماتالمستخدمالحاليةToolStripMenuItem_Click);
            // 
            // تغييركلمةالمرورToolStripMenuItem
            // 
            this.تغييركلمةالمرورToolStripMenuItem.Image = global::Hotel.Properties.Resources.Password_32;
            this.تغييركلمةالمرورToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.تغييركلمةالمرورToolStripMenuItem.Name = "تغييركلمةالمرورToolStripMenuItem";
            this.تغييركلمةالمرورToolStripMenuItem.Size = new System.Drawing.Size(333, 38);
            this.تغييركلمةالمرورToolStripMenuItem.Text = "تغيير كلمة المرور";
            this.تغييركلمةالمرورToolStripMenuItem.Click += new System.EventHandler(this.تغييركلمةالمرورToolStripMenuItem_Click);
            // 
            // تسجيلالخروجToolStripMenuItem
            // 
            this.تسجيلالخروجToolStripMenuItem.Image = global::Hotel.Properties.Resources.sign_out_32__2;
            this.تسجيلالخروجToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.تسجيلالخروجToolStripMenuItem.Name = "تسجيلالخروجToolStripMenuItem";
            this.تسجيلالخروجToolStripMenuItem.Size = new System.Drawing.Size(333, 38);
            this.تسجيلالخروجToolStripMenuItem.Text = "تسجيل الخروج";
            this.تسجيلالخروجToolStripMenuItem.Click += new System.EventHandler(this.تسجيلالخروجToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Hotel.Properties.Resources.closeBlack32;
            this.pictureBox1.Location = new System.Drawing.Point(0, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1924, 983);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // userControl11
            // 
            this.userControl11.BackColor = System.Drawing.Color.White;
            this.userControl11.Location = new System.Drawing.Point(22, 89);
            this.userControl11.Name = "userControl11";
            this.userControl11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userControl11.Size = new System.Drawing.Size(292, 83);
            this.userControl11.TabIndex = 4;
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.msMainMenue);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msMainMenue.ResumeLayout(false);
            this.msMainMenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem op1;
        private System.Windows.Forms.ToolStripMenuItem op2;
        private System.Windows.Forms.ToolStripMenuItem op3;
        private System.Windows.Forms.ToolStripMenuItem op4;
        private System.Windows.Forms.ToolStripMenuItem op5;
        private System.Windows.Forms.ToolStripMenuItem op6;
        private System.Windows.Forms.ToolStripMenuItem op7;
        private System.Windows.Forms.ToolStripMenuItem op8;
        private System.Windows.Forms.ToolStripMenuItem الحسابToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem معلوماتالمستخدمالحاليةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تغييركلمةالمرورToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تسجيلالخروجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem الحجوزاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ادارةالحجوزاتToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UserControl1 userControl11;
        private System.Windows.Forms.ToolStripMenuItem للابالToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem لبابلاToolStripMenuItem;
    }
}