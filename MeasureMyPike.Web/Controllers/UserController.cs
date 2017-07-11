﻿using System.Web.Http;
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
        
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(string username)
        {
            var user = iUserService.GetUser(username);
            if (user == null)
            {
                var message = string.Format("User with id = {0} not found", username);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
        }

        // POST: api/User
        [System.Web.Http.HttpPost]
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

        // DELETE: api/User/5
        [System.Web.Http.HttpDelete]
        public bool Delete([FromBody]NewUser userToDelete)
        {
            var deleted = iUserService.DeleteUser(userToDelete.Username);

            return deleted;
        }
    }
}
