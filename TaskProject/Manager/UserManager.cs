using Entity;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace Manager
{
    public class UserManager
    {
        public void Add(UserModel model)
        {
            using (Context db = new Context())
            {
                User user = new User
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    CreateDate = DateTime.Now,
                    Username = model.Username,
                    Password = model.Password,
                    Gender = model.Gender,
                    Flag = false
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Edit(int id, UserEditModel model)
        { 
            using (Context db = new Context())
            {
                var eu = db.Users.Where(i => i.Id == id).FirstOrDefault();
                eu.Name = model._Name;
                eu.Birthday = model._Birthday.Date;
                eu.Password = model._Password;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Del a = new Del();
            using (Context db = new Context())
            {
                var eu = db.Users.Where(i => i.Id == id).FirstOrDefault();
                if (eu != null)
                {
                    eu.Flag = true;
                    a._CreateDate = eu.CreateDate;
                    a._DelectedId = eu.Id;
                    db.SaveChanges();
                }
            } 
           Log.Logging(a);
        }


        public UserTaskList GetTask(int id)
        {
            using (Context db = new Context())
            {
                var usertask = (from u in db.Users join t in db.Tasks 
                                on u.Id equals t.AssignedId into Tasks
                                //group t by u into gr
                                where u.Id == id
                                select new UserTaskList
                                {
                                    _Name = u.Name,
                                    _LastName = u.LastName,
                                    _Username = u.Username,
                                    _Brithday = u.Birthday,
                                    _Tasklist = Tasks.ToList()
                                }).FirstOrDefault();
                return usertask;
            }
        }

    }
}
