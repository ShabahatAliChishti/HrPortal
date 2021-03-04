using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    public class Attendance_Property
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }

        public DateTime Attendance_Date { get; set; }

        //public TimeSpan Time_In { get; set; }

        //public TimeSpan Time_Out { get; set; }

        public string Time_In { get; set; }

        public string Time_Out { get; set; }

        public decimal Total_Hours { get; set; }

        public DataTable tbl_Attendance { get; set; }
    }

}
