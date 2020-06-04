using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZTProj.modes
{
    class Training : Action
    {
        public override bool checkAns(string ans, string word)
        {
            var label = (Label)grid.FindName("wrongAnswerLabel");
            if (ans.Equals(word))
            {
                label.Content = "";
                return true;
            }
            label.Content = "Błędna odpowiedź";
            return false;
        }

    }
}
