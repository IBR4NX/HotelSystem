using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataAccuss
{
    public class clsGuestData
    {
        // ارجاع كل المستخدمين
        public static DataTable GetAllGuests()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);



            SqlCommand command = new SqlCommand("SP_GetAllGuests", connection);

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


        public static bool GetGuestsByIdentityNumber(ref int GuestID, ref string FirstName, ref string LastName, ref string Email,
            ref string Phone, ref string Address, ref DateTime CreatedAt, string IdentityNumber)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetGuestsByIdentityNumber", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@IdentityNumber", IdentityNumber);




                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;
                   
                            GuestID = (int)reader["GuestID"];
            
                            FirstName = (string)reader["FirstName"];
                            LastName = (string)reader["LastName"];
                            Email = (string)reader["Email"];
                            Phone = (string)reader["Phone"];
                            Address = (string)reader["Address"];
                            CreatedAt = (DateTime)reader["CreatedAt"];


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


        public static bool GetGuestsByGuestID( int GuestID, ref string FirstName, ref string LastName, ref string Email,
        ref string Phone, ref string Address, ref DateTime CreatedAt, ref string IdentityNumber)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetGuestsByGuestID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@GuestID", GuestID);




                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;


                            FirstName = (string)reader["FirstName"];
                            LastName = (string)reader["LastName"];
                            Email = (string)reader["Email"];
                            Phone = (string)reader["Phone"];
                            Address = (string)reader["Address"];
                            CreatedAt = (DateTime)reader["CreatedAt"];
                            IdentityNumber = (string)reader["IdentityNumber"];


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



        // اضافة مستخدم
        public static int AddNewGuest(string FirstName, string LastName, string Email,
             string Phone, string Address, DateTime CreatedAt, string IdentityNumber)
        {
            int GuestID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand("SP_AddGuest", connection);

            try
            {

                //إعداد الأمر
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                // إضافة المعلمات
                //string password = ComputeHash(table.PasswordHash);

                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@Email", Email);
           
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
                command.Parameters.AddWithValue("@IdentityNumber", IdentityNumber);
                //command.Parameters.AddWithValue("@CreatedAt", Role);


                // إعداد معلمة الخرج
                SqlParameter outputIdParam = new SqlParameter("@GuestID", SqlDbType.Int)
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
                GuestID = (int)command.Parameters["@GuestID"].Value;
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

            return GuestID;
        }


        // التعديل على شخص
        public static bool UpdateGuest(int GuestID, string FirstName, string LastName, string Email,
             string Phone, string Address, DateTime CreatedAt, string IdentityNumber)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_UpdateGuest", connection);
            //إعداد الأمر
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@GuestID", GuestID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@IdentityNumber", IdentityNumber);
            command.Parameters.AddWithValue("@Phone", Phone);

            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (Address != "" && Address != null)
                command.Parameters.AddWithValue("@Address", Address);
            else
                command.Parameters.AddWithValue("@Address", System.DBNull.Value);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);


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
        public static bool DeleteGuest(int GuestID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Guests 
                                where GuestID = @GuestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@GuestID", GuestID);

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

        //هل المستخدم موجود من خلال اسم المستخدم
        public static bool IsGuestExist(string IdentityNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Guests WHERE IdentityNumber = @IdentityNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IdentityNumber", IdentityNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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


    }
}
