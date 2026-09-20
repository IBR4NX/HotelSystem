using Hotel_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Hotel.Reservations
{
    public partial class ctrRoome : UserControl
    {
      /*  public EStatus Status
        {
            get { return _eStatus; }
            set
            {
                _eStatus = value;
                panel1.Invalidate(); // طلب إعادة رسم panel1 عند تغيير الحالة
          * }
        }*/
        // حدث اعادة تحميل الغرف
        public event Action<int> OnLoadeRooms;
        // Create a protected method to raise the event with a parameter
        protected virtual void LoadeRooms(int RoomID )
        {
            Action<int> handler = OnLoadeRooms;
            if (handler != null)
            {
                handler(RoomID); // Raise the event with the parameter
            }
        }




        private int _RoomID = -1;
        clsRoom _Room;
        clsReservation _Reservation;
        int _ReservationID = -1;
        // Available = متاح
        // Occupied =  مشغول 
        // Maintenance = صيانة
        // Reserved = محجوز
        // Cleaning = تنظيف
        public enum EStatus { Available = 1, Occupied = 2, Maintenance = 3, Reserved = 4, Cleaning = 5 }
        private EStatus _eStatus = EStatus.Available;
        public EStatus Status
        {
            get { return _eStatus; }
            set
            {
                if (_eStatus != value) // تحقق من عدم تكرار القيمة
                {
                    _eStatus = value;

                    OnStatusChanged();
                    //panel1.Invalidate(); // طلب إعادة رسم panel1 عند تغيير الحالة
                }
            }
        }


  
        // طريقة لتحديث الرسم
        private void OnStatusChanged()
        {
            Color borderColor;

          //  _Room = new clsRoom();
            
            switch (_eStatus)
            {
                case EStatus.Available:
                    borderColor = Color.Green;
                    btn.ForeColor = Color.Green;
                    btn.Text = "حجز";
                    btn.Enabled = true;
                    btnCleaning.Visible = false;
                    btn.Visible = true;
                    break;
                case EStatus.Reserved:
                case EStatus.Occupied:
                    borderColor = Color.Red;
                    btn.Text = "ادارة الحجز";
                    btn.ForeColor = Color.Red;
                    btn.Enabled = true;
                    btn.Visible = true;

                    break;
                case EStatus.Cleaning:
                    borderColor = Color.Orange;
                    btn.Text = "غير متاح";
                    btnCleaning.Visible = true;
                    btn.Visible = true;

                    break;
                case EStatus.Maintenance:
                    borderColor = Color.Yellow;
                    btn.Text = "غير متاح";
                    btn.Visible = false;
                    break;
                default:
                    borderColor = Color.Transparent;
                    btn.Text = "غير متاح";
                    btn.Visible = false;
                    break;
            }

            
            // رسم الحدود
            using (Graphics g = panel1.CreateGraphics())
            {
               // g.DrawRectangle(new Pen(Color.White, 5), 0, 0, panel1.Width - 1, panel1.Height - 1);

                g.DrawRectangle(new Pen(borderColor, 5), 0, 0, panel1.Width - 1, panel1.Height - 1);
            }

            //setDataRoom(_Room.RoomID.ToString(), _Room.NumberOfBeds.ToString(), _Room.RoomTypeID.ToString(), _Room.Price, _Room.Status);

            // يمكنك أيضًا عرض النص على زر أو عنصر واجهة مستخدم آخر إذا لزم الأمر
            // button.Text = buttonText; // إذا كان لديك زر لعرض النص
        }
        public ctrRoome(string roomID, string NumberOfBeds, string roomType, decimal price, string status, int RoomID = -1)
        {
            InitializeComponent();

            if (status == "متاح")
            {
                _eStatus = EStatus.Available;
            }
            else if (status == "محجوز")
            {
                _eStatus = EStatus.Reserved;
            }
            else if(status == "تنظيف")
            {
                _eStatus = EStatus.Cleaning;
            }
            else if(status == "صيانة")
            {
                _eStatus = EStatus.Maintenance;
            }
            else
            {
                _eStatus = EStatus.Occupied;    
            }
            lblNumberOfBeds.Text = NumberOfBeds;
            lblRoomType.Text = roomType;
            lblRoomID.Text = roomID;
            lblPrice.Text = price.ToString();
            lblState.Text = status;
            //lblDate.Text = DateTime.Now.ToString("yyyy-mm-dd");

            _RoomID = Convert.ToInt32(roomID);
            //(([Status]='تنظيف' OR [Status]='محجوز' OR [Status]='صيانة' OR [Status]='مشغول' OR [Status]='متاح')

            _Reservation = clsReservation.GetReservationInfoByRoomID(RoomID);
            if( _Reservation != null)
            {
                _ReservationID = _Reservation.ReservationID;

            }

            //setDataRoom( roomID, NumberOfBeds, roomType, price, status);
            // GetReservationInfoByRoomID

        }

      
        private void ctrRoome_Load(object sender, EventArgs e)
        {
            //groupBox1.BorderStyle = BorderStyle.FixedSingle;
        }



        private void panel1_Click(object sender, EventArgs e)
        {
            AddUpdateReservation frm = new AddUpdateReservation(_RoomID);
            frm.ShowDialog();
        }

   


        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (_eStatus == EStatus.Available)
            {
                g.DrawRectangle(new Pen(Color.Green, 5), 0, 0, panel1.Width - 1, panel1.Height - 1);
                btn.Text = "حجز";
                btn.Enabled = true;
            }
            else if (_eStatus == EStatus.Reserved || _eStatus == EStatus.Occupied)
            {
                g.DrawRectangle(new Pen(Color.Red, 5), 0, 0, panel1.Width - 1, panel1.Height - 1);
                btn.Text = "ادارة الحجز";
                btn.ForeColor = Color.Red;
                btn.Enabled = true;
            }
            else if (_eStatus == EStatus.Cleaning)
            {
                g.DrawRectangle(new Pen(Color.Orange, 5), 0, 0, panel1.Width - 1, panel1.Height - 1);
                btn.Text = "غير متاح";
                btn.Visible = false;
                btnCleaning.Visible = true;
            }
            else if (_eStatus == EStatus.Maintenance)
            {
                g.DrawRectangle(new Pen(Color.Yellow, 5), 0, 0, panel1.Width - 1, panel1.Height - 1);
                btn.Text = "غير متاح";
                btn.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_ReservationID != -1)
            {
                AddUpdateReservation frm = new AddUpdateReservation(_RoomID, _ReservationID);
                frm.ShowDialog();
            }
            else
            {
                AddUpdateReservation frm = new AddUpdateReservation(_RoomID);
                frm.ShowDialog();
            }
            _Room = clsRoom.Find(_RoomID);
            
            ReFreshctrRoom();
            if (OnLoadeRooms != null)
                // Raise the event with a parameter
                LoadeRooms(_RoomID);

        }

        private void ReFreshctrRoom()
        {
            
       
            lblNumberOfBeds.Text = _Room.NumberOfBeds.ToString();
            lblRoomType.Text = _Room.RoomTypeID.ToString();
            lblRoomID.Text = _Room.RoomID.ToString();
            lblPrice.Text = _Room.Price.ToString();
            lblState.Text = _Room.Status;
            //lblDate.Text = DateTime.Now.ToString("yyyy-mm-dd");

            if (_Room.Status == "متاح")
            {
                _eStatus = EStatus.Available;
                _ReservationID = -1;
                
            }
            else if (_Room.Status == "محجوز")
            {
                _eStatus = EStatus.Reserved;
                _Reservation = clsReservation.GetReservationInfoByRoomID(_Room.RoomID);
                _ReservationID = _Reservation.ReservationID;

            }
            else if (_Room.Status == "تنظيف")
            {
                _eStatus = EStatus.Cleaning;
                _ReservationID = -1;

            }
            else if (_Room.Status == "صيانة")
            {
                _eStatus = EStatus.Maintenance;
                _ReservationID = -1;

            }
            else
            {
                _eStatus = EStatus.Occupied;
            }
            OnStatusChanged();
        }

        private void btnCleaning_Click(object sender, EventArgs e)
        {
            _Room = clsRoom.Find(_RoomID);

            _Room.Status = "متاح";
            _Room.Save();
            ReFreshctrRoom();
            // _RoomID = Convert.ToInt32(roomID);
            if (OnLoadeRooms != null)
                // Raise the event with a parameter
                LoadeRooms(_RoomID);
        }
    }
}
