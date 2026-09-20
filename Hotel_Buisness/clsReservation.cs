using Hotel_DataAccuss;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    // الحجوزات
    public class clsReservation
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ReservationID { get; set; }
        public int GuestID { get; set; }// رقم النزيل
        public int RoomID { get; set; }// رقم الغرفة
        public int UserID { get; set; }// رقم المستخدم الذي قام بانشاء الحجز
        public DateTime CheckInDate { get; set; }// موعد الدخول
        public DateTime CheckOutDate { get; set; }// موعد الخروج
        public int NumberOfGuests { get; set; }// عدد النزلاء
        public string Status { get; set; } // مثل Confirmed, Cancelled
        public DateTime CreatedAt { get; set; }// تاريخ انشاء الحجز
        public decimal TotalAmount { get; set; }// المبلغ النهائي للحجز
        // Confirmed = قيد الحجز
        // Cancelled = ملغي
        // Completed = منتهي
        public clsGuest  Guest { get; set; }
        public clsRoom Room { get; set; }
        public clsUser  User { get; set; }
        public enum EState { Confirmed = 1, Cancelled = 2, Completed = 3 }
        public EState eState { get; set; }

        // كونستركتر بدون معلمات مع قيم مبدئية
        public clsReservation()
        {
            ReservationID = 0;
            GuestID = 0;
            RoomID = 0;
            UserID = 0;
            CheckInDate = DateTime.Now;
            CheckOutDate = DateTime.Now.AddDays(1);
            NumberOfGuests = 1;
            Status = "Confirmed";
            CreatedAt = new DateTime();
            TotalAmount = 0;
            eState = EState.Confirmed;
            Mode = enMode.AddNew;
        }

        // كونستركتر يستقبل قيم
        public clsReservation(int reservationID, int guestID, int roomID, int userID,
            DateTime checkInDate, DateTime checkOutDate,
            int numberOfGuests, string status, DateTime createAt, decimal totalAmount)
        {
            ReservationID = reservationID;
            GuestID = guestID;
            RoomID = roomID;
            UserID = userID;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            NumberOfGuests = numberOfGuests;
            Status = status;
            CreatedAt = createAt;
            TotalAmount = totalAmount;
            eState = EState.Confirmed;
            Mode = enMode.Update;
            Guest = clsGuest.Find(guestID);
            Room = clsRoom .Find(roomID);   
            User = clsUser.FindByUserID(userID);
        }


        private bool _AddNewReservation()
        {
            //call DataAccess Layer 
            //this.Password = ComputeHash(this.Password);
            this.ReservationID = clsReservationData.AddNewReservation(this.GuestID, this.RoomID, this.UserID,
                this.CheckInDate, this.CheckOutDate, this.NumberOfGuests, this.Status, this.CreatedAt,
                this.TotalAmount);

            return (this.ReservationID != -1);
        }
        private bool _UpdateReservation()
        {
            //call DataAccess Layer 
            // this.PasswordHash = ComputeHash(this.Password);

            return clsReservationData.UpdateReservation(this.ReservationID, this.GuestID, this.RoomID, this.UserID,
                this.CheckInDate, this.CheckOutDate, this.NumberOfGuests, this.Status, this.CreatedAt,
                this.TotalAmount);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReservation())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateReservation();

            }

            return false;
        }

        // يرجع لي المستخدم على حسب اسمة وكلمة السر
        public static clsReservation GetReservationInfoByRoomID(int RoomID)
        {
            int ReservationID = 0;
            int GuestID = 0;
            int UserID = 0;
            DateTime CheckInDate = DateTime.Now;
            DateTime CheckOutDate = DateTime.Now.AddDays(1);
            int NumberOfGuests = 1;
            string Status = "Confirmed";
            decimal TotalAmount = 0;
            DateTime CreatedAt = new DateTime();


            bool IsActive = false;

            //Password = ComputeHash(Password);

            bool IsFound = clsReservationData.GetReservationInfoByRoomID(ref ReservationID, ref GuestID, RoomID, ref UserID,
            ref CheckInDate, ref CheckOutDate,
            ref NumberOfGuests, ref Status, ref CreatedAt, ref TotalAmount);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsReservation(ReservationID, GuestID, RoomID, UserID,
                CheckInDate, CheckOutDate, NumberOfGuests, Status, CreatedAt,
                TotalAmount);
            else
                return null;
        }

        public static clsReservation Find(int ReservationID)
        {
            int RoomID = 0;
            int GuestID = 0;
            int UserID = 0;
            DateTime CheckInDate = DateTime.Now;
            DateTime CheckOutDate = DateTime.Now.AddDays(1);
            int NumberOfGuests = 1;
            string Status = "Confirmed";
            decimal TotalAmount = 0;
            DateTime CreatedAt = new DateTime();


            bool IsActive = false;

            //Password = ComputeHash(Password);

            bool IsFound = clsReservationData.GetReservationInfoByReservationID( ReservationID, ref GuestID, ref RoomID, ref UserID,
            ref CheckInDate, ref CheckOutDate,
            ref NumberOfGuests, ref Status, ref CreatedAt, ref TotalAmount);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsReservation(ReservationID, GuestID, RoomID, UserID,
                CheckInDate, CheckOutDate, NumberOfGuests, Status, CreatedAt,
                TotalAmount);
            else
                return null;
        }

        public static bool DeleteReservation(int ReservationID)
        {
            return clsReservationData.DeleteReservation(ReservationID);
        }


        public static DataTable GetAllReservations()
        {
            return clsReservationData.GetAllReservations();
        }


    }
}
