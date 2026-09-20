using Hotel_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Reservations
{
    public partial class frmListAddReservation : Form
    {
        private DataTable _dtAllRooms;

        public frmListAddReservation()
        {
            InitializeComponent();
           // this.panel1.Paint += new PaintEventHandler(this.panel1_Paint_1);

        }

        private void AddReservation_Load(object sender, EventArgs e)
        {
            /*_dtAllRooms = clsRoom.GetAllRooms();
            // ضبط مكان لعرض الغرف (مثل FlowLayoutPanel)
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            this.Controls.Add(flowLayoutPanel);

            // إنشاء غرفة لكل صف في الجدول وعرضها
            foreach (DataRow row in _dtAllRooms.Rows)
            {
                ctrRoome roomControl = new ctrRoome(
                    row["RoomID"].ToString(),
                    row["NumberOfBeds"].ToString(),
                    row["NameRoom"].ToString(),
                    (decimal)row["Price"],
                    row["Status"].ToString(),
                    (int)row["RoomID"]
                );
                roomControl.OnLoadeRooms += LoadeRooms;
                //roomControl.OnLoadeRooms.Inv
                flowLayoutPanel.Controls.Add(roomControl); // إضافة للتحكم في الـ FlowLayoutPanel
            }
*/

            LoadRooms();

        }

        private void LoadRooms()
        {
          //  this.Controls.Clear();
            // الحصول على بيانات الغرف
            _dtAllRooms = clsRoom.GetAllRooms();

            // ضبط مكان لعرض الغرف (مثل FlowLayoutPanel)
            /* FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
             {
                 Dock = DockStyle.Fill
             };
             this.Controls.Add(flowLayoutPanel);
             flowLayoutPanel.Controls.Clear();*/ // مسح المحتوى الحالي

            flowLayoutPanel1.Controls.Clear();  
            // إنشاء غرفة لكل صف في الجدول وعرضها
            foreach (DataRow row in _dtAllRooms.Rows)
            {
                ctrRoome roomControl = new ctrRoome(
                    row["RoomID"].ToString(),
                    row["NumberOfBeds"].ToString(),
                    row["NameRoom"].ToString(),
                    (decimal)row["Price"],
                    row["Status"].ToString(),
                    (int)row["RoomID"]
                );
                roomControl.OnLoadeRooms += LoadeRooms2; // ربط الحدث
               // flowLayoutPanel.Controls.Add(roomControl); // إضافة التحكم في الـ FlowLayoutPanel
                this.flowLayoutPanel1.Controls.Add(roomControl); // إضافة التحكم في الـ FlowLayoutPanel
            }
            lblRecordsCount.Text = _dtAllRooms.Rows.Count.ToString();
        }

        private void LoadeRooms2(int d)
        {
             //MessageBox.Show("تم النقر على الزر داخل CustomButtonControl!");
            //this.Refresh();
            // AddReservation_Load(null, null);
           // this.Controls.Clear();
            LoadRooms();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {

            LoadRoomsBy("متاح");
        }


        private void LoadRoomsBy(string filter)
        {
           
            // الحصول على بيانات الغرف
            _dtAllRooms = clsRoom.GetAllRooms();

          
            flowLayoutPanel1.Controls.Clear();
            int Count = 0;
            // إنشاء غرفة لكل صف في الجدول وعرضها
            foreach (DataRow row in _dtAllRooms.Rows)
            {
                if (row["Status"].ToString() == filter)
                {
                    ctrRoome roomControl = new ctrRoome(
                        row["RoomID"].ToString(),
                        row["NumberOfBeds"].ToString(),
                        row["NameRoom"].ToString(),
                        (decimal)row["Price"],
                        row["Status"].ToString(),
                        (int)row["RoomID"]
                    );
                    Count++;
                    roomControl.OnLoadeRooms += LoadeRooms2; // ربط الحدث
                    //flowLayoutPanel.Controls.Add(roomControl); // إضافة التحكم في الـ FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(roomControl); // إضافة التحكم في الـ FlowLayoutPanel
                }
            }
            lblRecordsCount.Text = Count.ToString();

        }
        private void button2_Click(object sender, EventArgs e)
        {

            LoadRoomsBy("محجوز");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Controls.flowLayoutPanel.Clear();
            LoadRooms();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadRoomsBy("تنظيف");

        }
    }
}
