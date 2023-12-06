
namespace Buses.Classes
{
    internal class Bus:Transport
    {
        public float LuggageCompart {  get; protected set; }
        public Bus() : base()
        {
            LuggageCompart = 0;
        }
        public Bus(int capacity, float luggageCompart):base(capacity)
        {
            LuggageCompart = luggageCompart;
        }
        public override string ToString()
        {
            return $"[Bus {Id}]\n" +
                   $"Capacity: {Capacity}\n" +
                   $"Luggage Compartment: {LuggageCompart} m^3";
        }
    }
}
