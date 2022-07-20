using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using BattItaliaAPI.DB.User;
using BattItaliaAPI.DB.WorkOrders;

namespace BattItaliaAPI.Controllers
{
    [Authorize]
    public class WorkOrderController : ApiController
    {
        private IWorkOrderSelect iWorkOrderSelect = null;
        private IWorkOrderInsert iWorkOrderInsert = null;
        private IWorkOrder_UserInsert iWorkOrderUserInsert = null;
        private IWorkOrderLogInsert iWorkOrderLogInsert = null;
        private IWorkOrderUpdate iWorkOrderUpdate = null;
        private IUserSelect iUserSelect = null;

        public IEnumerable<WorkOrderSelectResults> Get(int? id, int? stato, int? difficolta, string modello)
        {
            iWorkOrderSelect = new WorkOrderSelect();
            if(!string.IsNullOrWhiteSpace(modello))
            {
                modello = '%' + modello + '%';
            }

            var res = iWorkOrderSelect.Execute(id, stato, difficolta, modello);

            return res;

        }

        public IEnumerable<WorkOrderSelectResults> Get()
        {
            iWorkOrderSelect = new WorkOrderSelect();

            var res = iWorkOrderSelect.Execute();

            return res;

        }

        // Post: api/workOrder
        public bool Post([FromBody] WorkOrderSelectResults value)
        {
            iWorkOrderInsert = new WorkOrderInsert();

            var res = iWorkOrderInsert.ExecuteNonQuery(value.clientId, value.tipoOggetto, value.modello, value.accessori, value.difetto, value.difettofisso, value.stato, value.difficolta, value.descrizione, value.note, value.dataInizio, value.dataFine, value.riferimento);

            if (res == 1)
                return true;
            else
                return false;
        }

        // Post: api/workOrder/id
        public bool Post(int id)
        {
            //iWorkOrderInsert = new WorkOrderInsert();
            iWorkOrderSelect = new WorkOrderSelect();
            iWorkOrderLogInsert = new WorkOrderLogInsert();
            iWorkOrderUserInsert = new WorkOrder_UserInsert();
            iUserSelect = new UserSelect();
            iWorkOrderUpdate = new WorkOrderUpdate();

            var workOrder = iWorkOrderSelect.Execute(id, null, null, null)?.FirstOrDefault();

            if(workOrder == null)
            {
                return false;
            }

            var user = HttpContext.Current.User.Identity.Name;
            var dbUser = iUserSelect.Execute(user, null)?.FirstOrDefault();

            if(dbUser == null) //should never happen
            {
                return false;
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            SqlTransaction transaction = conn.BeginTransaction();

            var insertResult = iWorkOrderUserInsert.ExecuteNonQuery(dbUser.users_id, id, DateTime.Now, conn, transaction) == 1;
            var updateResult = iWorkOrderUpdate.ExecuteNonQuery(0, id, conn, transaction) == 1;

            if(insertResult && updateResult)
            {
                transaction.Commit();
                return true;
            }
            
            return false;
        }

    }
}