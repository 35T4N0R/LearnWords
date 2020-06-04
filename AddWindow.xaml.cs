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
using System.Windows.Shapes;

namespace ZTProj
{
    /// <summary>
    /// Logika interakcji dla klasy AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        IDatabase facade = new IDatabase();
        int toUpdate = -1;

        public AddWindow()
        {
            InitializeComponent();

        }
        public AddWindow(int? id)
        {
            InitializeComponent();
            if(id != null || id != -1)
            {
                toUpdate =(int) id;
                var word = facade.getPolishWords().ElementAt(toUpdate);
                wordTextBox.Text = word.content;
                transTextBox.Text = word.wordTrans.content;
                langTextBox.Text = word.wordTrans.lang;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (toUpdate != -1)
            {
                string word = wordTextBox.Text;
                string trans = transTextBox.Text;
                string lang = langTextBox.Text;
                facade.editWord(toUpdate, word, trans, lang);
            }
            else
            {
                string word = wordTextBox.Text;
                string trans = transTextBox.Text;
                string lang = langTextBox.Text;
                facade.addWord(word, trans, lang);
            }
            
            this.Close();
        }
    }
}
