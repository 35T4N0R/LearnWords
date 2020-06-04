using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ZTProj.modes
{
    class Test : Action
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        public int score = 0;
        public int getScore() { return this.score; }
        public int counter = 0;
        public Question question;
        public override bool checkAns(string ans, string word)
        {
            if(ans == null)
            {
                ans = "";
            }
            question = new Question(actualWord, previousAnswers, score, counter);
            
            counter++;
            var label = (Label)grid.FindName("wrongAnswerLabel");
            label.Content = "pytanie " + (counter + 1) + "/10";
            if (counter>=10)
            {
                EndTest endTestWindow = new EndTest(score);
                endTestWindow.ShowDialog();
                mw.MainFrame.Content = new MenuPage();
            }
            if (ans.Equals(word))
            {
                score++;
            }
            
            return true;
        }
    }
}
