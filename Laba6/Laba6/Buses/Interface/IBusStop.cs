using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Interface
{
    internal interface IBusStop
    {
        string Name { get; }
        string Location {  get; }
    }
}
