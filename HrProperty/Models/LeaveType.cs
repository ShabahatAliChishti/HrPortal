using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Date_created { get; set; }
        public bool Is_Active { get; set; }
        public string status { get; set; }

    }
}
