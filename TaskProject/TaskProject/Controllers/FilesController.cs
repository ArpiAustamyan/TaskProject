using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace TaskProject.Controllers
{
    public class FilesController : ApiController
    {
        [System.Web.Http.HttpPost]
        public IHttpActionResult Index(HttpPostedFileBase file)
        {
            using (Context db = new Context())
            {
                string path;
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    path = Path.Combine(
                        HttpContext.Current.Server.MapPath(@"C:\Users\santr\OneDrive\Рабочий стол\EntityFiles\"),
                        fileName
                    );

                    file.SaveAs(path);
                    db.Files.Add(new Entity.File
                    {
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
