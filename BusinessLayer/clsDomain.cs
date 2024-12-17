using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDomain
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        public int DomainID { get; set; } // Unique identifier for the domain
        public string DomainName { get; set; } // Name of the domain
        public int DomainTypeID { get; set; } // ID of the domain type
        public clsDomainType DomainTpyeInfo { get; }

        public clsDomain()
        {
            DomainID = 0; // Default to zero
            DomainName = string.Empty; // Default to empty string
            DomainTypeID = 0; // Default to zero
            _Mode = enMode.Add; // Set mode to Add
        }

        public clsDomain(int domainID, string domainName, int domainTypeID)
        {
            DomainID = domainID; // Initialize DomainID
            DomainName = domainName; // Initialize DomainName
            DomainTypeID = domainTypeID; // Initialize DomainTypeID

            DomainTpyeInfo = clsDomainType.Find(domainTypeID);
            _Mode = enMode.Update; // Set mode to Update
        }

        static public clsDomain Find(string domainName, int domainTypeID)
        {
            int domainID = 0; // Default to zero

            if (clsDomainData.GetDomain(domainName, domainTypeID, ref domainID))
            {
                return new clsDomain(domainID, domainName, domainTypeID); // Return new clsDomain object
            }

            return null; // Return null if not found
        }

        static public clsDomain Find(int domainID)
        {
            string domainName = string.Empty; // Default to empty string
            int domainTypeID = 0; // Default to zero

            if (clsDomainData.GetDomain(domainID, ref domainName, ref domainTypeID))
            {
                return new clsDomain(domainID, domainName, domainTypeID); // Return new clsDomain object
            }

            return null; // Return null if not found
        }

        static public bool IsExist(int domainID)
        {
            return clsDomainData.IsExist(domainID); // Check if domain exists
        }

        static public bool Delete(int domainID)
        {
            return clsDomainData.DeleteDomain(domainID); // Delete domain by ID
        }

        static public DataTable GetDomains()
        {
            return clsDomainData.GetDomains(); // Get all domains as DataTable
        }

        static public DataTable GetDomains(int DomainType)
        {
            return clsDomainData.GetDomains(DomainType); // Get all domains as DataTable
        }
        
        // Add New Domain Info
        private bool _Add()
        {
            int resultDomainID = clsDomainData.AddNewDomain(DomainName, DomainTypeID); // Add new domain

            if (resultDomainID > 0)
            {
                this.DomainID = resultDomainID; // Set DomainID
                return true; // Return success
            }

            return false; // Return failure
        }

        // Update Domain Info
        private bool _Update()
        {
            return clsDomainData.UpdateDomainInfo(DomainID, DomainName, DomainTypeID); // Update domain
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
