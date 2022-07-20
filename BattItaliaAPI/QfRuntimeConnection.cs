using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/* What provider are you using? For SqlClient, you will need to add a project reference (.net framework) or 
the System.Data.SqlClient nuget package (.net core). */


namespace BattItaliaAPI
{
    class QfRuntimeConnection
    {
        public static IDbConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        }
    }
}