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
        public int id { get; set; } 
      
        public int getTodayMessage { get; set; }

        public int getMonthMessage { get; set; }

        public int getYearMessage { get; set; }

        public int getTodayTask { get; set; }

        public int getMonthTask { get; set; }

        public int getYearTask { get; set; }

        public int getTodayComment { get; set; }

        public int getMonthComment { get; set; }

        public int getYearComment { get; set; }
    }
}
