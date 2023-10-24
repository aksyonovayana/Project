using Buses.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Buses.Class
{
    internal class Passenger:IPassenger
    {
        string _fullName;
        List<ITicket> _tickets;
        public string FullName {  get { return _fullName; } }
        public List<ITicket> Tickets { get {  return _tickets; } }
        public event TicketNotifHandler OnDeparture;
        public Passenger(string fullName)
        {
            _fullName = fullName;
            _tickets = new List<ITicket>();
        }
        public int BuyTicket(IJourney journey, string description)
        {
            int number = journey.GetCode();
            if (number < 0)
            {
                return 1;
            }
            decimal price = journey.Route.Stops.Count * 5.65m;
            ITicket ticket = new Ticket(number, price, description,journey,this);
            _tickets.Add(ticket);
            journey.Tickets.Add(ticket);
            return 0;
        }
        public override string ToString()
        {
            return $"[Passenger]\n" +
                   $"{_fullName}\n" +
                   $"Tickets: {_tickets.Count}";
        }
        public void CheckTickets()
        {
            foreach (ITicket ticket in _tickets)
            {
                if (ticket.Journey.Departure.AddHours(-2)>=DateTime.Now)
                {
                    OnDeparture?.Invoke(ticket);
                }
            }

        }
    }
}
