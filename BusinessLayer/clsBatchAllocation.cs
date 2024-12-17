using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBatchAllocation
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        public int BatchesAllocationID { get; set; } 
        public int BatchID { get; set; }
        public clsBatch BatchInfo { get; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; } 

        public clsBatchAllocation()
        {
            BatchesAllocationID = 0;
            BatchID = 0; // Default to zero
            StartTime = TimeSpan.Zero; // Default to zero time
            EndTime = TimeSpan.Zero; // Default to zero time

            BatchInfo = null;
            _Mode = enMode.Add;
        }

        public clsBatchAllocation(int batchesAllocationID, int batchID, TimeSpan startTime, TimeSpan endTime)
        {
            BatchesAllocationID = batchesAllocationID;
            BatchID = batchID;
            StartTime = startTime;
            EndTime = endTime;

            BatchInfo = clsBatch.Find(batchID);

            _Mode = enMode.Update;
        }

        static public clsBatchAllocation FindByBatchesAllocationID(int batchesAllocationID)
        {
            int batchID = 0; // Default
            TimeSpan startTime = TimeSpan.Zero; // Default
            TimeSpan endTime = TimeSpan.Zero; // Default

            if (clsBatchAllocationData.GetBatchAllocationByAllocationID(batchesAllocationID, ref batchID, ref startTime, ref endTime))
            {
                return new clsBatchAllocation(batchesAllocationID, batchID, startTime, endTime);
            }

            return null;
        }

        static public clsBatchAllocation FindByBatchID(int batchID)
        {
            int batchesAllocationID = 0; // Default
            TimeSpan startTime = TimeSpan.Zero; // Default
            TimeSpan endTime = TimeSpan.Zero; // Default

            if (clsBatchAllocationData.GetBatchAllocationByBatchID(batchID, ref batchesAllocationID, ref startTime, ref endTime))
            {
                return new clsBatchAllocation(batchesAllocationID, batchID, startTime, endTime);
            }

            return null;
        }

        static public bool IsExistByBatchAllocation(int batchesAllocationID)
        {
            return clsBatchAllocationData.IsExistByBatchAllocationID(batchesAllocationID);
        }

        static public bool IsExistByBatchID(int batchesAllocationID)
        {
            return clsBatchAllocationData.IsExistByBatchID(batchesAllocationID);
        } 

        static public bool Delete(int batchesAllocationID)
        {
            return clsBatchAllocationData.DeleteBatchAllocation(batchesAllocationID);
        }

        static public DataTable GetBatchAllocations()
        {
            return clsBatchAllocationData.GetBatchesAllocations();
        }

        // Add New Batch Allocation Info
        private bool _Add()
        {
            int resultBatchesAllocationID = clsBatchAllocationData.AddNewBatchAllocation(BatchID, StartTime, EndTime);

            if (resultBatchesAllocationID > 0)
            {
                this.BatchesAllocationID = resultBatchesAllocationID;
                return true;
            }

            return false;
        }

        // Update Batch Allocation Info
        private bool _Update()
        {
            return clsBatchAllocationData.UpdateBatchAllocation(BatchesAllocationID, BatchID, StartTime, EndTime);
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
