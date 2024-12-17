using BusinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SA.Globle
{
    static public class clsGloble
    {
        public static clsUser CurrentUser;

        private static string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\SA";

        public static void SaveUserIdAndPassword(string UserID, string Password)
        {

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, "UserID", UserID, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", Password, RegistryValueKind.String);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        public static bool GetUsreIDAndPassword(ref string UserID, ref string Password)
        {

            try
            {
                // Read the value from the Registry
                UserID = Registry.GetValue(keyPath, "UserID", null) as string;
                Password = Registry.GetValue(keyPath, "Password", null) as string;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return UserID != null && Password != null;
        }

        public static void DeleteUserSavedInfo()
        {
            string KEYBATH = @"SOFTWARE\SA";
            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(KEYBATH, true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue("UserID");
                            key.DeleteValue("Password");

                        }                      
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException: Run the program with administrative privileges.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        static public bool IsValidEmail(this string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }


    }
}
