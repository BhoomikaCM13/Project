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
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "MaxTtileLength")]
        public string Title { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "MaxContentLength")]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int countmessage { get; set; }

        [Required]
        [ForeignKey("Profile")]
        public int PId { get; set; }

        public Profile Profile { get; set; }
    }
}
