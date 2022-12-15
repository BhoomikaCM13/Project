using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeEntity
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string name { get; set; }

        public string position { get; set; }

        public string department { get; set; }


        [MaxLength(50, ErrorMessage = "MaxContentLength")] 
        public string userName { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}
