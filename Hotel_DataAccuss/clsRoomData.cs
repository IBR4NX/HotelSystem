using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataAccuss
{
    public class clsRoomData
    {

        // ارجاع كل الغرف
        public static DataTable GetAllRooms()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);



            SqlCommand command = new SqlCommand("SP_GetAllRooms", connection);

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
        public static int AddNewRoom( int RoomTypeID, string Status, string Description,
            int NumberOfBeds, int MaxOccupancy, string NameRoom, decimal Price)
        {
            int RoomID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand("SP_AddRoom", connection);

            try
            {

                //إعداد الأمر
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                // إضافة المعلمات
                //string password = ComputeHash(table.PasswordHash);

                command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@NumberOfBeds", NumberOfBeds);
                command.Parameters.AddWithValue("@MaxOccupancy", MaxOccupancy);
                command.Parameters.AddWithValue("@NameRoom", NameRoom);
                command.Parameters.AddWithValue("@Price", Price);
                //command.Parameters.AddWithValue("@CreatedAt", Role);

                if (Description != "" && Description != null)
                    command.Parameters.AddWithValue("@Description", Description);
                else
                    command.Parameters.AddWithValue("@Description", System.DBNull.Value);
                // إعداد معلمة الخرج
                SqlParameter outputIdParam = new SqlParameter("@RoomID", SqlDbType.Int)
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
                RoomID = (int)command.Parameters["@RoomID"].Value;
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

            return RoomID;
        }


        // التعديل على شخص
        public static bool UpdateRoom(int RoomID, int RoomTypeID, string Status, string Description,
            int NumberOfBeds, int MaxOccupancy, string NameRoom, decimal Price)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_UpdateRoom", connection);
            //إعداد الأمر
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@RoomID", RoomID);

            command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@NumberOfBeds", NumberOfBeds);
            command.Parameters.AddWithValue("@MaxOccupancy", MaxOccupancy);
            command.Parameters.AddWithValue("@NameRoom", NameRoom);
            command.Parameters.AddWithValue("@Price", Price);
            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Description", Description);
            else
                command.Parameters.AddWithValue("@Description", System.DBNull.Value);


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
        // حذف مستخدم
        public static bool DeleteRoom(int RoomID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Rooms 
                                 WHERE RoomID = @RoomID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool GetRoomInfoByRoomID(int RoomID,ref int RoomTypeID, ref string Status, ref string Description,
           ref int NumberOfBeds, ref int MaxOccupancy, ref string NameRoom, ref decimal Price)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetRoomByRoomRoomID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@RoomID", RoomID);




                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;

                            RoomTypeID = (int)reader["RoomTypeID"];
                            Status = (string)reader["Status"];
                            NumberOfBeds = (int)reader["NumberOfBeds"];
                            MaxOccupancy = (int)reader["MaxOccupancy"];
                            Price = (decimal)reader["Price"];
                            NameRoom = (string)reader["NameRoom"];
                            if (reader["Description"] != DBNull.Value)
                            {
                                Description = (string)reader["Description"];
                            }
                            else
                            {
                                Description = "";
                            }

                        }
                        else
                        {
                            // The record was not found
                            isFound = false;
                        }

                        reader.Close();


                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }


            return isFound;
        }


        public static bool GetRoomInfoByNameRoom(ref int RoomID, ref int RoomTypeID, ref string Status, ref string Description,
       ref int NumberOfBeds, ref int MaxOccupancy,  string NameRoom, ref decimal Price)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetRoomsByNameRoom", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@NameRoom", NameRoom);




                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;
                            RoomID = (int)reader["RoomID"];
                            RoomTypeID = (int)reader["RoomTypeID"];
                            Status = (string)reader["Status"];
                            NumberOfBeds = (int)reader["NumberOfBeds"];
                            MaxOccupancy = (int)reader["MaxOccupancy"];
                            Price = (decimal)reader["Price"];
                           
                            if (reader["Description"] != DBNull.Value)
                            {
                                Description = (string)reader["Description"];
                            }
                            else
                            {
                                Description = "";
                            }

                        }
                        else
                        {
                            // The record was not found
                            isFound = false;
                        }

                        reader.Close();


                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }


            return isFound;
        }


    }
}
