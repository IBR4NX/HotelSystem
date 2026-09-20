using Hotel.Properties;
using Hotel_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.User
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private clsUser _User;

        private int _UserID = -1;

        public int UserID
        {
            get { return _UserID; }
        }

        public clsUser SelectedUserInfo
        {
            get { return _User; }
        }
      

        //تحميل معلومات الشخص

        public void LoadUserInfo(int UserID)// نعرض بيانات الشخص على حسب رقمة الوطني
        {

            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

      

   

        //   عرض البيانات
        private void _FillPersonInfo()
        {
            _UserID = _User.UserID;
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.Username;
            lblName.Text = _User.FirstName + " " + _User.LastName;
            lblEmail.Text = _User.Email;
            lblRole.Text = _User.Role;
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";


        }


        // لو البيانات مش موجوده يعمل اعاده تحميل
        public void ResetPersonInfo()
        {
            _UserID = -1;
             lblUserID.Text = "[????]";
             lblUserName.Text = "[????]";
             lblUserID.Text = "[????]";
             lblEmail.Text = "[????]";
             lblRole.Text = "[????]";
            lblIsActive.Text = "[????]";

        }

 

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(_UserID);
            frm.DataBack += frmAddUpdateUser_DataBack;
            frm.ShowDialog();

            //refresh
            // اعادة تحميل
            LoadUserInfo(_UserID);
        }

        private void frmAddUpdateUser_DataBack(object sender, int UserID)
        {
            LoadUserInfo(UserID);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
