using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Buses.Interface
{
    delegate void TicketNotifHandler(ITicket ticket);
    internal interface IPassenger
    {
        string FullName {  get; }
        List<ITicket> Tickets { get; }
        int BuyTicket(IJourney journey, string desctiption);
        event TicketNotifHandler OnDeparture;
        public void CheckTickets();
    }
}
