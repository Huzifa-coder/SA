using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUser
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        public enum enPermissions { All = 0, UsersList = 2 , StudentList = 4, TutorList = 8, PeopleList = 16, BatchesList = 32, ProgramsList = 64, DomainList = 128, TypesList = 256, PaymentList = 512 }

        public string UserID { get; set; }
        public int PersonID { get; set; }
        clsPerson PersonInfo { get; }
        public string Password { get; set; }
        public short Permissions { get; set; }

        public clsUser()
        {
            UserID = string.Empty;
            PersonID = -1;
            Password = string.Empty;
            Permissions = 1;

            _Mode = enMode.Add;
        }

        public clsUser(string userID, int personID, string password, short permissions)
        {
            UserID = userID;
            PersonID = personID;
            Password = password;
            Permissions = permissions;

            PersonInfo = clsPerson.Find(personID);
            _Mode = enMode.Update;
        }

        static public clsUser Find(string userID)
        {
            int personID = -1;
            string password = string.Empty;
            short permissions = 0;

            if (clsUserData.GetUser(userID, ref personID, ref password, ref permissions))
            {
                return new clsUser(userID, personID, password, permissions);
            }

            return null;
        }

        static public clsUser Find(int PersonID)
        {
            string UserID = string.Empty;
            string password = string.Empty;
            short permissions = 0;

            if (clsUserData.GetUser(PersonID, ref UserID, ref password, ref permissions))
            {
                return new clsUser(UserID, PersonID, password, permissions);
            }

            return null;
        }

        static public bool IsExist(string userID)
        {
            return clsUserData.IsExist(userID);
        }

        static public bool IsExist(int PersonID)
        {
            return clsUserData.IsExist(PersonID);
        }

        static public bool Delete(string userID)
        {
            return clsUserData.DeleteUser(userID);
        }

        static public DataTable GetUsers()
        {
            return clsUserData.GetUsers();
        }

        public bool HasPermission(enPermissions permissions)
        {

            return (this.Permissions & (short)permissions) == (short)permissions || this.Permissions == (short)enPermissions.All;
        }

        private bool _Add()
        {      

            return clsUserData.AddNewUser(this.UserID, PersonID, Password, Permissions); ;
        }

        // Update User Info
        private bool _Update()
        {
            return clsUserData.UpdateUserInfo(UserID, PersonID, Password, Permissions);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_Add())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public DataTable GetStudentsList()
        {
            return clsStudentData.GetStudents(UserID);
        }

        public DataTable GetNotifiyStudentsList()
        {
            return clsStudentData.GetNotifiyStudentsList(UserID);
        }

    }
}
