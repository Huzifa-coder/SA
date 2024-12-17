using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.clsSettings;

namespace DataAccess
{
    public class clsBatchAllocationData
    {
        public static bool GetBatchAllocationByAllocationID(int batchesAllocationID, ref int batchID, ref TimeSpan startTime, ref TimeSpan endTime)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM BatchesAllocation WHERE BatchesAllocationID = @BatchesAllocationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BatchesAllocationID", batchesAllocationID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                batchID = reader.GetInt32(reader.GetOrdinal("BatchID"));
                                startTime = reader.GetTimeSpan(reader.GetOrdinal("StartTime"));
                                endTime = reader.GetTimeSpan(reader.GetOrdinal("EndTime"));

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }

        public static bool GetBatchAllocationByBatchID(int batchID, ref int batchesAllocationID, ref TimeSpan startTime, ref TimeSpan endTime)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM BatchesAllocation WHERE BatchID = @batchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@batchID", batchID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                batchesAllocationID = reader.GetInt32(reader.GetOrdinal("BatchesAllocationID"));
                                startTime = reader.GetTimeSpan(reader.GetOrdinal("StartTime"));
                                endTime = reader.GetTimeSpan(reader.GetOrdinal("EndTime"));

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }

        public static int AddNewBatchAllocation(int batchID, TimeSpan startTime, TimeSpan endTime)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[BatchesAllocation] ([BatchID], [StartTime], [EndTime]) VALUES " +
                               "(@BatchID, @StartTime, @EndTime); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = batchID });
                    command.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.Time) { Value = startTime });
                    command.Parameters.Add(new SqlParameter("@EndTime", SqlDbType.Time) { Value = endTime });

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            ID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return ID;
        }
      
        public static bool UpdateBatchAllocation(int batchesAllocationID, int batchID, TimeSpan startTime, TimeSpan endTime)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[BatchesAllocation] SET [BatchID] = @BatchID, [StartTime] = @StartTime, [EndTime] = @EndTime WHERE BatchesAllocationID = @BatchesAllocationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BatchesAllocationID", SqlDbType.Int) { Value = batchesAllocationID });
                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = batchID });
                    command.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.Time) { Value = startTime });
                    command.Parameters.Add(new SqlParameter("@EndTime", SqlDbType.Time) { Value = endTime });

                    try
                    {
                        connection.Open();

                        int affectedRows = command.ExecuteNonQuery();
                        isUpdated = affectedRows > 0;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isUpdated;
        }

        public static bool DeleteBatchAllocation(int batchesAllocationID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM [dbo].[BatchesAllocation] WHERE BatchesAllocationID = @BatchesAllocationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BatchesAllocationID", SqlDbType.Int) { Value = batchesAllocationID });

                    try
                    {
                        connection.Open();

                        int affectedRows = command.ExecuteNonQuery();
                        isDeleted = affectedRows > 0;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isDeleted;
        }

        static public bool IsExistByBatchID(int batchID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM BatchesAllocation WHERE BatchID = @BatchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = batchID });

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteReader();
                        isFound = (result as SqlDataReader).HasRows;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }

        static public bool IsExistByBatchAllocationID(int BatchesAllocationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT BatchesAllocationID FROM BatchesAllocation WHERE BatchesAllocationID = @BatchesAllocationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BatchesAllocationID", SqlDbType.Int) { Value = BatchesAllocationID });

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        isFound = result != null;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }

        static public DataTable GetBatchesAllocations()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_BatchesAllocation_View";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return dt;
        }

        public static DataTable GetBatchAllocations(int tutorID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "select * from View_BatchesAllocation_View where Tutor = (select FullName from View_Tutors_Info where TutorID = @TutorID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = tutorID });    

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return dt;
        }
    }
}
