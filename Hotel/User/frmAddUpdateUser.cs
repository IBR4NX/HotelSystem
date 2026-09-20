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
    public partial class frmAddUpdateUser : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersenID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;
        clsUser _User;
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "إضافة مستخدم جديد";
                this.Text = "إضافة مستخدم جديد";
                _User = new clsUser();


            }
            else
            {
                lblTitle.Text = "تحديث المستخدم";
                this.Text = "تحديث المستخدم";

                btnSave.Enabled = true;


            }

            // txtUserName.Text = "";
            //txtPassword.Text = "";
            // txtConfirmPassword.Text = "";
            // chkIsActive.Checked = true;


        }

        private void _LoadData()
        {

             _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.Username;
            txtPassword.Text = _User.PasswordHash;
            txtConfirmPassword.Text = _User.PasswordHash;
            txtFirstName.Text = _User.FirstName;
            txtLestName.Text = _User.LastName;
            txtEmail.Text = _User.Email;
            comboBox1.Text = _User.Role;
            chkIsActive.Checked = _User.IsActive;
            //  ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);// عرض البيانات
        }


        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            comboBox1.SelectedIndex = 0;
            if(_Mode == enMode.Update) 
                _LoadData();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "لا يمكن أن يكون اسم المستخدم فارغًا");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            };


            if (_Mode == enMode.AddNew)
            {
                // لو كان المستخدم موجود بالفعل

                if (clsUser.isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "اسم المستخدم يستخدمه مستخدم آخر");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                };
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.Username != txtUserName.Text.Trim())
                {
                    if (clsUser.isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "اسم المستخدم يستخدمه مستخدم آخر");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    };

                }
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "لا يمكن أن تكون كلمة المرور فارغة");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "تأكيد كلمة المرور لا يتطابق مع كلمة المرور!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "لا يمكن أن يكون حقل الاسم الاول فارغا");
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            };
        }

        private void txtLestName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLestName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLestName, "لا يمكن أن يكون حقل الاسم الثاني فارغا");
            }
            else
            {
                errorProvider1.SetError(txtLestName, null);
            };
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "لا يمكن أن يكون حقل البريد الاكتروني فارغا");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.Username = txtUserName.Text.Trim();
            _User.PasswordHash = txtPassword.Text.Trim();
            _User.FirstName = txtFirstName.Text.Trim();
            _User.LastName = txtLestName.Text.Trim();
            _User.Email = txtEmail.Text.Trim();
            _User.Role = comboBox1.Text.Trim();
        
            _User.IsActive = chkIsActive.Checked;


            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "تحديث المستخدم";
                this.Text = "تحديث المستخدم";

                MessageBox.Show("تم حفظ البيانات بنجاح.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("خطأ: لم يتم حفظ البيانات بنجاح.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _UserID);
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
