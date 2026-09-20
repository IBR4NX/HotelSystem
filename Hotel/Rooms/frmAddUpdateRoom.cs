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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel.Rooms
{
    public partial class frmAddUpdateRoom : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersenID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _RoomID = -1;
        clsRoom _Room;
        public frmAddUpdateRoom()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateRoom(int RoomID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _RoomID = RoomID;
        }
        private void _FillRoomTypeInComoboBox()
        {
            DataTable dtRoomType = clsRoomType.GetAllRoomTypeData();

            foreach (DataRow row in dtRoomType.Rows)
            {
                cmbRoomType.Items.Add(row[1]);
            }
        }
        private void _ResetDefualtValues()
        {
            _FillRoomTypeInComoboBox();

           /* foreach (DataRow dr in dt.Rows)
            {
            }*/

            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "إضافة غرفة جديدة";
                this.Text = "إضافة غرفة جديدة";
                _Room = new clsRoom();


                //ctrlPersonCardWithFilter1.FilterFocus();// عمل تركيز على مربع البحث
            }
            else
            {
                lblTitle.Text = "تحديث الغرفة";
                this.Text = "تحديث الغرفة";

                btnSave.Enabled = true;


            }

            // txtUserName.Text = "";
            //txtPassword.Text = "";
            // txtConfirmPassword.Text = "";
            // chkIsActive.Checked = true;


        }

        private void _LoadData()
        {

            _Room = clsRoom.Find(_RoomID);

            if (_Room == null)
            {
                MessageBox.Show("No Room with ID = " + _RoomID, "Room Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblRoomID.Text = _Room.RoomID.ToString();
            txtNameRoom.Text = _Room.NameRoom;
            cmbRoomType.Text = clsRoomType.Find(_Room.RoomTypeID).RoomTypeName;

            cmbStatus.Text = _Room.Status;
            nudNumberOfBeds.Value = _Room.NumberOfBeds;
            nudMaxOccupancy.Value = _Room.MaxOccupancy;
            nudPrice.Value = _Room.Price;
            txtDescription.Text = _Room.Description;
            //  ctrlPersonCardWithFilter1.LoadPersonInfo(_Room.PersonID);// عرض البيانات
        }
        private void frmAddUpdateRoom_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            cmbRoomType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void txtNameRoom_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNameRoom.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNameRoom, "لا يمكن أن يكون حقل اسم الغرفة فارغا");
            }
            else
            {
                errorProvider1.SetError(txtNameRoom, null);
            };
        }

        private void nudNumberOfBeds_Validating(object sender, CancelEventArgs e)
        {
           if(nudNumberOfBeds.Value < 1)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudNumberOfBeds, "يجب ان يكون هناك عدد اسرة");
            }
            else
            {
                errorProvider1.SetError (nudNumberOfBeds, null);
            }
        }

        private void nudMaxOccupancy_Validating(object sender, CancelEventArgs e)
        {
            if (nudMaxOccupancy.Value < 1)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudMaxOccupancy, "يجب ان يكون هناك عدد اشخاص");
            }
            else
            {
                errorProvider1.SetError(nudMaxOccupancy, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _Room.NameRoom = txtNameRoom.Text.Trim();
            _Room.Status = cmbStatus.Text;
            _Room.NumberOfBeds = Convert.ToInt32(nudNumberOfBeds.Value);
            _Room.MaxOccupancy = Convert.ToInt32(nudMaxOccupancy.Value);
            _Room.RoomTypeID = clsRoomType.Find(cmbRoomType.Text).RoomTypeID;
            _Room.Price = nudPrice.Value;
            _Room.Description = txtDescription.Text.Trim();


            if (_Room.Save())
            {
                lblRoomID.Text = _Room.RoomID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "تحديث المستخدم";
                this.Text = "تحديث المستخدم";

                MessageBox.Show("تم حفظ البيانات بنجاح.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("خطأ: لم يتم حفظ البيانات بنجاح.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _RoomID);
            this.Close();
        }
    }
    
}
