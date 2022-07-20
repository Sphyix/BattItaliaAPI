namespace BattItaliaAPI.DB.WorkOrders
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static WorkOrderLogInsert;
    public interface IWorkOrderLogInsert
    {

        int ExecuteNonQuery(int? workOrderId, int? userId, string azione, int? statoInziale, int? statoFinale, DateTime? dataEvento);
        int ExecuteNonQuery(int? workOrderId, int? userId, string azione, int? statoInziale, int? statoFinale, DateTime? dataEvento, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        int? WorkOrderId { get; set; }
        int? UserId { get; set; }
        string Azione { get; set; }
        int? StatoInziale { get; set; }
        int? StatoFinale { get; set; }
        DateTime? DataEvento { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class WorkOrderLogInsert : IWorkOrderLogInsert
    {// props for params
        public int? WorkOrderId { get; set; }
        public int? UserId { get; set; }
        public string Azione { get; set; }
        public int? StatoInziale { get; set; }
        public int? StatoFinale { get; set; }
        public DateTime? DataEvento { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(int? workOrderId, int? userId, string azione, int? statoInziale, int? statoFinale, DateTime? dataEvento)
        {
            WorkOrderId = workOrderId;
            UserId = userId;
            Azione = azione;
            StatoInziale = statoInziale;
            StatoFinale = statoFinale;
            DataEvento = dataEvento;

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
        public virtual int ExecuteNonQuery(int? workOrderId, int? userId, string azione, int? statoInziale, int? statoFinale, DateTime? dataEvento, IDbConnection conn, IDbTransaction tx = null)
        {
            WorkOrderId = workOrderId;
            UserId = userId;
            Azione = azione;
            StatoInziale = statoInziale;
            StatoFinale = statoFinale;
            DataEvento = dataEvento;

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
                    myParam.ParameterName = "@workOrderId";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)WorkOrderId ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@userId";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)UserId ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@azione";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Azione ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@statoInziale";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)StatoInziale ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@statoFinale";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)StatoFinale ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@dataEvento";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "DateTime");
                    myParam.Value = (object)DataEvento ?? DBNull.Value;
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
DECLARE @workOrderId INT;
DECLARE @userId INT;
DECLARE @azione VARCHAR(50);
DECLARE @statoInziale INT;
DECLARE @statoFinale INT;
DECLARE @dataEvento DATETIME;
endDesignTime*/
INSERT INTO WorkOrderLog (
	workOrderId,
	userId,
	azione,
	statoInziale,
	statoFinale,
	dataEvento
)
VALUES (
	@workOrderId,
	@userId,
	@azione,
	@statoInziale,
	@statoFinale,
	@dataEvento
)
";
        }
    }
}
