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
    public partial class ctrlResevationCardWithFilter : UserControl
    {
        public event Action<int> OnReservationSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void ReservationSelected(int GuestID)
        {
            Action<int> handler = OnReservationSelected;
            if (handler != null)
            {
                handler(GuestID); // Raise the event with the parameter
            }
        }

        public clsReservation _Reservation;

        public int _ReservationID = -1;

        clsInvoice _Invoice;
        public int _InvoiceID = -1;

        public clsPayment _Payment;
        public int _PaymentID = -1;

        public int ReservationID
        {
            get { return _ReservationID; }
        }

        public clsReservation SelectedReservationInfo
        {
            get { return _Reservation; }
        }

        public ctrlResevationCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadReservationInfo(int ReservationID, bool filtet = true)// نعرض بيانات الشخص على حسب رقمة الوطني
        {


            _Reservation = clsReservation.Find(ReservationID);
            if (_Reservation == null)
            {
                ResetReservationInfo();
                MessageBox.Show("No Reservation with ReservationID = " + ReservationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtFilterValue.Text = ReservationID.ToString();
            gbFilters.Enabled = filtet;
            _FillPersonInfo();
        }





        //   عرض البيانات
        private void _FillPersonInfo()
        {
            _ReservationID = _Reservation.ReservationID;
            lblReservationID.Text = _Reservation.ReservationID.ToString();
            lblCheckInDate.Text = _Reservation.CheckInDate.ToString("yyyy-mm-dd");
            lblCheckOutDate.Text = _Reservation.CheckOutDate.ToString("yyyy-mm-dd");
            lblNumberOfGuests.Text = _Reservation.NumberOfGuests.ToString();
            lblTotalAmount.Text = _Reservation.TotalAmount.ToString();




            TimeSpan difference = _Reservation.CheckOutDate.Subtract(_Reservation.CheckInDate);

            lblNumberOfNights.Text = difference.Days.ToString();

            _Invoice = clsInvoice.FindByReservationID(_Reservation.ReservationID);
            if(_Invoice != null )
            _InvoiceID = _Invoice.InvoiceID;

            _Payment = clsPayment.FindByInvoiceID(_InvoiceID);
            if (_Payment != null)
            {
                _PaymentID = _Payment.PaymentID;

                lblPaymentStatus.Text = _Payment.Status;
            }
            ctrlGuestCard1.LoadGuestInfo(_Reservation.GuestID);
            ctrlRootCard1.LoadRoomInfo(_Reservation.RoomID);


            if (OnReservationSelected != null)
                // Raise the event with a parameter
                ReservationSelected(_Reservation.ReservationID);
        }


        // لو البيانات مش موجوده يعمل اعاده تحميل
        public void ResetReservationInfo()
        {
            _ReservationID = -1;
            lblReservationID.Text = "[????]";
            lblReservationID.Text = "[????]";
            lblCheckInDate.Text = "[????]";
            lblCheckOutDate.Text = "[????]";
            lblNumberOfGuests.Text = "[????]";
            lblNumberOfNights.Text = "";
            lblTotalAmount.Text = "[????]";

            lblTotalAmount.Text = "[????]";


        }




        private void btnFind_Click(object sender, EventArgs e)
        {
            int ReservationID = int.Parse(txtFilterValue.Text);
            LoadReservationInfo(ReservationID);
        }

        private void ctrlResevationCardWithFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
