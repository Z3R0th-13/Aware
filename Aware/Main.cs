namespace Aware
{
    using System;
    using Aware;

    public class mainAware
    {
        private static void Main(string[] args)
        {
            banner.Banner(); // Print Banner
            dateandTime.DateandTime(); // Date and time, both localmachine and UTC.
            getHostnameAndIP.HostnameAndIP(); // Grab the hostname and IP addresses associated with the machine
            queryMcAfee.QueryMcafee(); // Query registry for McAfee exclusion list
            processChecking.Processes(); // Query the system to see if specific processes are running
            AdminCheck.IsCurrentUserAdmin(); // Check if the user is currently running in an administrative context
            LAPSSettings.ListLapsSettings(); // Check whether or not LAPS is enabled
            ieEnum.IEEnum(); // Checked for typed in URLs in IE.
            officeEnum.OfficeEnum(); // Look for trusted documents
            defenderExclude.DefenderExclude(); // Look for paths that have been specifically excluded from Windows Defender
            Console.WriteLine(
                "\r\n==================================\r\n" +
                "=========== FINISHED =============\r\n" +
                "==================================");
            Console.ReadLine(); // Remove in production.
        }
    }
}