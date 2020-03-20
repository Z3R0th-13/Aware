using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Security.Principal;
using System.Diagnostics;
using System.Collections.Generic;

namespace Aware
{
    class Program
    {
        public static void Banner()
        {
            Console.WriteLine(@"   _____  __      __  _____ _____________________
  /  _  \/  \    /  \/  _  \\______   \_   _____/
 /  /_\  \   \/\/   /  /_\  \|       _/|    __)_ 
/    |    \        /    |    \    |   \|        \
\____|__  /\__/\  /\____|__  /____|_  /_______  /
        \/      \/         \/       \/        \/ 
             _____)        _____)                
            /_____/       /_____/                
            /    \        /    \                 
           (  ()  )      (  ()  )                
            \____/ ______ \____/                 
                  /_____/                        ");
        }

        public static void DateandTime() // Will grab the machines current date as well as UTC
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            Console.WriteLine("\r\n=== Date / Time ===\r\n");
            Console.WriteLine("\t" + "[*] " + "Current localtime is: " + localDate);
            Console.WriteLine("\t" + "[*] " + "UTC current time is: " + utcDate);
        }
    
        public static void IEEnum() // Checks the registry for manually typed in URLs in Internet Explorer.
        {
            RegistryKey checkme = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\"); // Registry hive and keys to look at. 

            object URLs = checkme.GetValue("TypedURLs", ""); // Subkey to actually look at

            if (URLs != null)
            {
                using (RegistryKey tempKey = checkme.OpenSubKey("TypedURLs"))
                {
                    Console.WriteLine("\r\n=== TYPED URLS ===\r\n");
                    foreach (string valueName in tempKey.GetValueNames()) // For every value in the subkey, print the values.
                    {
                        Console.WriteLine("\t" + "[*] " + "{0}: {1}", valueName, tempKey.GetValue(valueName).ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("\r\n=== TYPED URLS ===\r\n");
                Console.WriteLine("\t" + "[*] " + "I couldn't find anything");
            }
        }

        public static void DefenderExclude() // Looks for Windows Defender Exclude settings.
        {
            try
            {
                RegistryKey checkme = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows Defender\\Exclusions\\"); // Registry hive and keys to look at

                object Excludes = checkme.GetValue("Paths", ""); // Subkey to actually look at

                if (Excludes != null)
                {
                    using (RegistryKey tempKey = checkme.OpenSubKey("Paths"))
                    {
                        Console.WriteLine("\r\n=== Windows Defender Path Exclusions ===\r\n");
                        foreach (string valueName in tempKey.GetValueNames()) // For every value in the subkey, print the values.
                        {
                            Console.WriteLine("\t" + "[*] " + "{0}: {1}", valueName, tempKey.GetValue(valueName).ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\r\n=== Windows Defender Path Exclusions ===\r\n");
                    Console.WriteLine("\t" + "[*] " + "I couldn't find anything");
                }
            }
            catch
            {
                // Do Nothing
            }
            try
            {
                RegistryKey checkme = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows Defender\\Exclusions\\"); // Registry hive and keys to look at

                object Excludes = checkme.GetValue("Extensions", ""); // Subkey to actually look at

                if (Excludes != null)
                {
                    using (RegistryKey tempKey = checkme.OpenSubKey("Extensions"))
                    {
                        Console.WriteLine("\r\n=== Windows Defender Extension Exclusions ===\r\n");
                        foreach (string valueName in tempKey.GetValueNames()) // For every value in the subkey, print the values.
                        {
                            Console.WriteLine("\t" + "[*] " + "{0}: {1}", valueName, tempKey.GetValue(valueName).ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\r\n=== Windows Defender Extension Exclusions ===\r\n");
                    Console.WriteLine("\t" + "[*] " + "I couldn't find anything");
                }
            }
            catch
            {
                // Do Nothing
            }
            try
            {
                RegistryKey checkme = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows Defender\\Exclusions\\"); // Hive and keys to look at

                object Excludes = checkme.GetValue("Processes", ""); // Subkey to actually look at 

                if (Excludes != null)
                {
                    using (RegistryKey tempKey = checkme.OpenSubKey("Processes"))
                    {
                        Console.WriteLine("\r\n=== Windows Defender Process Exclusions ===\r\n");
                        foreach (string valueName in tempKey.GetValueNames()) // For every value in the subkey, print the values.
                        {
                            Console.WriteLine("\t" + "[*] " + "{0}: {1}", valueName, tempKey.GetValue(valueName).ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\r\n=== Windows Defender Process Exclusions ===\r\n");
                    Console.WriteLine("\t" + "[*] " + "I couldn't find anything");
                }
            }
            catch
            {
                // Do Nothing
            }
            try
            {
                RegistryKey checkme = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows Defender\\Exclusions\\"); // Hive and keys to look at

                object Excludes = checkme.GetValue("TemporaryPaths", ""); // Subkey to actually look at

                if (Excludes != null)
                {
                    using (RegistryKey tempKey = checkme.OpenSubKey("TemporaryPaths"))
                    {
                        Console.WriteLine("\r\n=== Windows Defender Temporary Path Exclusions ===\r\n");
                        foreach (string valueName in tempKey.GetValueNames()) // For every value in the subkey, print the values.
                        {
                            Console.WriteLine("\t" + "[*] " + "{0}: {1}", valueName, tempKey.GetValue(valueName).ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\r\n=== Windows Defender Temporary Path Exclusions ===\r\n");
                    Console.WriteLine("\t" + "[*] " + "I couldn't find anything");
                }
            }
            catch
            {
                // Do Nothing
            }
        }

        public static void OfficeEnum()
        {
            try
            {
                RegistryKey checkme = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\16.0\\PowerPoint\\Security\\Trusted Documents"); // Hive and keys to look at

                object trustRecs = checkme.GetValue("TrustRecords", ""); // Subkey to actually look at

                if (trustRecs != null)
                {
                    using (RegistryKey tempKey = checkme.OpenSubKey("TrustRecords"))
                    {
                        Console.WriteLine("\r\n=== PPT TRUSTED FILES ===\r\n");
                        foreach (string valueName in tempKey.GetValueNames()) // For every value in the subkey, print the values.
                        {
                            Console.WriteLine("\t" + "[*] " + "{0}: {1}", valueName, tempKey.GetValue(valueName).ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\r\n=== PPT TRUSTED FILES ===\r\n");
                    Console.WriteLine("\t" + "[*] " + "I couldn't find anything");
                    Console.WriteLine(trustRecs);
                }
            }
            catch
            {
                // Do nothing
            }
            try
            {
                RegistryKey checkme = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\16.0\\Excel\\Security\\Trusted Documents"); // Hive and keys to look at
                object trustRecs = checkme.GetValue("TrustRecords", ""); // Subkey to actually look at

                if (trustRecs != null)
                {
                    using (RegistryKey tempKey = checkme.OpenSubKey("TrustRecords"))
                    {
                        Console.WriteLine("\r\n=== EXCEL TRUSTED FILES ===\r\n");
                        foreach (string valueName in tempKey.GetValueNames()) // For every value in the subkey, print the values.
                        {
                            Console.WriteLine("\t" + "[*] " + "{0}: {1}", valueName, tempKey.GetValue(valueName).ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\r\n=== EXCEL TRUSTED FILES ===\r\n");
                    Console.WriteLine("\t" + "[*] " + "I couldn't find anything");
                    Console.WriteLine(trustRecs);
                }
            }
            catch
            {
                // Do nothing
            }
            try
            {
                RegistryKey checkme = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\16.0\\Word\\Security\\Trusted Documents"); // Hive and keys to look at
                object trustRecs = checkme.GetValue("TrustRecords", ""); // Subkey to actually look at 

                if (trustRecs != null)
                {
                    using (RegistryKey tempKey = checkme.OpenSubKey("TrustRecords"))
                    {
                        Console.WriteLine("\r\n=== WORD TRUSTED FILES ===\r\n");
                        foreach (string valueName in tempKey.GetValueNames()) // For every value in the subkey, print the values
                        {
                            Console.WriteLine("\t" + "[*] " + "{0}: {1}", valueName, tempKey.GetValue(valueName).ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\r\n=== WORD TRUSTED FILES ===\r\n");
                    Console.WriteLine("\t" + "[*] " + "I couldn't find anything");
                    Console.WriteLine(trustRecs);
                }
            }
            catch
            {
                // Do nothing
            }

        }

        public static void Processes() // Check current running processes for different things such as AV, EDR, or VMs
        {
            Console.WriteLine("\r\n=== PROCESS CHECKING ===\r\n");
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                string checkme = theprocess.ProcessName;
                if (checkme == "MsMpEng") // Common Windows Defender process name
                {
                    Console.WriteLine("\t" + "[*] Windows Defender is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "masvc") // Common process for McAfee
                {
                    Console.WriteLine("\t" + "[*] McAfee Agent is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "Mcshield") // VSE Process
                {
                    Console.WriteLine("\t" + "[*] McAfee VSE is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "esensor") // Endgame process
                {
                    Console.WriteLine("\t" + "[*] ENDGAME is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "sysmon") // Sysmon process
                {
                    Console.WriteLine("\t" + "[*] SYSMON is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "Procmon") // Procmon process
                {
                    Console.WriteLine("\t" + "[*] Procmon is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "splunkd") // Splunk process
                {
                    Console.WriteLine("\t" + "[*] Splunk is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "TaniumClient") // Tanium process
                {
                    Console.WriteLine("\t" + "[*] Tanium is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "winlogbeat") // Winlogbeat process
                {
                    Console.WriteLine("\t" + "[*] Winlogbeat is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "vmnetdhcp") // Vmware DHCP process. Indicitive of running vmware.
                {
                    Console.WriteLine("\t" + "[*] Vmware is running");
                }
                else
                {
                    // Do nothing
                }
            }
        }

        public static void QueryMcafee() // Will query the McAfee registry key for exclusions. 
        {
            // NEED TO FIX THIS! I NEED THE REGISTRY PATH AND KEY VALUE FOR MCAFEE!
            RegistryKey exclusion = Registry.LocalMachine.OpenSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\McAfee\Endpoint\EXCLUSION");
            if (exclusion != null)
            {
                Console.WriteLine(exclusion.GetValue("setting"));
            }
            else
            {
                // Do nothing
            }
        }

        public static void ListLapsSettings() // Checks to see if LAPs registry keys are on the machine. 
        {
            Console.WriteLine("\r\n=== LAPS Settings ===\r\n");

            string AdmPwdEnabled = GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "AdmPwdEnabled");

            if (AdmPwdEnabled != "")
            {
                Console.WriteLine("  {0,-37} : {1}", "LAPS Enabled", AdmPwdEnabled);

                string LAPSAdminAccountName = GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "AdminAccountName");
                Console.WriteLine("  {0,-37} : {1}", "LAPS Admin Account Name", LAPSAdminAccountName);

                string LAPSPasswordComplexity = GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "PasswordComplexity");
                Console.WriteLine("  {0,-37} : {1}", "LAPS Password Complexity", LAPSPasswordComplexity);

                string LAPSPasswordLength = GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "PasswordLength");
                Console.WriteLine("  {0,-37} : {1}", "LAPS Password Length", LAPSPasswordLength);

                string LAPSwdExpirationProtectionEnabled = GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "PwdExpirationProtectionEnabled");
                Console.WriteLine("  {0,-37} : {1}", "LAPS Expiration Protection Enabled", LAPSwdExpirationProtectionEnabled);
            }
            else
            {
                Console.WriteLine("\t" + "[*] LAPS is not enabled");
            }
        }

        public static string GetRegValue(string hive, string path, string value)
        {
            // returns a single registry value under the specified path in the specified hive (HKLM/HKCU)
            string regKeyValue = "";
            if (hive == "HKCU")
            {
                var regKey = Registry.CurrentUser.OpenSubKey(path);
                if (regKey != null)
                {
                    regKeyValue = String.Format("{0}", regKey.GetValue(value));
                }
                return regKeyValue;
            }
            else if (hive == "HKU")
            {
                var regKey = Registry.Users.OpenSubKey(path);
                if (regKey != null)
                {
                    regKeyValue = String.Format("{0}", regKey.GetValue(value));
                }
                return regKeyValue;
            }
            else
            {
                var regKey = Registry.LocalMachine.OpenSubKey(path);
                if (regKey != null)
                {
                    regKeyValue = String.Format("{0}", regKey.GetValue(value));
                }
                return regKeyValue;
            }
        }

        public static bool IsCurrentUserAdmin(bool checkCurrentRole = true) // Checks to see whether or not the user is currently running within an administrative context. Not necessarily indicitive of the user not being an admin. 
        {
            bool isElevated = false;
            Console.WriteLine("\r\n=== IS USER ADMIN ===\r\n");

            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                if (checkCurrentRole)
                {
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
                    if (isElevated == true)
                    {
                        Console.WriteLine("\t" + "[*] Currently running in an administrative context");
                    }
                    else
                    {
                        Console.WriteLine("\t" + "[*] Not currently running with administrator privileges");
                    }

                }
            }

            return isElevated;
        }

        public static void HostnameAndIP() // Will grab the current Hostname, IP, and MAC address(es)
        {
            string hostName = Dns.GetHostName();

            try
            {
                // Get the local computer host name.
                Console.WriteLine("\r\n=== HOSTNAME ===\r\n");
                Console.WriteLine("\t" + "[*] Hostname: " + hostName);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }

            Console.WriteLine("\r\n=== IP ADDRESSES ===\r\n");

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            string macdaddy = ni.GetPhysicalAddress().ToString();
                            Console.WriteLine("\t" + "[*] " + ni.Name + " " + ip.Address.ToString() + "\r\n\t\t" + "Mac address is: " + macdaddy);
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Banner(); // Print Banner
            DateandTime(); // Date and time, both localmachine and UTC.
            HostnameAndIP(); // Grab the hostname and IP addresses associated with the machine
            QueryMcafee(); // Query registry for McAfee exclusion list
            Processes(); // Query the system to see if specific processes are running
            IsCurrentUserAdmin(); // Check if the user is currently running in an administrative context
            ListLapsSettings(); // Check whether or not LAPS is enabled
            IEEnum(); // Checked for typed in URLs in IE.
            OfficeEnum(); // Look for trusted documents
            DefenderExclude(); // Look for paths that have been specifically excluded from Windows Defender
            Console.WriteLine(
                "\r\n==================================\r\n" +
                "=========== FINISHED =============\r\n" +
                "==================================");
            Console.ReadLine(); // Remove in production.
        }
    }
}