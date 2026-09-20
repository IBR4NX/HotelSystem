using Hotel_DataAccuss;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hotel_Buisness.clsUser;

namespace Hotel_Buisness
{
    public class clsRoom
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int NumberOfBeds { get; set; }
        public int MaxOccupancy { get; set; }

        public string NameRoom { get; set; }

        public decimal Price { get; set; }

        public clsRoomType RoomType { get; set; }
        // Available = متاح
        // Occupied =  مشغول 
        // Maintenance = صيانة
        // Reserved = محجوز
        // Cleaning = تنظيف

        public enum EStatus { Available = 1, Occupied = 2, Maintenance = 3, Reserved = 4, Cleaning =5 }
        public EStatus eStatus = EStatus.Available;

        // كونستركتر بدون معلمات مع قيم مبدئية
        public clsRoom()
        {
            RoomID = 0;
            RoomTypeID = 0;
            Status = "متاح";
            Description = "";
            NumberOfBeds = 1;
            MaxOccupancy = 1;
            NameRoom = "";
            Price = 0;
            Mode = enMode.AddNew;
            RoomType = new clsRoomType();
        }

        // كونستركتر يستقبل قيم
        public clsRoom(int roomID, int roomTypeID, string status, string description,
            int numberOfBeds, int maxOccupancy, string nameRoom, decimal price)
        {
            RoomID = roomID;
            RoomTypeID = roomTypeID;
            Status = status;
            Description = description;
            NumberOfBeds = numberOfBeds;
            MaxOccupancy = maxOccupancy;
            NameRoom = nameRoom;
            Price = price;
            Mode = enMode.Update;
            RoomType = clsRoomType.Find(roomTypeID);
        }


        public static DataTable GetAllRooms()
        {
            return clsRoomData.GetAllRooms();
        }


        private bool _AddNewRoom()
        {
            //call DataAccess Layer 
            //this.Password = ComputeHash(this.Password);
            this.RoomID = clsRoomData.AddNewRoom(this.RoomTypeID, this.Status, this.Description, this.NumberOfBeds,
                this.MaxOccupancy,NameRoom, this.Price);

            return (this.RoomID != -1);
        }
        private bool _UpdateRoom()
        {
            //call DataAccess Layer 
            // this.PasswordHash = ComputeHash(this.Password);

            return clsRoomData.UpdateRoom(this.RoomID, this.RoomTypeID, this.Status, this.Description, this.NumberOfBeds,
                this.MaxOccupancy, NameRoom, this.Price);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRoom())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateRoom();

            }

            return false;
        }



        public static clsRoom Find(int RoomID)
        {
            int RoomTypeID = 0;
            string Status = "متاح";
            string Description = "";
            int NumberOfBeds = 1;
            int MaxOccupancy = 1;
            string NameRoom = "";
            decimal Price = 0;

            if (clsRoomData.GetRoomInfoByRoomID(RoomID, ref RoomTypeID, ref Status, ref Description,
                ref NumberOfBeds, ref MaxOccupancy, ref NameRoom, ref Price))
                return new clsRoom(RoomID, RoomTypeID, Status, Description,
                NumberOfBeds, MaxOccupancy, NameRoom, Price);
            else
                return null;

        }

        public static clsRoom FindByNameRoom(string NameRoom)
        {
            int RoomID = 0;
            int RoomTypeID = 0;
            string Status = "متاح";
            string Description = "";
            int NumberOfBeds = 1;
            int MaxOccupancy = 1;
            decimal Price = 0;

            if (clsRoomData.GetRoomInfoByNameRoom(ref RoomID, ref RoomTypeID, ref Status, ref Description,
                ref NumberOfBeds, ref MaxOccupancy,  NameRoom, ref Price))
                return new clsRoom(RoomID, RoomTypeID, Status, Description,
                NumberOfBeds, MaxOccupancy, NameRoom, Price);
            else
                return null;

        }


        public static bool DeleteRoom(int RoomID)
        {
            return clsRoomData.DeleteRoom(RoomID);
        }

    }
}
