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
    public class clsTeachingDomainData
    {
        static public bool GetTeachingDomainByID(int TeachingDomainID, ref int TutorID, ref int DomainID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM TeachingDomains WHERE TeachingDomainID = @TeachingDomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TeachingDomainID", SqlDbType.Int) { Value = TeachingDomainID });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TutorID = reader.GetInt32(reader.GetOrdinal("TutorID"));
                                DomainID = reader.GetInt32(reader.GetOrdinal("DomainID"));

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

        static public int AddNewTeachingDomain(int TutorID, int DomainID)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[TeachingDomains] ([TutorID],[DomainID]) VALUES " +
                               "(@TutorID,@DomainID); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = TutorID });
                    command.Parameters.Add(new SqlParameter("@DomainID", SqlDbType.Int) { Value = DomainID });

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

        static public bool UpdateTeachingDomainInfo(int TeachingDomainID, int TutorID, int DomainID)
        {
            bool IsUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[TeachingDomains] SET " +
                               "[TutorID] = @TutorID, " +
                               "[DomainID] = @DomainID " +
                               "WHERE TeachingDomainID = @TeachingDomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TeachingDomainID", SqlDbType.Int) { Value = TeachingDomainID });
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = TutorID });
                    command.Parameters.Add(new SqlParameter("@DomainID", SqlDbType.Int) { Value = DomainID });

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

        static public bool DeleteTeachingDomain(int TeachingDomainID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM TeachingDomains WHERE TeachingDomainID = @TeachingDomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TeachingDomainID", SqlDbType.Int) { Value = TeachingDomainID });

                    try
                    {
                        connection.Open();
                        int affectedRows = command.ExecuteNonQuery();
                        isDeleted = affectedRows > 0;
                    }
                    catch (Exception ex)
                    {
                        isDeleted = false;
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isDeleted;
        }

        static public bool IsTeachingDomainExist(int TeachingDomainID)
        {
            bool isExist = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT COUNT(1) FROM TeachingDomains WHERE TeachingDomainID = @TeachingDomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TeachingDomainID", SqlDbType.Int) { Value = TeachingDomainID });

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        isExist = count > 0;
                    }
                    catch (Exception ex)
                    {
                        isExist = false;
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isExist;
        }

        static public bool IsTeachingDomainExist(int TutorID, int DomainID)
        {
            bool isExist = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT COUNT(1) FROM TeachingDomains WHERE DomainID = @DomainID AND TutorID = @TutorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainID", SqlDbType.Int) { Value = DomainID });
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int) { Value = TutorID });

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        isExist = count > 0;
                    }
                    catch (Exception ex)
                    {
                        isExist = false;
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isExist;
        }

        static public DataTable GetTeachingDomains(int TutorID)
        {
            DataTable teachingDomainsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_TutorTeachingDomains_Info WHERE TutorID = @TutorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TutorID", SqlDbType.Int){ Value = TutorID });
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                                teachingDomainsTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return teachingDomainsTable;
        }

        static public DataTable GetTeachingDomains()
        {
            DataTable teachingDomainsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_TutorTeachingDomains_Info";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)  
                                teachingDomainsTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return teachingDomainsTable;
        }

        public static DataTable GetTutorsByDomain(int domainID)
        {
            DataTable tutors = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_TutorTeachingDomains_Info";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                tutors.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return tutors;
        }
    }
}
