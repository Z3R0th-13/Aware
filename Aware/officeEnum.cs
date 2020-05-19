using System;
using Microsoft.Win32;

namespace Aware
{
    public class officeEnum
    {
        public static void OfficeEnum()
        {
            try
            {
                RegistryKey checkme = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\16.0\\PowerPoint\\Security\\Trusted Documents"); // Hive and keys to look at

                object trustRecs = checkme.GetValue("TrustRecords", string.Empty); // Subkey to actually look at

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
                object trustRecs = checkme.GetValue("TrustRecords", string.Empty); // Subkey to actually look at

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
                object trustRecs = checkme.GetValue("TrustRecords", string.Empty); // Subkey to actually look at 

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

    }
}