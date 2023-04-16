using System.Data.OleDb;

namespace WhiteBoard.Core
{
    public static class DBHelper
    {
        public static string connection =
            @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\support\Documents\WhiteBoard.accdb";

        // Функция подключения к базе данных и обработка запросов
        public static OleDbDataReader Execute(string selectSQL)
        {
            OleDbConnection connect = new OleDbConnection(connection); // подключаемся к базе данных
            connect.Open(); // открываем базу данных

            OleDbCommand cmd = new OleDbCommand(selectSQL, connect); // создаём запрос
            OleDbDataReader reader = cmd.ExecuteReader(); // получаем данные

            return reader; // возвращаем
        }
    }
}