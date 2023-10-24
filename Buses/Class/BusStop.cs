using Buses.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Class
{
    internal class BusStop:IBusStop
    {
        string _name;
        string _location;
        public string Name {  get { return _name; } }
        public string Location { get { return _location; } }
        public BusStop(string name, string location)
        {
            _name = name;
            _location = location;
        }
        public override string ToString()
        {
            return $"[Bus Stop]\n" +
                   $"{_name}";
        }
    }
}
