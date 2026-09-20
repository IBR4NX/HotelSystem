using Hotel.Global_Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel.Reservations
{
    public partial class AddUpdateReservation : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _RoomID = -1;
        clsRoom _Room;


        private int _GuestID = -1;
        clsGuest _Guest;


        clsInvoice _Invoice;
        private int _InvoiceID = -1;

        clsPayment _Payment;
        private int _PaymentID = -1;
        public int GuestID
        {
            get { return _GuestID; }
        }

        public clsGuest Selected_GuestInfo
        {
            get { return _Guest; }
        }

        private clsReservation _Reservation;
        private int _ReservationID;
        public AddUpdateReservation(int RoomID)
        {
            InitializeComponent();
            _RoomID = RoomID;
            _Mode = enMode.AddNew;
        }
        public AddUpdateReservation(int RoomID, int ReservationID)
        {
            InitializeComponent();
            _RoomID = RoomID;
            _ReservationID = ReservationID;
            _Mode = enMode.Update;

        }

        private void _ResetDefualtValues()
        {


            if (_Mode == enMode.AddNew)
            {
                _Reservation = new clsReservation();
               // _Invoice = new clsInvoice();
                //_Payment = new clsPayment();
                lblTitle.Text = "إضافة حجز جديد";
                this.Text = "إضافة حجز جديد";
                dtbCheckInDate.Value = DateTime.Now;
                dtbCheckOutDate.Value = dtbCheckInDate.Value.AddDays(1);
                //dtbCheckInDate.MaxDate = dtbCheckOutDate.Value.AddDays(-1);

                dtbCheckInDate.MinDate = DateTime.Now;
                dtbCheckOutDate.MinDate = dtbCheckInDate.Value.AddDays(1);
                if (_Room == null)
                {
                    lblTotalAmount.Text = "0";
                   
                }
                else
                {
                    lblTotalAmount.Text = _Room.Price.ToString();
                    ctrRoomCardWithFilter1.LoadRoomInfo(_RoomID);


                }
                TimeSpan difference = dtbCheckOutDate.Value.Subtract(dtbCheckInDate.Value);
                numNumberOfNights.Value = difference.Days;
               // nudNumberOfGuests.Value = difference.Days;
                cmbPaymentStatus.SelectedIndex = 0;


                //ctrlPersonCardWithFilter1.FilterFocus();// عمل تركيز على مربع البحث
            }
            else
            {
                lblTitle.Text = "تحديث الحجز";
                this.Text = "تحديث الحجز";

                btnSave.Text = "تعديل";
                btnCheckOut.Visible = true;
                btnCancellationReservation.Visible = true;

            }



        }

        private void _LoadData()
        {

            _Reservation = clsReservation.Find(_ReservationID);
            if (_Reservation == null)
            {
                MessageBox.Show("No Reservation with ID = " + _ReservationID, "Room Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            _Invoice = clsInvoice.FindByReservationID(_Reservation.ReservationID);
            if (_Invoice != null)
                _InvoiceID = _Invoice.InvoiceID;

            _Payment = clsPayment.FindByInvoiceID(_InvoiceID);
            if (_Payment != null)
            {
                _PaymentID = _Payment.PaymentID;

                cmbPaymentStatus.Text = _Payment.Status;

            }

            btnCheckOut.Visible = true;

            lblReservationID.Text = _Reservation.ReservationID.ToString();

            dtbCheckInDate.Value = _Reservation.CheckInDate;
            dtbCheckOutDate.Value = _Reservation.CheckOutDate;
            //dtbCheckInDate.MaxDate = dtbCheckOutDate.Value.AddDays(-1);
           
            lblTotalAmount.Text = _Reservation.TotalAmount.ToString();
            TimeSpan difference = dtbCheckOutDate.Value.Subtract(dtbCheckInDate.Value);

            nudNumberOfGuests.Value = _Reservation.NumberOfGuests ;
            numNumberOfNights.Value = difference.Days;
            // cmbPaymentStatus.SelectedIndex = 0;
            ctrRoomCardWithFilter1.LoadRoomInfo(_RoomID);
            ctrlGuestCardWithFilter1.LoadGuestInfo(_Reservation.GuestID);

        }
        private void AddUpdateReservation_Load(object sender, EventArgs e)
        {
            _Room = clsRoom.Find(_RoomID);
           /* if (_Room == null)
            {
                MessageBox.Show("No Room with ID = " + _Room, "Room Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }*/

            _ResetDefualtValues();

        

            if (_Mode == enMode.Update)
                _LoadData();

        }

    

        private void dtbCheckInDate_ValueChanged(object sender, EventArgs e)
        {
            //dtbCheckInDate.MaxDate = dtbCheckOutDate.Value.AddDays(-1);

            if (_Room == null)
            {
                lblTotalAmount.Text = "0";
                return;
            }

            TimeSpan difference = dtbCheckOutDate.Value.Subtract(dtbCheckInDate.Value);
            
            int differenceInDays = difference.Days;

            if (differenceInDays <= 0)
            {
                //dtbCheckOutDate.Value = DateTime.Now.AddDays(1);

             //   dtbCheckInDate.Value = DateTime.Now;
               // nudNumberOfGuests.Value = 1;
                numNumberOfNights.Value = 1;
                lblTotalAmount.Text = _Room.Price.ToString();
            }
            else
            {
                lblTotalAmount.Text = (_Room.Price * differenceInDays).ToString();

                numNumberOfNights.Value = differenceInDays ;
              //  dtbCheckInDate.MaxDate = dtbCheckOutDate.Value.AddDays(-1);
            }
           // dtbCheckInDate.MaxDate = dtbCheckOutDate.Value.AddDays(-1);

        }


        private void dtbCheckOutDate_ValueChanged(object sender, EventArgs e)
        {
            if (_Room == null)
            {
                lblTotalAmount.Text = "0";
                return;
            }

            TimeSpan difference = dtbCheckOutDate.Value.Subtract(dtbCheckInDate.Value);

            int differenceInDays = difference.Days;

            if (differenceInDays <= 0)
            {
               // dtbCheckInDate.Value = DateTime.Now;
               // dtbCheckOutDate.Value = dtbCheckInDate.Value.AddDays(1);
               // numNumberOfNights.Value =  1;
                numNumberOfNights.Value =  1;
                lblTotalAmount.Text = _Room.Price.ToString();

            }
            else
            {
                lblTotalAmount.Text = (_Room.Price * differenceInDays).ToString();
                numNumberOfNights.Value = differenceInDays;
                dtbCheckOutDate.MinDate = dtbCheckInDate.Value.AddDays(1);

            }
            //dtbCheckInDate.MaxDate = dtbCheckOutDate.Value.AddDays(-1);

        }

        private void nudNumberOfGuests_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {



            // 1. تحقق من صحة البيانات
            if (!this.ValidateChildren())
            {
                MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Guest = clsGuest.Find(_GuestID);
            if (_Guest == null)
            {
                MessageBox.Show("يرجى تحديد النزيل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 2. البحث عن معلومات الغرفة
            _Room = clsRoom.Find(_RoomID);
            if (_Room == null)
            {
                MessageBox.Show($"لا توجد غرفة بالمعرف: {_RoomID}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. تحضير نموذج الحجز
            if (_Mode == enMode.AddNew)
            {
                _Reservation = new clsReservation();
            }
            else if (_Mode == enMode.Update)
            {
                _Reservation = clsReservation.Find(_ReservationID);
                if (_Reservation == null)
                {
                    MessageBox.Show($"لا يوجد حجز بالمعرف: {_ReservationID}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 4. تحديث معلومات الحجز
            _Reservation.GuestID = _Guest.GuestID;
            _Reservation.RoomID = _RoomID;
            _Reservation.UserID = clsGlobal.CurrentUser.UserID;
            _Reservation.CheckInDate = dtbCheckInDate.Value;
            _Reservation.CheckOutDate = dtbCheckOutDate.Value;
            _Reservation.NumberOfGuests = Convert.ToInt32(nudNumberOfGuests.Value);
            _Reservation.CreatedAt = DateTime.Now;
            _Reservation.Status = _Mode == enMode.AddNew ? "Confirmed" : _Reservation.Status; // الحالة الجديدة للحجز
            _Reservation.TotalAmount = Convert.ToDecimal(lblTotalAmount.Text);

            // 5. حساب المبلغ الإجمالي
            TimeSpan stayDuration = _Reservation.CheckOutDate - _Reservation.CheckInDate;
            decimal totalAmount = (decimal)stayDuration.Days * _Room.Price;
            _Reservation.TotalAmount = totalAmount;

            // 6. حفظ البيانات
            if (_Reservation.Save())
            {
                // حفظ حالة الغرفة
                _Room.Status = "محجوز";
                _Room.Save();
                _ReservationID = _Reservation.ReservationID;
                lblReservationID.Text = _Reservation.ReservationID.ToString();


                if (_Invoice == null)
                {

                    // حفظ الفاتورة
                    _Invoice = new clsInvoice
                    {
                        IssueDate = DateTime.Now,
                        ReservationID = _Reservation.ReservationID,
                        Status = "مدفوع",
                        TotalAmount = _Reservation.TotalAmount
                    };

                    if (_Invoice.Save())
                    {
                        // حفظ المدفوعات
                        clsPayment payment = new clsPayment
                        {
                            InvoiceID = _Invoice.InvoiceID,
                            Amount = _Invoice.TotalAmount,
                            PaymentDate = DateTime.Now,
                            Status = cmbPaymentStatus.Text
                        };
                        payment.Save();
                    }
                }
                else
                {
                    _Invoice.IssueDate = DateTime.Now;
                    _Invoice.TotalAmount = _Reservation.TotalAmount;
                    if (_Invoice.Save())
                    {
                        _Payment.Amount = _Invoice.TotalAmount;
                        _Payment.Status = cmbPaymentStatus.Text;
                        // حفظ المدفوعات
                        /*   clsPayment payment = new clsPayment
                           {
                               InvoiceID = _Invoice.InvoiceID,
                               Amount = _Invoice.TotalAmount,
                               PaymentDate = DateTime.Now,
                               Status = cmbPaymentStatus.Text
                           };*/
                        _Payment.Save();
                    }
                }

                // 7. عرض رسالة نجاح
                MessageBox.Show("تم حفظ البيانات بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("خطأ: لم يتم حفظ البيانات بنجاح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ctrlGuestCardWithFilter1_OnGuestSelected(int obj)
        {
            _GuestID = obj;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

          /*  if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

              _Guest = clsGuest.Find(_GuestID);
              if (_Guest == null)
              {
                  MessageBox.Show("قم بتحديد النزيل؟",
  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
              }
              _Reservation.GuestID = _GuestID;
              _Reservation.RoomID = _RoomID;
              _Reservation.UserID = clsGlobal.CurrentUser.UserID;
              _Reservation.CheckInDate = dtbCheckInDate.Value;
              _Reservation.CheckOutDate = dtbCheckOutDate.Value;
              _Reservation.NumberOfGuests = _Room.MaxOccupancy;
              _Reservation.CreatedAt = DateTime.Now;
              // Confirmed = قيد الحجز
              // Cancelled = ملغي
              // Completed = منتهي

              _Reservation.Status = "Completed";
              _Reservation.TotalAmount = Convert.ToDecimal(lblTotalAmount.Text);

              if (_Reservation.Save())
              {
                  //lblGuestID.Text = _Guest.GuestID.ToString();
                  _ReservationID = _Reservation.ReservationID;
                  //change form mode to update.
                  //lblTitle.Text = "تحديث المستخدم";
                  //this.Text = "تحديث المستخدم";

                  _Room.Status = "تنظيف";
                  _Room.Save();
                  TimeSpan difference = dtbCheckOutDate.Value.Subtract(DateTime.Now);
                  if (difference.Days > 0)
                  {

                      decimal totale = difference.Days * _Room.Price;
                      _Invoice = new clsInvoice();
                      _Invoice.IssueDate = DateTime.Now;
                      _Invoice.ReservationID = _ReservationID;
                      _Invoice.Status = "مستردة";
                      _Invoice.TotalAmount = totale;
                      MessageBox.Show($"المبلغ الباقي = {totale.ToString()}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                      if (_Invoice.Save())
                      {
                          clsPayment Payment = clsPayment.FindByInvoiceID(_InvoiceID);
                          Payment.Amount = _Reservation.TotalAmount - totale;
                          if (Payment.Save())
                          {
                  MessageBox.Show("ارجاع المبلغ.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                          }

                          if (Payment.Save())
                          {
                              Payment.InvoiceID = _Invoice.InvoiceID;
                              Payment.Amount = _Invoice.TotalAmount;
                              Payment.PaymentDate = DateTime.Now;
                              Payment.Status = cmbPaymentStatus.Text;
                          }


                      }
                  }



                  _Mode = enMode.Update;

                  MessageBox.Show("تم حفظ البيانات بنجاح.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


              }
              else
                  MessageBox.Show("خطأ: لم يتم حفظ البيانات بنجاح.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

  */

            // 1. تحقق من صحة البيانات
            if (!this.ValidateChildren())
            {
                MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. البحث عن معلومات النزيل
            _Guest = clsGuest.Find(_GuestID);
            if (_Guest == null)
            {
                MessageBox.Show("يرجى تحديد النزيل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. تحديث معلومات الحجز
            _Reservation.Status = "Completed"; // تغيير الحالة إلى "مكتمل"
            _Reservation.CheckOutDate = DateTime.Now; // تحديث تاريخ المغادرة

            if (_Reservation.Save())
            {

                

                // 4. تحديث حالة الغرفة
                _Room.Status = "تنظيف"; // تغيير الحالة إلى "تنظيف"
                _Room.Save(); // حفظ التغييرات في الغرفة

                // 5. حساب المبلغ المسترد (إذا لزم الأمر)
                TimeSpan difference = dtbCheckOutDate.Value.Subtract(DateTime.Now);
                decimal totalRefund = 0;

                if (difference.Days > 0)
                {
                    totalRefund = difference.Days * _Room.Price; // حساب المبلغ المسترد
                    MessageBox.Show($"المبلغ المسترد = {totalRefund:F2}", "المبلغ المسترد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*    // 6. إصدار الفاتورة النهائية
                    clsInvoice invoice = new clsInvoice
                    {
                        IssueDate = DateTime.Now,
                        ReservationID = _Reservation.ReservationID,
                        Status = "مكتمل",
                        TotalAmount = _Reservation.TotalAmount - totalRefund // المبلغ النهائي بعد الاسترداد
                    };*/


                _Invoice.IssueDate = DateTime.Now;
                _Invoice.Status = "مدفوع";
                _Invoice.TotalAmount = _Reservation.TotalAmount - totalRefund;

                if (_Invoice.Save())
                {
                    _Payment.Status = cmbPaymentStatus.Text;
                    _Payment.Amount = _Invoice.TotalAmount;
                    _Payment.PaymentDate = DateTime.Now;

                    _Payment.Save(); // حفظ تفاصيل الدفع
                }

                // 7. عرض رسالة نجاح
                MessageBox.Show("تم تسجيل المغادرة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("خطأ: لم يتم تسجيل المغادرة بنجاح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancellationReservation_Click(object sender, EventArgs e)
        {
            // 1. تحقق من صحة البيانات
            _Reservation = clsReservation.Find(_ReservationID);
            if (_Reservation == null)
            {
                MessageBox.Show($"لا يوجد حجز بالمعرف: {_ReservationID}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. تحديث حالة الحجز
            _Reservation.Status = "Cancelled"; // تغيير الحالة إلى "ملغى"
            if (!_Reservation.Save())
            {

                MessageBox.Show("خطأ: لم يتم تحديث حالة الحجز.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
   
            if (_Room != null)
            {
                _Room.Status = "تنظيف"; // تغيير الحالة إلى "متاحة"
                _Room.Save();
            }

            // 4. إدارة الفواتير
         //   clsInvoice invoice = clsInvoice.FindByReservationID(_Reservation.ReservationID);

            if (_Invoice != null)
            {
                _Invoice.Status = "مستردة"; // تحديث حالة الفاتورة
                _Invoice.Save();
            }
            else
            {
                _Invoice = clsInvoice.FindByReservationID(_Reservation.ReservationID);
                _Invoice.Status = "مستردة"; // تحديث حالة الفاتورة
                _Invoice.Save();
            }
            // 5. عرض رسالة نجاح
            MessageBox.Show("تم إلغاء الحجز بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void ctrRoomCardWithFilter1_OnRoomSelected(int obj)
        {
            _Room = clsRoom.Find(obj);
            _RoomID = _Room.RoomID;
            lblTotalAmount.Text = _Room.Price.ToString();

        }

        private void numNumberOfNights_ValueChanged(object sender, EventArgs e)
        {
            dtbCheckOutDate.Value = dtbCheckInDate.Value.AddDays(Convert.ToUInt32(numNumberOfNights.Value));
            TimeSpan difference = dtbCheckOutDate.Value.Subtract(dtbCheckInDate.Value);

            int differenceInDays = difference.Days;

            lblTotalAmount.Text = (_Room.Price * differenceInDays).ToString();
        }
    }
}
