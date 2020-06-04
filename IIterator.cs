using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    interface IIterator
    {
        IWord First { get; }
        IWord Next { get; }
        IWord Current { get; }
        bool IsDone { get; }
    }
}
