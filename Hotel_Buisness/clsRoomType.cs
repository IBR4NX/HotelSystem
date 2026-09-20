using Hotel_DataAccuss;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsRoomType
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string Description { get; set; }

        // كونستركتر بدون معلمات مع قيم مبدئية
        public clsRoomType()
        {
            RoomTypeID = 0;
            RoomTypeName = "";
            Description = "";
        }

        // كونستركتر يستقبل قيم
        public clsRoomType(int roomTypeID, string roomTypeName, string description)
        {
            RoomTypeID = roomTypeID;
            RoomTypeName = roomTypeName;
            Description = description;
        }


        public static DataTable GetAllRoomTypeData()
        {
            return clsRoomTypeData.GetAllRoomTypeData();
        }


        public static clsRoomType Find(string RoomTypeName)
        {
            int RoomTypeID = -1;
            string Description = "";

            if (clsRoomTypeData.GetRoomTypeInfoByRoomTypeName(ref RoomTypeID,  RoomTypeName, ref Description))
                return new clsRoomType(RoomTypeID, RoomTypeName, Description);
            else
                return null;

        }

        public static clsRoomType Find(int RoomTypeID)
        {
            string RoomTypeName = "";
            string Description = "";

            if (clsRoomTypeData.GetRoomTypeInfoByRoomTypeID( RoomTypeID, ref RoomTypeName, ref Description))
                return new clsRoomType(RoomTypeID, RoomTypeName, Description);
            else
                return null;

        }
    }
}
