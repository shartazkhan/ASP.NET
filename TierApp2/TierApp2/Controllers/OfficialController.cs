using BusinessLogicLayer;
using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TierApp2.Controllers
{
    public class OfficialController : ApiController
    {
        
            [Route("api/Official/Names")]
            [HttpGet]
            public List<string> GetNames()
            {
                return OfficialService.GetNames();
            }

            [Route("api/Official/Get")]
            [HttpGet]
            public List<OfficialModel> Get()
            {
                return OfficialService.Get();
            }

            [Route("api/Official/Create")]
            [HttpPost]
            public void Create(OfficialModel Official)
            {
                OfficialService.Add(Official);
            }

            [Route("api/Official/Detele")]
            [HttpDelete]
            public void Detele(int id)
            {
                OfficialService.Delete(id);
            }

            [Route("api/Official/Edit")]
            [HttpPut]
            public void Edit(OfficialModel Official)
            {
                OfficialService.Edit(Official);
            }
        
    }
}
