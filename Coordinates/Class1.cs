using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates
{
    public class Cord
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public string name { get; set; }

        public string delimiter { get; set; }

        public Cord(string name, double x, double y, double z, string delimiter)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.z = z;
        }
       public string CordPrint()
        {
            return this.name+this.delimiter+this.x+this.delimiter+this.y+this.delimiter+this.z;
        }

    }
}
