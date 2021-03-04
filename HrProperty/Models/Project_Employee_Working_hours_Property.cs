using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
   public class Project_Employee_Working_hours_Property
    {

        public int Id { get; set; }
        public int projectid { get; set; }
        public int employeeid { get; set; }
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
        public decimal totaltime { get; set; }
        public string status { get; set; }

        public bool IsCompleted { get; set; }

        public bool TaskCompleted { get; set; }
    }
}
