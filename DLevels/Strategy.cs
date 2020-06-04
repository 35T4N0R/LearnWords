using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZTProj
{
    public abstract class Strategy
    {
        public IDatabase facade = new IDatabase();
        public Random rand = new Random();
        public abstract void generateAns(Grid grid);
        public abstract string getAns(Grid grid);
        public abstract List<string> randomizeAnswers(Grid grid, WordTrans word, string lang);
    }
}
