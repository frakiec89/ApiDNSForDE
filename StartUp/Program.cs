
using System.Diagnostics;


var startInfo = new ProcessStartInfo();
startInfo.FileName = "cmd";
startInfo.Arguments = "C:\\Users\\Ahtyamov\\source\\repos\\ApiDNSForDE\\KlientDNS\\bin\\Debug\\net6.0\\KlientDNS.exe";


var proc = Process.Start(startInfo);