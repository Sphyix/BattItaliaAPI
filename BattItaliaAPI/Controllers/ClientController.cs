using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BattItaliaAPI.DB;
using BattItaliaAPI.DB.Client;

namespace BattItaliaAPI.Controllers
{
    [Authorize]
    public class ClientController : ApiController
    {
        private IClientInsert iClientInsert = null;
        private IClientUpdate iClientUpdate = null;
        private IClientSelect iClientSelect = null;
        // GET: api/client
        public IEnumerable<ClientSelectResults> Get()
        {
            iClientSelect = new ClientSelect();
            var f = HttpContext.Current.User;

            var res = iClientSelect.Execute();

            return res;

        }

        // GET: api/client?nome=&cognome=
        public IEnumerable<ClientSelectResults> GetByNomeCognome(string nome, string cognome, string telefono)
        {
            iClientSelect = new ClientSelect();
            if (string.IsNullOrWhiteSpace(nome))
            {
                nome = null;
            }
            if (string.IsNullOrWhiteSpace(cognome))
            {
                cognome = null;
            }

            var res = iClientSelect.Execute(null, nome, cognome, telefono);

            return res;
        }

        // GET: api/client/[id]
        public IEnumerable<ClientSelectResults> GetById(int? id)
        {
            iClientSelect = new ClientSelect();

            if(id == null)
            {
                return null;
            }

            var res = iClientSelect.Execute(id, null, null, null);

            return res;
        }

        // Post: api/client
        public bool Post([FromBody] ClientSelectResults value)
        {
            iClientInsert = new ClientInsert();

            var res = iClientInsert.ExecuteNonQuery(value.nome, value.cognome, value.telefono, value.mail, value.via, value.civico, value.ccap);

            if (res == 1)
                return true;
            else
                return false;
        }

        // Patch: api/client
        public bool Patch(ClientSelectResults input)
        {
            iClientSelect = new ClientSelect();
            iClientUpdate = new ClientUpdate();

            if (input == null || input.clients_id == 0)
            {
                return false;
            }

            var dbInput = iClientSelect.Execute(input.clients_id, null, null, null).First();
            if(dbInput == null)
            {
                return false;
            }

            ClientSelectResults updatedClient = new ClientSelectResults();

            updatedClient.nome = DbHelper.CheckValue(input.nome, dbInput.nome);
            updatedClient.cognome = DbHelper.CheckValue(input.cognome, dbInput.cognome);
            updatedClient.telefono = DbHelper.CheckValue(input.telefono, dbInput.telefono);
            updatedClient.mail = DbHelper.CheckValue(input.mail, dbInput.mail);
            updatedClient.ccap = input.ccap == null ? dbInput.ccap : input.ccap;
            updatedClient.via = DbHelper.CheckValue(input.via, dbInput.via);
            updatedClient.civico = DbHelper.CheckValue(input.civico, dbInput.civico);


            var res = iClientUpdate.ExecuteNonQuery(input.clients_id, updatedClient.nome, updatedClient.cognome, updatedClient.telefono, updatedClient.mail, updatedClient.ccap, updatedClient.via, updatedClient.civico);

            if (res == 1)
                return true;
            else
                return false;
        }


    }
}