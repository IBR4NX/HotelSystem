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

namespace Hotel.Guests
{
    
    public partial class frmAddUpdateGuest : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersenID);
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _GuestID = -1;
        clsGuest _Guest;

        public frmAddUpdateGuest()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }
        public frmAddUpdateGuest(int GuestID)
        {
            InitializeComponent();
            _Mode = enMode.Update;

            _GuestID = GuestID;
        }

        private void frmAddUpdateGuest_Load(object sender, EventArgs e)
        {

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "إضافة نزيل جديد";
                this.Text = "إضافة نزيل جديد";
                ctrlAddAndUpdateGuest1.ResetDefualtValues(-1);
                _Guest = new clsGuest();
            }
            else
            {
                lblTitle.Text = "تحديث نزيل";
                this.Text = "تحديث نزيل";

                ctrlAddAndUpdateGuest1.ResetDefualtValues(_GuestID);
                _Guest = clsGuest.Find(_GuestID);

                if (_Guest == null)
                {
                    MessageBox.Show("No Guest with ID = " + _Guest, "Guest Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrlAddAndUpdateGuest1.Save();
            _GuestID = ctrlAddAndUpdateGuest1.GuestID;
        }

        // هاذا الحدث يرجع لي اسم المستخدم بعد الاظافة
        private void ctrlAddAndUpdateGuest1_OnAddOrUpdateGuest(int obj)
        {
            //MessageBox.Show(obj.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _GuestID);

            this.Close();
        }
    }
}
