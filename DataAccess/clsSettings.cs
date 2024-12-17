using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class clsSettings
    {

        static public void WriteEventLogEntry(string Message, EventLogEntryType type)
        {
            string SourceName = "SA";

            if(!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
                Console.WriteLine("Event Source Created.");
            }

            EventLog.WriteEntry(SourceName,Message, type);

        }

    }
}
