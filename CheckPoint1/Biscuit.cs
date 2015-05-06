using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
   public class Biscuit:Sweets,IBiscuit
    {
       public TypeBiscuit TypeBiscuit { get; set; }
       public Biscuit() { }
       public Biscuit (string name, double weight, double price, double sugar, TypeBiscuit typebiscuit)
       {
           Name = name;
           Weight = weight;
           Price = price;
           Sugar = sugar;
           this.TypeBiscuit = typebiscuit; 
       }
    }
}
