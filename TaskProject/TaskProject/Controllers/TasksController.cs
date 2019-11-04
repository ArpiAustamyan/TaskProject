using Entity;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace TaskProject.Controllers
{
    public class TasksController : ApiController
    {
        TaskManager tm = new TaskManager();

        [ResponseType(typeof(Task))]
        [BasicAuthentication]
        public IHttpActionResult PostTask(TaskModel task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            task.CreateId = Security.AuthId;
            tm.Add(task);
            return CreatedAtRoute("DefaultApi", new { id = task }, task);
        }

        [Route("api/Task/Delete")]
        [HttpPut]
        [BasicAuthentication]
        public IHttpActionResult DeleteTask(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tm.Delete(id);
            return Ok();
        }
    }
}
