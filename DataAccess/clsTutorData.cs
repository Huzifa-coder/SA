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
    public class clsTutorData
    {
        static public bool GetTutorByTutorID(int TutorID, ref int PersonID, ref string Phone)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Tutor WHERE TutorID = @TutorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = TutorID });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"));
                                Phone = reader.GetString(reader.GetOrdinal("Phone"));
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

        static public bool GetTutorByPersonID(int PersonID, ref int TutorID, ref string Phone)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Tutor WHERE PersonID = @PersonID";

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
                                TutorID = reader.GetInt32(reader.GetOrdinal("TutorID"));
                                Phone = reader.GetString(reader.GetOrdinal("Phone"));
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

        static public int AddNewTutor(int PersonID, string Phone)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Tutor] ([PersonID], [Phone]) VALUES (@PersonID, @Phone); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });
                    command.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = Phone });

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

        static public bool UpdateTutorInfo(int TutorID, int PersonID, string Phone)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[Tutor] SET [PersonID] = @PersonID, [Phone] = @Phone WHERE TutorID = @TutorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = TutorID });
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });
                    command.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = Phone });

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

        static public bool DeleteTutor(int TutorID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM [dbo].[Tutor] WHERE TutorID = @TutorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = TutorID });

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

        static public bool IsExistByTutorID(int TutorID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT TutorID FROM Tutor WHERE TutorID = @TutorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = TutorID });

                    try
                    {
                        connection.Open();

                        object ob = command.ExecuteScalar();

                        if (ob != null)
                        {
                            isFound = (int)command.ExecuteScalar() > 0;
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

        static public bool IsExistByPersonID(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT 1 FROM Tutor WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });

                    try
                    {
                        connection.Open();
                        object ob = command.ExecuteScalar();

                        if (ob != null)
                        {
                            isFound = (int)command.ExecuteScalar() > 0;
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

        static public DataTable GetTutors()
        {
            DataTable tutorsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_Tutors_Info";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            tutorsTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return tutorsTable;
        }

        static public DataTable GetTutors(int DomainID)
        {
            DataTable tutorsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "select FirstName + ' ' + LastName As FullName from People  " +
                               "inner join Tutor on Tutor.PersonID = People.PersonID " +
                               "inner join TeachingDomains on TeachingDomains.TutorID = Tutor.TutorID " +
                               "where TeachingDomains.DomainID = @DomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainID", SqlDbType.Int) { Value = DomainID});

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            tutorsTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return tutorsTable;
        }

        public static bool IsTutorEmptyForBatch(int batchID, TimeSpan startTime, TimeSpan endTime)
        {
            bool IsEmpty = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string procedure = "IsTutorEmptyForBatch";

                using (SqlCommand command = new SqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int) { Value = batchID });
                    command.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.Time) { Value = startTime });
                    command.Parameters.Add(new SqlParameter("@EndTime", SqlDbType.Time) { Value = endTime });

                    SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };

                    command.Parameters.Add(returnParameter);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        IsEmpty = (int)returnParameter.Value == 1;
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsEmpty;
        }

        public static DataTable GetTutorFreeTimeList(int tutorID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "select * from GetAvalableTimePerTutor(@TutorID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = tutorID });

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
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
