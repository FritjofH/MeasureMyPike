using MeasureMyPike.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
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
            if (user == null)
            {
                var message = string.Format("Fel lösenord eller användarnamn");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }

            //här ska jwt fixas
            var token = TokenManager.CreateToken(user);

            var responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Headers.Add("token", token);

            return responseMessage;
        }
    }
}