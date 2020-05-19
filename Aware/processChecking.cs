using System;
using System.Diagnostics;

namespace Aware
{
    public class processChecking
    {
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

    }
}