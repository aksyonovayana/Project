using Buses.Classes;
using Laba.Data;
using Microsoft.EntityFrameworkCore;

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
            using (BusContext db = new BusContext())
            {
                //FillContext(db);
                //db.SaveChanges();
                //return;
                List<Journey> journeys = db.Journeys.Include(j=>j.Transport).Include(j=>j.Route).ThenInclude(r=>r.Stops).ToList();
                Passenger account = new Passenger("Yana");
                db.Passengers.Add(account);
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
                            while (ManageJourneys(account, journeys) != 0);
                            break;
                        case 2:
                            account.OnDeparture += Method;
                            break;
                        case 3:
                            db.SaveChanges();
                            return;
                    }
                }
            }
        }
        static void Method(Ticket ticket)
        {
            Console.Clear();
            Console.WriteLine($"Tour ticket expires soon\n{ticket}");
            Console.ReadKey();
        }
        static void FillContext(BusContext db)
        {
            List<BusStop> busStops = new List<BusStop>()
            {
                    new BusStop("Peremogy shkola st.", "Peremogy 5 st."),
                    new BusStop("Polyana", "Borshagivska 128 st."),
                    new BusStop("Arkadiya", "Vadyma Hetmana 24 st.")
            };
            Bus bus1 = new Bus(25, 10);
            Bus bus2 = new Bus(50, 20);
            MiniBus miniBus = new MiniBus(10);
            Route route = new Route(busStops);
            Journey journey1 = new Journey(bus1, route, new DateTime(2023, 11, 10));
            db.Journeys.Add(journey1);
            Journey journey2 = new Journey(bus2, route, new DateTime(2023,12,16));
            db.Journeys.Add(journey2);
            Journey journey3 = new Journey(miniBus, route, new DateTime(2023, 12, 30));
            db.Journeys.Add(journey3);
        }
        static void TicketList(Passenger client)
        {
            Console.WriteLine($"Tickets:");
            Console.WriteLine("0.Return.");
            foreach (Ticket ticket in client.Tickets)
            {
                Console.WriteLine($"{client.Tickets.IndexOf(ticket) + 1}.{ticket}");
            }
        }
        static void JourneyList(List<Journey> journeys)
        {
            Console.WriteLine($"Tickets:");
            Console.WriteLine("0.Return.");
            foreach (Journey journey in journeys)
            {
                Console.WriteLine($"{journeys.IndexOf(journey) + 1}.{journey}");
            }
        }
        static int ManageJourneys(Passenger account,List<Journey> journeys)
        {
            if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out uint choose) && choose <= journeys.Count)
            {
                if (choose == 0)
                {
                    return 0;
                }
                ManageChosen(account, journeys[(int)choose-1]);
            }
            return 1;
        }
        static void ManageChosen(Passenger account, Journey journey)
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
                        Ticket ticket = new Ticket(75m,"Desk",journey,account);
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
