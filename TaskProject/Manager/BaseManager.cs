//using Entity;
//using Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;


//namespace Manager
//{
//    public class BaseManager
//    {

//        public void Delete<T>(int id) where T :class
//        {
//            Del a = new Del();
//            using (Context db = new Context())
//            {
//                var eu = db.Set<T>().FirstOrDefault(GetIdQuery(id));
//                eu.Flag = true;
//                a._CreateDate = eu.CreateDate;
//                a._DelectedId = eu.Id;
//                db.SaveChanges();

//            }

//            Log.Logging(a);
//        }

//        private Expression<Func<object, bool>> GetIdQuery(int id)
//        {
//            throw new NotImplementedException();
//        }

//        //private Expression<Func<T, bool>> GetIdQuery<T>(T record) where T : class
//        //{
//        //    if (typeof(T) == typeof(PoiModel))
//        //    {
//        //        //here is the problem
//        //    }
//        //}

//        //private Expression<Func<PoiModel, bool>> GetIdQuery(PoiModel record)
//        //{
//        //    return p => p.PoiId == record.PoiId;
//        //}
//    }
//}
