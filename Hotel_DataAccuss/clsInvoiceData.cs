using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataAccuss
{
    public class clsInvoiceData
    {


        public static DataTable GetAllInvoices()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);



            SqlCommand command = new SqlCommand("SP_GetAllInvoices", connection);

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
        public static int AddNewInvoice( int ReservationID, DateTime IssueDate,
            decimal TotalAmount, string Status)
        {
            int InvoiceID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand("SP_AddInvoices", connection);

            try
            {

                //إعداد الأمر
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                // إضافة المعلمات
                //string password = ComputeHash(table.PasswordHash);

                command.Parameters.AddWithValue("@ReservationID", ReservationID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                command.Parameters.AddWithValue("@Status", Status);
        
                // إعداد معلمة الخرج
                SqlParameter outputIdParam = new SqlParameter("@InvoiceID", SqlDbType.Int)
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
                InvoiceID = (int)command.Parameters["@InvoiceID"].Value;
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

            return InvoiceID;
        }


        // التعديل على شخص
        public static bool UpdateInvoice(int InvoiceID, int ReservationID, DateTime IssueDate,
            decimal TotalAmount, string Status)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_UpdateInvoices", connection);
            //إعداد الأمر
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
            command.Parameters.AddWithValue("@Status", Status);

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


        public static bool GetInvoiceInfoByInvoiceID(int InvoiceID, ref int ReservationID, ref DateTime IssueDate,
            ref decimal TotalAmount, ref string Status)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetInvoicesByInvoiceID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@InvoiceID", InvoiceID);




                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;

                            ReservationID = (int)reader["ReservationID"];
                            IssueDate = (DateTime)reader["IssueDate"];
                            TotalAmount = (decimal)reader["TotalAmount"];
                            Status = (string)reader["Status"];
           

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

        public static bool GetInvoiceInfoByReservationID(ref int InvoiceID,  int ReservationID, ref DateTime IssueDate,
    ref decimal TotalAmount, ref string Status)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetInvoicesByReservationID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@ReservationID", ReservationID);




                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;

                            InvoiceID = (int)reader["InvoiceID"];
                            IssueDate = (DateTime)reader["IssueDate"];
                            TotalAmount = (decimal)reader["TotalAmount"];
                            Status = (string)reader["Status"];


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



        // حذف مستخدم
        public static bool DeletInvoice(int InvoiceID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Invoices
                          where InvoiceID = @InvoiceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

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


    }
}
