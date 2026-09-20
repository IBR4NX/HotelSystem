using Hotel_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Hotel.Guests
{
    public partial class frmListGuests : Form
    {
        private DataTable _dtAllGuests;
        public frmListGuests()
        {
            InitializeComponent();
        }

        private void frmListGuests_Load(object sender, EventArgs e)
        {
            _dtAllGuests = clsGuest.GetAllGuests();
            dgvGuests.DataSource = _dtAllGuests;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvGuests.Rows.Count.ToString();

            if (dgvGuests.Rows.Count > 0)
            {
      
                dgvGuests.Columns[0].HeaderText = "Guest ID";
                dgvGuests.Columns[0].Width = 110;

                dgvGuests.Columns[1].HeaderText = "Identity Number";
                dgvGuests.Columns[1].Width = 250;

                dgvGuests.Columns[2].HeaderText = "Name";
                dgvGuests.Columns[2].Width = 250;

                dgvGuests.Columns[3].HeaderText = "Email";
                dgvGuests.Columns[3].Width = 200;

                dgvGuests.Columns[4].HeaderText = "Phone";
                dgvGuests.Columns[4].Width = 120;

                dgvGuests.Columns[5].HeaderText = "Address";
                dgvGuests.Columns[5].Width = 120;

                dgvGuests.Columns[6].HeaderText = "CreatedAt";
                dgvGuests.Columns[6].Width = 120;

            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "CreatedAt")
            {

                txtFilterValue.Visible = false;
                dtbDate.Visible = true;
                dtbDate.Value = DateTime.Now;

            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
              
                dtbDate.Visible = false;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
     

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Guest ID":
                    FilterColumn = "GuestID";
                    break;
                case "Identity Number":
                    FilterColumn = "IdentityNumber";
                    break;

                case "Name":
                    FilterColumn = "Name";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Address":
                    FilterColumn = "Address";
                    break;
                case "CreatedAt":
                    FilterColumn = "CreatedAt";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllGuests.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvGuests.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "Name" && FilterColumn != "Email" && FilterColumn != "Address"
                && FilterColumn != "IdentityNumber" && FilterColumn != "CreatedAt")
                //in this case we deal with numbers not string.
                _dtAllGuests.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllGuests.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllGuests.Rows.Count.ToString();
        }

        // امنعه من ادخال حروف عربي
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Guest ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateGuest frmAddUpdateGuest = new frmAddUpdateGuest();
            frmAddUpdateGuest.ShowDialog();
            frmListGuests_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateGuest frmAddUpdateGuest = new frmAddUpdateGuest((int)dgvGuests.CurrentRow.Cells[0].Value);
            frmAddUpdateGuest.ShowDialog();
            frmListGuests_Load(null, null);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateGuest frmAddUpdateGuest = new frmAddUpdateGuest();
            frmAddUpdateGuest.ShowDialog();
            frmListGuests_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int GuesID = (int)dgvGuests.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("هل أنت متأكد أنك تريد حذف معرف النزيل = [" + GuesID + "]", "تأكيد الحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsGuest.DeleteGuest(GuesID))
                {
                    MessageBox.Show("تم حذف النزيل بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListGuests_Load(null, null);
                }

                else
                    MessageBox.Show("لا يتم حذف النزيل بسبب البيانات المرتبطة به.", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowGuestInfo frm = new frmShowGuestInfo((int)dgvGuests.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListGuests_Load(null, null);

        }

        private void dtbDate_ValueChanged(object sender, EventArgs e)
        {
            string FilterColumn = "CreatedAt";
            string FilterValue = dtbDate.Value.ToString("yyyy-MM-dd");
            // استخدم علامات الاقتباس حول القيمة النصية
            _dtAllGuests.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);


            lblRecordsCount.Text = _dtAllGuests.Rows.Count.ToString();
        }
    }
}
