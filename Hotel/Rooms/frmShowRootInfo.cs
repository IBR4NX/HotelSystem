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
    public partial class frmShowRootInfo : Form
    {
        private int _RoomID = -1;

        public frmShowRootInfo(int roomID)
        {
            InitializeComponent();
            _RoomID = roomID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowRootInfo_Load(object sender, EventArgs e)
        {
            ctrlRootCard1.LoadRoomInfo(_RoomID);
        }
    }
}
