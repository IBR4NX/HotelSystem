using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;



namespace HotelManagement
    {
        public partial class ReportForm : Form
        {
            public ReportForm()
            {
                InitializeComponent();
            }

      

        private void ReportForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=.;Database=Hotel;User Id=sa;Password=123456;Trusted_Connection=true;"; // استبدلها بسلسلة الاتصال الخاصة بك

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // تقرير الإشغال
                SqlCommand cmdOccupancy = new SqlCommand(@"SELECT (SELECT COUNT(*) FROM Rooms WHERE Status = 'متاح') AS AvailableRooms, 
(SELECT COUNT(*) FROM Rooms WHERE Status = 'محجوز') AS 
OccupiedRooms", connection);
                SqlDataReader reader = cmdOccupancy.ExecuteReader();
                if (reader.Read())
                {
                    txtAvailableRooms.Text = reader["AvailableRooms"].ToString();
                    txtOccupiedRooms.Text = reader["OccupiedRooms"].ToString();
                }
                reader.Close();

                // تقرير الحجوزات
                SqlCommand cmdReservations = new SqlCommand("SELECT COUNT(*) AS TotalReservations, SUM(CASE WHEN Status = 'Confirmed' THEN 1 ELSE 0 END) AS ConfirmedReservations FROM Reservations", connection);
                reader = cmdReservations.ExecuteReader();
                if (reader.Read())
                {
                    txtTotalReservations.Text = reader["TotalReservations"].ToString();
                    txtConfirmedReservations.Text = reader["ConfirmedReservations"].ToString();
                }
                reader.Close();

                // تقرير المدفوعات
                SqlCommand cmdPayments = new SqlCommand("SELECT COUNT(*) AS TotalPayments, SUM(Amount) AS TotalAmount FROM Payments", connection);
                reader = cmdPayments.ExecuteReader();
                if (reader.Read())
                {
                    txtTotalPayments.Text = reader["TotalPayments"].ToString();
                    txtTotalAmount.Text = reader["TotalAmount"].ToString();
                }
                reader.Close();

                // تقرير الإيرادات اليومية
                SqlCommand cmdDailyRevenue = new SqlCommand("SELECT SUM(TotalAmount) AS DailyRevenue FROM Invoices WHERE IssueDate = CAST(GETDATE() AS DATE)", connection);
                reader = cmdDailyRevenue.ExecuteReader();
                if (reader.Read())
                {
                    txtDailyRevenue.Text = reader["DailyRevenue"].ToString();
                }
                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=.;Database=Hotel;User Id=sa;Password=123456;Trusted_Connection=true;"; // استبدلها بسلسلة الاتصال الخاصة بك

            // إنشاء مستند Word
            Word.Application wordApp = new Word.Application();
            Word.Document wordDoc = wordApp.Documents.Add();

            // إضافة عنوان للمستند
            Word.Paragraph title = wordDoc.Content.Paragraphs.Add();
            title.Range.Text = "تقارير الفندق";
            title.Range.Font.Size = 24; // تغيير حجم الخط
            title.Range.Font.Bold = 1; // جعل الخط عريض
            title.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            title.Range.InsertParagraphAfter();

            // إضافة مسافة بين العنوان والتقارير
            wordDoc.Content.InsertParagraphAfter();

            // إعداد الجدول
            Word.Table table = wordDoc.Tables.Add(wordDoc.Content, 1, 3);
            table.Borders.Enable = 1; // تفعيل حدود الجدول

            // إعداد رؤوس الجدول
            table.Cell(1, 1).Range.Text = "التقرير";
            table.Cell(1, 2).Range.Text = "القيمة";
            table.Cell(1, 3).Range.Text = "التاريخ";
            FormatTableHeader(table.Rows[1]);

            int rowIndex = 2;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // تقرير الإشغال
                SqlCommand cmdOccupancy = new SqlCommand(@"SELECT (SELECT COUNT(*) FROM Rooms WHERE Status = 'متاح') AS AvailableRooms, 
(SELECT COUNT(*) FROM Rooms WHERE Status = 'محجوز') AS 
OccupiedRooms", connection);
                SqlDataReader reader = cmdOccupancy.ExecuteReader();

                if (reader.Read())
                {
                    AddTableRow(table, rowIndex++, "عدد الغرف المتاحة", reader["AvailableRooms"].ToString());
                    AddTableRow(table, rowIndex++, "عدد الغرف المحجوزة", reader["OccupiedRooms"].ToString());
                }
                reader.Close();

                // تقرير الحجوزات
                SqlCommand cmdReservations = new SqlCommand("SELECT COUNT(*) AS TotalReservations, SUM(CASE WHEN Status = 'Confirmed' THEN 1 ELSE 0 END) AS ConfirmedReservations FROM Reservations", connection);
                reader = cmdReservations.ExecuteReader();

                if (reader.Read())
                {
                    AddTableRow(table, rowIndex++, "إجمالي الحجوزات", reader["TotalReservations"].ToString());
                    AddTableRow(table, rowIndex++, "عدد الحجوزات المؤكدة", reader["ConfirmedReservations"].ToString());
                }
                reader.Close();

                // تقرير المدفوعات
                SqlCommand cmdPayments = new SqlCommand("SELECT COUNT(*) AS TotalPayments, SUM(Amount) AS TotalAmount FROM Payments", connection);
                reader = cmdPayments.ExecuteReader();

                if (reader.Read())
                {
                    AddTableRow(table, rowIndex++, "إجمالي المدفوعات", reader["TotalPayments"].ToString());
                    AddTableRow(table, rowIndex++, "المبلغ الإجمالي", reader["TotalAmount"].ToString());
                }
                reader.Close();

                // تقرير الإيرادات اليومية
                SqlCommand cmdDailyRevenue = new SqlCommand("SELECT SUM(TotalAmount) AS DailyRevenue FROM Invoices WHERE IssueDate = CAST(GETDATE() AS DATE)", connection);
                reader = cmdDailyRevenue.ExecuteReader();

                if (reader.Read())
                {
                    AddTableRow(table, rowIndex++, "الإيرادات اليومية", reader["DailyRevenue"].ToString());
                }
                reader.Close();
            }

            // عرض المستند
            wordApp.Visible = true;
        }

        private void FormatTableHeader(Word.Row row)
        {
            for (int i = 1; i <= row.Cells.Count; i++)
            {
                row.Cells[i].Range.Font.Bold = 1; // جعل الخط عريض
                row.Cells[i].Range.Font.Size = 14; // تغيير حجم الخط
                row.Cells[i].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; // محاذاة المركز
            }
        }

        private void AddTableRow(Word.Table table, int rowIndex, string reportName, string value)
        {
            table.Rows.Add();
            table.Cell(rowIndex, 1).Range.Text = reportName;
            table.Cell(rowIndex, 2).Range.Text = value;
            table.Cell(rowIndex, 3).Range.Text = DateTime.Now.ToShortDateString();
            FormatTableRow(table.Rows[rowIndex]);
        }

        private void FormatTableRow(Word.Row row)
        {
            for (int i = 1; i <= row.Cells.Count; i++)
            {
                row.Cells[i].Range.Font.Size = 12; // تغيير حجم الخط
                row.Cells[i].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; // محاذاة المركز
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
