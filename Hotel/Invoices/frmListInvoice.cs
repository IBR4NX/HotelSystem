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

namespace Hotel.Invoices
{
    public partial class frmListInvoice : Form
    {
        private static DataTable _dtAllInvoices;
        public frmListInvoice()
        {
            InitializeComponent();
        }

        private void frmListInvoice_Load(object sender, EventArgs e)
        {
            _dtAllInvoices = clsInvoice.GetAllInvoices();

            dgvInvoices.DataSource = _dtAllInvoices;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvInvoices.Rows.Count.ToString();

            if (dgvInvoices.Rows.Count > 0)
            {

                dgvInvoices.Columns[0].HeaderText = "Invoice ID";
                dgvInvoices.Columns[0].Width = 110;

                dgvInvoices.Columns[1].HeaderText = "Reservation ID";
                dgvInvoices.Columns[1].Width = 110;

                dgvInvoices.Columns[2].HeaderText = "Issue Date";
                dgvInvoices.Columns[2].Width = 170;

                dgvInvoices.Columns[3].HeaderText = "Total Amount";
                dgvInvoices.Columns[3].Width = 120;

                dgvInvoices.Columns[4].HeaderText = "Status";
                dgvInvoices.Columns[4].Width = 120;

            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateInvoice frm = new frmAddUpdateInvoice();
            frm .ShowDialog();
            frmListInvoice_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateInvoice frm = new frmAddUpdateInvoice((int)dgvInvoices.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListInvoice_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InvoiceID = (int)dgvInvoices.CurrentRow.Cells[0].Value;
            // int 

            if (MessageBox.Show("هل أنت متأكد أنك تريد حذف معرف الفاتورة = [" + InvoiceID + "]", "تأكيد الحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                clsPayment Payment = clsPayment.FindByInvoiceID(InvoiceID);
                if(Payment != null)
                {
                    clsPayment.DeletePayment(Payment.PaymentID);

                }

                if (clsInvoice.DeletInvoice(InvoiceID))
                {
                    MessageBox.Show("تم حذف الفاتورة بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   

                    frmListInvoice_Load(null, null);
                }

                else
                    MessageBox.Show("لا يتم حذف الفاتورة بسبب البيانات المرتبطة به.", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInvoiceInfo frm = new frmShowInvoiceInfo((int)dgvInvoices.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListInvoice_Load(null, null);

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
            else if (cbFilterBy.Text == "Issue Date")
            {

                txtFilterValue.Visible = false;
                dtbIssueDate.Visible = true;
                dtbIssueDate.Value = DateTime.Now;

            }
            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cmbStatus.Visible = false;
                dtbIssueDate.Visible = false;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*الكل
مدفوع
غير مدفوعة
مستردة*/



            string FilterColumn = "Status";
            string FilterValue = cmbStatus.Text;
            if (FilterValue == "الكل")
                _dtAllInvoices.DefaultView.RowFilter = "";
            //in this case we deal with numbers not string.
            // تأكد من أن القيمة ليست فارغة
            else if (!string.IsNullOrWhiteSpace(FilterValue))
            {
                // استخدم علامات الاقتباس حول القيمة النصية
                _dtAllInvoices.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);
            }
            else
            {
                MessageBox.Show("يرجى إدخال قيمة صالحة للتصفية.");
            }
            lblRecordsCount.Text = _dtAllInvoices.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

     
            string FilterColumn = "";

            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Invoice ID":
                    FilterColumn = "InvoiceID";
                    break;
                case "Reservation ID":
                    FilterColumn = "ReservationID";
                    break;
                case "Issue Date":
                    FilterColumn = "IssueDate";
                    break;
                case "Total Amount":
                    FilterColumn = "TotalAmount";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
               
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllInvoices.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvInvoices.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "InvoiceID" || FilterColumn == "ReservationID" || FilterColumn == "TotalAmount")
                //in this case we deal with numbers not string.
                _dtAllInvoices.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllInvoices.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllInvoices.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Invoice ID" || cbFilterBy.Text == "Reservation ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dtbIssueDate_ValueChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IssueDate";
            string FilterValue = dtbIssueDate.Value.ToString("yyyy-MM-dd");
            // استخدم علامات الاقتباس حول القيمة النصية
            _dtAllInvoices.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);


            lblRecordsCount.Text = _dtAllInvoices.Rows.Count.ToString();
        }
    }
}
