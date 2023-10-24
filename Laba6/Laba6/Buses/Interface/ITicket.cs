using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Interface
{
    internal interface ITicket
    {
        int Number {  get; }
        decimal Price { get; }
        string Description {  get; }
        IJourney Journey { get; }
        IPassenger Passenger { get; }
    }
}
