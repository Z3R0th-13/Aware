using System;
using Microsoft.Win32;

namespace Aware
{
    public class defenderExclude
    {
        public static void DefenderExclude() // Looks for Windows Defender Exclude settings.
        {
            try
            {
                RegistryKey checkme = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows Defender\\Exclusions\\"); // Registry hive and keys to look at

                object excludes = checkme.GetValue("Paths", string.Empty); // Subkey to actually look at

                if (excludes != null)
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

                object excludes = checkme.GetValue("Extensions", string.Empty); // Subkey to actually look at

                if (excludes != null)
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

                object excludes = checkme.GetValue("Processes", string.Empty); // Subkey to actually look at 

                if (excludes != null)
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

                object excludes = checkme.GetValue("TemporaryPaths", string.Empty); // Subkey to actually look at

                if (excludes != null)
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

    }
}