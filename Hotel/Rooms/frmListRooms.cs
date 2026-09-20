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

namespace Hotel.Rooms
{
    public partial class frmListRooms : Form
    {
        private DataTable _dtAllRooms;
        public frmListRooms()
        {
            InitializeComponent();
        }
        private void _FillRoomTypeInComoboBox()
        {
            DataTable dtRoomType = clsRoomType.GetAllRoomTypeData();

            foreach (DataRow row in dtRoomType.Rows)
            {
                cmbRoomType.Items.Add(row[1]);
            }
        }
        private void frmListRooms_Load(object sender, EventArgs e)
        {
            _dtAllRooms = clsRoom.GetAllRooms();

            dgvRooms.DataSource = _dtAllRooms;
            lblRecordsCount.Text = dgvRooms.Rows.Count.ToString();

            if (dgvRooms.Rows.Count > 0)
            {
                dgvRooms.Columns[0].HeaderText = "Room ID";
                dgvRooms.Columns[0].Width = 100;

                dgvRooms.Columns[1].HeaderText = "Name Room";
                dgvRooms.Columns[1].Width = 110;

                dgvRooms.Columns[2].HeaderText = "RoomType Name";
                dgvRooms.Columns[2].Width = 150;

                dgvRooms.Columns[3].HeaderText = "Status";
                dgvRooms.Columns[3].Width = 100;

                dgvRooms.Columns[4].HeaderText = "Description";
                dgvRooms.Columns[4].Width = 250;

                dgvRooms.Columns[5].HeaderText = "Number Of Beds";
                dgvRooms.Columns[5].Width = 120;

                dgvRooms.Columns[6].HeaderText = "Max Occupancy";
                dgvRooms.Columns[6].Width = 120;

                dgvRooms.Columns[7].HeaderText = "Price";
                dgvRooms.Columns[7].Width = 120;
            }

            _FillRoomTypeInComoboBox();
 


        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateRoom frm = new frmAddUpdateRoom();
            frm.ShowDialog();
            frmListRooms_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateRoom frm = new frmAddUpdateRoom((int)dgvRooms.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListRooms_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomID = (int)dgvRooms.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("هل أنت متأكد أنك تريد حذف معرف الغرقة = [" + RoomID + "]", "تأكيد الحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsRoom.DeleteRoom(RoomID))
                {
                    MessageBox.Show("تم حذف المستخدم بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListRooms_Load(null, null);
                }

                else
                    MessageBox.Show("لا يتم حذف المستخدم بسبب البيانات المرتبطة به.", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowRootInfo frm = new frmShowRootInfo((int)dgvRooms.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
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
            else if(cbFilterBy.Text == "RoomType Name")
            {
                txtFilterValue.Visible = false;
                cmbRoomType.Visible = true;
                cmbStatus.Visible = false;

                cmbRoomType.Focus();
                cmbRoomType.SelectedIndex = 0;
            }
            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cmbStatus.Visible = false;
                cmbRoomType.Visible = false;
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
                case "Room ID":
                    FilterColumn = "RoomID";
                    break;
                case "Name Room":
                    FilterColumn = "NameRoom";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;


                case "Description":
                    FilterColumn = "Description";
                    break;

                case "Number Of Beds":
                    FilterColumn = "NumberOfBeds";
                    break;
                    
                case "Max Occupancy":
                    FilterColumn = "MaxOccupancy";
                    break;
                case "Price":
                    FilterColumn = "Price";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllRooms.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAllRooms.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "NameRoom" && FilterColumn != "Description")
                //in this case we deal with numbers not string.
                _dtAllRooms.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllRooms.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllRooms.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Room ID" || cbFilterBy.Text == "Price" || cbFilterBy.Text == "Number Of Beds" || cbFilterBy.Text == "Max Occupancy")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "Status";
            string FilterValue = cmbStatus.Text;
            if (FilterValue == "All")
                _dtAllRooms.DefaultView.RowFilter = "";
            //in this case we deal with numbers not string.
            // تأكد من أن القيمة ليست فارغة
           else if (!string.IsNullOrWhiteSpace(FilterValue))
            {
                // استخدم علامات الاقتباس حول القيمة النصية
                _dtAllRooms.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);
            }
            else
            {
                MessageBox.Show("يرجى إدخال قيمة صالحة للتصفية.");
            }
            lblRecordsCount.Text = _dtAllRooms.Rows.Count.ToString();


        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "RoomTypeName";
            string FilterValue = cmbRoomType.Text;


            if (FilterValue == "All")
                _dtAllRooms.DefaultView.RowFilter = "";
            else if (!string.IsNullOrWhiteSpace(FilterValue))
            {
                // استخدم علامات الاقتباس حول القيمة النصية
                _dtAllRooms.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);
            }
            else
            {
                MessageBox.Show("يرجى إدخال قيمة صالحة للتصفية.");
            }
            lblRecordsCount.Text = _dtAllRooms.Rows.Count.ToString();
        }
    }
}
