using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BattItaliaAPI.DB
{
    public class DbHelper
    {
        static string myConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        public static MySqlConnection OpenConnection()
        {
            
            MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            return conn;

        }

        public static string CheckValue(string input, string dbInput)
        {
            if (string.IsNullOrWhiteSpace(input) && string.IsNullOrWhiteSpace(dbInput))
            {
                return string.Empty;
            }
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            if (string.IsNullOrWhiteSpace(input) && !string.IsNullOrWhiteSpace(dbInput))
            {
                return dbInput;
            }
            return string.Empty;
        }
    }

}