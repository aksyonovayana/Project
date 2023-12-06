using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Classes
{
    internal abstract class Transport
    {
        public int Id { get; protected set; }
        public int Capacity {  get; protected set; }
        public Journey? Journey { get; protected set; }

        public Transport()
        {
            Capacity = 0;
            Journey = new Journey();
        }
        public Transport(int capacity):base() 
        {
            Capacity = capacity;
        }

        public abstract override string ToString();
    }
}
