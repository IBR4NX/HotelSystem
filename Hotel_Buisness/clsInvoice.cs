using Hotel_DataAccuss;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsInvoice
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InvoiceID { get; set; }
        public int ReservationID { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // مثل Paid, Unpaid, Refunded

        public clsReservation Reservation { get; set; }
        // كونستركتر بدون معلمات مع قيم مبدئية
        public clsInvoice()
        {
            InvoiceID = -1;
            ReservationID = -1;
            IssueDate = DateTime.Now;
            TotalAmount = 0.0m;
            Status = "";
            Mode = enMode.AddNew;
        }
        //('Paid', 'Unpaid', 'Refunded')
        // كونستركتر يستقبل قيم
        public clsInvoice(int invoiceID, int reservationID, DateTime issueDate, 
            decimal totalAmount, string status)
        {
            InvoiceID = invoiceID;
            ReservationID = reservationID;
            IssueDate = issueDate;
            TotalAmount = totalAmount;
            Status = status;
            Mode = enMode.Update;
            Reservation = clsReservation.Find(ReservationID);
        }



        private bool _AddNewInvoice()
        {
            //call DataAccess Layer 
            //this.Password = ComputeHash(this.Password);
            this.InvoiceID = clsInvoiceData.AddNewInvoice(this.ReservationID, this.IssueDate, this.TotalAmount, this.Status);

            return (this.InvoiceID != -1);
        }
        private bool _UpdateInvoice()
        {
            //call DataAccess Layer 
            // this.PasswordHash = ComputeHash(this.Password);

            return clsInvoiceData.UpdateInvoice(this.InvoiceID, this.ReservationID, this.IssueDate, 
                this.TotalAmount, this.Status);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInvoice())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateInvoice();

            }

            return false;
        }

        public static clsInvoice Find(int InvoiceID)
        {
            int ReservationID = 0;
           DateTime IssueDate = DateTime.Now;
            decimal TotalAmount = 0.0m;
            string Status = "";

            if (clsInvoiceData.GetInvoiceInfoByInvoiceID(InvoiceID, ref ReservationID, ref IssueDate,
                ref TotalAmount, ref Status))
                return new clsInvoice(InvoiceID, ReservationID, IssueDate,
                 TotalAmount,  Status);
            else
                return null;

        }

        public static clsInvoice FindByReservationID(int ReservationID)
        {
            int InvoiceID = 0;
            DateTime IssueDate = DateTime.Now;
            decimal TotalAmount = 0.0m;
            string Status = "";

            if (clsInvoiceData.GetInvoiceInfoByReservationID(ref InvoiceID, ReservationID, ref IssueDate,
                ref TotalAmount, ref Status))
                return new clsInvoice(InvoiceID, ReservationID, IssueDate,
                 TotalAmount, Status);
            else
                return null;

        }

        public static DataTable GetAllInvoices()
        {
            return clsInvoiceData.GetAllInvoices();
        }

        public static bool DeletInvoice(int InvoiceID)
        {
            return clsInvoiceData.DeletInvoice(InvoiceID);
        }
    }
}
