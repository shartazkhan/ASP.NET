using BusinessLogicLayer;
using BusinessLogicLayer.BEnt;
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

        [Route("api/Consumer/GetAll")]
        [HttpGet]
        public List<ConsumerModel> GetAll()
        {
            return ConsumerService.GetAll();
        }

        [Route("api/Consumer/Create")]
        [HttpPost]
        public void Create(ConsumerModel consumer)
        {
            ConsumerService.AddConsumer(consumer);
        }

        [Route("api/Consumer/Detele")]
        [HttpDelete]
        public void Detele(int id)
        {
            ConsumerService.DeleteConsumer(id);
        }
    }
}
