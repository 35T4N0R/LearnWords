using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    class ConcreteCreatorPol : Creator
    {
        public override IWord FactoryMethod()
        {
            return new WordPol();
        }

    }
}
