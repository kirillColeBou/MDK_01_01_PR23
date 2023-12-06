using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGifts_Тепляков.Classes
{
    public class GiftContext : Model.Gift, Interfaces.IGift
    {
        public List<GiftContext> AllGifts()
        {
            List<GiftContext> allGifts = new List<GiftContext>();
            OleDbConnection connection = Common.DBConnection.Connection();
            OleDbDataReader dataGifts = Common.DBConnection.Query("SELECT * FROM [Заказы]", connection);
            while (dataGifts.Read())
            {
                GiftContext newGift = new GiftContext();
                newGift.id = dataGifts.GetInt32(0);
                newGift.FIO = dataGifts.GetString(1);
                newGift.category_gift = dataGifts.GetString(2);
                newGift.text = dataGifts.GetString(3);
                newGift.address = dataGifts.GetString(4);
                newGift.date = dataGifts.GetString(5);
                newGift.email = dataGifts.GetString(6);
                allGifts.Add(newGift);
            }
            Common.DBConnection.CloseConnection(connection);
            return allGifts;
        }

        public void Save(bool Update = false)
        {
            if (Update)
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query("UPDATE [Заказы] " +
                                          "SET " +
                                          $"[ФИО заказчика] = '{this.FIO}', " +
                                          $"[Категория подарка] = '{this.category_gift}', " +
                                          $"[Текст сообщения] = '{this.text}', " +
                                          $"[Адрес доставки] = '{this.address}', " +
                                          $"[Дата и время отправки письма] = '{this.date}', " +
                                          $"[Почта для связи] = '{this.email}', " +
                                          $"WHERE [Код] = {this.id}", connection);
                Common.DBConnection.CloseConnection(connection);
            }
            else
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query("INSERT INTO " +
                                            "[Заказы]" +
                                                "([ФИО заказчика]," +
                                                "[Категория подарка]," +
                                                "[Текст сообщения]," +
                                                "[Адрес доставки]," +
                                                "[Дата и время отправки письма]," +
                                                "[Почта для связи])" +
                                            "VALUES (" +
                                                $"'{this.FIO}', " +
                                                $"'{this.category_gift}', " +
                                                $"'{this.text}', " +
                                                $"'{this.address}', " +
                                                $"'{this.date}', " +
                                                $"'{this.email}')", connection);
                Common.DBConnection.CloseConnection(connection);
            }
        }

        public void Delete()
        {
            OleDbConnection connection = Common.DBConnection.Connection();
            Common.DBConnection.Query($"DELETE FROM [Заказы] WHERE [Код] = {this.id}", connection);
            Common.DBConnection.CloseConnection(connection);
        }
    }
}
