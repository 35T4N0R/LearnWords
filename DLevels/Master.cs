using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ZTProj
{
    class Master : Strategy
    {
        public override void generateAns(Grid grid)
        {
            TextBox ans = new TextBox();
            ans.Name = "Ans";
            ans.VerticalAlignment = VerticalAlignment.Top;
            ans.Margin = new Thickness(30, 120, 30, 0);
            ans.Height = 30;

            grid.Children.Add(ans);
        }

        public override string getAns(Grid grid)
        {
            return grid.Children.OfType<TextBox>().FirstOrDefault().Text;
        }

        public override List<string> randomizeAnswers(Grid grid, WordTrans word,string lang)
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}
