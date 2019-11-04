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
        public void Add(TaskModel model)
        {
            using (Context db = new Context())
            {
                Task task = new Task
                {
                    CreateId=model.CreateId,
                    AssignedId = model.AssignedId,
                    Title = model.Title,
                    CreateDate = DateTime.Now,
                    ExpirationDate = model.ExpirationDate,
                    Status = Statuses.Open,
                    Description = model.Description,
                    Flag = false
                };
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }

        public TaskInfoModel[] Get(int id)
        {
            using (Context db = new Context())
            {
                var tasks = (from t in db.Tasks
                             join u in db.Users on t.CreateId equals u.Id 
                             join f in db.Files on t.CreateId equals f.Id into Files
                             where t.CreateId == id
                             select new TaskInfoModel
                             {
                                 _Title=t.Title,
                                 _Description=t.Description,
                                 _CreateDate=t.CreateDate,
                                 _ExpireDate=t.ExpirationDate,
                                 _FirstName=u.Name,
                                 _LastName=u.LastName,
                                 _Status=t.Status,
                                 _AttCount=Files.Count()
                             }).ToArray();
                return tasks;
            }
        }

        public void Delete(int createid,int taskid)
        {
            Del a = new Del();
            using (Context db = new Context())
            {
                var eu = db.Tasks.Where(i => i.CreateId == createid).FirstOrDefault();
                eu.Flag = true;
                db.SaveChanges();
                a._CreateDate = eu.CreateDate;
                a._DelectedId = eu.AssignedId;
               
            }
            Log.Logging(a);
        }

       
    }
}
