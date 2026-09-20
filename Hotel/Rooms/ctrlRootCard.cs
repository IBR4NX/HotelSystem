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

namespace Hotel.Rooms
{
    public partial class ctrlRootCard : UserControl
    {
        private clsRoom _Room;

        private int _RoomID = -1;

        public int RoomID
        {
            get { return _RoomID; }
        }

        public clsRoom SelectedRoomInfo
        {
            get { return _Room; }
        }
        public ctrlRootCard()
        {
            InitializeComponent();
        }


        public void LoadRoomInfo(int RoomID)// نعرض بيانات الشخص على حسب رقمة الوطني
        {

            _Room = clsRoom.Find(RoomID);
            if (_Room == null)
            {
                ResetRoomInfo();
                MessageBox.Show("No Person with PersonID = " + RoomID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }


        public void LoadRoomInfoByNameRoom(string NameRoom)// نعرض بيانات الشخص على حسب رقمة الوطني
        {

            _Room = clsRoom.FindByNameRoom(NameRoom);
            if (_Room == null)
            {
                ResetRoomInfo();
                MessageBox.Show("No Room with Name Room = " + NameRoom, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }


        //   عرض البيانات
        private void _FillPersonInfo()
        {
            _RoomID = _Room.RoomID;
            lblRoomID.Text = _Room.RoomID.ToString();
            lblNameRoom.Text = _Room.NameRoom;
            lblStatus.Text = _Room.Status;
            lblRoomType.Text = clsRoomType.Find(_Room.RoomTypeID).RoomTypeName;
            lblNumberOfBeds.Text = _Room.NumberOfBeds.ToString();
            lblMaxOccupancy.Text = _Room.MaxOccupancy.ToString();
            lblPrice.Text = _Room.Price.ToString();
            txtDescription.Text = _Room.Description;

        }


        // لو البيانات مش موجوده يعمل اعاده تحميل
        public void ResetRoomInfo()
        {
            _RoomID = -1;
            lblRoomID.Text = "[????]";
            lblNameRoom.Text = "[????]";
            lblStatus.Text = "[????]";
            lblRoomType.Text = "[????]";
            lblNumberOfBeds.Text = "[????]";
            lblMaxOccupancy.Text = "[????]";
            txtDescription.Text = "";
            lblPrice.Text = "[????]";
            //  lblRoomName.Text = "[????]";
            lblNameRoom.Text = "[????]";
            lblMaxOccupancy.Text = "[????]";
           // lblRole.Text = "[????]";
           // lblIsActive.Text = "[????]";

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateRoom frmAddUpdateRoom = new frmAddUpdateRoom(_RoomID);
            frmAddUpdateRoom.DataBack += frmAddUpdateRoom_DataBack;
            frmAddUpdateRoom.ShowDialog();
        }
        private void frmAddUpdateRoom_DataBack(object sender, int RoomID)
        {
            LoadRoomInfo(RoomID);
        }
    }
}
