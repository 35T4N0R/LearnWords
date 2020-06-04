using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    public class WordTrans : IWord
    {
        public string lang { get; set; }
        public string content { get; set; }

        public WordPol wordPol { get; set; }

        public  void AddTranslate(IWord word)
        {
            this.wordPol = (WordPol) word;
        }
    }
}
