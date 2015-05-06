using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
    public class Chocolate:Sweets,IChocolate
    {
        public double Cocoa { get; set; }
        public Chocolate() { }
        public Chocolate(string name, double weight, double price, double sugar, double cocoa)
       {
           Name = name;
           Weight = weight;
           Price = price;
           Sugar = sugar;
           this.Cocoa = cocoa;
 
        }
    }
}
