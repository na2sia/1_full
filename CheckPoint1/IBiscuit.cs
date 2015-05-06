using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
    interface IBiscuit:ISweets
    {
        TypeBiscuit TypeBiscuit { get; }

    }
}
