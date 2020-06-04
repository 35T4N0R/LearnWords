using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    class WordAggregate : IWordAggregate
    {
        List<WordPol> polishWords;
        List<WordTrans> transWords;

        public WordAggregate()
        {
            polishWords = new List<WordPol>();
            transWords = new List<WordTrans>();
        }

        public int Count
        {
            get
            {
                return polishWords.Count;
            }
        }

        public IIterator GetIterator()
        {
            return (IIterator)new WordIterator(this);
        }

        public WordPol getPol(int index)
        {
            if (polishWords.Count > 0) return polishWords[index];
            else return null;
        }

        public WordTrans getTrans(int index)
        {
            if (transWords.Count > 0) return transWords[index];
            else return null;
        }

        public void insertPol(WordPol word)
        {
            polishWords.Add(word);
        }

        public void insertTrans(WordTrans word)
        {
            transWords.Add(word);
        }

        public void removeWord(int id)
        {
            var word = polishWords[id];
            var trans = word.wordTrans;
            transWords.Remove(trans);
            polishWords.Remove(word);
        }
    }
}
