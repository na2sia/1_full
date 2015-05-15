using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
   public class GiftSweets:ICollection<ISweets>
    {
       private ICollection<ISweets> giftList = new List<ISweets>();

       #region ICollection<ISweets>
       public void Add(ISweets item)
       {
           giftList.Add(item);
       }

       public void Clear()
       {
           giftList.Clear();
       }

       public bool Contains(ISweets item)
       {
           return giftList.Contains(item);
       }

       public void CopyTo(ISweets[] array, int arrayIndex)
       {
           giftList.CopyTo(array,arrayIndex);
       }

       public int Count
       {
           get { return giftList.Count; }
       }

       public bool IsReadOnly
       {
           get { return giftList.IsReadOnly; }
       }

       public bool Remove(ISweets item)
       {
           return giftList.Remove(item);
       }

       public IEnumerator<ISweets> GetEnumerator()
       {
            return giftList.GetEnumerator();
       }

       System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
       {
           return this.GetEnumerator();
       }
       #endregion

       
       public void Sort(IComparer<ISweets> comparer)
       {
           giftList = giftList.OrderBy(x => x, comparer).ToList();
       }
                    
       public double TotalWeight 
       {
           get { return giftList.Sum(x => x.Weight); }
       }

       public IEnumerable<ISweets> GetSweets(double startsugar, double endsugar)
       {
           return giftList.Where(x=>(x.Sugar>=startsugar && x.Sugar<=endsugar));
       }
       

    }

}
