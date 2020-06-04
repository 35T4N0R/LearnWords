using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    public class IDatabase
    {
        WordDatabase instance = WordDatabase.GetInstance();
        private readonly Random rng = new Random();
        public void addWord(string word, string trans, string lang)
        {
            Creator creatorPol = new ConcreteCreatorPol();
            Creator creatorTrans = new ConcreteCreatorTrans(); 

            var wordPol = creatorPol.FactoryMethod();
            wordPol.content = word;
            wordPol.lang = "pol";
            
            var wordTrans = creatorTrans.FactoryMethod();
            wordTrans.content = trans;
            wordTrans.lang = lang;

            wordPol.AddTranslate(wordTrans);
            wordTrans.AddTranslate(wordPol);
            instance.addWord((WordPol)wordPol);
            instance.addWord((WordTrans)wordTrans);
        }
        public void editWord(int id, string word, string trans, string lang)
        {
            instance.getPolishWords().ElementAt(id).content = word;
            instance.getPolishWords().ElementAt(id).wordTrans.content = trans;
            instance.getPolishWords().ElementAt(id).wordTrans.lang = lang;
        }
        public void deleteWord(int id)
        {
            instance.deleteWord(id);
        }

        public WordTrans getRandomTransWord(string language)
        {
            
            int randIndex = rng.Next(instance.getLangTransWords(language).Count);
            return instance.getLangTransWords(language).ElementAt(randIndex);
        }
        public List<WordPol> getPolishWords()
        {
            return instance.getPolishWords();
        }

        public List<WordTrans> getTransWords()
        {
            return instance.getTransWords();
        }
    }
}
