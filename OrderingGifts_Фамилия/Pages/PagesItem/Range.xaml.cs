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

namespace OrderingGifts_Фамилия.Pages.PagesItem
{
    /// <summary>
    /// Логика взаимодействия для Range.xaml
    /// </summary>
    public partial class Range : Page
    {
        public Range()
        {
            InitializeComponent();
        }

        private void NewRange(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сортировка выполнена");
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
