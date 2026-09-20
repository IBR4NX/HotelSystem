using Hotel_DataAccuss;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsPayment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PaymentID { get; set; }
        public int InvoiceID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } // مثل Credit Card, Cash, Online

        public clsInvoice Invoice { get; set; }
        // كونستركتر بدون معلمات مع قيم مبدئية
        public clsPayment()
        {
            PaymentID = 0;
            InvoiceID = 0;
            Amount = 0.0m;
            PaymentDate = DateTime.Now;
            Status = "Cash";
            Mode = enMode.AddNew;
            
        }

        // كونستركتر يستقبل قيم
        public clsPayment(int paymentID, int invoiceID, decimal amount, DateTime paymentDate,
            string status)
        {
            PaymentID = paymentID;
            InvoiceID = invoiceID;
            Amount = amount;
            PaymentDate = paymentDate;
            Status = status;
            Mode = enMode.Update;
            Invoice = clsInvoice.Find(InvoiceID);
        }

        private bool _AddNewPayment()
        {
            //call DataAccess Layer 
            //this.Password = ComputeHash(this.Password);
            this.PaymentID = clsPaymentData.AddNewPayment(this.InvoiceID, this.Amount,
                this.PaymentDate, this.Status);

            return (this.InvoiceID != -1);
        }
        private bool _UpdatePayment()
        {
            //call DataAccess Layer 
            // this.PasswordHash = ComputeHash(this.Password);

            return clsPaymentData.UpdatePayment(this.PaymentID, this.InvoiceID, this.Amount,
                this.PaymentDate, this.Status);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePayment();

            }

            return false;
        }



        public static clsPayment FindByInvoiceID(int InvoiceID)
        {
            int PaymentID = 0;
            decimal Amount = 0.0m;
            DateTime PaymentDate = DateTime.Now;
            string Status = "Cash";

            if (clsPaymentData.GetPaymentInfoByInvoiceID(ref PaymentID, InvoiceID, ref Amount,
                ref PaymentDate, ref Status))
                return new clsPayment(PaymentID, InvoiceID, Amount,PaymentDate, Status);
            else
                return null;

        }

        public static clsPayment Find(int PaymentID)
        {
            int InvoiceID = 0;
            decimal Amount = 0.0m;
            DateTime PaymentDate = DateTime.Now;
            string Status = "Cash";

            if (clsPaymentData.GetPaymentInfoByPaymentID( PaymentID, ref InvoiceID, ref Amount,
                ref PaymentDate, ref Status))
                return new clsPayment(PaymentID, InvoiceID, Amount, PaymentDate, Status);
            else
                return null;

        }

        public static DataTable GetAllPayments()
        {
            return clsPaymentData.GetAllPayments();
        }

        public static bool DeletePayment(int PaymentID)
        {
            return clsPaymentData.DeletePayment(PaymentID);
        }

    }
}
