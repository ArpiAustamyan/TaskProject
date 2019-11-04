using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CreateId { get; set; }
        public int AssignedId { get; set; }
        public string Name { get; set; }

        [ForeignKey("CreateId,AssignedId")]
        public Task Task { set; get; }
    }
}
