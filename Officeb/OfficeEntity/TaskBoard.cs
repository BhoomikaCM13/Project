using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OfficeEntity
{
    public class TaskBoard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Tasks _task { get; set; }

        [Required]
        public List<Comment> comments { get; set; } 

        public int countMessage { get; set; }
    }
}
