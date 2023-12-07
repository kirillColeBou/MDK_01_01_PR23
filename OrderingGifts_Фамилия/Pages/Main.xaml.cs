using OrderingGifts_Тепляков;
using OrderingGifts_Фамилия.Pages.PagesItem;
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
using System.Xml.Linq;

namespace OrderingGifts_Фамилия.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public static Main main;
        public Main()
        {
            InitializeComponent();
            CreateUI();
            main = this;
        }

        public void CreateUI()
        {
            parrent.Children.Clear();
            foreach (OrderingGifts_Тепляков.Classes.GiftContext gift in MainWindow.init.AllGifts)
            {
                parrent.Children.Add(new OrderingGifts_Тепляков.Elements.Item(gift));
            }
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
