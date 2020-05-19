using System;

namespace Aware
{
    public class dateandTime
    {
        public static void DateandTime() // Will grab the machines current date as well as UTC
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            Console.WriteLine("\r\n=== Date / Time ===\r\n");
            Console.WriteLine("\t" + "[*] " + "Current localtime is: " + localDate);
            Console.WriteLine("\t" + "[*] " + "UTC current time is: " + utcDate);
        }
    }
}