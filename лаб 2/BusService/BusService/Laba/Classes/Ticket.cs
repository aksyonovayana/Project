
using System.ComponentModel.DataAnnotations;

namespace Buses.Classes
{
    internal class Ticket
    {
        int _number;
        decimal _price;
        string _description;
        Passenger _passenger;
        Journey _journey;
        [Key]
        public int Number { get { return _number; } protected set { _number = value; } }
        public decimal Price { get { return _price; } protected set { _price = value; } }
        public string Description { get { return _description; } protected set { _description = value; } }
        public int PassengerId { get; protected set; }
        public Passenger Passenger { get { return _passenger; } protected set { _passenger = value; } }
        public int JourneyId { get; protected set; }
        public Journey Journey {  get { return _journey; } protected set { _journey = value; } }
        public Ticket()
        {
            _price = 0;
            _description = string.Empty;
            _journey= new Journey();
            _passenger = new Passenger();
        }
        public Ticket(decimal price, string description,Journey journey,Passenger passenger)
        {
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
