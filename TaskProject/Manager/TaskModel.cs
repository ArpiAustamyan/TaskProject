using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entity.Enums;

namespace Manager
{
    public class TaskModel
    {
        //public int CreateId { get; set; }
        //public int AssignedId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Statuses Status { get; set; }
        public string Description { get; set; }
        public bool Flag { get; set; }
        public User Create { set; get; } 
        public User Assigned { set; get; }
    }
}
