using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    class Question
    {
        private IWord word;
        private List<string> answers;
        private int score;
        private int counter;

        public Question(IWord word,List<string> answers, int score, int counter)
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
                return word;
            }
            set
            {
                word = value;
            }
        }
        public IWord getWord()
        {
            return this.word;
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

        public Memento CreateMemento()
        {
            return new Memento(this.word, this.answers,this.score, this.counter);
        }

        public void RestoreMemento(Memento memento)
        {
            this.word = memento.Word;
            this.answers = memento.Answers;
            this.score = memento.Score;
            this.counter = memento.Counter;
        }
    }
}
