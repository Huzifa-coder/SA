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
    public class clsUserData
    {
        static public bool GetUser(string UserID, ref int PersonID, ref string Password, ref short Permissions)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = UserID });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null && reader.Read())
                            {
                                PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"));
                                Password = reader.GetString(reader.GetOrdinal("Password"));
                                Permissions = reader.GetInt16(reader.GetOrdinal("Permissions"));

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        static public bool GetUser(int PersonID, ref string UserID, ref string Password, ref short Permissions)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null && reader.Read())
                            {
                                UserID = reader.GetString(reader.GetOrdinal("UserID"));
                                Password = reader.GetString(reader.GetOrdinal("Password"));
                                Permissions = reader.GetInt16(reader.GetOrdinal("Permissions"));

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        static public bool AddNewUser(string UserID, int PersonID, string Password, short Permissions)
        {
            bool isAdded = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Users] ([UserID], [PersonID], [Password], [Permissions]) " +
                               "VALUES (@UserID, @PersonID, @Password, @Permissions); " +
                               "SELECT UserID FROM [dbo].[Users] WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = UserID });
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });
                    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar) { Value = Password });
                    command.Parameters.Add(new SqlParameter("@Permissions", SqlDbType.SmallInt) { Value = Permissions });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader result = command.ExecuteReader())
                        {
                            if (result != null && result.Read())
                            {
                                isAdded = result.GetString(result.GetOrdinal("UserID")) == UserID;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return isAdded;
        }

        static public bool UpdateUserInfo(string UserID, int PersonID, string Password, short Permissions)
        {
            int affectedRows = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[Users] SET [PersonID] = @PersonID, [Password] = @Password, [Permissions] = @Permissions " +
                               "WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = UserID });
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });
                    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar) { Value = Password });
                    command.Parameters.Add(new SqlParameter("@Permissions", SqlDbType.SmallInt) { Value = Permissions });

                    try
                    {
                        connection.Open();
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return affectedRows > 0;
        }

        static public bool DeleteUser(string UserID)
        {
            bool IsDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM [dbo].[Users] WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = UserID });

                    try
                    {
                        connection.Open();
                        int affectedRows = command.ExecuteNonQuery();
                        IsDeleted = affectedRows > 0;

                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsDeleted;
        }

        static public bool IsExist(string UserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT UserID FROM Users WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = UserID });

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

        static public bool IsExist(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT UserID FROM Users WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });

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

        static public DataTable GetUsers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_Users_Info";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null && reader.HasRows)
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
