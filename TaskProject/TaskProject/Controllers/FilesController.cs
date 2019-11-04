using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;


namespace TaskProject.Controllers
{
    [BasicAuthentication]
    public class FilesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index(int taskid )
        {
            using (Context db = new Context())
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                string path;
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    path = (@"C:\Users\santr\OneDrive\Рабочий стол\EntityFiles\") +
                        fileName;
                    

                    file.SaveAs(path);
                    db.Files.Add(new Entity.File
                    {
                        Id=Security.AuthId-1,
                        TaskId=taskid,
                        Name = path
                    });
                    db.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }

    }
}
