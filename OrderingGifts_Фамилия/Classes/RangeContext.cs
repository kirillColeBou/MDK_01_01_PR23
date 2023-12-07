using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGifts_Тепляков.Classes
{
    public class RangeContext : Model.Range, Interfaces.IRange
    {
        public List<RangeContext> AllRanges()
        {
            List<RangeContext> allRanges = new List<RangeContext>();
            OleDbConnection connection = Common.DBConnection.Connection();
            OleDbDataReader dataRanges = Common.DBConnection.Query("SELECT * FROM [Сортировка]", connection);
            while (dataRanges.Read())
            {
                RangeContext newRange = new RangeContext();
                newRange.id = dataRanges.GetInt32(0);
                newRange.FIO = dataRanges.GetString(1);
                newRange.category_gift = dataRanges.GetString(2);
                newRange.text = dataRanges.GetString(3);
                newRange.address = dataRanges.GetString(4);
                newRange.date = dataRanges.GetDateTime(5);
                newRange.email = dataRanges.GetString(6);
                allRanges.Add(newRange);
            }
            Common.DBConnection.CloseConnection(connection);
            return allRanges;
        }
    }
}
