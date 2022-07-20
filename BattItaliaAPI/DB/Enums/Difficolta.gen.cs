namespace BattItaliaAPI.DB.Enums
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static Difficolta;
    public interface IDifficolta
    {

        List<DifficoltaResults> Execute();
        IEnumerable<DifficoltaResults> Execute(IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar();
        System.Int32? ExecuteScalar(IDbConnection conn, IDbTransaction tx = null);
        DifficoltaResults Create(IDataRecord record);

        DifficoltaResults GetOne();
        DifficoltaResults GetOne(IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);

        string ExecutionMessages { get; }
    }

    public partial class Difficolta : IDifficolta
    {// props for params

        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }

        public virtual int ExecuteNonQuery()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return ExecuteNonQuery(conn);
            }
        }
        public virtual int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            using (IDbCommand cmd = conn.CreateCommand())
            {
                if (tx != null)
                    cmd.Transaction = tx;
                cmd.CommandText = getCommandText();

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
endDesignTime*/

SELECT * FROM workOrder_difficolta
";
        }
        public virtual List<DifficoltaResults> Execute()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                return returnVal;
            }
        }

        public virtual IEnumerable<DifficoltaResults> Execute(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            using (IDbCommand cmd = conn.CreateCommand())
            {
                if (tx != null)
                    cmd.Transaction = tx;
                cmd.CommandText = getCommandText();

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
        public virtual DifficoltaResults GetOne()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return GetOne(conn);
            }
        }
        public virtual DifficoltaResults GetOne(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            {
                var all = Execute(conn, tx);
                DifficoltaResults returnVal;
                using (IEnumerator<DifficoltaResults> iter = all.GetEnumerator())
                {
                    iter.MoveNext();
                    returnVal = iter.Current;
                }
                return returnVal;
            }
        }
        public virtual System.Int32? ExecuteScalar()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return ExecuteScalar(conn);
            }
        }

        public virtual System.Int32? ExecuteScalar(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            using (IDbCommand cmd = conn.CreateCommand())
            {
                if (tx != null)
                    cmd.Transaction = tx;
                cmd.CommandText = getCommandText();

                var result = cmd.ExecuteScalar();

                // only convert dbnull if nullable
                // Assign output parameters to instance properties. 

                if (result == null || result == DBNull.Value)
                    return null;
                else
                    return (System.Int32?)result;
            }
        }

        public virtual DifficoltaResults Create(IDataRecord record)
        {
            var returnVal = CreatePoco(record);

            if (record[0] != null && record[0] != DBNull.Value)
                returnVal.workOrder_difficolta_id = (int)record[0];

            if (record[1] != null && record[1] != DBNull.Value)
                returnVal.difficolta = (string)record[1];

            returnVal.OnLoad();
            return returnVal;
        }
    }
    public partial class DifficoltaResults
    {
        protected int _workOrder_difficolta_id; //(int not null)
        public int workOrder_difficolta_id
        {
            get { return _workOrder_difficolta_id; }
            set { _workOrder_difficolta_id = value; }
        }
        protected string _difficolta; //(varchar not null)
        public string difficolta
        {
            get { return _difficolta; }
            set { _difficolta = value; }
        }
    }
}
