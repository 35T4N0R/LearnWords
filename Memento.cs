using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    class Memento
    {
        private IWord word;
        private List<string> answers;
        private int score;
        private int counter;

        public Memento(IWord word,List<string> answers, int score, int counter)
        {
            this.word = word;
            this.answers = answers;
            this.score = score;
            this.counter = counter;
        }

        public IWord Word
        {
            get
            {
                return this.word;
            }
            set
            {
                word = value;
            }
        }

        public List<string> Answers
        {
            get
            {
                return answers;
            }
            set
            {
                answers = value;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        public int Counter
        {
            get
            {
                return counter;
            }
            set
            {
                counter = value;
            }
        }

    }
}
