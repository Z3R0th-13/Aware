using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Aware
{
    public class getHostnameAndIP
    {
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
    }
}