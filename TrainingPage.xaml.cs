using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using ZTProj.modes;

namespace ZTProj
{
    /// <summary>
    /// Logika interakcji dla klasy TrainingPage.xaml
    /// </summary>
    public partial class TrainingPage : Page
    {
        private DifficultyLevel dificulty;
        private IDatabase facade = new IDatabase();
        private Action action;
        WordTrans wordTrans;
        private string mode;
        Test test;
        Caretaker caretaker;
        List<string> previousAnswers;
        public TrainingPage(string lvl, string lang, string type, string mode)
        {
            switch(type)
            {
                case "training":
                    action = new Training();
                    break;
                case "Test":
                    action = new Test();
                    break;
            }
            switch (lvl)
            {
                case "Łatwy":
                    dificulty = new DifficultyLevel(new Easy());
                    break;
                case "Normalny":
                    dificulty = new DifficultyLevel(new Normal());
                    break;
                case "Trudny":
                    dificulty = new DifficultyLevel(new Hard());
                    break;
                case "Ekspert":
                    dificulty = new DifficultyLevel(new Expert());
                    break;
                case "Mistrz":
                    dificulty = new DifficultyLevel(new Master());
                    break;

            }

            this.mode = mode;
            InitializeComponent();
            if (type == "Test")
            {
                wrongAnswerLabel.Content = "pytanie 1/10";
            }
            if (action.GetType() == typeof(Training))
            {
                previousQuestion.Visibility = Visibility.Hidden;
                TestButton.Margin = new Thickness(0, 0, 0, 10);
            }
            else
            {
                previousQuestion.IsEnabled = false;
            }
            wordTrans = facade.getRandomTransWord(lang);
            dificulty.generateAns(radios);
            if (mode == "Polski->Obcy")
            {
                previousAnswers = dificulty.randomizeAnswers(radios, wordTrans, lang);
                WordLabel.Content = wordTrans.wordPol.content;
                action.actualWord = wordTrans;
            }
            else
            {
                previousAnswers = dificulty.randomizeAnswers(radios, wordTrans, "pol");
                WordLabel.Content = wordTrans.content;
                action.actualWord = wordTrans;
            }
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            if (action.GetType() != typeof(Training))
            {
                test = (Test)action;

            }




            if(mode == "Polski->Obcy")
            {
                action.Stud(radios, dificulty, wordTrans.lang,previousAnswers);
                previousAnswers = action.answers;
            }
            else
            {
                action.Stud(radios, dificulty, "pol",previousAnswers);
                previousAnswers = action.answers;
            }

            if (action.GetType() != typeof(Training))
            {
                caretaker = new Caretaker();
                caretaker.Memento = test.question.CreateMemento();
            }
            previousQuestion.IsEnabled = true;

        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void previousQuestion_Click(object sender, RoutedEventArgs e)
        {
            test.question.RestoreMemento(caretaker.Memento);
            action.actualWord = (WordTrans)test.question.Word;

            if (mode == "Polski->Obcy")
            {
                WordLabel.Content = action.actualWord.wordPol.content;
            }
            else
            {
                WordLabel.Content = action.actualWord.content;
            }
            test.score = test.question.Score;
            test.counter = test.question.Counter;

            if(dificulty.strategy.GetType() != typeof(Master))
            {

                for (int i = 0; i < test.question.Answers.Count; i++)
                {
                    radios.Children.OfType<RadioButton>().ElementAt(i).Content = test.question.Answers[i];
                }
                previousAnswers = test.question.Answers;
                
            }

            previousQuestion.IsEnabled = false;
            wrongAnswerLabel.Content = "pytanie " + (test.question.Counter + 1) + "/10";
            
        }
    }
}
