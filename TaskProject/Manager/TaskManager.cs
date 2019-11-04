using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Entity;
using Models;
using System.IO;
using File = System.IO.File;
using static Entity.Enums;

namespace Manager
{
    public class TaskManager
    {
        public void Add(Task model)
        {
            using (Context db = new Context())
            {
                model.Status = Statuses.Open;
                model.Flag = false;
                db.Tasks.Add(model);
                db.SaveChanges();
            }
        }

        public void Delete(int createid)
        {
            Del a = new Del();
            using (Context db = new Context())
            {
                var eu = db.Tasks.Where(i => i.CreateId == createid).FirstOrDefault();
                eu.Flag = true;
                db.Entry(eu).State = EntityState.Modified;
                db.SaveChanges();
                a._CreateDate = eu.CreateDate;
                a._DelectedId = eu.AssignedId;
               
            }
            Log.Logging(a);
        }

       
    }
}
