using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Interface
{
    internal interface IJourney
    {
        IBus Bus { get; }
        IRoute Route { get; }
        DateTime Departure {  get; }
        List<ITicket> Tickets { get; }
        int GetCode();
    }
}
