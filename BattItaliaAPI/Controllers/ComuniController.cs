using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BattItaliaAPI.DB.Comuni;

namespace BattItaliaAPI.Controllers
{
    [Authorize]
    public class ComuniController: ApiController
    {
        private IComuniSelect iComuniSelect = null;
        private IProvinceSelect iProvinceSelect = null;
        private IRegioniSelect iRegioniSelect = null;


        [HttpGet]
        [Route("api/comuni/{provincia}")]
        public IEnumerable<ComuniSelectResults> Get(string provincia)
        {
            iComuniSelect = new ComuniSelect();

            var res = iComuniSelect.Execute(provincia, null);

            return res;
        }

        //[HttpGet]
        //[Route("api/comuni/{cap}")]
        //public IEnumerable<ComuniSelectResults> GetByCap(int cap)
        //{
        //    iComuniSelect = new ComuniSelect();

        //    var res = iComuniSelect.Execute(null, cap);

        //    return res;
        //}

        [HttpGet]
        [Route("api/province/{regione_id}")]
        public IEnumerable<ProvinceSelectResults> GetProvince(int regione_id)
        {
            iProvinceSelect = new ProvinceSelect();

            var res = iProvinceSelect.Execute(regione_id);

            return res;
        }

        [HttpGet]
        [Route("api/regioni")]
        public IEnumerable<RegioniSelectResults> GetRegioni()
        {
            iRegioniSelect = new RegioniSelect();

            var res = iRegioniSelect.Execute();

            return res;
        }
    }
}