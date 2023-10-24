using Buses.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Class
{
    internal class Journey:IJourney
    {
        IBus _bus;
        IRoute _route;
        DateTime _departure;
        List<ITicket> _tickets;
        public IBus Bus { get { return _bus; } }
        public IRoute Route { get { return _route; } }
        public DateTime Departure { get { return _departure; } }
        public List<ITicket> Tickets { get {  return _tickets; } }
        public Journey(IBus bus, IRoute route, DateTime departure)
        {
            _bus = bus;
            _route = route;
            _departure = departure;
            _tickets = new List<ITicket>();
        }
        public int GetCode()
        {
            if(_tickets.Count == _bus.Capacity)
            {
                return -1;
            }
            string id = _tickets.Count.ToString();
            string bus = _bus.Id.ToString();
            string date = _departure.Day.ToString() +
                          _departure.Month.ToString() +
                          _departure.Year.ToString() +
                          _departure.Hour.ToString() +
                          _departure.Minute.ToString();
            string sum = id+bus+date;
            return int.Parse(sum);
        }
        public override string ToString()
        {
            return $"[Journey]\n" +
                   $"Bus №{_bus.Id}\n" +
                   $"Route {_route.Id}\n" +
                   $"Departure - {_departure}";
        }
    }
}
