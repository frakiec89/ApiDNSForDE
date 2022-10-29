using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlientDNS
{
    internal class Internet_Tools
    {
        public static string GetActiveEthernetOrWifiNetworkInterface()
        {
            var Nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
                a => a.OperationalStatus == OperationalStatus.Up &&
                (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

            return Nic.Name;
        }

        public static string GetActiveEthernetIP(string strHostName)
        {
            var nic = NetworkInterface.GetAllNetworkInterfaces();
            var n = nic.Single(x => x.Name == strHostName);
            return n.GetPhysicalAddress().ToString();   
        }




        public static string GetDNS (string namaAdapter)
        {

            NetworkInterface[] intf = NetworkInterface.GetAllNetworkInterfaces();


            var e = intf.Single(x => x.Name == namaAdapter).GetIPProperties().DnsAddresses;

            string s = "";

            foreach (var item in e)
            {
                s +=  item.MapToIPv4(); 
            }

            return s;

        }


        public static void SetDNS(string dnsString, string adapter)
        {

            string comand = $"/C netsh interface ip set dns name=\"{adapter}\" source=\"static\" address=\"{dnsString}\"";
            ProcessStartInfo psiOpt = new ProcessStartInfo("runas.exe");
            psiOpt.FileName = "cmd.exe";
            //psiOpt.UserName = "admin";
            //psiOpt.Password = GetPassword("GTX1050ti");
            psiOpt.Arguments = comand;
            psiOpt.Verb = "runas";
            psiOpt.UseShellExecute = true;
            using Process procCommand = Process.Start(psiOpt);
            procCommand.CloseMainWindow();
        }

        private static SecureString GetPassword(string password)
        {
            SecureString secureString = new SecureString();
            foreach (var item in password)
            {
                secureString.AppendChar(item);
            }
            return secureString;
        }
    }
}
