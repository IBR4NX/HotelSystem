using Hotel_DataAccuss;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // مثل Admin, Staff, Manager
        public DateTime CreatedAt { get; set; }
        public bool IsActive {  get; set; }

        // كونستركتر بدون معلمات مع قيم مبدئية
        public clsUser()
        {
            UserID = 0;
            Username = "";
            PasswordHash = "";
            FirstName = "";
            LastName = "";
            Email = "";
            Role = "";
            CreatedAt = new DateTime();
            IsActive = true;
            Mode = enMode.AddNew;
        }

        // كونستركتر يستقبل قيم
        public clsUser(int userID, string username, string passwordHash,
            string firstName, string lastName, string email, string role, DateTime createdAt, bool isActive)
        {
            UserID = userID;
            Username = username;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
            CreatedAt = createdAt;
            IsActive = isActive;   
            Mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        // يرجع لي المستخدم على حسب اسمة وكلمة السر
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
             int UserID = -1;
             string FirstName = "";
             string LastName = "";
             string Email= "";
             string Role = "";
             DateTime CreatedAt = new DateTime();
  

             bool IsActive = false;

            //Password = ComputeHash(Password);

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref FirstName, 
                                ref LastName, ref Email, ref Role, ref CreatedAt, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, UserName, Password,  FirstName,
                                 LastName,  Email,  Role,  CreatedAt, IsActive);
            else
                return null;
        }

        private bool _AddNewUser()
        {
            //call DataAccess Layer 
            //this.Password = ComputeHash(this.Password);
            this.UserID = clsUserData.AddNewUser(this.Username, this.PasswordHash,
                this.FirstName, this.LastName, this.Email, this.Role, this.IsActive);

            return (this.UserID != -1);
        }
          private bool _UpdateUser()
          {
              //call DataAccess Layer 
             // this.PasswordHash = ComputeHash(this.Password);

              return clsUserData.UpdateUser(this.UserID, this.Username, this.PasswordHash,
                this.FirstName, this.LastName, this.Email, this.Role, this.IsActive);
          }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }


        //هل المستخدم موجود من خلال اسم المستخدم

        public static bool isUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        // ارجاع المستخدم عن طريق الرقم
        public static clsUser FindByUserID(int UserID)
        {
            string UserName = "", Password = "";
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Role = "";
            DateTime CreatedAt = new DateTime();


            bool IsActive = false;

      

            bool IsFound = clsUserData.GetUserInfoByUserID
                                (UserID, ref UserName, ref Password, ref FirstName,
                                ref LastName, ref Email, ref Role, ref CreatedAt, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, UserName, Password, FirstName,
                                                 LastName, Email, Role, CreatedAt, IsActive);
            else
                return null;
        }


        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

    }
}
