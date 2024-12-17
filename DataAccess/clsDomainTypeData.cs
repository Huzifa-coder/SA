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
    public class clsDomainTypeData
    {

        static public bool GetDomainType(int DomainTypeID, ref string DomainTypeName)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM DomainTypes WHERE DomainTypeID = @DomainTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DomainTypeID", DomainTypeID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null && reader.Read())
                            {
                                DomainTypeName = reader.GetString(reader.GetOrdinal("DomainTypeName"));
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

        static public bool GetDomainType(string DomainTypeName, ref int DomainTypeID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM DomainTypes WHERE DomainTypeName = @DomainTypeName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainTypeName", SqlDbType.NVarChar) { Value = DomainTypeName });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
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

        static public int AddNewDomainType(string DomainTypeName)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[DomainTypes] ([DomainTypeName]) VALUES (@DomainTypeName); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainTypeName", SqlDbType.NVarChar, 50) { Value = DomainTypeName });

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

        static public bool UpdateDomainTypeInfo(int DomainTypeID, string DomainTypeName)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[DomainTypes] SET [DomainTypeName] = @DomainTypeName WHERE DomainTypeID = @DomainTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainTypeID", SqlDbType.Int) { Value = DomainTypeID });
                    command.Parameters.Add(new SqlParameter("@DomainTypeName", SqlDbType.NVarChar, 50) { Value = DomainTypeName });

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

        static public bool DeleteDomainType(int DomainTypeID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM [dbo].[DomainTypes] WHERE DomainTypeID = @DomainTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainTypeID", SqlDbType.Int) { Value = DomainTypeID });

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

        static public bool IsExist(int DomainTypeID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT DomainTypeID FROM DomainTypes WHERE DomainTypeID = @DomainTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DomainTypeID", SqlDbType.Int) { Value = DomainTypeID });

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

        static public DataTable GetDomainTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM DomainTypes";

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
