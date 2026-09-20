using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Guests
{
    public partial class frmShowGuestInfo : Form
    {
        

        private int _GuestID = -1;
        public frmShowGuestInfo(int GuestID)
        {
            InitializeComponent();
            _GuestID = GuestID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowGuestInfo_Load(object sender, EventArgs e)
        {
            ctrlGuestCard1.LoadGuestInfo(_GuestID);
        }
    }
}
