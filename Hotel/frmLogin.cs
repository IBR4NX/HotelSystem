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
using Hotel_DataAccuss;
namespace Hotel
{
    public partial class frmLogin : Form
    {
        public frmLogin() 
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ارجعا بيانات المستخدم من خلال اسمه وكلمة السر
            clsUser user = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (user != null) 
            {
                //if (!user.db)
                //MessageBox.Show(".  فشل اتصال قاعدة البيانات تاكد من بيانات الاتصال", "  اتصال قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    if (chkRememberMe.Checked)
                {
                    //store username and password

                    // تخزين اسم المستخدم وكلمة المرور
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    // قم بتخزين اسم المستخدم وكلمة المرور الفارغين
                    clsGlobal.RememberUsernameAndPassword("", "");

                }

                //incase the user is not active
                // لو كان المستخدم مش فعال او ناشط ما يدخلة للنظام
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("حسابك غير نشط، اتصل بالمسؤول.", "في الحساب النشط", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;// حفض المستخدم الذي قام بدخول الى النظام
                this.Hide();// اخفي الفورم 
                frmMain frm = new frmMain(this);
                frm.ShowDialog();

            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show(". اسم المستخدم/كلمة المرور غير صالحة", "بيانات الاعتماد خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                clsDataAccessSettings.GetConnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            string UserName = "", Password = "";

            //اذا كان في بيانات في الملف يعبئ المتغيرات ويرجع ترو
            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
