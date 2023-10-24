using Buses.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Class
{
    internal class Ticket:ITicket
    {
        int _number;
        decimal _price;
        string _description;
        IPassenger _passenger;
        IJourney _journey;
        public int Number { get { return _number; } }
        public decimal Price { get { return _price; } }
        public string Description { get { return _description; } }
        public IPassenger Passenger { get { return _passenger; } }
        public IJourney Journey {  get { return _journey; } }
        public Ticket(int number, decimal price, string description,IJourney journey,IPassenger passenger)
        {
            _number = number;
            _price = price;
            _description = description;
            _journey = journey;
            _passenger = passenger;
        }
        public override string ToString()
        {
            return $"[Ticket]№{_number}\n" +
                   $"{_price}$\n" +
                   $"{_description}";
        }
    }
}
