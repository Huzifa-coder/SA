using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsStudent
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        // Properties
        public int StudentID { get; set; } // Unique identifier for the student
        public string Phone { get; set; } // Student's phone number
        public int PersonID { get; set; } // Identifier for the person associated with the student
        public clsPerson PersonInfo { get; } // Person information associated with the student
        public string Email { get; set; } // Student's email address
        public DateTime JoinDate { get; set; } // Date when the student joined
        public int BatchID { get; set; } // Identifier for the batch the student is part of
        public clsBatch BatchInfo { get; } // Batch information associated with the student

        public string CreatedByID { get; set; } // Identifier for the user who created the student record
        public clsUser UserCreateByInfo { get; } // User information for the creator

        public clsStudent()
        {
            StudentID = -1; // Default to -1 for uninitialized ID
            PersonID = -1; // Default to -1 for uninitialized person ID
            Phone = string.Empty; // Default to empty string
            Email = string.Empty; // Default to empty string
            JoinDate = DateTime.MinValue; // Default to minimum date
            BatchID = -1; // Default to -1 for uninitialized batch ID
            CreatedByID = string.Empty; // Default to empty string

            _Mode = enMode.Add; // Set mode to Add
        }

        public clsStudent(int studentID,int personID, string phone, string email,
                          DateTime joinDate, int batchID,
                          string createdBy)
        {
            StudentID = studentID;
            PersonID = personID; // Initialize PersonID
            Phone = phone; // Initialize Phone
            Email = email; // Initialize Email
            JoinDate = joinDate; // Initialize JoinDate
            BatchID = batchID; // Initialize BatchID
            CreatedByID = createdBy; // Initialize CreatedByID

            BatchInfo = clsBatch.Find(batchID); // Find batch info
            PersonInfo = clsPerson.Find(personID); // Find person info
            UserCreateByInfo = clsUser.Find(createdBy); // Find user info for creator

            _Mode = enMode.Update; // Set mode to Add
        }

        static public clsStudent FindByStudentID(int studentID)
        {
            int personID = -1; // Default to -1 for uninitialized person ID
            string phone = string.Empty; // Default to empty string
            string email = string.Empty; // Default to empty string
            string tutor = string.Empty; // Default to empty string
            DateTime joinDate = DateTime.MinValue; // Default to minimum date
            int batchID = -1; // Default to -1 for uninitialized batch ID
            string createdBy = string.Empty; // Default to empty string

            if (clsStudentData.GetStudentByStudentID(studentID, ref personID, ref phone, ref email, ref joinDate, ref batchID, ref createdBy))
            {
                return new clsStudent(studentID, personID, phone, email, joinDate, batchID, createdBy); // Return new clsStudent object
            }

            return null; // Return null if not found
        }

        static public clsStudent FindByPersonID(int PersonID)
        {
            int studentID = -1; // Default to -1 for uninitialized person ID
            string phone = string.Empty; // Default to empty string
            string email = string.Empty; // Default to empty string
            string tutor = string.Empty; // Default to empty string
            DateTime joinDate = DateTime.MinValue; // Default to minimum date
            int batchID = -1; // Default to -1 for uninitialized batch ID
            string createdBy = string.Empty; // Default to empty string

            if (clsStudentData.GetStudentByPersonID(PersonID, ref studentID, ref phone, ref email, ref joinDate, ref batchID, ref createdBy))
            {
                return new clsStudent(studentID, PersonID, phone, email, joinDate, batchID, createdBy); // Return new clsStudent object
            }

            return null; // Return null if not found
        }

        static public bool IsExistByStudentID(int studentID)
        {
            return clsStudentData.IsExistByStudentID(studentID); // Check if student exists by ID
        }

        static public bool IsExistByPersonID(int PersonID)
        {
            return clsStudentData.IsExistByPersonID(PersonID); // Check if student exists by ID
        }

        static public bool Delete(int studentID)
        {

            return clsStudentData.DeleteStudent(studentID); // Delete student if no payment exists   
        }

        static public DataTable GetStudents()
        {
            return clsStudentData.GetStudents(); // Get all students as DataTable
        }

        static public DataTable GetStudents(string userID)
        {
            return clsStudentData.GetStudents(userID); // Get students for a specific user
        }

        static public DataTable GetNotifiyStudentsList()
        {
            return clsStudentData.GetNotifiyStudentsList(); // Get students to notify
        }

        private bool _AddStudent()
        {
            int studentID = clsStudentData.AddNewStudent(PersonID, Phone, Email, JoinDate, BatchID, CreatedByID); // Add new student

            if (studentID > 0)
            {
                this.StudentID = studentID; // Set StudentID
                return true; // Return success
            }

            return false; // Return failure
        }

        private bool _Update()
        {
            return clsStudentData.UpdateStudentInfo(StudentID, PersonID, Phone, Email, JoinDate, BatchID); // Update student info
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddStudent())
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
