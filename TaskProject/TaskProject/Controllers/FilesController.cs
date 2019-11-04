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
    public class FilesController : ApiController
    {
        [System.Web.Http.HttpPost]
        public IHttpActionResult Index(int id1 )
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
                        CreateId=Security.AuthId-1,
                        AssignedId=id1 ,
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
