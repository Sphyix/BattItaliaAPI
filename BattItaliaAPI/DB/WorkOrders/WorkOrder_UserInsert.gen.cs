namespace BattItaliaAPI.DB.WorkOrders
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static WorkOrder_UserInsert;
    public interface IWorkOrder_UserInsert
    {

        int ExecuteNonQuery(int? userId, int? workOrderId, DateTime? dataAssegnazione);
        int ExecuteNonQuery(int? userId, int? workOrderId, DateTime? dataAssegnazione, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        int? UserId { get; set; }
        int? WorkOrderId { get; set; }
        DateTime? DataAssegnazione { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class WorkOrder_UserInsert : IWorkOrder_UserInsert
    {// props for params
        public int? UserId { get; set; }
        public int? WorkOrderId { get; set; }
        public DateTime? DataAssegnazione { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(int? userId, int? workOrderId, DateTime? dataAssegnazione)
        {
            UserId = userId;
            WorkOrderId = workOrderId;
            DataAssegnazione = dataAssegnazione;

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
        public virtual int ExecuteNonQuery(int? userId, int? workOrderId, DateTime? dataAssegnazione, IDbConnection conn, IDbTransaction tx = null)
        {
            UserId = userId;
            WorkOrderId = workOrderId;
            DataAssegnazione = dataAssegnazione;

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
                    myParam.ParameterName = "@dataAssegnazione";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "DateTime");
                    myParam.Value = (object)DataAssegnazione ?? DBNull.Value;
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
DECLARE @userId INT;
DECLARE @workOrderId INT;
DECLARE @dataAssegnazione DATETIME;
endDesignTime*/
INSERT INTO workOrder_user (
	userId,
	workOrderId,
	dataAssegnazione
)
VALUES (
	@userId,
	@workOrderId,
	@dataAssegnazione
)
";
        }
    }
}
