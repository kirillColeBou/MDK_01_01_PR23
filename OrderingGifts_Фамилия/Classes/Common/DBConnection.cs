﻿using System.Data.OleDb;

namespace OrderingGifts_Тепляков.Classes.Common
{
    public class DBConnection
    {
        public static readonly string Path = @"C:\Users\kiril\OneDrive\Рабочий стол\ПР23\OrderingGifts_Тепляков\OrderingGifts_Фамилия\bin\Debug\ПР22.accdb";
        public static OleDbConnection Connection()
        {
            OleDbConnection oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path);
            oleDbConnection.Open();
            return oleDbConnection;
        }
        public static OleDbDataReader Query(string Query, OleDbConnection Connection)
        {
            return new OleDbCommand(Query, Connection).ExecuteReader();
        }
        public static void CloseConnection(OleDbConnection Connection)
        {
            Connection.Close();
        }
    }
}
