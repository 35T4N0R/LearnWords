using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    class WordIterator : IIterator
    {
        IWordAggregate aggregate;
        int currIndex = 0;

        public WordIterator(IWordAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public IWord First
        {
            get
            {
                currIndex = 0;
                return aggregate.getPol(currIndex++);
            }
            
        }

        public IWord Next
        {
            get
            {
                if(IsDone == false)
                {
                    return aggregate.getPol(currIndex++);
                }
                else
                {
                    return null;
                }
            }
        }
            

        public IWord Current
        {
            get
            {
                return aggregate.getPol(currIndex);
            }
        }
        public bool IsDone
        {
            get
            {
                if(currIndex < aggregate.Count)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
