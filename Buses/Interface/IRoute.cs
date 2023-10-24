using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Interface
{
    internal interface IRoute
    {
        int Id {  get; }
        List<IBusStop> Stops { get; }
    }
}
