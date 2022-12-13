using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OfficeEntity
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "MaxContentLength")]
        public string content { get; set; }

        public DateTime createdOn { get; set; }

        [Required]
        [ForeignKey("Tasks")]
        public int taskId { get; set; }

        public Tasks task { get; set; }


        [Required]
        [ForeignKey("Profile")]
        public int profileId { get; set; }

        public Profile profile { get; set; }


    }
}
