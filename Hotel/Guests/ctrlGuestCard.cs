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

namespace Hotel.Guests
{
    
    public partial class ctrlGuestCard : UserControl
    {
        public ctrlGuestCard()
        {
            InitializeComponent();
        }


        private clsGuest _Guest;

        private int _GuestID = -1;

        public int GuestID
        {
            get { return _GuestID; }
        }

        public clsGuest SelectedGuestInfo
        {
            get { return _Guest; }
        }



        //تحميل معلومات الشخص

        public void LoadGuestInfo(int GuestID)// نعرض بيانات الشخص على حسب رقمة الوطني
        {

            _Guest = clsGuest.Find(GuestID);
            _GuestID = GuestID;
            if (_Guest == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Guest with GuestID = " + GuestID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }


        public void LoadGuestInfoByIdentityNumber(string IdentityNumber)// نعرض بيانات الشخص على حسب رقمة الوطني
        {

            _Guest = clsGuest.FindByIdentityNumber(IdentityNumber);
            _GuestID = GuestID;
            if (_Guest == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Guest with GuestID = " + GuestID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }


        //   عرض البيانات
        private void _FillPersonInfo()
        {


            llEditGuestInfo.Enabled = true;
            lblGuestID.Text = _Guest.GuestID.ToString();
            lblIdentityNumber.Text = _Guest.IdentityNumber;
            lblName.Text = _Guest.FirstName + " " + _Guest.LastName;

            lblEmail.Text = _Guest.Email;
            lblPhon.Text = _Guest.Phone;
            lblAddress.Text = _Guest.Address;
            lblCreatedAt.Text = _Guest.CreatedAt.ToString("yyyy-mm-dd");

        }


        // لو البيانات مش موجوده يعمل اعاده تحميل
        public void ResetPersonInfo()
        {
            _GuestID = -1;
            lblGuestID.Text = "[????]";
            lblIdentityNumber.Text = "[????]";
            lblName.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhon.Text = "[????]";
            lblAddress.Text = "[????]";
            lblCreatedAt.Text = "[????]";
            llEditGuestInfo.Enabled = false;

        }


        //frmShowGuestInfo
        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }



        private void llEditPersonInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmAddUpdateGuest frm = new frmAddUpdateGuest(_Guest.GuestID);
            frm.DataBack += frmAddUpdateGuest_DataBack;
            frm.ShowDialog();
            //refresh
            // اعادة تحميل
            LoadGuestInfo(_GuestID);
        }
        private void frmAddUpdateGuest_DataBack(object sender, int GuestID)
        {
            LoadGuestInfo(GuestID);    
        }
    }
}
