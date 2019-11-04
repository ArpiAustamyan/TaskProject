using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entity.Enums;

namespace Entity
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CreateId { get; set; }
        public int AssignedId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; } 
        public Statuses Status { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public bool Flag { get; set; }

        [ForeignKey("CreateId")]
        public User Create { set; get; }
        [ForeignKey("AssignedId")]
        public User Assigned { set; get; }
    }
}
