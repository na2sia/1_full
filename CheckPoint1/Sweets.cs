using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
    public class Sweets:ISweets
    {

        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public double Sugar { get; set; }
        public Sweets() { }
        public Sweets(string name, double weight, double price, double sugar)
        {
            this.Name = name;
            this.Weight = weight;
            this.Price = price;
            this.Sugar = sugar;
        }
    }
}
