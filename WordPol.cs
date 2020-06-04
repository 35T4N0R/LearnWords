using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    public class WordPol : IWord
    {
        public string content { get; set; }

        public WordTrans wordTrans { get; set; }
        public string lang { get; set; }

        public  void AddTranslate(IWord word)
        {
            this.wordTrans = (WordTrans) word;
        }
    }
}
