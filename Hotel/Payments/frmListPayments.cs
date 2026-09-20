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

namespace Hotel.Payments
{
    public partial class frmListPayments : Form
    {
        private static DataTable _dtAllPayments;

        public frmListPayments()
        {
            InitializeComponent();
        }

        private void frmListPayments_Load(object sender, EventArgs e)
        {
            _dtAllPayments = clsPayment.GetAllPayments();

            dgvPayments.DataSource = _dtAllPayments;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvPayments.Rows.Count.ToString();

            if (dgvPayments.Rows.Count > 0)
            {

                dgvPayments.Columns[0].HeaderText = "Payment ID";
                dgvPayments.Columns[0].Width = 110;

                dgvPayments.Columns[1].HeaderText = "Invoice ID";
                dgvPayments.Columns[1].Width = 110;

                dgvPayments.Columns[2].HeaderText = "Amount";
                dgvPayments.Columns[2].Width = 170;

                dgvPayments.Columns[3].HeaderText = "Payment Date";
                dgvPayments.Columns[3].Width = 170;

                dgvPayments.Columns[4].HeaderText = "Status";
                dgvPayments.Columns[4].Width = 120;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            else if(cbFilterBy.Text == "Payment Date")
            {

                txtFilterValue.Visible = false;
                dtbPaymentDate.Visible = true;
                dtbPaymentDate.Value = DateTime.Now;

            }
            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cmbStatus.Visible = false;
                dtbPaymentDate.Visible = false;

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
                case "Payment ID":
                    FilterColumn = "PaymentID";
                    break;
                case "Invoice ID":
                    FilterColumn = "InvoiceID";
                    break;
                case "Amount":
                    FilterColumn = "Amount";
                    break;
                case "Payment Date":
                    FilterColumn = "PaymentDate";
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
                _dtAllPayments.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPayments.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "InvoiceID" || FilterColumn == "PaymentID" || 
                FilterColumn == "Amount")
                //in this case we deal with numbers not string.
                _dtAllPayments.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllPayments.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllPayments.Rows.Count.ToString();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Status";
            string FilterValue = cmbStatus.Text;
            if (FilterValue == "All")
                _dtAllPayments.DefaultView.RowFilter = "";
            //in this case we deal with numbers not string.
            // تأكد من أن القيمة ليست فارغة
            else if (!string.IsNullOrWhiteSpace(FilterValue))
            {
                // استخدم علامات الاقتباس حول القيمة النصية
                _dtAllPayments.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);
            }
            else
            {
                MessageBox.Show("يرجى إدخال قيمة صالحة للتصفية.");
            }
            lblRecordsCount.Text = _dtAllPayments.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Invoice ID" || cbFilterBy.Text == "Payment ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dtbPaymentDate_ValueChanged(object sender, EventArgs e)
        {
            string FilterColumn = "PaymentDate";
            string FilterValue = dtbPaymentDate.Value.ToString("yyyy-MM-dd");
            // استخدم علامات الاقتباس حول القيمة النصية
            _dtAllPayments.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);
            
         
            lblRecordsCount.Text = _dtAllPayments.Rows.Count.ToString();
        }
    }
}
