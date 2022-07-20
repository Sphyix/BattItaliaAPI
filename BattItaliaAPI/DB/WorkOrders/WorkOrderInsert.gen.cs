namespace BattItaliaAPI.DB.WorkOrders
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using static WorkOrderInsert;
    public interface IWorkOrderInsert
    {

        int ExecuteNonQuery(int? clientId, int? tipoOggetto, string modello, string accessori, string difetto, int? difettofisso, int? stato, int? difficolta, string descrizione, string note, DateTime? dataInizio, DateTime? dataFine, string riferimento);
        int ExecuteNonQuery(int? clientId, int? tipoOggetto, string modello, string accessori, string difetto, int? difettofisso, int? stato, int? difficolta, string descrizione, string note, DateTime? dataInizio, DateTime? dataFine, string riferimento, IDbConnection conn, IDbTransaction tx = null);
        int ExecuteNonQuery();
        int ExecuteNonQuery(IDbConnection conn, IDbTransaction tx = null);
        int? ClientId { get; set; }
        int? TipoOggetto { get; set; }
        string Modello { get; set; }
        string Accessori { get; set; }
        string Difetto { get; set; }
        int? Difettofisso { get; set; }
        int? Stato { get; set; }
        int? Difficolta { get; set; }
        string Descrizione { get; set; }
        string Note { get; set; }
        DateTime? DataInizio { get; set; }
        DateTime? DataFine { get; set; }
        string Riferimento { get; set; }

        string ExecutionMessages { get; }
    }

    public partial class WorkOrderInsert : IWorkOrderInsert
    {// props for params
        public int? ClientId { get; set; }
        public int? TipoOggetto { get; set; }
        public string Modello { get; set; }
        public string Accessori { get; set; }
        public string Difetto { get; set; }
        public int? Difettofisso { get; set; }
        public int? Stato { get; set; }
        public int? Difficolta { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        public string Riferimento { get; set; }
        void AppendExececutionMessage(string msg) { ExecutionMessages += msg + Environment.NewLine; }
        public string ExecutionMessages { get; protected set; }
        public virtual int ExecuteNonQuery(int? clientId, int? tipoOggetto, string modello, string accessori, string difetto, int? difettofisso, int? stato, int? difficolta, string descrizione, string note, DateTime? dataInizio, DateTime? dataFine, string riferimento)
        {
            ClientId = clientId;
            TipoOggetto = tipoOggetto;
            Modello = modello;
            Accessori = accessori;
            Difetto = difetto;
            Difettofisso = difettofisso;
            Stato = stato;
            Difficolta = difficolta;
            Descrizione = descrizione;
            Note = note;
            DataInizio = dataInizio;
            DataFine = dataFine;
            Riferimento = riferimento;

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
        public virtual int ExecuteNonQuery(int? clientId, int? tipoOggetto, string modello, string accessori, string difetto, int? difettofisso, int? stato, int? difficolta, string descrizione, string note, DateTime? dataInizio, DateTime? dataFine, string riferimento, IDbConnection conn, IDbTransaction tx = null)
        {
            ClientId = clientId;
            TipoOggetto = tipoOggetto;
            Modello = modello;
            Accessori = accessori;
            Difetto = difetto;
            Difettofisso = difettofisso;
            Stato = stato;
            Difficolta = difficolta;
            Descrizione = descrizione;
            Note = note;
            DataInizio = dataInizio;
            DataFine = dataFine;
            Riferimento = riferimento;

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
                    myParam.ParameterName = "@clientId";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)ClientId ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@tipoOggetto";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)TipoOggetto ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@modello";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Modello ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@accessori";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Accessori ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@difetto";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Difetto ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@difettofisso";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Difettofisso ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@stato";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Stato ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@difficolta";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "Int32");
                    myParam.Value = (object)Difficolta ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@descrizione";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Descrizione ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@note";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Note ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@dataInizio";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "DateTime");
                    myParam.Value = (object)DataInizio ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@dataFine";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "DateTime");
                    myParam.Value = (object)DataFine ?? DBNull.Value;
                    cmd.Parameters.Add(myParam);
                }
                {
                    var myParam = cmd.CreateParameter();
                    myParam.Direction = ParameterDirection.Input;
                    myParam.ParameterName = "@riferimento";
                    myParam.DbType = (DbType)Enum.Parse(typeof(DbType), "AnsiString");
                    myParam.Value = (object)Riferimento ?? DBNull.Value;
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
DECLARE @clientId INT;
DECLARE @tipoOggetto INT;
DECLARE @modello VARCHAR(50);
DECLARE @accessori VARCHAR(300);
DECLARE @difetto VARCHAR(300);
DECLARE @difettofisso INT;
DECLARE @stato INT;
DECLARE @difficolta INT;
DECLARE @descrizione VARCHAR(400);
DECLARE @note VARCHAR(400);
DECLARE @dataInizio DATETIME;
DECLARE @dataFine DATETIME;
DECLARE @riferimento VARCHAR(30);
endDesignTime*/
INSERT INTO workOrders (
	clientId,
	tipoOggetto,
	modello,
	accessori,
	difetto,
	difettofisso,
	stato,
	difficolta,
	descrizione,
	note,
	dataInizio,
	dataFine,
	riferimento
)
VALUES (
	@clientId,
	@tipoOggetto,
	@modello,
	@accessori,
	@difetto,
	@difettofisso,
	@stato,
	@difficolta,
	@descrizione,
	@note,
	@dataInizio,
	@dataFine,
	@riferimento
)
";
        }
    }
}
