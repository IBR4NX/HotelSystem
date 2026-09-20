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
    public partial class frmShowReservationInfo : Form
    {



        public int _ReservationID = -1;
        public frmShowReservationInfo(int ReservationID)
        {
            InitializeComponent();
            _ReservationID = ReservationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowReservationInfo_Load(object sender, EventArgs e)
        {
            ctrlResevationCard1.LoadReservationInfo(_ReservationID);
        }
    }
}
