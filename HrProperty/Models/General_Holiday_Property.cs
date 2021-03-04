using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
   public class General_Holiday_Property
    {
        public int ID { get; set; }
        public int holiday_month { get; set; }
        public int holiday_year { get; set; }

        public int holiday { get; set; }
        public bool is_active { get; set; }
    }
}
