using Hotel.Rooms;
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
using System.Xml.Linq;

namespace Hotel.Rooms
{
    public partial class ctrRoomCardWithFilter : UserControl
    {
        public event Action<int> OnRoomSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void RoomSelected(int RoomID)
        {
            Action<int> handler = OnRoomSelected;
            if (handler != null)
            {
                handler(RoomID); // Raise the event with the parameter
            }
        }

        private int _RoomID = -1;

        public int RoomID  // يرجع لي الرقم من الكنترول القديم الى الكنترول الجديد
        {
            get { return ctrlRootCard1.RoomID; }
        }

        public clsRoom SelectedRoomInfo// يرجع لي الشخص من الكنترول القديم
        {
            get { return ctrlRootCard1.SelectedRoomInfo; }
        }
        public ctrRoomCardWithFilter()
        {
            InitializeComponent();
        }
        private void FindNow()
        {
            clsRoom Room = new clsRoom();
            switch (cbFilterBy.Text)
            {
                
                case "Room ID":
                  
                    ctrlRootCard1.LoadRoomInfo(int.Parse(txtFilterValue.Text));
                    break;

                case "Name Room":
                 
                    ctrlRootCard1.LoadRoomInfoByNameRoom(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnRoomSelected != null)
                // Raise the event with a parameter
                RoomSelected(ctrlRootCard1.RoomID);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            clsRoom Room;
            switch (cbFilterBy.Text)
            {

                case "Room ID":
                    Room = clsRoom.Find(int.Parse(txtFilterValue.Text));
                    if(Room == null)
                    {
                        FindNow();
                        return;

                    }

                    if (Room.Status != "متاح")
                    {
                        MessageBox.Show("الغرفة محجوزة اختار غرفة اخرى!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ctrlRootCard1.ResetRoomInfo();

                        return;
                    }


                    break;

                case "Name Room":
                    Room = clsRoom.FindByNameRoom(txtFilterValue.Text);
                    if (Room == null)
                    {
                        FindNow();
                        return;

                    }
                    if (Room.Status != "متاح")
                    {
                        MessageBox.Show("الغرفة محجوزة اختار غرفة اخرى!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ctrlRootCard1.ResetRoomInfo();
                        return;

                    }

                    break;

                default:
                    break;
            }
            FindNow();
        }



        public void LoadRoomInfo(int RoomID)// عرض البيانات
        {

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = RoomID.ToString();
            gbFilters.Enabled = false;
            FindNow();

        }

        private void ctrRoomCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdateRoom frm1 = new frmAddUpdateRoom();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void DataBackEvent(object sender, int RoomID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = RoomID.ToString();
            ctrlRootCard1.LoadRoomInfo(RoomID);
            FindNow();
        }

        private void ctrlRootCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
