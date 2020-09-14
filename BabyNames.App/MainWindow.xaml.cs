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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BabyNames.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<BabyName> listOfBabyNames = new List<BabyName>();

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            var lines = File.ReadLines("babynames.txt").Take(10).ToList();
            foreach (var line in lines)
            {
                listOfBabyNames.Add(new BabyName(line));
            }

            ListDecadeTopNames.ItemsSource = lines;
        }
    }
}
