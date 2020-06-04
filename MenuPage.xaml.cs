using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZTProj.modes;

namespace ZTProj
{
    /// <summary>
    /// Logika interakcji dla klasy MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        IDatabase facade = new IDatabase();


        public MenuPage()
        {
            InitializeComponent();
            List<string> languagelist = facade.getTransWords().Select(x => x.lang).Distinct().ToList();
            foreach (string s in languagelist)
                LanguageList.Items.Add(s);
            LanguageList.SelectedIndex = 0;
        }

        private void WordButton_Click(object sender, RoutedEventArgs e)
        {
            mw.MainFrame.Content = new WordsPage();
        }

        private void TreningButton_Click(object sender, RoutedEventArgs e)
        {
            var lvl = DifficultyList.Text;
            var lang = LanguageList.Text;
            mw.MainFrame.Content = new TrainingPage(lvl,lang, "training", Modelist.Text);
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            var lvl = DifficultyList.Text;
            var lang = LanguageList.Text;
            mw.MainFrame.Content = new TrainingPage(lvl, lang, "Test", Modelist.Text);
        }
    }
}
