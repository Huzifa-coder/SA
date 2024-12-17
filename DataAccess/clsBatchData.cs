using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static DataAccess.clsSettings;

namespace DataAccess
{
    public class clsBatchData
    {
        static public bool GetBatch(int BatchID, ref string Name, ref int TutorID, ref DateTime StartDate, ref DateTime EndDate, ref int ProgramID, ref int Capacity, ref int Mode, ref string OnGoingTopic, ref byte Status)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Batches WHERE BatchID = @BatchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BatchID", BatchID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null && reader.Read())
                            {
                                Name = reader.GetString(reader.GetOrdinal("Name"));
                                TutorID = reader.GetInt32(reader.GetOrdinal("TutorID"));
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
                                ProgramID = reader.GetInt32(reader.GetOrdinal("ProgramID"));
                                Capacity = reader.GetInt32(reader.GetOrdinal("Capacity"));
                                Mode = reader.GetInt32(reader.GetOrdinal("Mode"));
                                Status = reader.GetByte(reader.GetOrdinal("Status"));

                                if (reader["OnGoingTopic"] == DBNull.Value)
                                    OnGoingTopic = string.Empty;
                                else
                                    OnGoingTopic = reader.GetString(reader.GetOrdinal("OnGoingTopic"));

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

        static public bool GetBatch(string BatchName, ref int TutorID, ref int BatchID, ref DateTime StartDate, ref DateTime EndDate, ref int ProgramID, ref int Capacity, ref int Mode, ref string OnGoingTopic, ref byte Status)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT BatchID, TutorID, StartDate, EndDate, ProgramID, Capacity, Mode, OnGoingTopic, Status FROM Batches WHERE Name = @BatchName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BatchName", SqlDbType.NChar) { Value = BatchName });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                BatchID = reader.GetInt32(reader.GetOrdinal("BatchID"));
                                TutorID = reader.GetInt32(reader.GetOrdinal("TutorID"));
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
                                ProgramID = reader.GetInt32(reader.GetOrdinal("ProgramID"));
                                Capacity = reader.GetInt32(reader.GetOrdinal("Capacity"));
                                Mode = reader.GetInt32(reader.GetOrdinal("Mode"));
                                Status = reader.GetByte(reader.GetOrdinal("Status"));

                                if (reader.IsDBNull(reader.GetOrdinal("OnGoingTopic")))
                                    OnGoingTopic = string.Empty;
                                else
                                    OnGoingTopic = reader.GetString(reader.GetOrdinal("OnGoingTopic"));

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

        static public int AddNewBatch(string Name, int TutorID, DateTime StartDate, DateTime EndDate, int ProgramID, int Capacity, int Mode, string OnGoingTopic, byte Status)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Batches] ([Name], [TutorID], [StartDate], [EndDate], [ProgramID], [Capacity], [Mode], [OnGoingTopic], [Status]) VALUES " +
                               "(@Name, @TutorID, @StartDate, @EndDate, @ProgramID, @Capacity, @Mode, @OnGoingTopic, @Status); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NChar) { Value = Name });
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = TutorID });
                    command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.Date) { Value = StartDate });
                    command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.Date) { Value = EndDate });
                    command.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int) { Value = ProgramID });
                    command.Parameters.Add(new SqlParameter("@Capacity", SqlDbType.Int) { Value = Capacity });
                    command.Parameters.Add(new SqlParameter("@Mode", SqlDbType.Int) { Value = Mode });
                    command.Parameters.Add(new SqlParameter("@Status", SqlDbType.TinyInt) { Value = Status });
                    command.Parameters.Add(new SqlParameter("@OnGoingTopic", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(OnGoingTopic) ? (object)DBNull.Value : OnGoingTopic });

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
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return ID;
        }

        static public bool UpdateBatchInfo(int BatchID, string Name, int TutorID, DateTime StartDate, DateTime EndDate, int ProgramID, int Capacity, int Mode, string OnGoingTopic, byte Status)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[Batches] SET [Name] = @Name, [TutorID] = @TutorID, [StartDate] = @StartDate, [EndDate] = @EndDate, " +
                               "[ProgramID] = @ProgramID, [Capacity] = @Capacity, [Mode] = @Mode, [OnGoingTopic] = @OnGoingTopic, [Status] = @Status WHERE BatchID = @BatchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = BatchID });
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NChar) { Value = Name });
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = TutorID });
                    command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.Date) { Value = StartDate });
                    command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.Date) { Value = EndDate });
                    command.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int) { Value = ProgramID });
                    command.Parameters.Add(new SqlParameter("@Capacity", SqlDbType.Int) { Value = Capacity });
                    command.Parameters.Add(new SqlParameter("@Mode", SqlDbType.Int) { Value = Mode });
                    command.Parameters.Add(new SqlParameter("@Status", SqlDbType.TinyInt) { Value = Status });
                    command.Parameters.Add(new SqlParameter("@OnGoingTopic", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(OnGoingTopic) ? (object)DBNull.Value : OnGoingTopic });

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

        static public bool DeleteBatch(int BatchID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string procedure = "SP_DeleteBatch";

                using (SqlCommand command = new SqlCommand(procedure , connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = BatchID });

                    SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };  
                    command.Parameters.Add(returnParameter);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        isDeleted = (int)returnParameter.Value == 1;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isDeleted;
        }

        static public bool IsExist(int BatchID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT BatchID FROM Batches WHERE BatchID = @BatchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = BatchID });

                    try
                    {
                        connection.Open();

                        int count = (int)command.ExecuteScalar();
                        isFound = count > 0;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }

        static public DataTable GetBatches()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "select * , dbo.BatchHasAllocation(BatchID)as hasAllocation from View_Batches_Info";

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

        public static bool IsFull(int BatchID)
        {
            bool IsFull = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT 1 FROM Batches WHERE BatchID = @BatchID AND Capacity > (SELECT COUNT(*) STUDENTS WHERE BatchID = @BatchID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = BatchID });

                    try
                    {
                        connection.Open();

                        int count = (int)command.ExecuteScalar();
                        IsFull = count > 0;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsFull;
        }

        public static DataTable GetBatchesTimes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "select * from View_BatchesTimes_Info";

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
    }
}
