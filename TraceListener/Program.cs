using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TraceListener
{
    class Program
    {
        static void Main(string[] args)
        {
            Logging s = new Logging("mySwitch", "test Switches");
            s.WriteLine();
        }
    }

    public class Logging
    {
        private static TraceSwitch s;

        public Logging(string switchName, string switchDesc)
        {
            s = new TraceSwitch(switchName, switchDesc);
        }
        public void WriteLine()
        {
            switch (s.Level)
            {
                case TraceLevel.Off:
                    break;
                case TraceLevel.Error:
                    Trace.Listeners["myTextListener"].WriteLine("Message");
                    Trace.Listeners["myLogListener"].WriteLine("Message");
                    Trace.Listeners["DBTraceListener"].WriteLine("Message");
                    Trace.Listeners["Default"].WriteLine("Message");
                    break;
                case TraceLevel.Warning:
                    Trace.Listeners["myTextListener"].WriteLine("Message");
                    Trace.Listeners["DBTraceListener"].WriteLine("Message");
                    Trace.Listeners["Default"].WriteLine("Message");
                    break;
                case TraceLevel.Info:
                    Trace.Listeners["Default"].WriteLine("Message");
                    Trace.Listeners["myTextListener"].WriteLine("Message");
                    break;
                case TraceLevel.Verbose:
                    Trace.Listeners["myTextListener"].WriteLine("Message");
                    Trace.Listeners["myLogListener"].WriteLine("Message");
                    Trace.Listeners["DBTraceListener"].WriteLine("Message");
                    Trace.Listeners["Default"].WriteLine("Message");
                    break;
                default:
                    break;
            }
        }
    }
    public class DBTraceListener : DefaultTraceListener
    {
        public override void WriteLine(string message)
        {
            base.Write(message);
            TestAleEntities ctx = new TestAleEntities();
            ctx.Log.Add(new TraceListener.Log() { Message = "ciao" });
            ctx.SaveChanges();

        }
    }
}
