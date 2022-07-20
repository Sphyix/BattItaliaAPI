namespace BattItaliaAPI.DB.Enums
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static TipoOggettoInsert;
    public interface ITipoOggettoInsert
    {

        int ExecuteNonQuery(string oggetto_nome);
        int ExecuteNonQuery(string oggetto_nome, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        string Oggetto_nome { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class TipoOggettoInsert : ITipoOggettoInsert
    {// props for params
        public string Oggetto_nome { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(string oggetto_nome)
        {
            Oggetto_nome = oggetto_nome;

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
        public virtual int ExecuteNonQuery(string oggetto_nome, IDbConnection conn, IDbTransaction tx = null)
        {
            Oggetto_nome = oggetto_nome;

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
                    myParam.ParameterName = "@oggetto_nome";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Oggetto_nome ?? DBNull.Value;
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
DECLARE @oggetto_nome VARCHAR(40);
endDesignTime*/
INSERT INTO tipoOggetto (
	oggetto_nome
)
VALUES (
	@oggetto_nome
)
";
        }
    }
}
