using MySql.Data.MySqlClient;

namespace Kino_Yar.Classes.Common
{
    public class Connection
    {
        public static readonly string confing = "server=127.0.0.1;uid=root;pwd=;database=cinema;";
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(confing);
            connection.Open();

            return connection;
        }
        public static MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}