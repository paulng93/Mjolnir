using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hudl.Mjolnir.External;

namespace ThorsHammerPoCConsole
{
    class MyStats : IStats
    {
        public void Event(string service, string state, long? metric)
        {
            Console.WriteLine("Service " + service);
            Console.WriteLine("State " + state);
            if (metric != null)
            { 
            Console.WriteLine("metric " + metric);
            }
        }

        public void Elapsed(string service, string state, TimeSpan elasped)
        {
            Console.WriteLine("Service " + service);
            Console.WriteLine("State " + state);
            Console.WriteLine(elasped);
        }

        public void Gauge(string service, string state, long? metric = null)
        {
            Console.WriteLine("Service " + service);
            Console.WriteLine("State " + state);
            if (metric != null)
            {
                Console.WriteLine("metric " + metric);
            }
        }
    }
}
