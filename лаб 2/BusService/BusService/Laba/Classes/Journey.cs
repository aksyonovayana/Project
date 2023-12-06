using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Buses.Classes
{
    internal class Journey
    {
        Transport _transport;
        Route _route;
        DateTime _departure;
        List<Ticket> _tickets;
        public int Id {  get; protected set; }
        public int TransportId {  get; protected set; }
        public Transport Transport { get { return _transport; } protected set { _transport = value; } }
        public int RouteId { get; protected set; }
        public Route Route { get { return _route; } protected set { _route = value; } }
        public DateTime Departure { get { return _departure; } protected set { _departure = value; } }
        public List<Ticket> Tickets { get {  return _tickets; } protected set { _tickets = value; } }
        public Journey()
        {
            _route = new Route();
            _departure = new DateTime();
            _tickets = new List<Ticket>();
        }
        public Journey(Transport bus, Route route, DateTime departure):base()
        {
            _transport = bus;
            _route = route;
            _departure = departure;
            _tickets = new List<Ticket>();
        }
        /*public int GetCode()
        {
            if (_tickets.Count == _bus.Capacity)
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
            string sum = id + bus + date;
            return int.Parse(sum);
        }*/
        public override string ToString()
        {
            return $"[Journey]\n" +
                   $"Bus №{_transport.Id}\n" +
                   $"Route {_route.Id}\n" +
                   $"Departure - {_departure}";
        }
    }
}
