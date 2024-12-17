using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLayer
{
    public class clsProgram
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        public int ProgramID { get; set; } // Unique identifier for the program
        public string ProgramName { get; set; } // Name of the program
        public string Duration { get; set; } // Duration of the program (e.g., in hours or days)
        public int DomainID { get; set; } // Identifier for the domain associated with the program
        public clsDomain DomainInfo { get; }

        public clsProgram()
        {
            ProgramID = 0; // Default to zero
            ProgramName = string.Empty; // Default to empty string
            Duration = string.Empty; // Default duration
            DomainID = 0; // Default to zero
            _Mode = enMode.Add; // Set mode to Add
        }

        public clsProgram(int programID, string programName, string duration, int domainID)
        {
            ProgramID = programID; // Initialize ProgramID
            ProgramName = programName; // Initialize ProgramName
            Duration = duration; // Initialize Duration
            DomainID = domainID; // Initialize DomainID

            DomainInfo = clsDomain.Find(domainID);
            _Mode = enMode.Update; // Set mode to Update
        }

        static public clsProgram Find(int programID)
        {
            string programName = string.Empty; // Default to empty string
            string duration = string.Empty; // Default duration
            int domainID = 0; // Default to zero

            if (clsProgramData.GetProgram(programID, ref programName, ref duration, ref domainID))
            {
                return new clsProgram(programID, programName, duration, domainID); // Return new clsProgram object
            }

            return null; // Return null if not found
        }

        static public clsProgram Find(string programName)
        {
            int programID = 0; // Default to zero
            string duration = string.Empty; // Default duration
            int domainID = 0; // Default to zero

            if (clsProgramData.GetProgram(programName, ref programID, ref duration, ref domainID))
            {
                return new clsProgram(programID, programName, duration, domainID); // Return new clsProgram object
            }

            return null; // Return null if not found
        }

        static public bool IsExist(int programID)
        {
            return clsProgramData.IsExist(programID); // Check if program exists
        }

        static public bool Delete(int programID)
        {
            return clsProgramData.DeleteProgram(programID); // Delete program by ID
        }

        static public DataTable GetPrograms()
        {
            return clsProgramData.GetPrograms(); // Get all programs as DataTable
        }

        static public DataTable GetPrograms(int DomainID)
        {
            return clsProgramData.GetPrograms(DomainID);
        }

        // Add New Program Info
        private bool _Add()
        {
            int resultProgramID = clsProgramData.AddNewProgram(ProgramName, Duration, DomainID); // Add new program

            if (resultProgramID > 0)
            {
                this.ProgramID = resultProgramID; // Set ProgramID
                return true; // Return success
            }

            return false; // Return failure
        }

        // Update Program Info
        private bool _Update()
        {
            return clsProgramData.UpdateProgramInfo(ProgramID, ProgramName, Duration, DomainID); // Update program
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
