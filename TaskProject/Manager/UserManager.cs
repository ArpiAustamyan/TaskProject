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
                db.Entry(eu).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Del a = new Del();
            using (Context db = new Context())
            {
                var eu = db.Users.Where(i => i.Id == id).FirstOrDefault();
                eu.Flag = true;
                db.Entry(eu).State = EntityState.Modified;
                a._CreateDate = eu.CreateDate;
                a._DelectedId = eu.Id;
                db.SaveChanges();
               
            }
            
           Log.Logging(a);
        }

        public UserTaskList GetTask(int id)
        {
            using (Context db = new Context())
            {
                var usertask = (from u in db.Users
                                join t in db.Tasks on u.Id equals t.AssignedId
                                group t by u into gr
                                where gr.Key.Id == id
                                select new UserTaskList
                                {
                                    _Name = gr.Key.Name,
                                    _LastName = gr.Key.LastName,
                                    _Username = gr.Key.Username,
                                    _Brithday = gr.Key.Birthday,
                                    _Tasklist = gr.ToList()
                                }).FirstOrDefault();
                return usertask;
            }
        }

    }
}
