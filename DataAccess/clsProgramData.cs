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
    public class clsProgramData
    {
       
        // Method to get a program by ProgramID
        static public bool GetProgram(int ProgramID, ref string ProgramName, ref string Duration, ref int DomainID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Programs WHERE ProgramID = @ProgramID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProgramID", ProgramID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null && reader.Read())
                            {
                                ProgramName = reader.GetString(reader.GetOrdinal("ProgramName"));
                                Duration = reader.GetString(reader.GetOrdinal("Duration"));  // Change to GetString
                                DomainID = reader.GetInt32(reader.GetOrdinal("DomainID"));
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

        // Overloaded method to get a program by ProgramName
        static public bool GetProgram(string ProgramName, ref int ProgramID, ref string Duration, ref int DomainID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT ProgramID, Duration, DomainID FROM Programs WHERE ProgramName = @ProgramName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ProgramName", SqlDbType.NVarChar) { Value = ProgramName });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null && reader.Read())
                            {
                                ProgramID = reader.GetInt32(reader.GetOrdinal("ProgramID"));
                                Duration = reader.GetString(reader.GetOrdinal("Duration"));  // Change to GetString
                                DomainID = reader.GetInt32(reader.GetOrdinal("DomainID"));
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

        // Method to add a new program
        static public int AddNewProgram(string ProgramName, string Duration, int DomainID)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Programs] ([ProgramName], [Duration], [DomainID]) VALUES " +
                               "(@ProgramName, @Duration, @DomainID); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ProgramName", SqlDbType.NVarChar) { Value = ProgramName });
                    command.Parameters.Add(new SqlParameter("@Duration", SqlDbType.NVarChar) { Value = Duration });  // Change to NVarChar
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

        // Method to update program info
        static public bool UpdateProgramInfo(int ProgramID, string ProgramName, string Duration, int DomainID)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[Programs] SET [ProgramName] = @ProgramName, [Duration] = @Duration, [DomainID] = @DomainID WHERE ProgramID = @ProgramID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int) { Value = ProgramID });
                    command.Parameters.Add(new SqlParameter("@ProgramName", SqlDbType.NVarChar) { Value = ProgramName });
                    command.Parameters.Add(new SqlParameter("@Duration", SqlDbType.NVarChar) { Value = Duration });  // Change to NVarChar
                    command.Parameters.Add(new SqlParameter("@DomainID", SqlDbType.Int) { Value = DomainID });

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

        // Method to delete a program
        static public bool DeleteProgram(int ProgramID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM [dbo].[Programs] WHERE ProgramID = @ProgramID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int) { Value = ProgramID });

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

        // Method to check if a program exists
        static public bool IsExist(int ProgramID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT ProgramID FROM Programs WHERE ProgramID = @ProgramID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int) { Value = ProgramID });

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

        // Method to get all programs
        static public DataTable GetPrograms()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_Programs_Info";

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

        static public DataTable GetPrograms(int DomainID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Programs WHERE DomainID = @DomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainID", SqlDbType.Int) { Value = DomainID});
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
