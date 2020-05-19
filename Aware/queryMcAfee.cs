using System;
using Microsoft.Win32;

namespace Aware
{
    public class queryMcAfee
    {
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
    }
}