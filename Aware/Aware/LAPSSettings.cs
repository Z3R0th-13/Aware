using System;

namespace Aware
{
    public class LAPSSettings
    {
        public static void ListLapsSettings() // Checks to see if LAPs registry keys are on the machine. 
        {
            Console.WriteLine("\r\n=== LAPS Settings ===\r\n");

            string admPwdEnabled = getRegValue.GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "AdmPwdEnabled");

            if (admPwdEnabled != string.Empty)
            {
                Console.WriteLine("  {0,-37} : {1}", "LAPS Enabled", admPwdEnabled);

                string lAPSAdminAccountName = getRegValue.GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "AdminAccountName");
                Console.WriteLine("  {0,-37} : {1}", "LAPS Admin Account Name", lAPSAdminAccountName);

                string lAPSPasswordComplexity = getRegValue.GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "PasswordComplexity");
                Console.WriteLine("  {0,-37} : {1}", "LAPS Password Complexity", lAPSPasswordComplexity);

                string lAPSPasswordLength = getRegValue.GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "PasswordLength");
                Console.WriteLine("  {0,-37} : {1}", "LAPS Password Length", lAPSPasswordLength);

                string lAPSwdExpirationProtectionEnabled = getRegValue.GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "PwdExpirationProtectionEnabled");
                Console.WriteLine("  {0,-37} : {1}", "LAPS Expiration Protection Enabled", lAPSwdExpirationProtectionEnabled);
            }
            else
            {
                Console.WriteLine("\t" + "[*] LAPS is not enabled");
            }
        }
    }
}