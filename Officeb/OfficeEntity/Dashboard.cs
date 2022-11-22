using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OfficeEntity
{
     public class Dashboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
      
        public int GetTodaymsg { get; set; }
        public int GetMonthmsg { get; set; }
        public int GetYearmsg { get; set; }
        public int GetTodayTask { get; set; }
        public int GetMonthTask { get; set; }
        public int GetYearTask { get; set; }

        public int GetTodaycomment { get; set; }
        public int GetMonthcomment { get; set; }
        public int GetYearcomment { get; set; }


    }
}
