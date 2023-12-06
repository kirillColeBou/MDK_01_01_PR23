using OrderingGifts_Тепляков;
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

namespace OrderingGifts_Фамилия.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void AddNewGift(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.add);
        }

        private void RangeGift(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.range);
        }
    }
}
