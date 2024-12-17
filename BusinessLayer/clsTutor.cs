using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTutor
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        // Properties
        public int TutorID { get; set; }
        public int PersonID { get; set; }
        public string Phone { get; set; }

        public clsPerson PersonInfo { get; }

        public clsTutor()
        {
            TutorID = -1;
            PersonID = -1;
            Phone = string.Empty;

            PersonInfo = null;

            _Mode = enMode.Add;
        }

        public clsTutor(int tutorID, int personID, string password,string phone)
        {
            TutorID = tutorID;
            PersonID = personID;
            Phone = phone;

            PersonInfo = clsPerson.Find(personID);

            _Mode = enMode.Update;
        }

        static public clsTutor FindByPersonID(int personID)
        {
            int tutorID = -1;
            string phone = string.Empty;
            string password = string.Empty;

            if (clsTutorData.GetTutorByPersonID(personID, ref tutorID, ref phone))
            {
                return new clsTutor(tutorID, personID, password, phone);
            }

            return null;
        }

        static public clsTutor FindByTutorID(int tutorID)
        {
            int personID = -1;
            string phone = string.Empty;
            string password = string.Empty;

            if (clsTutorData.GetTutorByTutorID(tutorID, ref personID, ref phone))
            {
                return new clsTutor(tutorID, personID, password, phone);
            }

            return null;
        }

        static public bool IsExistByPersonID(int personID)
        {
            return clsTutorData.IsExistByPersonID(personID);
        }

        static public bool IsExistByTutorID(int tutorID)
        {
            return clsTutorData.IsExistByTutorID(tutorID);
        }

        static public bool Delete(int tutorID)
        {
            return clsTutorData.DeleteTutor(tutorID);
        }

        static public DataTable GetTutors()
        {
            return clsTutorData.GetTutors();
        }

        static public DataTable GetTutors(int DomainID)
        {
            return clsTutorData.GetTutors(DomainID);
        }

        private bool _Add()
        {
            int resultTutorID = clsTutorData.AddNewTutor(PersonID,Phone);

            if (resultTutorID > 0)
            {
                this.TutorID = resultTutorID;
                return true;
            }

            return false;
        }

        private bool _Update()
        {
            return clsTutorData.UpdateTutorInfo(TutorID, PersonID, Phone);
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

        public static bool IsTutorEmptyForBatch(int batchID, TimeSpan startTime, TimeSpan endTime)
        {
            return clsTutorData.IsTutorEmptyForBatch(batchID, startTime, endTime);
        }

        public static DataTable GetBatchesAllocation(int TutorID)
        {
            return clsBatchAllocationData.GetBatchAllocations(TutorID);
        }

        public static DataTable GetAvalableTime(int tutorID)
        {
            return clsTutorData.GetTutorFreeTimeList(tutorID);
        }
    }

}
