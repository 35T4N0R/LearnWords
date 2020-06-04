using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZTProj
{
    abstract class Action
    {
        protected DifficultyLevel difficultyLevel;
        protected Grid grid;
        protected IDatabase facade = new IDatabase();
        public WordTrans actualWord;
        public List<string> answers;
        public List<string> previousAnswers;

        public abstract bool checkAns(string ans,string word);
        public void Stud(Grid grid, DifficultyLevel difficultyLevel, string lang, List<string> previousAnswers)
        {
            this.previousAnswers = previousAnswers;
            bool AnsCorrect;
            this.grid = grid;
            string ans = difficultyLevel.getAns(grid);
            if (lang == "pol")
            {
                AnsCorrect = checkAns(ans, actualWord.wordPol.content);
            }
            else
            {
                AnsCorrect = checkAns(ans, actualWord.content);
            }

            if(AnsCorrect)
            {
                WordTrans tempactualWord = facade.getRandomTransWord(actualWord.lang);
                while (tempactualWord.content.Equals(actualWord.content))
                {
                    tempactualWord = facade.getRandomTransWord(actualWord.lang);
                }
                actualWord = tempactualWord;
                if (lang == "pol")
                {
                    grid.Children.OfType<Label>().FirstOrDefault().Content = actualWord.content;
                }
                else
                {
                    grid.Children.OfType<Label>().FirstOrDefault().Content = actualWord.wordPol.content;
                }
                answers = difficultyLevel.randomizeAnswers(grid, actualWord, lang);
                if (difficultyLevel.strategy.GetType() != typeof(Master) && grid.Children.OfType<RadioButton>().FirstOrDefault(r => (bool)r.IsChecked)!=null)
                {
                    grid.Children.OfType<RadioButton>().FirstOrDefault(r => (bool)r.IsChecked).IsChecked = false;
                }else if(difficultyLevel.strategy.GetType() == typeof(Master))
                {
                    grid.Children.OfType<TextBox>().FirstOrDefault().Text = null;
                }
            }
        }
    }
}
