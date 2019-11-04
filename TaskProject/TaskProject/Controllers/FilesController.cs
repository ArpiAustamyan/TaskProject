using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace TaskProject.Controllers
{
    public class FilesController : ApiController
    {
        [HttpPost]
        [Route("api/UserTasks")]
        public IHttpActionResult PostCreate(File nfile, HttpPostedFileBase file)
        {
            using (Context db = new Context())
            {
                if (ModelState.IsValid)
                {
                    db.Files.Add(nfile);
                    db.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
        }
    }
}
