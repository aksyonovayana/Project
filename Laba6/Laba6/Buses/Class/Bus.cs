using Buses.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Class
{
    internal class Bus:IBus
    {
        int _id;
        int _capacity;
        public int Id {  get { return _id; } }
        public int Capacity { get { return _capacity; } }
        public Bus(int id, int capacity)
        {
            _id = id;
            _capacity = capacity;
        }
        public override string ToString()
        {
            return $"[Bus {_id}]\n" +
                   $"Capacity: {_capacity}";
        }
    }
}
