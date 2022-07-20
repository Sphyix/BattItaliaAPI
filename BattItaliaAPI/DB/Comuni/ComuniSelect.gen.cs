namespace BattItaliaAPI.DB.Comuni
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static ComuniSelect;
    public interface IComuniSelect
    {

        List<ComuniSelectResults> Execute(string provincia, int? cap);
        IEnumerable<ComuniSelectResults> Execute(string provincia, int? cap, IDbConnection conn, IDbTransaction tx = null);
        System.String ExecuteScalar(string provincia, int? cap);
        System.String ExecuteScalar(string provincia, int? cap, IDbConnection conn, IDbTransaction tx = null);

        List<ComuniSelectResults> Execute();
        IEnumerable<ComuniSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null);
        System.String ExecuteScalar();
        System.String ExecuteScalar(IDbConnection conn, IDbTransaction tx = null);
        ComuniSelectResults Create(IDataRecord record);

        ComuniSelectResults GetOne(string provincia, int? cap);
        ComuniSelectResults GetOne(string provincia, int? cap, IDbConnection conn, IDbTransaction tx = null);
        ComuniSelectResults GetOne();
        ComuniSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery(string provincia, int? cap);
        int ExecuteNonQuery(string provincia, int? cap, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        string Provincia { get; set; }
        int? Cap { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class ComuniSelect : IComuniSelect
    {// props for params
        public string Provincia { get; set; }
        public int? Cap { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(string provincia, int? cap)
        {
            Provincia = provincia;
            Cap = cap;

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
        public virtual int ExecuteNonQuery(string provincia, int? cap, IDbConnection conn, IDbTransaction tx = null)
        {
            Provincia = provincia;
            Cap = cap;

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
                    myParam.ParameterName = "@provincia";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Provincia ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@cap";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Cap ?? DBNull.Value;
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
DECLARE @provincia varchar(28);
declare @cap int = 58022;

endDesignTime*/
SELECT comune, caps.cap, provincia, regione, sigla from comuni
inner join caps on comuni.comune_id = caps.cap_id and (@cap IS NULL OR caps.cap = @cap)
WHERE (@provincia IS NULL OR sigla = @provincia)
order by comune


";
        }
        public virtual List<ComuniSelectResults> Execute(string provincia, int? cap)
        {
            Provincia = provincia;
            Cap = cap;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                ;
                return returnVal;
            }
        }

        public virtual List<ComuniSelectResults> Execute()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                return returnVal;
            }
        }

        public virtual IEnumerable<ComuniSelectResults> Execute(string provincia, int? cap, IDbConnection conn, IDbTransaction tx = null)
        {
            Provincia = provincia;
            Cap = cap;

            var returnVal = Execute(conn);
            return returnVal;
        }
        public virtual IEnumerable<ComuniSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null)
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
                    myParam.ParameterName = "@provincia";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Provincia ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@cap";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Cap ?? DBNull.Value;
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
        public virtual ComuniSelectResults GetOne(string provincia, int? cap)
        {
            Provincia = provincia;
            Cap = cap;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual ComuniSelectResults GetOne()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return GetOne(conn);
            }
        }
        public virtual ComuniSelectResults GetOne(string provincia, int? cap, IDbConnection conn, IDbTransaction tx = null)
        {
            Provincia = provincia;
            Cap = cap;

            {
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual ComuniSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            {
                var all = Execute(conn, tx);
                ComuniSelectResults returnVal;
                using (IEnumerator<ComuniSelectResults> iter = all.GetEnumerator())
                {
                    iter.MoveNext();
                    returnVal = iter.Current;
                }
                return returnVal;
            }
        }
        public virtual System.String ExecuteScalar(string provincia, int? cap)
        {
            Provincia = provincia;
            Cap = cap;

            var returnVal = ExecuteScalar();
            ;
            return returnVal;
        }

        public virtual System.String ExecuteScalar()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return ExecuteScalar(conn);
            }
        }

        public virtual System.String ExecuteScalar(string provincia, int? cap, IDbConnection conn, IDbTransaction tx = null)
        {
            Provincia = provincia;
            Cap = cap;

            var returnVal = ExecuteScalar(conn, tx);
            ;
            return returnVal;
        }
        public virtual System.String ExecuteScalar(IDbConnection conn, IDbTransaction tx = null)
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
                    myParam.ParameterName = "@provincia";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Provincia ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@cap";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Cap ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                var result = cmd.ExecuteScalar();

                // only convert dbnull if nullable
                // Assign output parameters to instance properties. 

                if (result == null || result == DBNull.Value)
                    return null;
                else
                    return (System.String)result;
            }
        }

        public virtual ComuniSelectResults Create(IDataRecord record)
        {
            var returnVal = CreatePoco(record);

            if (record[0] != null && record[0] != DBNull.Value)
                returnVal.comune = (string)record[0];

            if (record[1] != null && record[1] != DBNull.Value)
                returnVal.cap = (int?)record[1];

            if (record[2] != null && record[2] != DBNull.Value)
                returnVal.provincia = (string)record[2];

            if (record[3] != null && record[3] != DBNull.Value)
                returnVal.regione = (string)record[3];

            if (record[4] != null && record[4] != DBNull.Value)
                returnVal.sigla = (string)record[4];

            returnVal.OnLoad();
            return returnVal;
        }
    }
    public partial class ComuniSelectResults
    {
        protected string _comune; //(varchar not null)
        public string comune
        {
            get { return _comune; }
            set { _comune = value; }
        }
        protected int? _cap; //(int null)
        public int? cap
        {
            get { return _cap; }
            set { _cap = value; }
        }
        protected string _provincia; //(varchar not null)
        public string provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }
        protected string _regione; //(varchar not null)
        public string regione
        {
            get { return _regione; }
            set { _regione = value; }
        }
        protected string _sigla; //(varchar not null)
        public string sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }
    }
}
