using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OfficeEntity
{
  public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "MaxTtileLength")]
        public string title { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "MaxContentLength")]
        public string content { get; set; }

        public DateTime createdOn { get; set; }

        [ForeignKey("Profile")]
        public int pId { get; set; }

        public Profile Profile { get; set; }
    }
}
