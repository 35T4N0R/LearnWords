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

namespace ZTProj
{
    /// <summary>
    /// Logika interakcji dla klasy WordsPage.xaml
    /// </summary>
    public partial class WordsPage : Page
    {
        IDatabase facade = new IDatabase();

        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        List<WordPol> polishWords;
        List<WordTrans> transWords;
        public WordsPage()
        {
            InitializeComponent();
            polishWords = facade.getPolishWords();
            lista.ItemsSource = polishWords;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchBox.Text;
            List<WordPol> findedWords = polishWords.Where(e => e.content.Contains(searchText)).ToList();
            lista.ItemsSource = findedWords;
        }

        private void AddWord_Click(object sender, RoutedEventArgs e)
        {

            AddWindow aw = new AddWindow();
            aw.ShowDialog();
            polishWords = facade.getPolishWords();
            lista.ItemsSource = polishWords;
            lista.Items.Refresh();
            
        }

        private void DeleteWord_Click(object sender, RoutedEventArgs e)
        {
            if(lista.SelectedIndex != -1) facade.deleteWord(lista.SelectedIndex);
            polishWords = facade.getPolishWords();
            lista.ItemsSource = polishWords;
            lista.Items.Refresh();
        }

        private void EditWord_Click(object sender, RoutedEventArgs e)
        {
            if (lista.SelectedIndex != -1)
            {
                AddWindow aw = new AddWindow(lista.SelectedIndex);
                aw.ShowDialog();
            }
            lista.Items.Refresh();
        }
    }
}
