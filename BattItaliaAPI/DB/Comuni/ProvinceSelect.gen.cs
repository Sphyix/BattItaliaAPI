namespace BattItaliaAPI.DB.Comuni
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static ProvinceSelect;
    public interface IProvinceSelect
    {

        List<ProvinceSelectResults> Execute(int? regione);
        IEnumerable<ProvinceSelectResults> Execute(int? regione, IDbConnection conn, IDbTransaction tx = null);
        System.String ExecuteScalar(int? regione);
        System.String ExecuteScalar(int? regione, IDbConnection conn, IDbTransaction tx = null);

        List<ProvinceSelectResults> Execute();
        IEnumerable<ProvinceSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null);
        System.String ExecuteScalar();
        System.String ExecuteScalar(IDbConnection conn, IDbTransaction tx = null);
        ProvinceSelectResults Create(IDataRecord record);

        ProvinceSelectResults GetOne(int? regione);
        ProvinceSelectResults GetOne(int? regione, IDbConnection conn, IDbTransaction tx = null);
        ProvinceSelectResults GetOne();
        ProvinceSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery(int? regione);
        int ExecuteNonQuery(int? regione, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        int? Regione { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class ProvinceSelect : IProvinceSelect
    {// props for params
        public int? Regione { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(int? regione)
        {
            Regione = regione;

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
        public virtual int ExecuteNonQuery(int? regione, IDbConnection conn, IDbTransaction tx = null)
        {
            Regione = regione;

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
                    myParam.ParameterName = "@regione";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Regione ?? DBNull.Value;
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
DECLARE @regione int;

endDesignTime*/
SELECT DISTINCT provincia, sigla FROM comuni
WHERE cod_regione = @regione
order by provincia

";
        }
        public virtual List<ProvinceSelectResults> Execute(int? regione)
        {
            Regione = regione;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                ;
                return returnVal;
            }
        }

        public virtual List<ProvinceSelectResults> Execute()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                return returnVal;
            }
        }

        public virtual IEnumerable<ProvinceSelectResults> Execute(int? regione, IDbConnection conn, IDbTransaction tx = null)
        {
            Regione = regione;

            var returnVal = Execute(conn);
            return returnVal;
        }
        public virtual IEnumerable<ProvinceSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null)
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
                    myParam.ParameterName = "@regione";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Regione ?? DBNull.Value;
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
        public virtual ProvinceSelectResults GetOne(int? regione)
        {
            Regione = regione;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual ProvinceSelectResults GetOne()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return GetOne(conn);
            }
        }
        public virtual ProvinceSelectResults GetOne(int? regione, IDbConnection conn, IDbTransaction tx = null)
        {
            Regione = regione;

            {
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual ProvinceSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            {
                var all = Execute(conn, tx);
                ProvinceSelectResults returnVal;
                using (IEnumerator<ProvinceSelectResults> iter = all.GetEnumerator())
                {
                    iter.MoveNext();
                    returnVal = iter.Current;
                }
                return returnVal;
            }
        }
        public virtual System.String ExecuteScalar(int? regione)
        {
            Regione = regione;

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

        public virtual System.String ExecuteScalar(int? regione, IDbConnection conn, IDbTransaction tx = null)
        {
            Regione = regione;

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
                    myParam.ParameterName = "@regione";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Regione ?? DBNull.Value;
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

        public virtual ProvinceSelectResults Create(IDataRecord record)
        {
            var returnVal = CreatePoco(record);

            if (record[0] != null && record[0] != DBNull.Value)
                returnVal.provincia = (string)record[0];

            if (record[1] != null && record[1] != DBNull.Value)
                returnVal.sigla = (string)record[1];

            returnVal.OnLoad();
            return returnVal;
        }
    }
    public partial class ProvinceSelectResults
    {
        protected string _provincia; //(varchar not null)
        public string provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }
        protected string _sigla; //(varchar not null)
        public string sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }
    }
}
