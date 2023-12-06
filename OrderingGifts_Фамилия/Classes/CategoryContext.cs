using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGifts_Тепляков.Classes
{
    public class CategoryContext : Model.Category, Interfaces.ICategory
    {
        public List<CategoryContext> AllCategories()
        {
            List<CategoryContext> allCategories = new List<CategoryContext>();
            OleDbConnection connection = Common.DBConnection.Connection();
            OleDbDataReader dataCategories = Common.DBConnection.Query("SELECT * FROM [Категории]", connection);
            while(dataCategories.Read())
            {
                CategoryContext newCategory = new CategoryContext();
                newCategory.id = dataCategories.GetInt32(0);
                newCategory.category = dataCategories.GetString(1);
                allCategories.Add(newCategory);
            }
            Common.DBConnection.CloseConnection(connection);
            return allCategories;
        }

        public void Save(bool Update = false)
        {
            if (!Update)
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query("INSERT INTO " +
                                            "[Категории]" +
                                                "([Категория])" +
                                            "VALUES (" +
                                                $"'{this.category}')", connection);
                Common.DBConnection.CloseConnection(connection);
            }
            else
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query($"UPDATE [Категории] SET [Категория] = '{this.category}' WHERE [Код] = {this.id}", connection);
                Common.DBConnection.CloseConnection(connection);
            }
        }

        public void Delete()
        {
            OleDbConnection connection = Common.DBConnection.Connection();
            Common.DBConnection.Query($"DELETE FROM [Категории] WHERE [Код] = {this.id}", connection);
            Common.DBConnection.CloseConnection(connection);

        }
    }
}
