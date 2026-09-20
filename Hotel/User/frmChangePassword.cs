using Hotel.Global_Classes;
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
    public partial class frmChangePassword : Form
    {
        private int _UserID = -1;
        private clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        // اعادة تحميل
        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "لا يمكن أن تكون كلمة المرور فارغة");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            };

          //  string password = ComputeHash(txtCurrentPassword.Text.Trim());

            if (_User.PasswordHash != txtCurrentPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "كلمة المرور الحالية خاطئة!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            };
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "لا يمكن أن تكون كلمة المرور الجديدة فارغة");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            };
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "تأكيد كلمة المرور لا يتطابق مع كلمة المرور!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                //Here we dont continue becuase the form is not valid
                if (!this.ValidateChildren())
                {
                    //Here we dont continue becuase the form is not valid
                    MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _User.PasswordHash = txtNewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("تم تغيير كلمة المرور بنجاح.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCurrentPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
            else
            {
                MessageBox.Show("لقد حدث خطأ، لم يتم تغيير كلمة المرور.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("لم نتمكن من العثور على المستخدم الذي يحمل المعرف = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }
            ctrlUserCard1.LoadUserInfo(_UserID);// اعرض بيانات الكنترول
        }

        private void ctrlUserCard1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
