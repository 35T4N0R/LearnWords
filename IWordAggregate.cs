using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    interface IWordAggregate
    {
        IIterator GetIterator();
        void insertPol(WordPol word);
        void insertTrans(WordTrans word);
        WordPol getPol(int index);
        WordTrans getTrans(int index);
        int Count { get; }
        
    }
}
