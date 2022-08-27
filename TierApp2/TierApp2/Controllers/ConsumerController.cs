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
    public class ConsumerController : ApiController
    {
        [Route("api/Consumer/Names")]
        [HttpGet]
        public List<string> GetNames()
        {
            return ConsumerService.GetNames();
        }

        [Route("api/Consumer/Get")]
        [HttpGet]
        public List<ConsumerModel> Get()
        {
            return ConsumerService.Get();
        }

        [Route("api/Consumer/Create")]
        [HttpPost]
        public void Create(ConsumerModel consumer)
        {
            ConsumerService.Add(consumer);
        }

        [Route("api/Consumer/Detele")]
        [HttpDelete]
        public void Detele(int id)
        {
            ConsumerService.Delete(id);
        }

        [Route("api/Consumer/Edit")]
        [HttpPut]
        public void Edit(ConsumerModel consumer)
        {
            ConsumerService.Edit(consumer);
        }
    }
}
