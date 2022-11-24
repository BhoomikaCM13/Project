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
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "MaxTitleLength")]
        public string Title { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "MaxDescriptionLength")]
        public string Description { get; set; }

        public TaskStatus Status { get; set; }


        public DateTime CreatedOn { get; set; }

 
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        public Profile profile { get; set; }


        //public ICollection<Comment> comments { get; set; }
    }
}
