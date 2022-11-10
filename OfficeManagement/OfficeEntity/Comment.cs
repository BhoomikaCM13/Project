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
        public int Id { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage="MaxContentLength")]
        public string Content { get; set; }

        public DateTime CreatedOn = DateTime.Now;

        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        [Required]
        [ForeignKey("Profile")]
        public int PId{ get; set; }

        public Profile Profile { get; set; }

        

    }
}
