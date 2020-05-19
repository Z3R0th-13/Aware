using System;
using Microsoft.Win32;

namespace Aware
{
    public class ieEnum
    {

        public static void IEEnum() // Checks the registry for manually typed in URLs in Internet Explorer.
        {
            RegistryKey checkme = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\"); // Registry hive and keys to look at. 

            object uRLs = checkme.GetValue("TypedURLs", string.Empty); // Subkey to actually look at

            if (uRLs != null)
            {
                using (RegistryKey tempKey = checkme.OpenSubKey("TypedURLs"))
                {
                    Console.WriteLine("\r\n=== TYPED URLS ===\r\n");
                    string[] array = tempKey.GetValueNames();
                    for (int i = 0; i < array.Length; i++) // For every value in the subkey, print the values.
                    {
                        string valueName = array[i];
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
    }
}