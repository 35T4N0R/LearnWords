using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ZTProj
{
    class Hard : Strategy
    {
        public override void generateAns(Grid grid)
        {
            RadioButton ans1 = new RadioButton();
            ans1.Content = "";
            ans1.GroupName = "Answers";
            ans1.Name = "Ans1";
            ans1.Margin = new Thickness(100, 120, 0, 0);

            RadioButton ans2 = new RadioButton();
            ans2.Content = "";
            ans2.GroupName = "Answers";
            ans2.Name = "Ans2";
            ans2.Margin = new Thickness(100, 140, 0, 0);

            RadioButton ans3 = new RadioButton();
            ans3.Content = "";
            ans3.GroupName = "Answers";
            ans3.Name = "Ans3";
            ans3.Margin = new Thickness(100, 160, 0, 0);

            RadioButton ans4 = new RadioButton();
            ans4.Content = "";
            ans4.GroupName = "Answers";
            ans4.Name = "Ans4";
            ans4.Margin = new Thickness(100, 180, 0, 0);


            grid.Children.Add(ans1);
            grid.Children.Add(ans2);
            grid.Children.Add(ans3);
            grid.Children.Add(ans4);
        }

        public override string getAns(Grid grid)
        {
            return grid.Children.OfType<RadioButton>().FirstOrDefault(r => (bool)r.IsChecked).Content.ToString();
        }

        public override List<string> randomizeAnswers(Grid grid, WordTrans word,string lang)
        {
            int num = rand.Next(4);

            List<string> words = new List<string>();
            if (lang == "pol")
            {
                words.Add(word.wordPol.content);
            }
            else
            {
                words.Add(word.content);
            }
            string randomAns = null;

            for (int i = 0; i < 4; i++)
            {
                if (i != num)
                {
                    if (lang == "pol")
                    {
                        randomAns = facade.getRandomTransWord(word.lang).wordPol.content;
                    }
                    else
                    {
                        randomAns = facade.getRandomTransWord(word.lang).content;
                    }
                    if (!words.Contains(randomAns))
                    {
                        grid.Children.OfType<RadioButton>().ElementAt(i).Content = randomAns;
                        words.Add(randomAns);
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    if (lang == "pol")
                    {
                        grid.Children.OfType<RadioButton>().ElementAt(i).Content = word.wordPol.content;
                    }
                    else
                    {
                        grid.Children.OfType<RadioButton>().ElementAt(i).Content = word.content;
                    }
                }
            }
            return words;
        }
    }
}
