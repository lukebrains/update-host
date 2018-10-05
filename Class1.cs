using System;
using System.Management.Automation;

namespace HostUpdate
{
    [Cmdlet(VerbsCommon.Get, "HostUpdate")] //Add this PowerShell cmdlet name

    public class HostUpdate : Cmdlet //Extending Class1 from Cmdlet Class
    {
        protected override void BeginProcessing() {
            Console.WriteLine(Environment.OSVersion);
            Console.WriteLine("Updating host " + Environment.MachineName  + ".");
        }

        protected override void ProcessRecord() {
            if(Environment.OSVersion.ToString() == "Unix 17.7.0.0") {
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
                } else {
                    Console.WriteLine("Update complete.");
                }
            }
        }
    }
}

