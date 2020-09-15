using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

        public List<List<BabyName>> babyMatrix = new List<List<BabyName>>();
        public List<BabyName> listOfBabyNames = new List<BabyName>();

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            var lines = File.ReadLines("babynames.txt");
            foreach (var line in lines)
            {
                listOfBabyNames.Add(new BabyName(line));
            }

            for (int year = 1900; year <= 2000; year += 10)
            {
                List<BabyName> topTenBabyNames = new List<BabyName>();
                foreach (var baby in listOfBabyNames)
                {

                    if ((baby.Rank(year) > 0) && (baby.Rank(year) < 11))
                    {
                        topTenBabyNames.Add(baby);
                    }
                }

                babyMatrix.Add(topTenBabyNames);
            }

            ListDecadeTopNames.ItemsSource = listOfBabyNames.ToString();
        }

    }
}
