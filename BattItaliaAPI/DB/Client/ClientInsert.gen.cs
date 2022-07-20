namespace BattItaliaAPI.DB.Client
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static ClientInsert;
    public interface IClientInsert
    {

        int ExecuteNonQuery(string nome, string cognome, string telefono, string mail, string via, string civico, int? ccap);
        int ExecuteNonQuery(string nome, string cognome, string telefono, string mail, string via, string civico, int? ccap, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        string Nome { get; set; }
        string Cognome { get; set; }
        string Telefono { get; set; }
        string Mail { get; set; }
        string Via { get; set; }
        string Civico { get; set; }
        int? Ccap { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class ClientInsert : IClientInsert
    {// props for params
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Via { get; set; }
        public string Civico { get; set; }
        public int? Ccap { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(string nome, string cognome, string telefono, string mail, string via, string civico, int? ccap)
        {
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;
            Mail = mail;
            Via = via;
            Civico = civico;
            Ccap = ccap;

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
        public virtual int ExecuteNonQuery(string nome, string cognome, string telefono, string mail, string via, string civico, int? ccap, IDbConnection conn, IDbTransaction tx = null)
        {
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;
            Mail = mail;
            Via = via;
            Civico = civico;
            Ccap = ccap;

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
                    myParam.ParameterName = "@cognome";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Cognome ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@telefono";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Telefono ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@mail";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Mail ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@via";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Via ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@civico";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Civico ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@ccap";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Ccap ?? DBNull.Value;
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
DECLARE @nome VARCHAR(30);
DECLARE @cognome VARCHAR(30);
DECLARE @telefono VARCHAR(15);
DECLARE @mail VARCHAR(40);
DECLARE @via VARCHAR(50);
DECLARE @civico VARCHAR(8);
DECLARE @ccap INT;
endDesignTime*/
INSERT INTO clients (
	nome,
	cognome,
	telefono,
	mail,
	via,
	civico,
	ccap
)
VALUES (
	@nome,
	@cognome,
	@telefono,
	@mail,
	@via,
	@civico,
	@ccap
)
";
        }
    }
}
