namespace BattItaliaAPI.DB.WorkOrders
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static WorkOrderLogSelect;
    public interface IWorkOrderLogSelect
    {

        List<WorkOrderLogSelectResults> Execute(string username);
        IEnumerable<WorkOrderLogSelectResults> Execute(string username, IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar(string username);
        System.Int32? ExecuteScalar(string username, IDbConnection conn, IDbTransaction tx = null);

        List<WorkOrderLogSelectResults> Execute();
        IEnumerable<WorkOrderLogSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar();
        System.Int32? ExecuteScalar(IDbConnection conn, IDbTransaction tx = null);
        WorkOrderLogSelectResults Create(IDataRecord record);

        WorkOrderLogSelectResults GetOne(string username);
        WorkOrderLogSelectResults GetOne(string username, IDbConnection conn, IDbTransaction tx = null);
        WorkOrderLogSelectResults GetOne();
        WorkOrderLogSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery(string username);
        int ExecuteNonQuery(string username, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        string Username { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class WorkOrderLogSelect : IWorkOrderLogSelect
    {// props for params
        public string Username { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(string username)
        {
            Username = username;

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
        public virtual int ExecuteNonQuery(string username, IDbConnection conn, IDbTransaction tx = null)
        {
            Username = username;

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
                    myParam.ParameterName = "@username";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Username ?? DBNull.Value;
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
DECLARE @username varchar;
endDesignTime*/
	SELECT * FROM workOrderLog
	INNER JOIN users ON users.nome = @username and users.users_id = workOrderLog.userId

";
        }
        public virtual List<WorkOrderLogSelectResults> Execute(string username)
        {
            Username = username;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                ;
                return returnVal;
            }
        }

        public virtual List<WorkOrderLogSelectResults> Execute()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                return returnVal;
            }
        }

        public virtual IEnumerable<WorkOrderLogSelectResults> Execute(string username, IDbConnection conn, IDbTransaction tx = null)
        {
            Username = username;

            var returnVal = Execute(conn);
            return returnVal;
        }
        public virtual IEnumerable<WorkOrderLogSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null)
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
                    myParam.ParameterName = "@username";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Username ?? DBNull.Value;
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
        public virtual WorkOrderLogSelectResults GetOne(string username)
        {
            Username = username;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual WorkOrderLogSelectResults GetOne()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return GetOne(conn);
            }
        }
        public virtual WorkOrderLogSelectResults GetOne(string username, IDbConnection conn, IDbTransaction tx = null)
        {
            Username = username;

            {
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual WorkOrderLogSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            {
                var all = Execute(conn, tx);
                WorkOrderLogSelectResults returnVal;
                using (IEnumerator<WorkOrderLogSelectResults> iter = all.GetEnumerator())
                {
                    iter.MoveNext();
                    returnVal = iter.Current;
                }
                return returnVal;
            }
        }
        public virtual System.Int32? ExecuteScalar(string username)
        {
            Username = username;

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

        public virtual System.Int32? ExecuteScalar(string username, IDbConnection conn, IDbTransaction tx = null)
        {
            Username = username;

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
                    myParam.ParameterName = "@username";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Username ?? DBNull.Value;
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

        public virtual WorkOrderLogSelectResults Create(IDataRecord record)
        {
            var returnVal = CreatePoco(record);

            if (record[0] != null && record[0] != DBNull.Value)
                returnVal.workOrderLog_id = (int)record[0];

            if (record[1] != null && record[1] != DBNull.Value)
                returnVal.workOrderId = (int)record[1];

            if (record[2] != null && record[2] != DBNull.Value)
                returnVal.userId = (int)record[2];

            if (record[3] != null && record[3] != DBNull.Value)
                returnVal.azione = (string)record[3];

            if (record[4] != null && record[4] != DBNull.Value)
                returnVal.statoInziale = (int)record[4];

            if (record[5] != null && record[5] != DBNull.Value)
                returnVal.statoFinale = (int)record[5];

            if (record[6] != null && record[6] != DBNull.Value)
                returnVal.dataEvento = (DateTime?)record[6];

            if (record[7] != null && record[7] != DBNull.Value)
                returnVal.users_id = (int)record[7];

            if (record[8] != null && record[8] != DBNull.Value)
                returnVal.nome = (string)record[8];

            if (record[9] != null && record[9] != DBNull.Value)
                returnVal.email = (string)record[9];

            if (record[10] != null && record[10] != DBNull.Value)
                returnVal.passwd = (string)record[10];

            if (record[11] != null && record[11] != DBNull.Value)
                returnVal.permission = (int)record[11];

            returnVal.OnLoad();
            return returnVal;
        }
    }
    public partial class WorkOrderLogSelectResults
    {
        protected int _workOrderLog_id; //(int not null)
        public int workOrderLog_id
        {
            get { return _workOrderLog_id; }
            set { _workOrderLog_id = value; }
        }
        protected int _workOrderId; //(int not null)
        public int workOrderId
        {
            get { return _workOrderId; }
            set { _workOrderId = value; }
        }
        protected int _userId; //(int not null)
        public int userId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        protected string _azione; //(varchar null)
        public string azione
        {
            get { return _azione; }
            set { _azione = value; }
        }
        protected int _statoInziale; //(int not null)
        public int statoInziale
        {
            get { return _statoInziale; }
            set { _statoInziale = value; }
        }
        protected int _statoFinale; //(int not null)
        public int statoFinale
        {
            get { return _statoFinale; }
            set { _statoFinale = value; }
        }
        protected DateTime? _dataEvento; //(datetime null)
        public DateTime? dataEvento
        {
            get { return _dataEvento; }
            set { _dataEvento = value; }
        }
        protected int _users_id; //(int not null)
        public int users_id
        {
            get { return _users_id; }
            set { _users_id = value; }
        }
        protected string _nome; //(varchar null)
        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        protected string _email; //(varchar null)
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        protected string _passwd; //(varchar null)
        public string passwd
        {
            get { return _passwd; }
            set { _passwd = value; }
        }
        protected int _permission; //(int not null)
        public int permission
        {
            get { return _permission; }
            set { _permission = value; }
        }
    }
}
