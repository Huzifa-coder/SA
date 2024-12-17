using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.clsSettings;

namespace DataAccess
{
    public class clsDomainData
    {
        static public bool GetDomain(int DomainID, ref string DomainName, ref int DomainTypeID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Domains WHERE DomainID = @DomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DomainID", DomainID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null && reader.Read())
                            {
                                DomainName = reader.GetString(reader.GetOrdinal("DomainName"));
                                DomainTypeID = reader.GetInt32(reader.GetOrdinal("DomainTypeID"));

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

        static public bool GetDomain(string DomainName, int DomainTypeID, ref int DomainID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Domains WHERE DomainName = @DomainName And DomainTypeID = @DomainTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainName", SqlDbType.NVarChar, 50) { Value = DomainName });
                    command.Parameters.Add(new SqlParameter("@DomainTypeID", SqlDbType.Int) { Value = DomainTypeID });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
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

        static public int AddNewDomain(string DomainName, int DomainTypeID)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Domains] ([DomainName], [DomainTypeID]) VALUES (@DomainName, @DomainTypeID); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainName", SqlDbType.NVarChar, 50) { Value = DomainName });
                    command.Parameters.Add(new SqlParameter("@DomainTypeID", SqlDbType.Int) { Value = DomainTypeID });

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

        static public bool UpdateDomainInfo(int DomainID, string DomainName, int DomainTypeID)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[Domains] SET [DomainName] = @DomainName, [DomainTypeID] = @DomainTypeID WHERE DomainID = @DomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainID", SqlDbType.Int) { Value = DomainID });
                    command.Parameters.Add(new SqlParameter("@DomainName", SqlDbType.NVarChar, 50) { Value = DomainName });
                    command.Parameters.Add(new SqlParameter("@DomainTypeID", SqlDbType.Int) { Value = DomainTypeID });

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

        static public bool DeleteDomain(int DomainID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM [dbo].[Domains] WHERE DomainID = @DomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainID", SqlDbType.Int) { Value = DomainID });

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

        static public bool IsExist(int DomainID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT DomainID FROM Domains WHERE DomainID = @DomainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainID", SqlDbType.Int) { Value = DomainID });

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

        static public DataTable GetDomains()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "select DomainID, DomainName, DomainTypeName from Domains inner join DomainTypes on Domains.DomainTypeID = DomainTypes.DomainTypeID;";

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

        public static DataTable GetDomains(int DomainType)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Domains WHERE DomainTypeID = @DomainTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainTypeID", SqlDbType.Int) { Value = DomainType });
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
