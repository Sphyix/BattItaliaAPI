namespace BattItaliaAPI.DB.Client
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static ClientSelect;
    public interface IClientSelect
    {

        List<ClientSelectResults> Execute(int? id, string nome, string cognome, string telefono);
        IEnumerable<ClientSelectResults> Execute(int? id, string nome, string cognome, string telefono, IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar(int? id, string nome, string cognome, string telefono);
        System.Int32? ExecuteScalar(int? id, string nome, string cognome, string telefono, IDbConnection conn, IDbTransaction tx = null);

        List<ClientSelectResults> Execute();
        IEnumerable<ClientSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar();
        System.Int32? ExecuteScalar(IDbConnection conn, IDbTransaction tx = null);
        ClientSelectResults Create(IDataRecord record);

        ClientSelectResults GetOne(int? id, string nome, string cognome, string telefono);
        ClientSelectResults GetOne(int? id, string nome, string cognome, string telefono, IDbConnection conn, IDbTransaction tx = null);
        ClientSelectResults GetOne();
        ClientSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery(int? id, string nome, string cognome, string telefono);
        int ExecuteNonQuery(int? id, string nome, string cognome, string telefono, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        int? Id { get; set; }
        string Nome { get; set; }
        string Cognome { get; set; }
        string Telefono { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class ClientSelect : IClientSelect
    {// props for params
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Telefono { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(int? id, string nome, string cognome, string telefono)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;

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
        public virtual int ExecuteNonQuery(int? id, string nome, string cognome, string telefono, IDbConnection conn, IDbTransaction tx = null)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;

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
declare @id int;
declare @nome varchar;
declare @cognome varchar;
declare @telefono varchar;
endDesignTime*/


SELECT clients.*, comuni.*  FROM clients
left join caps on clients.ccap = caps.cap
left join comuni on caps.cap_id = comuni.comune_id
WHERE (@id IS NULL OR clients_id = @id)
AND (@nome IS NULL OR nome = @nome)
AND (@cognome IS NULL OR cognome = @cognome)
AND (@telefono IS NULL OR telefono = @telefono)
";
        }
        public virtual List<ClientSelectResults> Execute(int? id, string nome, string cognome, string telefono)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                ;
                return returnVal;
            }
        }

        public virtual List<ClientSelectResults> Execute()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                return returnVal;
            }
        }

        public virtual IEnumerable<ClientSelectResults> Execute(int? id, string nome, string cognome, string telefono, IDbConnection conn, IDbTransaction tx = null)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;

            var returnVal = Execute(conn);
            return returnVal;
        }
        public virtual IEnumerable<ClientSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null)
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
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Create(reader);
                    }
                }

                // Assign output parameters to instance properties. These will be available after this method returns.

            }
        }
        public virtual ClientSelectResults GetOne(int? id, string nome, string cognome, string telefono)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual ClientSelectResults GetOne()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return GetOne(conn);
            }
        }
        public virtual ClientSelectResults GetOne(int? id, string nome, string cognome, string telefono, IDbConnection conn, IDbTransaction tx = null)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;

            {
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual ClientSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            {
                var all = Execute(conn, tx);
                ClientSelectResults returnVal;
                using (IEnumerator<ClientSelectResults> iter = all.GetEnumerator())
                {
                    iter.MoveNext();
                    returnVal = iter.Current;
                }
                return returnVal;
            }
        }
        public virtual System.Int32? ExecuteScalar(int? id, string nome, string cognome, string telefono)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;

            var returnVal = ExecuteScalar();
            ;
            return returnVal;
        }

        public virtual System.Int32? ExecuteScalar()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return ExecuteScalar(conn);
            }
        }

        public virtual System.Int32? ExecuteScalar(int? id, string nome, string cognome, string telefono, IDbConnection conn, IDbTransaction tx = null)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;

            var returnVal = ExecuteScalar(conn, tx);
            ;
            return returnVal;
        }
        public virtual System.Int32? ExecuteScalar(IDbConnection conn, IDbTransaction tx = null)
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
                var result = cmd.ExecuteScalar();

                // only convert dbnull if nullable
                // Assign output parameters to instance properties. 

                if (result == null || result == DBNull.Value)
                    return null;
                else
                    return (System.Int32?)result;
            }
        }

        public virtual ClientSelectResults Create(IDataRecord record)
        {
            var returnVal = CreatePoco(record);

            if (record[0] != null && record[0] != DBNull.Value)
                returnVal.clients_id = (int)record[0];

            if (record[1] != null && record[1] != DBNull.Value)
                returnVal.nome = (string)record[1];

            if (record[2] != null && record[2] != DBNull.Value)
                returnVal.cognome = (string)record[2];

            if (record[3] != null && record[3] != DBNull.Value)
                returnVal.telefono = (string)record[3];

            if (record[4] != null && record[4] != DBNull.Value)
                returnVal.mail = (string)record[4];

            if (record[5] != null && record[5] != DBNull.Value)
                returnVal.via = (string)record[5];

            if (record[6] != null && record[6] != DBNull.Value)
                returnVal.civico = (string)record[6];

            if (record[7] != null && record[7] != DBNull.Value)
                returnVal.ccap = (int?)record[7];

            if (record[8] != null && record[8] != DBNull.Value)
                returnVal.comune = (string)record[8];

            if (record[9] != null && record[9] != DBNull.Value)
                returnVal.comune_id = (int?)record[9];

            if (record[10] != null && record[10] != DBNull.Value)
                returnVal.provincia = (string)record[10];

            if (record[11] != null && record[11] != DBNull.Value)
                returnVal.sigla = (string)record[11];

            if (record[12] != null && record[12] != DBNull.Value)
                returnVal.regione = (string)record[12];

            if (record[13] != null && record[13] != DBNull.Value)
                returnVal.cod_regione = (int?)record[13];

            returnVal.OnLoad();
            return returnVal;
        }
    }
    public partial class ClientSelectResults
    {
        protected int _clients_id; //(int not null)
        public int clients_id
        {
            get { return _clients_id; }
            set { _clients_id = value; }
        }
        protected string _nome; //(varchar null)
        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        protected string _cognome; //(varchar null)
        public string cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }
        protected string _telefono; //(varchar null)
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        protected string _mail; //(varchar null)
        public string mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        protected string _via; //(varchar null)
        public string via
        {
            get { return _via; }
            set { _via = value; }
        }
        protected string _civico; //(varchar null)
        public string civico
        {
            get { return _civico; }
            set { _civico = value; }
        }
        protected int? _ccap; //(int null)
        public int? ccap
        {
            get { return _ccap; }
            set { _ccap = value; }
        }
        protected string _comune; //(varchar null)
        public string comune
        {
            get { return _comune; }
            set { _comune = value; }
        }
        protected int? _comune_id; //(int null)
        public int? comune_id
        {
            get { return _comune_id; }
            set { _comune_id = value; }
        }
        protected string _provincia; //(varchar null)
        public string provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }
        protected string _sigla; //(varchar null)
        public string sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }
        protected string _regione; //(varchar null)
        public string regione
        {
            get { return _regione; }
            set { _regione = value; }
        }
        protected int? _cod_regione; //(int null)
        public int? cod_regione
        {
            get { return _cod_regione; }
            set { _cod_regione = value; }
        }
    }
}
