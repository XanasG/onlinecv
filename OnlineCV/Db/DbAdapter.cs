using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAspNet.Db
{
    public class DbAdapter
    {
        const String connString = "Database=test;Server=localhost;Port=3306;Uid=Master;Password=Master";

        MySqlConnection conn;
        MySqlCommand cmd;

        public DbAdapter()
        {
            Console.Out.WriteLine("Connecting to database!");
            conn = new MySqlConnection(connString);

            conn.Open();

            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from article";
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.Out.WriteLine("Reading from database!");
            while (reader.Read())
            {
                Console.Out.WriteLine(reader.GetString(0));
                Console.Out.WriteLine(reader["TOPIC"].ToString());
            }
            Console.Out.WriteLine("Closing conn!");
            reader.Close();
        }
    }
}
