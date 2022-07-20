namespace BattItaliaAPI.DB.Client
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static ClientUpdate;
    public interface IClientUpdate
    {

        int ExecuteNonQuery(int? id, string nome, string cognome, string telefono, string mail, int? ccap, string via, string civico);
        int ExecuteNonQuery(int? id, string nome, string cognome, string telefono, string mail, int? ccap, string via, string civico, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        int? Id { get; set; }
        string Nome { get; set; }
        string Cognome { get; set; }
        string Telefono { get; set; }
        string Mail { get; set; }
        int? Ccap { get; set; }
        string Via { get; set; }
        string Civico { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class ClientUpdate : IClientUpdate
    {// props for params
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public int? Ccap { get; set; }
        public string Via { get; set; }
        public string Civico { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(int? id, string nome, string cognome, string telefono, string mail, int? ccap, string via, string civico)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;
            Mail = mail;
            Ccap = ccap;
            Via = via;
            Civico = civico;

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
        public virtual int ExecuteNonQuery(int? id, string nome, string cognome, string telefono, string mail, int? ccap, string via, string civico, IDbConnection conn, IDbTransaction tx = null)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;
            Mail = mail;
            Ccap = ccap;
            Via = via;
            Civico = civico;

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
                    myParam.ParameterName = "@id";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Id ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
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
                    myParam.ParameterName = "@ccap";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Ccap ?? DBNull.Value;
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
DECLARE @id int;
DECLARE @nome VARCHAR(30);
DECLARE @cognome VARCHAR(30);
DECLARE @telefono VARCHAR(15);
DECLARE @mail VARCHAR(40);
DECLARE @ccap INT;
DECLARE @via VARCHAR(50);
DECLARE @civico VARCHAR(5);
endDesignTime*/
UPDATE clients
SET 
	nome = @nome,
	cognome = @cognome,
	telefono = @telefono,
	mail = @mail,
	ccap = @ccap,
	via = @via,
	civico = @civico
WHERE clients_id = @id
";
        }
    }
}
