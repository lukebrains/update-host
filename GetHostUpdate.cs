using System;
using System.Management.Automation;

namespace HostUpdate
{
    [Cmdlet(VerbsCommon.Get, "HostUpdate")] //Add this PowerShell cmdlet name

    public class HostUpdate : Cmdlet //Extending Class1 from Cmdlet Class
    {
        private string osVersion = Environment.OSVersion.ToString();
        protected override void BeginProcessing() {
            Console.WriteLine(osVersion);
            Console.WriteLine("Updating host " + Environment.MachineName  + ".");
        }

        protected override void ProcessRecord() {
            if(osVersion.Contains("Unix")) {
                if(System.IO.File.Exists("/usr/local/bin/brew")) {
                    // Update with the brew command line tool.
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    info.FileName = "brew";
                    info.Arguments = "update";
                    info.UseShellExecute = true;
                    process.StartInfo = info;
                    process.Start();
                    process.WaitForExit();
                    if(process.ExitCode != 0) {
                        Console.WriteLine("Update failed.");
                    }
                } else if(System.IO.File.Exists("/etc/centos-release")) {
                    // Update with the yum command line tool.
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    info.FileName = "yum";
                    info.Arguments = "update -y";
                    info.UseShellExecute = true;
                    process.StartInfo = info;
                    process.Start();
                    process.WaitForExit();
                    if(process.ExitCode != 0) {
                        Console.WriteLine("Update failed.");
                    }
                } else {
                    Console.Write("Update failed: Unsupported Unix version.");
                }
            }
        }
    }
}

