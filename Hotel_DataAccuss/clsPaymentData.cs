using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataAccuss
{
    public class clsPaymentData
    {

        public static DataTable GetAllPayments()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);



            SqlCommand command = new SqlCommand("SP_GetAllPayments", connection);

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
        public static int AddNewPayment( int InvoiceID, decimal Amount, DateTime PaymentDate,
            string Status)
        {
            int PaymentID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand("SP_AddPayment", connection);

            try
            {

                //إعداد الأمر
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                // إضافة المعلمات
                //string password = ComputeHash(table.PasswordHash);

                command.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                command.Parameters.AddWithValue("@Amount", Amount);
                command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                command.Parameters.AddWithValue("@Status", Status);

                // إعداد معلمة الخرج
                SqlParameter outputIdParam = new SqlParameter("@PaymentID", SqlDbType.Int)
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
                PaymentID = (int)command.Parameters["@PaymentID"].Value;
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

            return PaymentID;
        }


        // التعديل على شخص
        public static bool UpdatePayment(int PaymentID, int InvoiceID, decimal Amount, DateTime PaymentDate,
            string Status)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            SqlCommand command = new SqlCommand("SP_UpdatePayment", connection);
            //إعداد الأمر
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PaymentID", PaymentID);
            command.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
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


        public static bool GetPaymentInfoByInvoiceID(ref int PaymentID, int InvoiceID, ref decimal Amount, ref DateTime PaymentDate,
            ref string Status)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                 
                    using (SqlCommand command = new SqlCommand("SP_GetPaymentByInvoiceID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@InvoiceID", InvoiceID);




                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;
                         
                            PaymentID = (int)reader["PaymentID"];
                            Amount = (decimal)reader["Amount"];
                            PaymentDate = (DateTime)reader["PaymentDate"];
                     
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



        public static bool GetPaymentInfoByPaymentID(int PaymentID, ref int InvoiceID, ref decimal Amount, ref DateTime PaymentDate,
            ref string Status)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                   
                    using (SqlCommand command = new SqlCommand("SP_GetPaymentByPaymentID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@PaymentID", PaymentID);




                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;

                            InvoiceID = (int)reader["InvoiceID"];
                            Amount = (decimal)reader["Amount"];
                            PaymentDate = (DateTime)reader["PaymentDate"];

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

        public static bool DeletePayment(int PaymentID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Payments
                        where PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PaymentID", PaymentID);

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
