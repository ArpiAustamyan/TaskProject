using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entity.Enums;

namespace Models
{
    public class TaskInfoModel
    {
        public string _Title { get; set; }
        public string _Description { get; set; }
        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        public DateTime _CreateDate { get; set; }
        public DateTime _ExpireDate { get; set; }
        public int _AttCount { get; set; }
        public Statuses _Status { get; set; }
    }
}
