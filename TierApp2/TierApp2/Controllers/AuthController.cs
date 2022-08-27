using BusinessEntityLayer;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TierApp2.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(UserModel user)
        {
            var token = AuthService.Authinticate(user);
            if (token != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, token);
                return response;
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.Unauthorized,"User not found");
                return response;
            } 
            
        }
    }
}
