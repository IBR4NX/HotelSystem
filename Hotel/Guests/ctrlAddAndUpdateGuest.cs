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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel.Guests
{
    public partial class ctrlAddAndUpdateGuest : UserControl
    {
        public event Action<int> OnAddOrUpdateGuest;
        // Create a protected method to raise the event with a parameter
        protected virtual void AddOrUpdateGuest(int GuestID)
        {
            Action<int> handler = OnAddOrUpdateGuest;
            if (handler != null)
            {
                handler(GuestID); 
            }
        }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _GuestID = -1;
        clsGuest _Guest;
        public int GuestID
        {
            get { return _GuestID; }
        }

        public clsGuest Selected_GuestInfo
        {
            get { return _Guest; }
        }
        public ctrlAddAndUpdateGuest()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }


        public void ResetDefualtValues(int GuestID)
        {
            //this will initialize the reset the defaule values

            if (GuestID == -1)
                _Mode = enMode.AddNew;
            else
            {
                _Mode = enMode.Update;
                _GuestID = GuestID;
            }

            if (_Mode == enMode.AddNew)
            {
       
                _Guest = new clsGuest();
                dtbCreatedAt.Value = DateTime.Now;
                lblGuestID.Text = "???";
                txtIdentityNumber.Text = "";
                txtFirstName.Text = "";
                txtLestName.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtPhon.Text = "";

            }
            else
            {


                _LoadData();
        
            }




        }

        private void _LoadData()
        {

            _Guest = clsGuest.Find(_GuestID);

            if (_Guest == null)
            {
                MessageBox.Show("No Guest with ID = " + _Guest, "Guest Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                

                return;
            }

            //the following code will not be executed if the person was not found
            lblGuestID.Text = _Guest.GuestID.ToString();
            txtIdentityNumber.Text = _Guest.IdentityNumber;
            txtFirstName.Text = _Guest.FirstName;
            txtLestName.Text = _Guest.LastName;
            txtEmail.Text = _Guest.Email;
            txtPhon.Text = _Guest.Phone;
            txtAddress.Text = _Guest.Address;
            dtbCreatedAt.Value = _Guest.CreatedAt;
            //  ctrlPersonCardWithFilter1.LoadPersonInfo(_Guest.PersonID);// عرض البيانات
        }


        public void Save()
        {

           if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _Guest.IdentityNumber = txtIdentityNumber.Text.Trim();
            _Guest.FirstName = txtFirstName.Text.Trim();
            _Guest.LastName = txtLestName.Text.Trim();
            _Guest.Email = txtEmail.Text.Trim();
            _Guest.Phone = txtPhon.Text.Trim();
            _Guest.Address = txtAddress.Text.Trim();
            _Guest.CreatedAt = dtbCreatedAt.Value;



            if (_Guest.Save())
            {
                lblGuestID.Text = _Guest.GuestID.ToString();
                _GuestID = _Guest.GuestID;
                //change form mode to update.
                //lblTitle.Text = "تحديث المستخدم";
                //this.Text = "تحديث المستخدم";



                if (OnAddOrUpdateGuest != null && _Mode == enMode.AddNew)
                    // Raise the event with a parameter
                    AddOrUpdateGuest(_Guest.GuestID);

                _Mode = enMode.Update;

                MessageBox.Show("تم حفظ البيانات بنجاح.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
                MessageBox.Show("خطأ: لم يتم حفظ البيانات بنجاح.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtIdentityNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdentityNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtIdentityNumber, "لا يمكن أن يكون رقم الهوية فارغًا");
                return;
            }
            else
            {
                errorProvider1.SetError(txtIdentityNumber, null);
            }

            //Make sure the national number is not used by another person
            if (txtIdentityNumber.Text.Trim() != _Guest.IdentityNumber &&  clsGuest.IsGuestExist(txtIdentityNumber.Text.Trim()) )
            {
                e.Cancel = true;
                errorProvider1.SetError(txtIdentityNumber, "رقم الهوية يستخدم لشخص آخر!");

            }
            else
            {
                errorProvider1.SetError(txtIdentityNumber, null);
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "لا يمكن أن يكون الاسم الول فارغًا");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            }
        }

        private void txtLestName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLestName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLestName, "لا يمكن أن يكون الاسم الثاني فارغًا");
                return;
            }
            else
            {
                errorProvider1.SetError(txtLestName, null);
            }
        }
    }
}
