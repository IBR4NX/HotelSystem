using Hotel_DataAccuss;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsGuest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int GuestID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt {  get; set; }
        public string IdentityNumber { get; set; }

        // كونستركتر
        public clsGuest(int guestID, string firstName, string lastName, string email,
            string phone, string address, DateTime createdAt, string IdentityNumber)
        {
            this.GuestID = guestID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
            this.CreatedAt = createdAt;
            this.IdentityNumber = IdentityNumber;
            Mode = enMode.Update;

        }

        public clsGuest()
        {
            GuestID = 0;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            CreatedAt = new DateTime();
            IdentityNumber = "";
            Mode = enMode.AddNew;
        }


        public static DataTable GetAllGuests()
        {
            return clsGuestData.GetAllGuests();
        }


        private bool _AddNewGuest()
        {
          
            this.GuestID = clsGuestData.AddNewGuest(this.FirstName, this.LastName, this.Email,
         this.Phone, this.Address, this.CreatedAt, this.IdentityNumber);

            return (this.GuestID != -1);
        }
        private bool _UpdateGuest()
        {
            //call DataAccess Layer 
            // this.PasswordHash = ComputeHash(this.Password);

            return clsGuestData.UpdateGuest(this.GuestID, this.FirstName, this.LastName, this.Email,
         this.Phone, this.Address, this.CreatedAt, this.IdentityNumber);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewGuest())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateGuest();

            }

            return false;
        }



        public static clsGuest Find(int GuestID)
        {
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            DateTime CreatedAt = new DateTime();
            string IdentityNumber = "";

            if (clsGuestData.GetGuestsByGuestID(GuestID, ref FirstName, ref LastName, ref Email,
        ref  Phone, ref Address, ref CreatedAt, ref  IdentityNumber))
                return new clsGuest(GuestID, FirstName, LastName, Email,
         Phone,  Address,  CreatedAt,  IdentityNumber);
            else
                return null;

        }

        public static clsGuest FindByIdentityNumber(string IdentityNumber)
        {
            int GuestID = -1;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            DateTime CreatedAt = new DateTime();

            if (clsGuestData.GetGuestsByIdentityNumber(ref GuestID, ref FirstName, ref LastName, ref Email,
        ref Phone, ref Address, ref CreatedAt,  IdentityNumber))
                return new clsGuest(GuestID, FirstName, LastName, Email,
         Phone, Address, CreatedAt, IdentityNumber);
            else
                return null;

        }

        public static bool DeleteGuest(int GuestID)
        {
            return clsGuestData.DeleteGuest(GuestID);
        }

        public static bool IsGuestExist(string IdentityNumber)
        {
            return clsGuestData.IsGuestExist(IdentityNumber);
        }

    }
}
