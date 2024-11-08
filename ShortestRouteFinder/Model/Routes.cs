using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteFinder.Model
{



    public class Route
    {
        public string Start { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }

        public Route(string start, string destination, double distance)
        {
            Start = start;
            Destination = destination;
            Distance = distance;

        }
    }

}
