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
    public class clsPersonData
    {
   
        static public bool GetPerson(int PersonID, ref string FirstName, ref string LastName)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM People WHERE PersonID = @PersonID";

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
                                FirstName = reader["FirstName"] as string;
                                LastName = reader["LastName"] as string;

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

        static public int AddNewPerson(string FirstName, string LastName)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[People] ([FirstName], [LastName]) VALUES " +
                               "(@FirstName, @LastName); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = FirstName });
                    command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = LastName });

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
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

        static public bool UpdatePersonInfo(int PersonID, string FirstName, string LastName)
        {
            bool IsUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[People] SET [FirstName] = @FirstName, " +
                               "[LastName] = @LastName WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });
                    command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = FirstName });
                    command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = LastName });

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

        static public bool DeletePerson(int PersonID)
        {
            bool IsDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM [dbo].[People] WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });

                    try
                    {
                        connection.Open();

                        int AffectedRows = command.ExecuteNonQuery();
                        IsDeleted = AffectedRows > 0;

                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsDeleted;
        }

        static public bool IsExist(int PersonID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT PersonID FROM People WHERE PersonID = @PersonID";

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

        static public DataTable GetPeople()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM People";

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

        public static int GetPersonID(string fullName)
        {
            int PersonID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "select PersonID from People where " + 
                               "FirstName + ' ' + LastName = @FullName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar) { Value = fullName });

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        PersonID = (int)result;

                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return PersonID;
        }
    }
}
