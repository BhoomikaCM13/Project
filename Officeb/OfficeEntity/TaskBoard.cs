using OfficeEntity;
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
        public int id { get; set; }

        [Required]
        public Tasks task { get; set; }

        [Required]
        public string comment { get; set; }

        [Required]
        public List<Comment> commentsList { get; set; } 

        public int countMessage { get; set; }

        public Comment comments { get; set; }
    }
}
