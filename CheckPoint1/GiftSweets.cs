using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
   public class GiftSweets:ICollection<ISweets>
    {
       private ICollection<ISweets> gift = new List<ISweets>();

       #region ICollection<ISweets>
       public void Add(ISweets item)
       {
           gift.Add(item);
       }

       public void Clear()
       {
           gift.Clear();
       }

       public bool Contains(ISweets item)
       {
           return gift.Contains(item);
       }

       public void CopyTo(ISweets[] array, int arrayIndex)
       {
           gift.CopyTo(array,arrayIndex);
       }

       public int Count
       {
           get { return gift.Count; }
       }

       public bool IsReadOnly
       {
           get { return gift.IsReadOnly; }
       }

       public bool Remove(ISweets item)
       {
           return gift.Remove(item);
       }

       public IEnumerator<ISweets> GetEnumerator()
       {
            return gift.GetEnumerator();
       }

       System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
       {
           return this.GetEnumerator();
       }
       #endregion
       public void Sort(IComparer<ISweets> comparer)
       {
           var newList = gift.ToList();
           newList.Sort(comparer);
           gift = newList;
       }
      
       public double TotalWeight()
       {           
           double Summ = 0;
           foreach (var i in gift)
           {
               Summ = Summ + i.Weight;
           }
           return Summ;
        }
       public IEnumerable<ISweets> GetSweets(double startsugar, double endsugar)
       {
           foreach (var i in gift)
           {
               if (i.Sugar >= startsugar && i.Sugar<= endsugar)
               {
                   yield return i;
               }
           }
       }
       

    }

}
