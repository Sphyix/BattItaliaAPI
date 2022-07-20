﻿namespace BattItaliaAPI.DB.WorkOrders
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static UserWorkOrdersSelect;
    public interface IUserWorkOrdersSelect
    {

        List<UserWorkOrdersSelectResults> Execute(int? userId);
        IEnumerable<UserWorkOrdersSelectResults> Execute(int? userId, IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar(int? userId);
        System.Int32? ExecuteScalar(int? userId, IDbConnection conn, IDbTransaction tx = null);

        List<UserWorkOrdersSelectResults> Execute();
        IEnumerable<UserWorkOrdersSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar();
        System.Int32? ExecuteScalar(IDbConnection conn, IDbTransaction tx = null);
        UserWorkOrdersSelectResults Create(IDataRecord record);

        UserWorkOrdersSelectResults GetOne(int? userId);
        UserWorkOrdersSelectResults GetOne(int? userId, IDbConnection conn, IDbTransaction tx = null);
        UserWorkOrdersSelectResults GetOne();
        UserWorkOrdersSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery(int? userId);
        int ExecuteNonQuery(int? userId, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        int? UserId { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class UserWorkOrdersSelect : IUserWorkOrdersSelect
    {// props for params
        public int? UserId { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(int? userId)
        {
            UserId = userId;

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
        public virtual int ExecuteNonQuery(int? userId, IDbConnection conn, IDbTransaction tx = null)
        {
            UserId = userId;

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
                    myParam.ParameterName = "@userId";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)UserId ?? DBNull.Value;
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
DECLARE @userId int;
endDesignTime*/
	SELECT workOrders.*, users.nome FROM workOrders
	INNER JOIN workOrder_user ON workOrders.workOrders_id = workOrder_user.workOrderId and workOrder_user.userId = @userId
	INNER JOIN users on users.users_id = workOrder_user.userId
";
        }
        public virtual List<UserWorkOrdersSelectResults> Execute(int? userId)
        {
            UserId = userId;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                ;
                return returnVal;
            }
        }

        public virtual List<UserWorkOrdersSelectResults> Execute()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                return returnVal;
            }
        }

        public virtual IEnumerable<UserWorkOrdersSelectResults> Execute(int? userId, IDbConnection conn, IDbTransaction tx = null)
        {
            UserId = userId;

            var returnVal = Execute(conn);
            return returnVal;
        }
        public virtual IEnumerable<UserWorkOrdersSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null)
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
                    myParam.ParameterName = "@userId";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)UserId ?? DBNull.Value;
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
        public virtual UserWorkOrdersSelectResults GetOne(int? userId)
        {
            UserId = userId;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual UserWorkOrdersSelectResults GetOne()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return GetOne(conn);
            }
        }
        public virtual UserWorkOrdersSelectResults GetOne(int? userId, IDbConnection conn, IDbTransaction tx = null)
        {
            UserId = userId;

            {
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual UserWorkOrdersSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            {
                var all = Execute(conn, tx);
                UserWorkOrdersSelectResults returnVal;
                using (IEnumerator<UserWorkOrdersSelectResults> iter = all.GetEnumerator())
                {
                    iter.MoveNext();
                    returnVal = iter.Current;
                }
                return returnVal;
            }
        }
        public virtual System.Int32? ExecuteScalar(int? userId)
        {
            UserId = userId;

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

        public virtual System.Int32? ExecuteScalar(int? userId, IDbConnection conn, IDbTransaction tx = null)
        {
            UserId = userId;

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
                    myParam.ParameterName = "@userId";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)UserId ?? DBNull.Value;
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

        public virtual UserWorkOrdersSelectResults Create(IDataRecord record)
        {
            var returnVal = CreatePoco(record);

            if (record[0] != null && record[0] != DBNull.Value)
                returnVal.workOrders_id = (int)record[0];

            if (record[1] != null && record[1] != DBNull.Value)
                returnVal.clientId = (int?)record[1];

            if (record[2] != null && record[2] != DBNull.Value)
                returnVal.tipoOggetto = (int)record[2];

            if (record[3] != null && record[3] != DBNull.Value)
                returnVal.modello = (string)record[3];

            if (record[4] != null && record[4] != DBNull.Value)
                returnVal.accessori = (string)record[4];

            if (record[5] != null && record[5] != DBNull.Value)
                returnVal.difetto = (string)record[5];

            if (record[6] != null && record[6] != DBNull.Value)
                returnVal.difettofisso = (int?)record[6];

            if (record[7] != null && record[7] != DBNull.Value)
                returnVal.stato = (int)record[7];

            if (record[8] != null && record[8] != DBNull.Value)
                returnVal.difficolta = (int)record[8];

            if (record[9] != null && record[9] != DBNull.Value)
                returnVal.descrizione = (string)record[9];

            if (record[10] != null && record[10] != DBNull.Value)
                returnVal.note = (string)record[10];

            if (record[11] != null && record[11] != DBNull.Value)
                returnVal.dataInizio = (DateTime)record[11];

            if (record[12] != null && record[12] != DBNull.Value)
                returnVal.dataFine = (DateTime?)record[12];

            if (record[13] != null && record[13] != DBNull.Value)
                returnVal.riferimento = (string)record[13];

            if (record[14] != null && record[14] != DBNull.Value)
                returnVal.nome = (string)record[14];

            returnVal.OnLoad();
            return returnVal;
        }
    }
    public partial class UserWorkOrdersSelectResults
    {
        protected int _workOrders_id; //(int not null)
        public int workOrders_id
        {
            get { return _workOrders_id; }
            set { _workOrders_id = value; }
        }
        protected int? _clientId; //(int null)
        public int? clientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        protected int _tipoOggetto; //(int not null)
        public int tipoOggetto
        {
            get { return _tipoOggetto; }
            set { _tipoOggetto = value; }
        }
        protected string _modello; //(varchar null)
        public string modello
        {
            get { return _modello; }
            set { _modello = value; }
        }
        protected string _accessori; //(varchar null)
        public string accessori
        {
            get { return _accessori; }
            set { _accessori = value; }
        }
        protected string _difetto; //(varchar null)
        public string difetto
        {
            get { return _difetto; }
            set { _difetto = value; }
        }
        protected int? _difettofisso; //(int null)
        public int? difettofisso
        {
            get { return _difettofisso; }
            set { _difettofisso = value; }
        }
        protected int _stato; //(int not null)
        public int stato
        {
            get { return _stato; }
            set { _stato = value; }
        }
        protected int _difficolta; //(int not null)
        public int difficolta
        {
            get { return _difficolta; }
            set { _difficolta = value; }
        }
        protected string _descrizione; //(varchar null)
        public string descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }
        protected string _note; //(varchar null)
        public string note
        {
            get { return _note; }
            set { _note = value; }
        }
        protected DateTime _dataInizio; //(datetime not null)
        public DateTime dataInizio
        {
            get { return _dataInizio; }
            set { _dataInizio = value; }
        }
        protected DateTime? _dataFine; //(datetime null)
        public DateTime? dataFine
        {
            get { return _dataFine; }
            set { _dataFine = value; }
        }
        protected string _riferimento; //(varchar null)
        public string riferimento
        {
            get { return _riferimento; }
            set { _riferimento = value; }
        }
        protected string _nome; //(varchar null)
        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
    }
}
