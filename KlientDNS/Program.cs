using KlientDNS;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

string path = @"http://192.168.10.160:81";



[DllImport("user32.dll")]
static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

[DllImport("kernel32.dll", ExactSpelling = true)]
static extern IntPtr GetConsoleWindow();


Console.WriteLine("Программа стартовала ");
Thread.Sleep(3000);
ShowWindow(GetConsoleWindow(), 0); // Скрыть.
try
{
    var api = new ApiServic();

    string adapter = Internet_Tools.GetActiveEthernetOrWifiNetworkInterface();

    string mack = Internet_Tools.GetActiveEthernetIP(adapter);
    string dns = Internet_Tools.GetDNS(adapter);


    while (true)
    {
        dns = Internet_Tools.GetDNS(adapter);
        NewMethod(path, api, adapter, mack, dns );
       
        Thread.Sleep(3000);
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    Console.Read();
}





static void NewMethod(string path, ApiServic api, string adapter, string mack, string dns)
{
    if (api.IsHost(mack, dns, path) == false)
    {
        var r = api.AddHost(mack, dns, path);
    }
    else
    {
       //  Console.WriteLine("Такой  хост  уже есть");
    }

    if (api.IsCangeDNS(mack, dns, path) == false)
    {
      
        dns = api.GetNewDNS(mack, dns, path);
        Internet_Tools.SetDNS( dns, adapter );
        Console.WriteLine("днс   поменялся");
        Console.WriteLine();
        Thread.Sleep(3000);
    }
    else
    {
      //    Console.WriteLine("днс не  поменялся");
    }
}