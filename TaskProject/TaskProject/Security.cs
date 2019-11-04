using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace TaskProject
{
    public static class Security
    {
        static public int AuthId;
        public static bool Login(string username, string password)
        {
            using (Context db = new Context())
            {
                var result = db.Users.Where(i => i.Username == username && i.Password == password).FirstOrDefault();
                if (result != null)
                {
                    AuthId=result.Id;
                    return true;
                }
                return false;
            }
        }
    }
}