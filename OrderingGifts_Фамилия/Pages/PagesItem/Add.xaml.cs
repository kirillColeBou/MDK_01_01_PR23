using OrderingGifts_Тепляков;
using OrderingGifts_Тепляков.Classes;
using OrderingGifts_Тепляков.Model;
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

namespace OrderingGifts_Фамилия.Pages.PagesItem
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Gift Gift;
        public Add(Gift Gift = null)
        {
            InitializeComponent();
            CreateCategory();
            if (Gift != null)
            {
                this.Gift = Gift;
                tb_fio.Text = this.Gift.FIO;
                tb_category.SelectedItem = this.Gift.category_gift;
                tb_text.Text = this.Gift.text;
                tb_address.Text = this.Gift.address;
                tb_date.Text = this.Gift.date.ToString("dd.MM.yyyy");
                tb_email.Text = this.Gift.email;
                btnAdd.Content = "Изменить";
            }
        }

        public void CreateCategory()
        {
            tb_category.Items.Clear();
            foreach (CategoryContext category in MainWindow.init.AllCategories)
            {
                tb_category.Items.Add(category.category);
            }
        }

        private void AddNewGift_db(object sender, RoutedEventArgs e)
        {
            if (tb_fio.Text.Length == 0)
            {
                MessageBox.Show("Укажите ФИО");
                return;
            }
            if (tb_category.Text.Length == 0)
            {
                MessageBox.Show("Укажите категорию");
                return;
            }
            if (tb_text.Text.Length == 0)
            {
                MessageBox.Show("Укажите текст к заказу");
                return;
            }
            if (tb_address.Text.Length == 0)
            {
                MessageBox.Show("Укажите адрес");
                return;
            }
            if (tb_date.Text.Length == 0)
            {
                MessageBox.Show("Укажите дату");
                return;
            }
            if (tb_email.Text.Length == 0)
            {
                MessageBox.Show("Укажите почту");
                return;
            }
            if (Gift == null)
            {
                GiftContext newGift = new GiftContext();
                newGift.FIO = tb_fio.Text;
                newGift.category_gift = tb_category.SelectedItem.ToString();
                newGift.text = tb_text.Text;
                newGift.address = tb_address.Text;
                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newGift.date = newDate;
                newGift.email = tb_email.Text;
                newGift.Save();
                MessageBox.Show("Заказ добавлен");
            }
            else
            {
                GiftContext newGift = new GiftContext();
                newGift.id = Gift.id;
                newGift.FIO = tb_fio.Text;
                newGift.category_gift = tb_category.SelectedItem.ToString();
                newGift.text = tb_text.Text;
                newGift.address = tb_address.Text;
                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newGift.date = newDate;
                newGift.email = tb_email.Text;
                newGift.Save(true);
                MessageBox.Show("Заказ изменен");
            }
            MainWindow.init.AllGifts = new GiftContext().AllGifts();
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }

        private void AddCategory(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.addCategory);
        }
    }
}
