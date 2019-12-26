using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Security.Principal;
using System.Diagnostics;

namespace Aware
{
    class Program
    {
        public static void Processes()
        {
            Console.WriteLine("\r\n=== PROCESS CHECKING ===\r\n");
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                string checkme = theprocess.ProcessName;
                if (checkme == "MsMpEng")
                {
                    Console.WriteLine("\t" + "[*] Windows Defender is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "masvc")
                {
                    Console.WriteLine("\t" + "[*] McAfee Agent is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "Mcshield")
                {
                    Console.WriteLine("\t" + "[*] McAfee VSE is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "esensor") 
                {
                    Console.WriteLine("\t" + "[*] ENDGAME is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "sysmon")
                {
                    Console.WriteLine("\t" + "[*] SYSMON is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "Procmon")
                {
                    Console.WriteLine("\t" + "[*] Procmon is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "splunkd")
                {
                    Console.WriteLine("\t" + "[*] Splunk is running");
                }
                else
                {
                    // Do nothing
                }
                if (checkme == "TaniumClient")
                {
                    Console.WriteLine("\t" + "[*] Tanium is running");
                }
                else
                {
                    // Do nothing
                }
            }
        }
        
        public static void QueryMcafee()
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

        public static void ListLapsSettings()
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

                string LASPwdExpirationProtectionEnabled = GetRegValue("HKLM", "Software\\Policies\\Microsoft Services\\AdmPwd", "PwdExpirationProtectionEnabled");
                Console.WriteLine("  {0,-37} : {1}", "LAPS Expiration Protection Enabled", LASPwdExpirationProtectionEnabled);
            }
            else
            {
                Console.WriteLine("\t" + "[*] LAPS not installed");
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

        public static bool IsCurrentUserAdmin(bool checkCurrentRole = true)
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

        public static void HostnameAndIP()
        {
            string hostName = Dns.GetHostName();

            try
            {
                // Get the local computer host name.
                Console.WriteLine("=== HOSTNAME ===\r\n");
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
                            Console.WriteLine("\t" +"[*] "+ ni.Name + " " + ip.Address.ToString());
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            HostnameAndIP(); // Grab the hostname and IP addresses associated with the machine
            QueryMcafee(); // Query registry for McAfee exclusion list
            Processes(); // Query the system to see if specific processes are running
            IsCurrentUserAdmin(); // Check if the user is currently running in an administrative context
            ListLapsSettings(); // Check whether or not LAPS is enabled
            //Console.ReadLine(); // Remove in production.
            Console.WriteLine("Finished");
        }
    }
}