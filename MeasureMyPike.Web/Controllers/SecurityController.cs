using MeasureMyPike.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeasureMyPike.Controllers
{
    public class LoginUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class SecurityController : ApiController
    {
        private ISecurityService isecurityService;
        private SecurityController()
        {
            isecurityService = new SecurityService();
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]LoginUser loginUser)
        {
            var user = isecurityService.Login(loginUser.Username, loginUser.Password);
            if (user == false)
            {
                var message = string.Format("Fel lösenord eller användarnamn");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}