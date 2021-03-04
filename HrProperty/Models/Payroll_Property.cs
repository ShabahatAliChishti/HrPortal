using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    [Serializable()]
   public class Payroll_Property
    {

       // [Required]
       // [DataType(DataType.Date)]
        public DateTime fromDate { get; set; }
       // [Required]
      //  [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        public int attendance_id { get; set; }

        public int daysWorked { get; set; }


        public int year { get; set; }

        public int month { get; set; }

        public int totalDays { get; set; }

        public int businessDays { get; set; }

        public int regularHolidays { get; set; }

        public int GeneralHolidays { get; set; }

        public int[] attendanceidarray { get; set; }

        public string attendanceidstring { get; set; }
    }
}
