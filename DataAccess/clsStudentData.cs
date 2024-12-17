using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Configuration;
using static DataAccess.clsSettings;

namespace DataAccess
{
    public class clsStudentData
    {
        static public bool GetStudentByStudentID(int StudentID, ref int PersonID, ref string Phone, ref string Email,
             ref DateTime JoinDate, ref int BatchID, ref string CreatedBy)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Students WHERE StudentID = @StudentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = StudentID });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"));
                                Phone = reader.GetString(reader.GetOrdinal("Phone"));
                                Email = reader.GetString(reader.GetOrdinal("Email"));
                                JoinDate = reader.GetDateTime(reader.GetOrdinal("JoinDate"));
                                BatchID = reader.GetInt32(reader.GetOrdinal("BatchID"));
                                CreatedBy = reader.GetString(reader.GetOrdinal("CreatedBy"));

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }

        static public bool GetStudentByPersonID(int PersonID, ref int StudentID, ref string Phone, ref string Email,
             ref DateTime JoinDate, ref int BatchID, ref string CreatedBy)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Students WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID"));
                                Phone = reader.GetString(reader.GetOrdinal("Phone"));
                                Email = reader.GetString(reader.GetOrdinal("Email"));
                                JoinDate = reader.GetDateTime(reader.GetOrdinal("JoinDate"));
                                BatchID = reader.IsDBNull(reader.GetOrdinal("BatchID")) ? -1 : reader.GetInt32(reader.GetOrdinal("BatchID"));
                                CreatedBy = reader.GetString(reader.GetOrdinal("CreatedBy"));

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }

        static public int AddNewStudent(int PersonID, string Phone, string Email,
             DateTime JoinDate, int BatchID, string CreatedBy)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Students] ([PersonID],[Phone],[Email],[JoinDate],[BatchID]," +
                               "[CreatedBy]) VALUES " +
                               "(@PersonID,@Phone,@Email,@JoinDate,@BatchID,@CreatedBy); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });
                    command.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = Phone });
                    command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = Email });
                    command.Parameters.Add(new SqlParameter("@JoinDate", SqlDbType.Date) { Value = JoinDate }); // Updated to SqlDbType.Date
                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = BatchID });
                    command.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar) { Value = CreatedBy });

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

        static public bool UpdateStudentInfo(int StudentID, int PersonID, string Phone, string Email,
             DateTime JoinDate, int BatchID)
        {
            bool IsUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[Students] SET " +
                               "[PersonID] = @PersonID, " +
                               "[Phone] = @Phone, " +
                               "[Email] = @Email, " +
                               "[JoinDate] = @JoinDate, " +
                               "[BatchID] = @BatchID " +
                               "WHERE StudentID = @StudentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = StudentID });
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });
                    command.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = Phone });
                    command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = Email });
                    command.Parameters.Add(new SqlParameter("@JoinDate", SqlDbType.Date) { Value = JoinDate }); // Updated to SqlDbType.Date
                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = BatchID });

                    try
                    {
                        connection.Open();

                        int AffectedRows = command.ExecuteNonQuery();
                        IsUpdated = AffectedRows > 0;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsUpdated;
        }

        static public bool DeleteStudent(int StudentID)
        {
            bool IsDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string procedure = "SP_DeleteStduent";

                using (SqlCommand command = new SqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = StudentID });

                    SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    command.Parameters.Add(returnParameter);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        IsDeleted = (int)returnParameter.Value == 1;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsDeleted;
        }

        static public bool IsExistByStudentID(int StudentID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT StudentID FROM Students WHERE StudentID = @StudentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = StudentID });

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        IsFound = result != null;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsFound;
        }

        static public bool IsExistByPersonID(int PersonID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT PersonID FROM Students WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        IsFound = result != null;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsFound;
        }

        static public DataTable GetStudents()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_Students_Info";

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

        static public DataTable GetStudents(string UserID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_Students_Info WHERE CreatedBy = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = UserID });

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

        static public DataTable GetNotifiyStudentsList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT TOP (1000) [View_Students_Info].[StudentID], [fullName], [Phone], [Email], [Tutor], [JoinDate], [BatchName], [CreatedBy] " +
                               "FROM [SA].[dbo].[View_Students_Info] " +
                               "INNER JOIN Payments ON [View_Students_Info].StudentID = Payments.StudentID " +
                               "WHERE Payments.Amount != Payments.PaidAmount " +
                               "AND Payments.DuaDate BETWEEN @TodayDate AND @FutureDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TodayDate", SqlDbType.Date) { Value = DateTime.Now.Date });
                    command.Parameters.Add(new SqlParameter("@FutureDate", SqlDbType.Date) { Value = DateTime.Now.Date.AddDays(2) });

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

        static public DataTable GetNotifiyStudentsList(string UserID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT [View_Students_Info].[StudentID], [fullName], [Phone], [Email], [Tutor], [JoinDate], [BatchName], [CreatedBy] " +
                               "FROM [SA].[dbo].[View_Students_Info] " +
                               "INNER JOIN Payments ON [View_Students_Info].StudentID = Payments.StudentID " +
                               "WHERE Payments.Amount != Payments.PaidAmount " +
                               "AND Payments.DuaDate BETWEEN @TodayDate AND @FutureDate " +
                               "AND View_Students_Info.CreatedBy = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TodayDate", SqlDbType.Date) { Value = DateTime.Now.Date });
                    command.Parameters.Add(new SqlParameter("@FutureDate", SqlDbType.Date) { Value = DateTime.Now.Date.AddDays(2) });
                    command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = UserID });

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
