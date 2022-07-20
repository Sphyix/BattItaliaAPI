namespace BattItaliaAPI.DB.WorkOrders
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static WorkOrderProveSelect;
    public interface IWorkOrderProveSelect
    {

        List<WorkOrderProveSelectResults> Execute(int? workOrdersId);
        IEnumerable<WorkOrderProveSelectResults> Execute(int? workOrdersId, IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar(int? workOrdersId);
        System.Int32? ExecuteScalar(int? workOrdersId, IDbConnection conn, IDbTransaction tx = null);

        List<WorkOrderProveSelectResults> Execute();
        IEnumerable<WorkOrderProveSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar();
        System.Int32? ExecuteScalar(IDbConnection conn, IDbTransaction tx = null);
        WorkOrderProveSelectResults Create(IDataRecord record);

        WorkOrderProveSelectResults GetOne(int? workOrdersId);
        WorkOrderProveSelectResults GetOne(int? workOrdersId, IDbConnection conn, IDbTransaction tx = null);
        WorkOrderProveSelectResults GetOne();
        WorkOrderProveSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery(int? workOrdersId);
        int ExecuteNonQuery(int? workOrdersId, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        int? WorkOrdersId { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class WorkOrderProveSelect : IWorkOrderProveSelect
    {// props for params
        public int? WorkOrdersId { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(int? workOrdersId)
        {
            WorkOrdersId = workOrdersId;

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
        public virtual int ExecuteNonQuery(int? workOrdersId, IDbConnection conn, IDbTransaction tx = null)
        {
            WorkOrdersId = workOrdersId;

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
                    myParam.ParameterName = "@workOrdersId";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)WorkOrdersId ?? DBNull.Value;
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
DECLARE @workOrdersId int = 1;
endDesignTime*/

	SELECT * FROM workOrder_prove
	WHERE (@workOrdersId IS NULL OR workOrdersId = @workOrdersId)
";
        }
        public virtual List<WorkOrderProveSelectResults> Execute(int? workOrdersId)
        {
            WorkOrdersId = workOrdersId;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                ;
                return returnVal;
            }
        }

        public virtual List<WorkOrderProveSelectResults> Execute()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                return returnVal;
            }
        }

        public virtual IEnumerable<WorkOrderProveSelectResults> Execute(int? workOrdersId, IDbConnection conn, IDbTransaction tx = null)
        {
            WorkOrdersId = workOrdersId;

            var returnVal = Execute(conn);
            return returnVal;
        }
        public virtual IEnumerable<WorkOrderProveSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null)
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
                    myParam.ParameterName = "@workOrdersId";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)WorkOrdersId ?? DBNull.Value;
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
        public virtual WorkOrderProveSelectResults GetOne(int? workOrdersId)
        {
            WorkOrdersId = workOrdersId;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual WorkOrderProveSelectResults GetOne()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return GetOne(conn);
            }
        }
        public virtual WorkOrderProveSelectResults GetOne(int? workOrdersId, IDbConnection conn, IDbTransaction tx = null)
        {
            WorkOrdersId = workOrdersId;

            {
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual WorkOrderProveSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            {
                var all = Execute(conn, tx);
                WorkOrderProveSelectResults returnVal;
                using (IEnumerator<WorkOrderProveSelectResults> iter = all.GetEnumerator())
                {
                    iter.MoveNext();
                    returnVal = iter.Current;
                }
                return returnVal;
            }
        }
        public virtual System.Int32? ExecuteScalar(int? workOrdersId)
        {
            WorkOrdersId = workOrdersId;

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

        public virtual System.Int32? ExecuteScalar(int? workOrdersId, IDbConnection conn, IDbTransaction tx = null)
        {
            WorkOrdersId = workOrdersId;

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
                    myParam.ParameterName = "@workOrdersId";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)WorkOrdersId ?? DBNull.Value;
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

        public virtual WorkOrderProveSelectResults Create(IDataRecord record)
        {
            var returnVal = CreatePoco(record);

            if (record[0] != null && record[0] != DBNull.Value)
                returnVal.workOrder_prove_id = (int)record[0];

            if (record[1] != null && record[1] != DBNull.Value)
                returnVal.workOrdersId = (int)record[1];

            if (record[2] != null && record[2] != DBNull.Value)
                returnVal.userId = (int)record[2];

            if (record[3] != null && record[3] != DBNull.Value)
                returnVal.nomeProva = (string)record[3];

            if (record[4] != null && record[4] != DBNull.Value)
                returnVal.esitoProva = (string)record[4];

            if (record[5] != null && record[5] != DBNull.Value)
                returnVal.dataProva = (DateTime?)record[5];

            returnVal.OnLoad();
            return returnVal;
        }
    }
    public partial class WorkOrderProveSelectResults
    {
        protected int _workOrder_prove_id; //(int not null)
        public int workOrder_prove_id
        {
            get { return _workOrder_prove_id; }
            set { _workOrder_prove_id = value; }
        }
        protected int _workOrdersId; //(int not null)
        public int workOrdersId
        {
            get { return _workOrdersId; }
            set { _workOrdersId = value; }
        }
        protected int _userId; //(int not null)
        public int userId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        protected string _nomeProva; //(varchar null)
        public string nomeProva
        {
            get { return _nomeProva; }
            set { _nomeProva = value; }
        }
        protected string _esitoProva; //(varchar null)
        public string esitoProva
        {
            get { return _esitoProva; }
            set { _esitoProva = value; }
        }
        protected DateTime? _dataProva; //(datetime null)
        public DateTime? dataProva
        {
            get { return _dataProva; }
            set { _dataProva = value; }
        }
    }
}
