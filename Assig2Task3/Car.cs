using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assig2Task3
{
    class Car
    {
        private static int carCount = 0;

        public int Id { get; private set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public String Colour { get; set; }

        public Car()
        {
            Id = ++carCount;
        }

        public Car(String make, String model, String colour)
        {
            Id = ++carCount;
            Make = make;
            Model = model;
            Colour = colour;
        }

      

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
