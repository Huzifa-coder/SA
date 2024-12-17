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
    public class clsCourseData
    {

        static public bool GetCourse(int CourseID, ref string Name, ref int Duration, ref int Fees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Courses WHERE CourseID = @CourseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@CourseID", SqlDbType.Int) { Value = CourseID });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Name = reader["Name"] as string;
                                Duration = (int)reader["Duration"];
                                Fees = (int)reader["Fees"];

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

        static public bool GetCourse(string CourseName, ref int CourseID, ref int Duration, ref int Fees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Courses WHERE Name = @CourseName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@CourseName", SqlDbType.NVarChar) { Value = CourseName });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CourseID = (int)reader["CourseID"];
                                Duration = (int)reader["Duration"];
                                Fees = (int)reader["Fees"];

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

        static public int AddNewCourse(string Name, int Duration, int Fees)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Courses] ([Name], [Duration], [Fees]) VALUES " +
                               "(@Name, @Duration, @Fees); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = Name });
                    command.Parameters.Add(new SqlParameter("@Duration", SqlDbType.Int) { Value = Duration });
                    command.Parameters.Add(new SqlParameter("@Fees", SqlDbType.Int) { Value = Fees });

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

        static public bool UpdateCourseInfo(int CourseID, string Name, int Duration, int Fees)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[Courses] SET [Name] = @Name, [Duration] = @Duration, [Fees] = @Fees " +
                               "WHERE CourseID = @CourseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@CourseID", SqlDbType.Int) { Value = CourseID });
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = Name });
                    command.Parameters.Add(new SqlParameter("@Duration", SqlDbType.Int) { Value = Duration });
                    command.Parameters.Add(new SqlParameter("@Fees", SqlDbType.Int) { Value = Fees });

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

        static public bool DeleteCourse(int CourseID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM [dbo].[Courses] WHERE CourseID = @CourseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@CourseID", SqlDbType.Int) { Value = CourseID });

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

        static public bool IsExist(int CourseID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT CourseID FROM Courses WHERE CourseID = @CourseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@CourseID", SqlDbType.Int) { Value = CourseID });

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

        static public DataTable GetCourses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Courses";

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
