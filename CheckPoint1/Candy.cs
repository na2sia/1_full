using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
   public class Candy: Sweets,ICandy
    {
       public Stuffing Stuffing { get; set; }

       public Candy()
       { }
       public Candy(string name, double weight, double price, double sugar, Stuffing stuffing)
       {
           Name = name;
           Weight = weight;
           Price = price;
           Sugar = sugar;
           Stuffing = stuffing;
       }
    }
}
