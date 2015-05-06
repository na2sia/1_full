using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
    interface ICandy: ISweets
    {
        Stuffing Stuffing { get; }
    }
}
