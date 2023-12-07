using OrderingGifts_Тепляков.Classes;
using OrderingGifts_Тепляков.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace OrderingGifts_Тепляков.Pages.PagesItem
{
    /// <summary>
    /// Логика взаимодействия для AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Page
    {
        public Category Category;
        public CategoryContext CategoryContext;
        public AddCategory(Category Category = null)
        {
            InitializeComponent();
            CreateCategory();
        }

        public void CreateCategory()
        {
            cb_category.Items.Clear();
            foreach(CategoryContext category in MainWindow.init.AllCategories)
            {
                cb_category.Items.Add(category.category);
            }
        }

        private void AddCategories(object sender, RoutedEventArgs e)
        {
            if (tb_new_category.Text.Length == 0)
            {
                MessageBox.Show("Укажите новую категорию подарка");
                return;
            }
            if (Category == null)
            {
                CategoryContext newCategory = new CategoryContext();
                newCategory.category = tb_new_category.Text;
                newCategory.Save();
                MessageBox.Show("Категория добавлена");
                MainWindow.init.AllCategories = new CategoryContext().AllCategories();
                CreateCategory();
                tb_new_category.Text = "";
            }
        }

        private void UpdateCategory(object sender, RoutedEventArgs e)
        {
            if (tb_new_category.Text != "")
            {
                CategoryContext newCategory = new CategoryContext();
                newCategory.category = tb_new_category.Text;
                OleDbConnection connection = Classes.Common.DBConnection.Connection();
                OleDbDataReader reader = Classes.Common.DBConnection.Query($"SELECT [Код] FROM [Категории] WHERE [Категория подарка] = '{cb_category.SelectedItem}'", connection);
                while (reader.Read())
                    newCategory.id = reader.GetInt32(0);
                Classes.Common.DBConnection.CloseConnection(connection);
                newCategory.Save(true);
                MessageBox.Show("Категория изменена");
                MainWindow.init.AllCategories = new CategoryContext().AllCategories();
                CreateCategory();
            }
            else MessageBox.Show("Выберите категорию для изменения");
        }

        private void DeleteCategory(object sender, RoutedEventArgs e)
        {
            if (tb_new_category.Text != "")
            {
                OleDbConnection connection = Classes.Common.DBConnection.Connection();
                Classes.Common.DBConnection.Query($"DELETE FROM [Категории] WHERE [Категория подарка] = '{tb_new_category.Text}'", connection);
                MessageBox.Show("Ответственный удален");
                MainWindow.init.AllCategories = new CategoryContext().AllCategories();
                CreateCategory();
            }
            else MessageBox.Show("Выбирите ответственного для удаления");
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.add);
        }

        private void Categories(object sender, SelectionChangedEventArgs e)
        {
            if (tb_new_category.Text == "")
                tb_new_category.Text = cb_category.SelectedItem.ToString();
            else
                tb_new_category.Text = "";
        }
    }
}
