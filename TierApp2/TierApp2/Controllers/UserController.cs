using BusinessLogicLayer;
using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TierApp2.Auth;

namespace TierApp2.Controllers
{
    public class UserController : ApiController
    {   
        [CustomAuth]
        [Route("api/User/Names")]
        [HttpGet]
        public List<string> GetNames()
        {
            return UserService.GetNames();
        }

        [CustomAuth]
        [Route("api/User/Get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            //return UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get());
        }

        [Route("api/User/Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get(id));
          
        }

        [Route("api/User/Create")]
        [HttpPost]
        public void Create(UserModel User)
        {
            UserService.Add(User);
        }

        [Route("api/User/Detele")]
        [HttpDelete]
        public void Detele(int id)
        {
            UserService.Delete(id);
        }

        [Route("api/User/Edit")]
        [HttpPut]
        public void Edit(UserModel User)
        {
            UserService.Edit(User);
        }
    }
}
