namespace BattItaliaAPI.DB.User
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static UserSelect;
    public interface IUserSelect
    {

        List<UserSelectResults> Execute(string username, int? id);
        IEnumerable<UserSelectResults> Execute(string username, int? id, IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar(string username, int? id);
        System.Int32? ExecuteScalar(string username, int? id, IDbConnection conn, IDbTransaction tx = null);

        List<UserSelectResults> Execute();
        IEnumerable<UserSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null);
        System.Int32? ExecuteScalar();
        System.Int32? ExecuteScalar(IDbConnection conn, IDbTransaction tx = null);
        UserSelectResults Create(IDataRecord record);

        UserSelectResults GetOne(string username, int? id);
        UserSelectResults GetOne(string username, int? id, IDbConnection conn, IDbTransaction tx = null);
        UserSelectResults GetOne();
        UserSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery(string username, int? id);
        int ExecuteNonQuery(string username, int? id, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        string Username { get; set; }
        int? Id { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class UserSelect : IUserSelect
    {// props for params
        public string Username { get; set; }
        public int? Id { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(string username, int? id)
        {
            Username = username;
            Id = id;

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
        public virtual int ExecuteNonQuery(string username, int? id, IDbConnection conn, IDbTransaction tx = null)
        {
            Username = username;
            Id = id;

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
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@id";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Id ?? DBNull.Value;
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
DECLARE @id int;
endDesignTime*/

SELECT * FROM users
WHERE (@id IS NULL OR users_id = @id)
AND (@username IS NULL OR nome = @username)


";
        }
        public virtual List<UserSelectResults> Execute(string username, int? id)
        {
            Username = username;
            Id = id;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                ;
                return returnVal;
            }
        }

        public virtual List<UserSelectResults> Execute()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = Execute(conn).ToList();
                return returnVal;
            }
        }

        public virtual IEnumerable<UserSelectResults> Execute(string username, int? id, IDbConnection conn, IDbTransaction tx = null)
        {
            Username = username;
            Id = id;

            var returnVal = Execute(conn);
            return returnVal;
        }
        public virtual IEnumerable<UserSelectResults> Execute(IDbConnection conn, IDbTransaction tx = null)
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
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@id";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Id ?? DBNull.Value;
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
        public virtual UserSelectResults GetOne(string username, int? id)
        {
            Username = username;
            Id = id;

            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual UserSelectResults GetOne()
        {
            using (IDbConnection conn = QfRuntimeConnection.GetConnection())
            {
                conn.Open();
                return GetOne(conn);
            }
        }
        public virtual UserSelectResults GetOne(string username, int? id, IDbConnection conn, IDbTransaction tx = null)
        {
            Username = username;
            Id = id;

            {
                var returnVal = GetOne(conn);
                return returnVal;
            }
        }
        public virtual UserSelectResults GetOne(IDbConnection conn, IDbTransaction tx = null)
        {
            ((SqlConnection)conn).InfoMessage += new SqlInfoMessageEventHandler(delegate (object sender, SqlInfoMessageEventArgs e) { AppendExececutionMessage(e.Message); });
            {
                var all = Execute(conn, tx);
                UserSelectResults returnVal;
                using (IEnumerator<UserSelectResults> iter = all.GetEnumerator())
                {
                    iter.MoveNext();
                    returnVal = iter.Current;
                }
                return returnVal;
            }
        }
        public virtual System.Int32? ExecuteScalar(string username, int? id)
        {
            Username = username;
            Id = id;

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

        public virtual System.Int32? ExecuteScalar(string username, int? id, IDbConnection conn, IDbTransaction tx = null)
        {
            Username = username;
            Id = id;

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
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@id";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Id ?? DBNull.Value;
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

        public virtual UserSelectResults Create(IDataRecord record)
        {
            var returnVal = CreatePoco(record);

            if (record[0] != null && record[0] != DBNull.Value)
                returnVal.users_id = (int)record[0];

            if (record[1] != null && record[1] != DBNull.Value)
                returnVal.nome = (string)record[1];

            if (record[2] != null && record[2] != DBNull.Value)
                returnVal.email = (string)record[2];

            if (record[3] != null && record[3] != DBNull.Value)
                returnVal.passwd = (string)record[3];

            if (record[4] != null && record[4] != DBNull.Value)
                returnVal.permission = (int)record[4];

            returnVal.OnLoad();
            return returnVal;
        }
    }
    public partial class UserSelectResults
    {
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
