using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBatch
    {
        enum enClssMode { Add, Update }
        enClssMode _Mode = enClssMode.Add;

        public enum enMode { Online, Ofline, Hybrid }
        public enum enStatus { TBD = 1, ToBeStarted, OnGoing, Cancelled, Complate }

        // Properties
        public int BatchID { get; set; }
        public string Name { get; set; }
        public int TutorID { get; set; }
        public clsTutor TutorInfo { get; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProgramID { get; set; } // Program ID
        public clsProgram ProgramInfo { get; }
        public int Capacity { get; set; }
        public string OnGoingTopic { get; set; }
        public enStatus Status { get; set; }

        public enMode Mode { get; set; }
        public string StringMode
        {
            get
            {
                return (Mode == enMode.Online) ? "Online" : (Mode == enMode.Ofline ? "Ofline" : "Hybrid");
            }
        }

        // Default Constructor
        public clsBatch()
        {
            BatchID = 0;
            Name = string.Empty;
            TutorID = 0;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            ProgramID = 0;
            Capacity = 0;
            Mode = enMode.Online; // Mode initialized to Add (as int)

            TutorInfo = clsTutor.FindByTutorID(TutorID);
            ProgramInfo = clsProgram.Find(ProgramID);
            _Mode = enClssMode.Add;
        }

        // Parameterized Constructor
        public clsBatch(int batchID, string name, int tutorID, DateTime startDate, DateTime endDate, int programID, int capacity, enMode mode, string onGoingTopic, enStatus status)
        {
            BatchID = batchID;
            Name = name;
            TutorID = tutorID;
            StartDate = startDate;
            EndDate = endDate;
            ProgramID = programID;
            Capacity = capacity;
            Mode = mode; // Mode initialized to Update (as int)
            OnGoingTopic = onGoingTopic;
            Status = status;
            _Mode = enClssMode.Update;

            TutorInfo = clsTutor.FindByTutorID(tutorID);
            ProgramInfo = clsProgram.Find(ProgramID);
        }

        // Static Find Method by BatchID
        static public clsBatch Find(int batchID)
        {
            string name = string.Empty;
            int tutorID = 0;
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            int programID = 0;
            int capacity = 0;
            int mode = 0;
            string onGoingTopic = string.Empty;
            byte status = 0;

            if (clsBatchData.GetBatch(batchID, ref name, ref tutorID, ref startDate, ref endDate, ref programID, ref capacity, ref mode, ref onGoingTopic, ref status))
            {
                return new clsBatch(batchID, name, tutorID, startDate, endDate, programID, capacity, (enMode)mode, onGoingTopic, (enStatus)status);
            }

            return null;
        }

        // Static Find Method by BatchName
        static public clsBatch Find(string batchName)
        {
            int batchID = -1;
            int tutorID = 0;
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            int programID = 0;
            int capacity = 0;
            int mode = 0;
            byte status = 0;
            string onGoingTopic = string.Empty;

            if (clsBatchData.GetBatch(batchName, ref tutorID, ref batchID, ref startDate, ref endDate, ref programID, ref capacity, ref mode, ref onGoingTopic, ref status))
            {
                return new clsBatch(batchID, batchName, tutorID, startDate, endDate, programID, capacity, (enMode)mode, onGoingTopic, (enStatus)status);
            }

            return null;
        }

        // Static Method to Check if Batch Exists
        static public bool IsExist(int batchID)
        {
            return clsBatchData.IsExist(batchID);
        }

        // Static Method to Delete a Batch
        static public bool Delete(int batchID)
        {
            return clsBatchData.DeleteBatch(batchID);
        }

        // Static Method to Get All Batches
        static public DataTable GetBatches()
        {
            return clsBatchData.GetBatches();
        }

        // Add New Batch Info
        private bool _Add()
        {
            int resultBatchID = clsBatchData.AddNewBatch(Name, TutorID, StartDate, EndDate, ProgramID, Capacity, (int)Mode, OnGoingTopic, (byte)Status);

            if (resultBatchID > 0)
            {
                this.BatchID = resultBatchID;
                return true;
            }

            return false;
        }

        // Update Batch Info
        private bool _Update()
        {
            return clsBatchData.UpdateBatchInfo(BatchID, Name, TutorID, StartDate, EndDate, ProgramID, Capacity, (int)Mode, OnGoingTopic, (byte)Status);
        }

        // Save Method
        public bool Save()
        {
            switch (_Mode)
            {
                case enClssMode.Add:
                    if (_Add())
                    {
                        _Mode = enClssMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enClssMode.Update:
                    return _Update();
            }

            return false;
        }

        // Check if Batch is Full
        public bool IsFull()
        {
            return clsBatchData.IsFull(BatchID);
        }

        // Static Method to Get Batches Times
        public static DataTable GetBatchesTimes()
        {
            return clsBatchData.GetBatchesTimes();
        }

    }
}