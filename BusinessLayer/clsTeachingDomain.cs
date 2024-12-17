using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTeachingDomain
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        // Properties
        public int TeachingDomainID { get; set; }
        public int TutorID { get; set; }// Add a class here
        clsTutor TutorInof { get; }

        public int DomainID { get; set; }
        clsDomain DomainInfo { get; }

        public clsTeachingDomain()
        {
            _Mode = enMode.Add;
        }

        public clsTeachingDomain(int teachingDomainID, int tutorID, int domainID)
        {
            TeachingDomainID = teachingDomainID;
            TutorID = tutorID;
            DomainID = domainID;

            TutorInof = clsTutor.FindByTutorID(tutorID);
            DomainInfo = clsDomain.Find(domainID);

            _Mode = enMode.Update;
        }

        static public clsTeachingDomain Find(int teachingDomainID)
        {
            int tutorID = -1; // Default value
            int domainID = -1; // Default value

            if (clsTeachingDomainData.GetTeachingDomainByID(teachingDomainID, ref tutorID, ref domainID))
            {
                return new clsTeachingDomain(teachingDomainID, tutorID, domainID);
            }

            return null;
        }

        static public bool IsExist(int teachingDomainID)
        {
            return clsTeachingDomainData.IsTeachingDomainExist(teachingDomainID);
        }

        static public bool IsExist(int TutorID, int DomainID)
        {
            return clsTeachingDomainData.IsTeachingDomainExist(TutorID, DomainID);
        }

        static public bool Delete(int teachingDomainID)
        {
            return clsTeachingDomainData.DeleteTeachingDomain(teachingDomainID);
        }

        static public DataTable GetTeachingDomains()
        {
            return clsTeachingDomainData.GetTeachingDomains();
        }

        static public DataTable GetTeachingDomains(int TutorID)
        {
            return clsTeachingDomainData.GetTeachingDomains(TutorID);
        }

        static public DataTable GetTutorsByDomain(int DomainID)
        {

            return clsTeachingDomainData.GetTutorsByDomain(DomainID);
        }

        private bool _Add()
        {
            int resultTeachingDomainID = clsTeachingDomainData.AddNewTeachingDomain(TutorID, DomainID);

            if (resultTeachingDomainID > 0)
            {
                this.TeachingDomainID = resultTeachingDomainID;
                return true;
            }

            return false;
        }

        private bool _Update()
        {
            return clsTeachingDomainData.UpdateTeachingDomainInfo(TeachingDomainID, TutorID, DomainID);
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

    }

}
