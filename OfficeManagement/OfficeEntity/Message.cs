using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OfficeEntity
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage="MaxTtileLength")]
        public string Title { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage="MaxContentLength")]
        public string Content { get; set; }

        [Required]
        public int PId { get; set; }

        public Profile profile { get; set; }
    }
}
