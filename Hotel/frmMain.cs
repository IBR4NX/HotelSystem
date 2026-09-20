using Hotel.Global_Classes;
using Hotel.Guests;
using Hotel.Invoices;
using Hotel.Payments;
using Hotel.Reservations;
using Hotel.Rooms;
using Hotel.User;
using HotelManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(clsGlobal.CurrentUser.Role == "Admin")
            {
                return;
            }
            else
            {
                op5.Visible = false;
                op6.Visible = false;
                op7.Visible = false;
                op8.Visible = false;
               
            }
        }

        private void op8_Click(object sender, EventArgs e)
        {
            frmListUsers frmListUsers = new frmListUsers();
            frmListUsers.ShowDialog();
        }

        private void معلوماتالمستخدمالحاليةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void تغييركلمةالمرورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();// اطهر صفحه الوجين

            this.Close();
        }

        private void op3_Click(object sender, EventArgs e)
        {
            frmListRooms frm = new frmListRooms();
            frm.ShowDialog();
        }

        private void op2_Click(object sender, EventArgs e)
        {
 
        }

        private void op1_Click(object sender, EventArgs e)
        {
            frmListGuests frm = new frmListGuests();
            frm.ShowDialog();
        }

  

        private void ادارةالحجوزاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListManageReservation frm = new frmListManageReservation();
            frm.ShowDialog();
        }

        private void الحجوزاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListAddReservation frm = new frmListAddReservation();
            frm.ShowDialog();
        }

        private void op4_Click(object sender, EventArgs e)
        {
            frmListInvoice frmListInvoice = new frmListInvoice();
            frmListInvoice.ShowDialog();
        }

        private void op5_Click(object sender, EventArgs e)
        {
            frmListPayments frmListPayments = new frmListPayments();
            frmListPayments.ShowDialog();
        }

        private void op6_Click(object sender, EventArgs e)
        {
            ReportForm frm = new ReportForm();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}
