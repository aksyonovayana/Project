
namespace Buses.Classes
{
    internal class BusStop
    {
        string _name;
        string _location;
        public int Id {  get; protected set; }
        public string Name {  get { return _name; } protected set { _name = value; } }
        public string Location { get { return _location; } protected set { _location = value; } }
        public List<Route>? Routes { get; protected set; }
        public BusStop(string name, string location)
        {
            _name = name;
            _location = location;
        }
        public override string ToString()
        {
            return $"[Bus Stop]\n" +
                   $"{_name}";
        }
    }
}
