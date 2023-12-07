using OrderingGifts_Тепляков.Classes;
using OrderingGifts_Тепляков.Interfaces;
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

namespace OrderingGifts_Тепляков.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        GiftContext Gift;
        RangeContext Range;
        public Item(GiftContext Gift)
        {
            InitializeComponent();
            IFio.Content = Gift.FIO;
            ICategory.Content = $"Категория: " + Gift.category_gift;
            IAddress.Content = $"Адрес: " + Gift.address;
            IDate.Content = $"Дата: " + Gift.date.ToString("dd.MM.yyyy");
            IEmail.Content = $"Почта: " + Gift.email;
            IText.Text = Gift.text;
            this.Gift = Gift;
        }

        public Item(RangeContext Range)
        {
            InitializeComponent();
            IFio.Content = Range.FIO;
            ICategory.Content = $"Категория: " + Range.category_gift;
            IAddress.Content = $"Адрес: " + Range.address;
            IDate.Content = $"Дата: " + Range.date.ToString("dd.MM.yyyy");
            IEmail.Content = $"Почта: " + Range.email;
            IText.Text = Range.text;
            this.Range = Range;
        }

        private void EditGift(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new OrderingGifts_Фамилия.Pages.PagesItem.Add(Gift));
        }

        private void DeleteGift(object sender, RoutedEventArgs e)
        {
            Gift.Delete();
            MainWindow.init.AllGifts = new GiftContext().AllGifts();
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
