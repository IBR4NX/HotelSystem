using Hotel.Guests;
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
    public partial class ctrlInvoiceCard : UserControl
    {
        public ctrlInvoiceCard()
        {
            InitializeComponent();
        }

        private clsInvoice _Invoice;

        private int _InvoiceID = -1;

        public int InvoiceID
        {
            get { return _InvoiceID; }
        }

        public clsInvoice SelectedInvoiceInfo
        {
            get { return _Invoice; }
        }



        //تحميل معلومات الشخص

        public void LoadInvoiceInfo(int InvoiceID)// نعرض بيانات الشخص على حسب رقمة الوطني
        {

            _Invoice = clsInvoice.Find(InvoiceID);
            _InvoiceID = InvoiceID;
            if (_Invoice == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Invoice with InvoiceID = " + InvoiceID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInvoiceInfo();
        }


   

        //   عرض البيانات
        private void _FillInvoiceInfo()
        {


           // llEditInvoiceInfo.Enabled = true;
            lblInvoiceID.Text = _Invoice.InvoiceID.ToString();
            lblStatus.Text = _Invoice.Status;

            lblTotalAmount.Text = _Invoice.TotalAmount.ToString();
            lblIssueDate.Text = _Invoice.IssueDate.ToString("yyyy-mm-dd");
            lblPaymentStatus.Text = clsPayment.FindByInvoiceID(_Invoice.InvoiceID).Status;
            llEditInvoiceInfo.Enabled = true;


        }


        // لو البيانات مش موجوده يعمل اعاده تحميل
        public void ResetPersonInfo()
        {
            llEditInvoiceInfo.Enabled = false;
            _InvoiceID = -1;
            lblInvoiceID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblTotalAmount.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblPaymentStatus.Text = "[????]";
      

        }

        private void llEditInvoiceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateInvoice frm = new frmAddUpdateInvoice(_Invoice.InvoiceID);
          //  frm.DataBack += frmAddUpdateGuest_DataBack;
            frm.ShowDialog();
            //refresh
            // اعادة تحميل
            LoadInvoiceInfo(_Invoice.InvoiceID);
        }
    }
}
