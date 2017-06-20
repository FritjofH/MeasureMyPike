using System.Web.Http;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Service;
using System.Net;
using System.Net.Http;

namespace MeasureMyPike.Controllers
{
    public class newUser
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UserController : ApiController
    {
        private IUserService iUserService;
        private UserController() {
            iUserService = new UserService();
        }

        // GET: api/User/5
        [HttpGet]
        public HttpResponseMessage Get(newUser inputUser)
        {
            var user = iUserService.GetUser(inputUser.username);
            if (user == null)
            {
                var message = string.Format("User with id = {0} not found", inputUser.username);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
        }

        // POST: api/User
        [HttpPost]
        public HttpResponseMessage Post([FromBody]newUser newUser)
        {
            var user = iUserService.CreateUser(newUser.lastName, newUser.firstName, newUser.username, newUser.password);
            if (user == null)
            {
                var message = string.Format("Could not add user");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
        }

        //// PUT: api/User/5
        //[HttpPut]
        //public HttpResponseMessage Put([FromBody]newUser updatedUserInformation)
        //{
        //    var user = iUserService.updateUser(updatedUserInformation.firstName, updatedUserInformation.lastName);
        //    if (user == null)
        //    {
        //        var message = string.Format("Could not update user");
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, user);
        //    }
        //}

        // DELETE: api/User/5
        [HttpDelete]
        public bool Delete([FromBody]newUser userToDelete)
        {
            var deleted = iUserService.DeleteUser(userToDelete.username);

            return deleted;
        }
    }
}
