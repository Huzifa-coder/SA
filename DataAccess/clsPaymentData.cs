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
    public class clsPaymentData
    {
        static public bool GetPaymentByPaymentID(int PaymentID, ref int Amount, ref int PaidAmount, ref DateTime DuaDate, ref int StudentID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PaymentID", SqlDbType.Int) { Value = PaymentID });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                                PaidAmount = reader.GetInt32(reader.GetOrdinal("PaidAmount"));
                                DuaDate = reader.GetDateTime(reader.GetOrdinal("DuaDate"));
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID"));

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

        public static bool GetPaymentByStudentID(int StudentID, ref int Amount, ref int PaidAmount, ref DateTime DueDate, ref int PaymentID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM Payments WHERE StudentID = @StudentID";

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
                                Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                                PaidAmount = reader.GetInt32(reader.GetOrdinal("PaidAmount"));
                                DueDate = reader.GetDateTime(reader.GetOrdinal("DuaDate"));
                                PaymentID = reader.GetInt32(reader.GetOrdinal("PaymentID"));

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

        static public int AddNewPayment(int Amount, int PaidAmount, DateTime DuaDate, int StudentID)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "INSERT INTO [dbo].[Payments] ([Amount], [PaidAmount], [DuaDate], [StudentID]) VALUES " +
                               "(@Amount, @PaidAmount, @DuaDate, @StudentID); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int) { Value = Amount });
                    command.Parameters.Add(new SqlParameter("@PaidAmount", SqlDbType.Int) { Value = PaidAmount });
                    command.Parameters.Add(new SqlParameter("@DuaDate", SqlDbType.Date) { Value = DuaDate });
                    command.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = StudentID });

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

        static public bool UpdatePaymentInfo(int PaymentID, int Amount, int PaidAmount, DateTime DuaDate, int StudentID)
        {
            int AffectedRows = -1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "UPDATE [dbo].[Payments] SET [Amount] = @Amount, " +
                               "[PaidAmount] = @PaidAmount, DuaDate = @DuaDate, [StudentID] = @StudentID " +
                               "WHERE PaymentID = @PaymentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PaymentID", SqlDbType.Int) { Value = PaymentID });
                    command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int) { Value = Amount });
                    command.Parameters.Add(new SqlParameter("@PaidAmount", SqlDbType.Int) { Value = PaidAmount });
                    command.Parameters.Add(new SqlParameter("@DuaDate", SqlDbType.Date) { Value = DuaDate });
                    command.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = StudentID });

                    try
                    {
                        connection.Open();

                        AffectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        WriteEventLogEntry(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return AffectedRows > 0;
        }

        static public bool DeletePayment(int PaymentID)
        {
            bool IsDeleted = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "DELETE FROM [dbo].[Payments] WHERE PaymentID = @PaymentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PaymentID", SqlDbType.Int) { Value = PaymentID });

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

        static public bool IsExistByPaymentID(int PaymentID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT PaymentID FROM Payments WHERE PaymentID = @PaymentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PaymentID", SqlDbType.Int) { Value = PaymentID });

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

        static public bool IsExistByStudentID(int StudentID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT PaymentID FROM Payments WHERE StudentID = @StudentID";

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

        static public DataTable GetPayments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString))
            {
                string query = "SELECT * FROM View_Payments_Info";

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
