using Hotel.Reservations;
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
    public partial class frmAddUpdateInvoice : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _InvoiceID = -1;
        clsInvoice _Invoice;

        clsPayment _Payment = new clsPayment();

        public frmAddUpdateInvoice()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateInvoice(int InvoiceID)
        {
            InitializeComponent();
            _InvoiceID = InvoiceID;
            _Mode = enMode.Update;
        }

        private void _ResetDefualtValues()
        {
         
          

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "إضافة فاتورة جديدة";
                this.Text = "إضافة فاتورة جديدة";
               
                _Invoice = new clsInvoice();
                _Payment = new clsPayment();
            }
            else
            {
                lblTitle.Text = "تحديث الفاتورة";
                this.Text = "تحديث الفاتورة";


            }

           


        }

        private void _LoadData()
        {

            _Invoice = clsInvoice.Find(_InvoiceID);

            if (_Invoice == null)
            {
                MessageBox.Show("No Invoice with ID = " + _InvoiceID, "Invoice Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlResevationCardWithFilter1.LoadReservationInfo(_Invoice.ReservationID, false);

            lblInvoiceID.Text = _Invoice.InvoiceID.ToString();
            cmbStatus.Text = _Invoice.Status;
            dtbIssueDate.Value = _Invoice.IssueDate;
            nudTotalAmount.Value = _Invoice.TotalAmount;
            ctrlResevationCardWithFilter1.LoadReservationInfo(_Invoice.ReservationID);
            _Payment = clsPayment.FindByInvoiceID(_Invoice.InvoiceID);
        }

        private void InvoiceUpdateGuest_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            cmbStatus.SelectedIndex = 0;
            cmbPaymentStatus.SelectedIndex = 0;


            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if(_Invoice.ReservationID == -1)
            {
                MessageBox.Show("لمي يتم تحديد الحجز الرجاء تحديد الحجز؟",
                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew)
            {

                if (clsInvoice.FindByReservationID(_Invoice.ReservationID) != null)
                {
                    MessageBox.Show("هنا لك فاتورة لهاذا الحجز",
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _Invoice.IssueDate = dtbIssueDate.Value;
            _Invoice.Status = cmbStatus.Text;
            _Invoice.TotalAmount = Convert.ToInt32(nudTotalAmount.Value);

           // Payment = clsPayment.FindByInvoiceID(_Invoice.InvoiceID);

            if (_Invoice.Save())
            {
                lblInvoiceID.Text = _Invoice.InvoiceID.ToString();
                if(_Payment == null)
                {
                    _Payment = new clsPayment();
                    _Payment.InvoiceID = _Invoice.InvoiceID;
                    _Payment.Amount = _Invoice.TotalAmount;
                    _Payment.PaymentDate = DateTime.Now;
                    _Payment.Status = cmbPaymentStatus.Text;
                }
                else
                {
                    _Payment.InvoiceID = _Invoice.InvoiceID;

                    _Payment.Amount = _Invoice.TotalAmount;
                    _Payment.PaymentDate = DateTime.Now;
                    _Payment.Status = cmbPaymentStatus.Text;
                }

                _Payment.Save();

                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "تحديث المستخدم";
                this.Text = "تحديث المستخدم";

                MessageBox.Show("تم حفظ البيانات بنجاح.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("خطأ: لم يتم حفظ البيانات بنجاح.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ctrlResevationCardWithFilter1_OnReservationSelected(int obj)
        {
            _Invoice.ReservationID = obj;

        }
    }
}
