using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OfficeEntity
{
    public class Tasks
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "MaxTitleLength")]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        public TaskStatus status { get; set; }


        public DateTime createdOn { get; set; }

 
        [ForeignKey("Profile")]
        public int profileId { get; set; }

        public Profile profile { get; set; }


        
    }
}
