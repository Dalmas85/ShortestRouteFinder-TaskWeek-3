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
        public string Start { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public double Distance { get; set; }
    }

}


