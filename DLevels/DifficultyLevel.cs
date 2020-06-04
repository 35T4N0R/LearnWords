using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZTProj
{
    class DifficultyLevel
    {
        public Strategy strategy;

        public DifficultyLevel(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void generateAns(Grid grid)
        {
            strategy.generateAns(grid);
        }
        public string getAns(Grid grid)
        {
            return strategy.getAns(grid);
        }
        public List<string> randomizeAnswers(Grid grid, WordTrans word,string lang)
        {
            return strategy.randomizeAnswers(grid, word, lang);
            
        }
    }
}
