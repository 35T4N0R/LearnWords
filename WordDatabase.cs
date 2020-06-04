using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZTProj
{
    public class WordDatabase
    {
        public static WordDatabase instance = null;

        WordAggregate aggregate;

        public static WordDatabase GetInstance()
        {
            if(instance == null)
            {
                instance = new WordDatabase();
            }
            return instance;
            
        }
 
        public WordPol getPol(int indeks)
        {
            return aggregate.getPol(indeks);
        }

        public WordTrans getTrans(int indeks)
        {
            return aggregate.getTrans(indeks);
        }

        public int wordsLength()
        {
            return aggregate.Count;
        }

        public void addWord(WordPol word)
        {
            aggregate.insertPol(word);
        }
        public void addWord(WordTrans word)
        {
            aggregate.insertTrans(word);
        }

        public void editWord(IWord word)
        {

        }

        public void deleteWord(int id)
        {
            aggregate.removeWord(id);
        }

        public List<WordPol> getPolishWords()
        {
            List<WordPol> list = new List<WordPol>();
            IIterator iterator = aggregate.GetIterator();

            WordPol word = (WordPol)iterator.First;
            list.Add(word);
            while (!iterator.IsDone)
            {
                word = (WordPol)iterator.Next;
                list.Add(word);
            }
            return list;
        }
        public List<WordTrans> getTransWords()
        {
            List<WordTrans> list = new List<WordTrans>();
            IIterator iterator = aggregate.GetIterator();

            WordPol word = (WordPol)iterator.First;
            list.Add(word.wordTrans);
            while (!iterator.IsDone)
            {
                word = (WordPol)iterator.Next;
                list.Add(word.wordTrans);
            }
            return list;
        }
        public List<WordTrans> getLangTransWords(string lang)
        {
            List<WordTrans> list = new List<WordTrans>();
            IIterator iterator = aggregate.GetIterator();
            WordPol word = (WordPol)iterator.First;
            list.Add(word.wordTrans);
            while (!iterator.IsDone)
            {
                word = (WordPol)iterator.Next;
                list.Add(word.wordTrans);
            }
            List<WordTrans> newlist = new List<WordTrans>();
            newlist = list.Where(s => s.lang == lang).ToList();
            return newlist;
        }

        public WordDatabase()
        {

            this.aggregate = new WordAggregate();
            using (StreamReader sr = new StreamReader(@"..\..\Data\FirstDataFile.txt"))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] tmp = line.Split(' ');

                    Creator creatorPol = new ConcreteCreatorPol();
                    Creator creatorTrans = new ConcreteCreatorTrans();

                    var wordPol = creatorPol.FactoryMethod();
                    wordPol.content = tmp[0];
                    wordPol.lang = "pol";

                    var wordTrans = creatorTrans.FactoryMethod();
                    wordTrans.content = tmp[1];
                    wordTrans.lang = tmp[2];

                    wordPol.AddTranslate(wordTrans);
                    wordTrans.AddTranslate(wordPol);

                    aggregate.insertPol((WordPol)wordPol);
                    aggregate.insertTrans((WordTrans)wordTrans);
                }
                
                sr.Close();
            }
        }


        
}
}
