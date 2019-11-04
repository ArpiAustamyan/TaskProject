using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Models
{
    public class UserTaskList
    {
        public string _Username;
        public string _Name;
        public string _LastName;
        public DateTime _Brithday;
        public List<Task> _Tasklist;
    }
}
