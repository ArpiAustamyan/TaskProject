using Entity;
using Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace TaskProject.Controllers
{
    [RoutePrefix("api/UsersController")]
    public class UsersController : ApiController
    {
        UserManager um = new UserManager();

        [Route("api/UserTasks")]
        [BasicAuthentication]
        public IHttpActionResult GetUserTasks()
        {
            um.GetTask(Security.AuthId);
            return Ok(um);
        }

        [ResponseType(typeof(UserModel))]
        public IHttpActionResult PostUser(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserManager um = new UserManager();
            um.Add(user);
            return CreatedAtRoute("DefaultApi", new { id = user }, user);
        }

        [Route("api/User/Edit")]
        [ResponseType(typeof(UserEditModel))]
        [BasicAuthentication]
        public IHttpActionResult PutEdit(UserEditModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            um.Edit(Security.AuthId, user);
            return Ok();
        }

        [Route("api/User/Delete")]
        [HttpPut]
        [BasicAuthentication]
        public IHttpActionResult DeleteUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           um.Delete(Security.AuthId);
           return Ok();
        }
    }
}
