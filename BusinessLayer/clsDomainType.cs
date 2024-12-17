using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDomainType
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        public int DomainTypeID { get; set; } // Unique identifier for the domain type
        public string DomainTypeName { get; set; } // Name of the domain type

        public clsDomainType()
        {
            DomainTypeID = 0; // Default to zero
            DomainTypeName = string.Empty; // Default to empty string

            _Mode = enMode.Add; // Set mode to Add
        }

        public clsDomainType(int domainTypeID, string domainTypeName)
        {
            DomainTypeID = domainTypeID; // Initialize DomainTypeID
            DomainTypeName = domainTypeName; // Initialize DomainTypeName
            _Mode = enMode.Update; // Set mode to Update
        }

        static public clsDomainType Find(int domainTypeID)
        {
            string domainTypeName = string.Empty; // Default to empty string

            if (clsDomainTypeData.GetDomainType(domainTypeID, ref domainTypeName))
            {
                return new clsDomainType(domainTypeID, domainTypeName); // Return new clsDomainType object
            }

            return null; // Return null if not found
        }

        static public clsDomainType Find(string domainTypeName)
        {
            int domainTypeID = 0; // Default to zero

            if (clsDomainTypeData.GetDomainType(domainTypeName, ref domainTypeID))
            {
                return new clsDomainType(domainTypeID, domainTypeName); // Return new clsDomainType object
            }

            return null; // Return null if not found
        }

        static public bool IsExist(int domainTypeID)
        {
            return clsDomainTypeData.IsExist(domainTypeID); // Check if domain type exists
        }

        static public bool Delete(int domainTypeID)
        {
            return clsDomainTypeData.DeleteDomainType(domainTypeID); // Delete domain type by ID
        }

        static public DataTable GetDomainTypes()
        {
            return clsDomainTypeData.GetDomainTypes(); // Get all domain types as DataTable
        }

        // Add New Domain Type Info
        private bool _Add()
        {
            int resultDomainTypeID = clsDomainTypeData.AddNewDomainType(DomainTypeName); // Add new domain type

            if (resultDomainTypeID > 0)
            {
                this.DomainTypeID = resultDomainTypeID; // Set DomainTypeID
                return true; // Return success
            }

            return false; // Return failure
        }

        // Update Domain Type Info
        private bool _Update()
        {
            return clsDomainTypeData.UpdateDomainTypeInfo(DomainTypeID, DomainTypeName); // Update domain type
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_Add()) // Attempt to add
                    {
                        _Mode = enMode.Update; // Change mode to Update
                        return true; // Return success
                    }
                    else
                    {
                        return false; // Return failure
                    }

                case enMode.Update:
                    return _Update(); // Attempt to update
            }

            return false; // Return failure if mode is invalid
        }
    }

}
