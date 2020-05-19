using System;
using System.Security.Principal;

namespace Aware
{
    public class AdminCheck
    {
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
    }
}