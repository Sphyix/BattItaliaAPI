namespace BattItaliaAPI.DB.User
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static UserInsert;
    public interface IUserInsert
    {

        int ExecuteNonQuery(string nome, string email, string passwd, int? permission);
        int ExecuteNonQuery(string nome, string email, string passwd, int? permission, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        string Nome { get; set; }
        string Email { get; set; }
        string Passwd { get; set; }
        int? Permission { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class UserInsert : IUserInsert
    {// props for params
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public int? Permission { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(string nome, string email, string passwd, int? permission)
        {
            Nome = nome;
            Email = email;
            Passwd = passwd;
            Permission = permission;

            var returnVal = ExecuteNonQuery();
            ;
            return returnVal;
        }

        public virtual int ExecuteNonQuery()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return ExecuteNonQuery(conn);
            }
        }
        public virtual int ExecuteNonQuery(string nome, string email, string passwd, int? permission, IDbConnection conn, IDbTransaction tx = null)
        {
            Nome = nome;
            Email = email;
            Passwd = passwd;
            Permission = permission;

            var returnVal = ExecuteNonQuery(conn, tx);
            ;
            return returnVal;
        }

        public virtual int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            using (IDbCommand cmd = conn.CreateCommand())
            {
                if (tx != null)
                    cmd.Transaction = tx;
                cmd.CommandText = getCommandText();


                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@nome";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Nome ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@email";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Email ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@passwd";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Passwd ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@permission";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Permission ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                var result = cmd.ExecuteNonQuery();

                // Assign output parameters to instance properties. 

                // only convert dbnull if nullable
                return result;
            }
        }

        public string getCommandText()
        {
            return @"
/* .sql query managed by QueryFirst add-in */
/*designTime - put parameter declarations and design time initialization here
DECLARE @nome VARCHAR(40);
DECLARE @email VARCHAR(45);
DECLARE @passwd VARCHAR(80);
DECLARE @permission INT;
endDesignTime*/
INSERT INTO users (
	nome,
	email,
	passwd,
	permission
)
VALUES (
	@nome,
	@email,
	@passwd,
	@permission
)
";
        }
    }
}
