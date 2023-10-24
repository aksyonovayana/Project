using Buses.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buses.Class
{
    internal class Route:IRoute
    {
        int _id;
        List<IBusStop> _stops;
        public int Id {  get { return _id; } }
        public List<IBusStop> Stops { get {  return _stops; } }
        public Route(int id, List<IBusStop> stops)
        {
            _id = id;
            _stops = stops;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IBusStop stop in _stops)
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
