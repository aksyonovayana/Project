using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Buses.Classes
{
    internal class Route
    {
        int _id;
        List<BusStop> _stops;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get { return _id; } protected set { _id = value; } }
        public List<BusStop> Stops { get {  return _stops; } protected set { _stops = value; } }
        public Journey? Journey { get;protected set; }
        public Route()
        {
            _stops = new List<BusStop>();
        }
        public Route(List<BusStop> stops):base()
        {
            _stops = stops;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (BusStop stop in _stops)
            {
                sb.Append(_stops.IndexOf(stop)+1);
                sb.Append(".");
                sb.Append(stop);
                sb.Append("\n");
            }
            return $"[Route {_id}]\n" +
                   $"Stops:\n"+sb.ToString();
        }
    }
}
