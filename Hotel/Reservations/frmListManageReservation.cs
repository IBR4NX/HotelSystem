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

namespace Hotel.Reservations
{
    public partial class frmListManageReservation : Form
    {
        private static DataTable _dtAllReservations;

        public frmListManageReservation()
        {
            InitializeComponent();
        }

        private void frmListManageReservation_Load(object sender, EventArgs e)
        {
            _dtAllReservations = clsReservation.GetAllReservations();
            dgvReservation.DataSource = _dtAllReservations;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvReservation.Rows.Count.ToString();
            if (dgvReservation.Rows.Count > 0)
            {
                dgvReservation.Columns[0].HeaderText = "Reservation ID";
                dgvReservation.Columns[0].Width = 80;

                dgvReservation.Columns[1].HeaderText = "Guest ID";
                dgvReservation.Columns[1].Width = 80;

                dgvReservation.Columns[2].HeaderText = "Guest Name";
                dgvReservation.Columns[2].Width = 150;

                dgvReservation.Columns[3].HeaderText = "Room ID";
                dgvReservation.Columns[3].Width = 80;

                dgvReservation.Columns[4].HeaderText = "Name Room";
                dgvReservation.Columns[4].Width = 80;

                dgvReservation.Columns[5].HeaderText = "User ID";
                dgvReservation.Columns[5].Width = 80;

                dgvReservation.Columns[6].HeaderText = "User name";
                dgvReservation.Columns[6].Width = 100;

                dgvReservation.Columns[7].HeaderText = "Check In Date";
                dgvReservation.Columns[7].Width = 100;

                dgvReservation.Columns[8].HeaderText = "Check Out Date";
                dgvReservation.Columns[8].Width = 120;

                dgvReservation.Columns[9].HeaderText = "Number Of Guests";
                dgvReservation.Columns[9].Width = 60;

                dgvReservation.Columns[10].HeaderText = "Status";
                dgvReservation.Columns[10].Width = 80;

                dgvReservation.Columns[11].HeaderText = "Created At";
                dgvReservation.Columns[11].Width = 120;

                dgvReservation.Columns[12].HeaderText = "Total Amount";
                dgvReservation.Columns[12].Width = 80;


            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUpdateReservation frm = new AddUpdateReservation(-1);
            frm.ShowDialog();
            frmListManageReservation_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ReservationID = (int)dgvReservation.CurrentRow.Cells[0].Value;
            int RoomID = (int)dgvReservation.CurrentRow.Cells[3].Value;

            AddUpdateReservation frm = new AddUpdateReservation(RoomID, ReservationID);
            frm.ShowDialog();
            frmListManageReservation_Load(null, null);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ReservationID = (int)dgvReservation.CurrentRow.Cells[0].Value;
            int RoomID = (int)dgvReservation.CurrentRow.Cells[3].Value;
           // int 

            if (MessageBox.Show("هل أنت متأكد أنك تريد حذف معرف الحجز = [" + ReservationID + "]", "تأكيد الحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsReservation.DeleteReservation(ReservationID))
                {
                    MessageBox.Show("تم حذف المستخدم بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clsRoom Room = clsRoom.Find(RoomID);
                    if (Room != null)
                    {
                        Room.Status = "متاح"; // تغيير الحالة إلى "متاحة"
                        Room.Save();
                    }
                    frmListManageReservation_Load(null, null);
                }

                else
                    MessageBox.Show("لا يتم حذف المستخدم بسبب البيانات المرتبطة به.", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ReservationID = (int)dgvReservation.CurrentRow.Cells[0].Value;

            frmShowReservationInfo frm = new frmShowReservationInfo(ReservationID);
            frm.ShowDialog();
            frmListManageReservation_Load(null, null);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddUpdateReservation frm = new AddUpdateReservation(-1);
            frm.ShowDialog();
            frmListManageReservation_Load(null, null);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Status")
            {
                txtFilterValue.Visible = false;
                cmbStatus.Visible = true;
                cmbStatus.Focus();
                cmbStatus.SelectedIndex = 0;
            }
            else if (cbFilterBy.Text == "Check In Date" || cbFilterBy.Text == "Check Out Date" || cbFilterBy.Text == "Created At")
            {

                txtFilterValue.Visible = false;
                dtbDate.Visible = true;
                dtbDate.Value = DateTime.Now;

            }
            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cmbStatus.Visible = false;
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
                case "Reservation ID":
                    FilterColumn = "ReservationID";
                    break;
                case "Guest ID":
                    FilterColumn = "GuestID";
                    break;

                case "Guest Name":
                    FilterColumn = "GuestName";
                    break;


                case "Room ID":
                    FilterColumn = "RoomID";
                    break;

                case "Name Room":
                    FilterColumn = "NameRoom";
                    break;

                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "User name":
                    FilterColumn = "Username";
                    break; 

                case "Check In Date":
                    FilterColumn = "CheckInDate";
                    break;
                case "Check Out Date":
                    FilterColumn = "CheckOutDate";
                    break;
                case "Number Of Guests":
                    FilterColumn = "NumberOfGuests";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                case "Created At":
                    FilterColumn = "CreatedAt";
                    break;
                case "Total Amount":
                    FilterColumn = "TotalAmount";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllReservations.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAllReservations.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ReservationID" || FilterColumn == "GuestID" ||
                FilterColumn == "RoomID" || FilterColumn == "UserID" || FilterColumn == "Status" ||
                FilterColumn == "TotalAmount")
                //in this case we deal with numbers not string.
                _dtAllReservations.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllReservations.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllReservations.Rows.Count.ToString();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Status";
            string FilterValue = cmbStatus.Text;
            if (FilterValue == "All")
                _dtAllReservations.DefaultView.RowFilter = "";
            //in this case we deal with numbers not string.
            // تأكد من أن القيمة ليست فارغة
            else if (!string.IsNullOrWhiteSpace(FilterValue))
            {
                // استخدم علامات الاقتباس حول القيمة النصية
                _dtAllReservations.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);
            }
            else
            {
                MessageBox.Show("يرجى إدخال قيمة صالحة للتصفية.");
            }
            lblRecordsCount.Text = _dtAllReservations.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Reservation ID" || cbFilterBy.Text == "Guest ID"
                || cbFilterBy.Text == "Room ID" || cbFilterBy.Text == "User ID"
                || cbFilterBy.Text == "Total Amount")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dtbDate_ValueChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {

                case "Check In Date":
                    FilterColumn = "CheckInDate";
                    break;
                case "Check Out Date":
                    FilterColumn = "CheckOutDate";
                    break;
             
                case "Created At":
                    FilterColumn = "CreatedAt";
                    break;
             
                default:
                    FilterColumn = "None";
                    break;

            }

            string FilterValue = dtbDate.Value.ToString("yyyy-MM-dd");
            // استخدم علامات الاقتباس حول القيمة النصية
            _dtAllReservations.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);


            lblRecordsCount.Text = _dtAllReservations.Rows.Count.ToString();
        }
    }
    
}
