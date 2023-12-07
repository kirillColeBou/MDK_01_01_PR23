using OrderingGifts_Тепляков;
using OrderingGifts_Тепляков.Classes;
using OrderingGifts_Тепляков.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
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
        public static Range range;
        public static bool RangeApply = false;
        public Range()
        {
            InitializeComponent();
            range = this;
        }

        private void NewRange(object sender, RoutedEventArgs e)
        {
            if (tb_date_start.SelectedDate != null && tb_date_end.SelectedDate != null)
            {
                RangeApply = true;
                var dateTimeFormatInfo = new DateTimeFormatInfo();
                dateTimeFormatInfo.ShortDatePattern = "MM/dd/yyyy";
                RangeContext newRange = new RangeContext();
                OleDbConnection connection = OrderingGifts_Тепляков.Classes.Common.DBConnection.Connection();
                OrderingGifts_Тепляков.Classes.Common.DBConnection.Query("DELETE FROM [Сортировка]", connection);
                OrderingGifts_Тепляков.Classes.Common.DBConnection.Query($"INSERT INTO [Сортировка]([ФИО заказчика],[Категория подарка],[Текст сообщения],[Адрес доставки],[Дата и время отправки письма],[Почта для связи]) SELECT [Заказы.ФИО заказчика], [Заказы.Категория подарка], [Заказы.Текст сообщения], [Заказы.Адрес доставки], [Заказы.Дата и время отправки письма], [Заказы.Почта для связи] FROM [Заказы] WHERE [Заказы.Дата и время отправки письма] BETWEEN #{tb_date_start.SelectedDate.Value.ToString("d", dateTimeFormatInfo)}# AND #{tb_date_end.SelectedDate.Value.ToString("d", dateTimeFormatInfo)}#", connection);
                OrderingGifts_Тепляков.Classes.Common.DBConnection.CloseConnection(connection);
                MainWindow.init.AllRanges = new RangeContext().AllRanges();
                MessageBox.Show("Сортировка применена");MainWindow.init.OpenPages(MainWindow.pages.main);
            }
            else MessageBox.Show("Ошибка сортировки");
            
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
