using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataAccuss
{
    public class clsReservationData
    {


        public static DataTable GetAllReservations()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);



            SqlCommand command = new SqlCommand("SP_GetAllReservations", connection);

            try
            {
                connection.Open();


                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }


        // اضافة مستخدم
        public static int AddNewReservation(int GuestID, int RoomID, int UserID,
            DateTime CheckInDate, DateTime CheckOutDate,
            int NumberOfGuests, string Status, DateTime CreateAt, decimal TotalAmount)
        {
            int  ReservationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand("SP_AddReservation", connection);

            try
            {

                //إعداد الأمر
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                // إضافة المعلمات
                //string password = ComputeHash(table.PasswordHash);

                command.Parameters.AddWithValue("@GuestID", GuestID);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@RoomID", RoomID);
                command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
                command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);
                command.Parameters.AddWithValue("@NumberOfGuests", NumberOfGuests);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@CreatedAt", CreateAt);
                command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
              

                // إعداد معلمة الخرج
                SqlParameter outputIdParam = new SqlParameter("@ReservationID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);


                // Execute
                //تنفيذ الأمر
                connection.Open();
                command.ExecuteNonQuery();


                // Retrieve the ID of the new person
                //استرجاع معرف الشخص الجديد 
                ReservationID = (int)command.Parameters["@ReservationID"].Value;
                connection.Close();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return ReservationID;
        }


        // التعديل على شخص
        public static bool UpdateReservation(int ReservationID, int GuestID, int RoomID, int UserID,
            DateTime CheckInDate, DateTime CheckOutDate,
            int NumberOfGuests, string Status, DateTime CreateAt, decimal TotalAmount)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_UpdateReservation", connection);
            //إعداد الأمر
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ReservationID", ReservationID);
            command.Parameters.AddWithValue("@GuestID", GuestID);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
            command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);
            command.Parameters.AddWithValue("@NumberOfGuests", NumberOfGuests);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@CreatedAt", CreateAt);
            command.Parameters.AddWithValue("@TotalAmount", TotalAmount);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }


            return (rowsAffected > 0);
        }

        public static bool GetReservationInfoByRoomID(ref int ReservationID, ref int GuestID, int RoomID, ref int UserID,
            ref DateTime CheckInDate, ref DateTime CheckOutDate,
            ref int NumberOfGuests, ref string Status, ref DateTime CreateAt, ref decimal TotalAmount)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Reservations.*
    FROM Reservations
    INNER JOIN Rooms ON Reservations.RoomID = Rooms.RoomID
    WHERE Reservations.Status = 'Confirmed'
      AND Rooms.Status = 'محجوز'
      AND Rooms.RoomID = @RoomID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    ReservationID = (int)reader["ReservationID"];
                    GuestID = (int)reader["GuestID"];
                    UserID = (int)reader["UserID"];

                    CheckInDate = (DateTime)reader["CheckInDate"];
                    CheckOutDate = (DateTime)reader["CheckOutDate"];
                    NumberOfGuests = (int)reader["NumberOfGuests"];
                    Status = (string)reader["Status"];
                  
                    CreateAt = (DateTime)reader["CreatedAt"];
                    TotalAmount = (decimal)reader["TotalAmount"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }



        public static bool GetReservationInfoByReservationID(int ReservationID, ref int GuestID, ref int RoomID, ref int UserID,
      ref DateTime CheckInDate, ref DateTime CheckOutDate,
      ref int NumberOfGuests, ref string Status, ref DateTime CreateAt, ref decimal TotalAmount)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Reservations
                  where ReservationID = @ReservationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReservationID", ReservationID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    RoomID = (int)reader["RoomID"];
                    GuestID = (int)reader["GuestID"];
                    UserID = (int)reader["UserID"];

                    CheckInDate = (DateTime)reader["CheckInDate"];
                    CheckOutDate = (DateTime)reader["CheckOutDate"];
                    NumberOfGuests = (int)reader["NumberOfGuests"];
                    Status = (string)reader["Status"];

                    CreateAt = (DateTime)reader["CreatedAt"];
                    TotalAmount = (decimal)reader["TotalAmount"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




        public static bool DeleteReservation(int ReservationID)
        {
            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete from Reservations
                                where ReservationID = @ReservationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);
            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


    }
}
