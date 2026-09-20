using Hotel_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Guests
{
    
    public partial class ctrlGuestCardWithFilter : UserControl
    {
        public event Action<int> OnGuestSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void GuestSelected(int GuestID)
        {
            Action<int> handler = OnGuestSelected;
            if (handler != null)
            {
                handler(GuestID); // Raise the event with the parameter
            }
        }

        private int _GuestID = -1;

        public int GuestID  // يرجع لي الرقم من الكنترول القديم الى الكنترول الجديد
        {
            get { return ctrlGuestCard1.GuestID; }
        }

        public clsGuest SelectedGuestInfo// يرجع لي الشخص من الكنترول القديم
        {
            get { return ctrlGuestCard1.SelectedGuestInfo; }
        }

        public ctrlGuestCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlGuestCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        public void LoadGuestInfo(int GuestID)// عرض البيانات
        {

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = GuestID.ToString();
            FindNow();
        }
        private void FindNow()
        {
 
            switch (cbFilterBy.Text)
            {
                case "Guest ID":
                    ctrlGuestCard1.LoadGuestInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "Identity Number":
                    ctrlGuestCard1.LoadGuestInfoByIdentityNumber(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnGuestSelected != null)
                // Raise the event with a parameter
                GuestSelected(ctrlGuestCard1.GuestID);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Guest ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewGuest_Click(object sender, EventArgs e)
        {
            frmAddUpdateGuest frm1 = new frmAddUpdateGuest();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void DataBackEvent(object sender, int GuestID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = GuestID.ToString();
            ctrlGuestCard1.LoadGuestInfo(GuestID);
            FindNow();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdateGuest frm1 = new frmAddUpdateGuest();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

        }

        internal void LoadRoomInfo(int roomID)
        {
            throw new NotImplementedException();
        }
    }
}
