using OrderingGifts_Тепляков;
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

namespace OrderingGifts_Фамилия.Pages.PagesItem
{
    /// <summary>
    /// Логика взаимодействия для Range.xaml
    /// </summary>
    public partial class Range : Page
    {
        public Gift Gift;
        public bool RangeIsApply = false;
        public static Range range;
        public Range()
        {
            InitializeComponent();
            range = this;
        }

        private void NewRange(object sender, RoutedEventArgs e)
        {
            if (cb_category.Text == "")
            {
                RangeContext newRange = new RangeContext();
                OleDbConnection connection = OrderingGifts_Тепляков.Classes.Common.DBConnection.Connection();
                OrderingGifts_Тепляков.Classes.Common.DBConnection.Query($"INSERT INTO [Сортировка]([])", connection);
                MainWindow.init.AllRanges = new RangeContext().AllRanges();
                MessageBox.Show("");
                

                RangeIsApply = true;
                Main.main.parrent.Children.Clear();
                MainWindow.init.OpenPages(MainWindow.pages.main);
            }
            else MessageBox.Show("");
            
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
