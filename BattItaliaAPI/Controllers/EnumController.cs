using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BattItaliaAPI.DB.Enums;

namespace BattItaliaAPI.Controllers
{
    [Authorize]
    public class EnumController : ApiController
    {
        private IPermissions iPermissions = null;

        [Route("api/enum/permissions")]
        public IEnumerable<PermissionsResults> GetPermissions()
        {
            iPermissions = new Permissions();

            var res = iPermissions.Execute();

            return res;

        }

        private IStato iStato = null;

        [Route("api/enum/stato")]
        public IEnumerable<StatoResults> GetStato()
        {
            iStato = new Stato();

            var res = iStato.Execute();

            return res;

        }

        private IDifficolta iDifficolta = null;

        [Route("api/enum/difficolta")]
        public IEnumerable<DifficoltaResults> GetDifficolta()
        {
            iDifficolta = new Difficolta();

            var res = iDifficolta.Execute();

            return res;

        }

        private ITipoOggetto iTipoOggetto = null;
        private ITipoOggettoInsert iTipoOggettoInsert = null;

        [Route("api/enum/tipooggetto")]
        public IEnumerable<TipoOggettoResults> GetTipoOggetto()
        {
            iTipoOggetto = new TipoOggetto();

            var res = iTipoOggetto.Execute();

            return res;

        }

        [Route("api/enum/tipooggetto")]
        public bool Post([FromBody] string nomeOggetto)
        {
            iTipoOggettoInsert = new TipoOggettoInsert();

            var res = iTipoOggettoInsert.ExecuteNonQuery(nomeOggetto);

            if (res == 1)
                return true;
            else
                return false;
        }


    }
}