using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EmailService.Logging
{
    public class Logger
    {
       
            public enum LogTypes : ushort { EmailServiceSetupFailed = 1, EmailSendingFailed = 2 };
            private static string MachineNamee { get; set; }
            public static void SetupLogger(string machineName)
            {
                MachineNamee = machineName;
                if (!EventLog.SourceExists("BlahaLogger", MachineNamee))
                {
                    EventLog.CreateEventSource(new EventSourceCreationData("BlahaLogger", "localhost") { MachineName = MachineNamee });
                }
            }

            public static EventLog GetNewEventLog()
            {
                return new EventLog("localhost", MachineNamee, "BlahaLogger");
            }
        
    }
}
