using System.Web.Http;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Service;
using System.Net;
using System.Net.Http;

namespace MeasureMyPike.Controllers
{
    public class NewUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserController : ApiController
    {
        private IUserService iUserService;
        private UserController() {
            iUserService = new UserService();
        }

        // GET: api/User/5
        [HttpGet]
        public HttpResponseMessage Get([FromUri]string newUser)
        {
            var user = iUserService.GetUser(newUser);
            if (user == null)
            {
                var message = string.Format("User with id = {0} not found", newUser);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
        }

        // POST: api/User
        [HttpPost]
        public HttpResponseMessage Post([FromBody]NewUser newUser)
        {
            var user = iUserService.CreateUser(newUser.LastName, newUser.FirstName, newUser.Username, newUser.Password);
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
        public bool Delete([FromBody]NewUser userToDelete)
        {
            var deleted = iUserService.DeleteUser(userToDelete.Username);

            return deleted;
        }
    }
}
