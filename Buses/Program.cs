using Buses.Class;
using Buses.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Buses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        public static void Run()
        {
            List<IJourney> journeys = GetJourneys();
            IPassenger account = new Passenger("Yana");
            while (true)
            {
                Menu();
                switch (Choose())
                {
                    case 0:
                        do
                        {
                            Console.Clear();
                            TicketList(account);
                        }
                        while (Console.ReadKey(intercept: true).KeyChar != '0');
                        break;
                    case 1:
                        do
                        {
                            Console.Clear();
                            JourneyList(journeys);
                        }
                        while (ManageJourneys(account,journeys)!=0);
                        break;
                    case 2:
                        account.OnDeparture += Method;
                        break;
                    case 3:
                        return;
                }
            }
        }
        static void Method(ITicket ticket)
        {
            Console.Clear();
            Console.WriteLine($"Tour ticket expires soon\n{ticket}");
            Console.ReadKey();
        }
        static List<IBusStop> GetBusStops()
        {
            {
                return new List<IBusStop>()
                {
                    new BusStop("Peremogy shkola st.", "Peremogy 5 st."),
                    new BusStop("Polyana", "Borshagivska 128 st."),
                    new BusStop("Arkadiya", "Vadyma Hetmana 24 st.")
                };
            }
        }
        static List<IJourney> GetJourneys()
        {
            return new List<IJourney>()
            {
                new Journey(new Bus(1,25),new Route(1,GetBusStops()),new DateTime(2023,11,10)),
                new Journey(new Bus(2,50),new Route(2,GetBusStops()),new DateTime(2023,12,16))
            };
        }
        static void TicketList(IPassenger client)
        {
            Console.WriteLine($"Tickets:");
            Console.WriteLine("0.Return.");
            foreach (ITicket ticket in client.Tickets)
            {
                Console.WriteLine($"{client.Tickets.IndexOf(ticket) + 1}.{ticket}");
            }
        }
        static void JourneyList(List<IJourney> journeys)
        {
            Console.WriteLine($"Tickets:");
            Console.WriteLine("0.Return.");
            foreach (IJourney journey in journeys)
            {
                Console.WriteLine($"{journeys.IndexOf(journey) + 1}.{journey}");
            }
        }
        static int ManageJourneys(IPassenger account,List<IJourney> journeys)
        {
            if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out uint choose) && choose <= account.Tickets.Count)
            {
                if (choose == 0)
                {
                    return 0;
                }
                ManageChosen(account, journeys[(int)choose-1]);
            }
            return 1;
        }
        static void ManageChosen(IPassenger account, IJourney journey)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(journey);
                Console.WriteLine("0.Return.\n" +
                                  "1.Buy ticket.");
                switch (Choose())
                {
                    case 0:
                        return;
                    case 1:
                        ITicket ticket = new Ticket(journey.GetCode(),75m,"Desk",journey,account);
                        account.Tickets.Add(ticket);
                        journey.Tickets.Add(ticket);
                        Console.Clear();
                        Console.WriteLine("Press any button...");
                        Console.ReadKey();
                        return;
                }
            }
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Choose option:\n" +
                              "0.See my tickets.\n" +
                              "1.Buy ticket.\n" +
                              "2.Push notification.\n" +
                              "3.Exit.");
        }
        static int Choose()
        {
            while (true)
            {
                if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out uint choose))
                {
                    return (int)choose;
                }
            }
        }
    }
}
