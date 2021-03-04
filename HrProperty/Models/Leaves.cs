using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    public class Leaves
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Select Leave Type")]
        public int LeaveType { get; set; }
        public int TotalDays { get; set; }
        [Required(ErrorMessage = "Please Select Leave From")]
        [DataType(DataType.Date)]

        public DateTime Leave_From { get; set; }
        [Required(ErrorMessage = "Please Select Leave To")]
        [DataType(DataType.Date)]
        public DateTime Leave_To { get; set; }
        public bool Is_Approved { get; set; }
        public bool Is_Rejected { get; set; }
        public DateTime Date_Applied { get; set; }
        public int Employee_Id { get; set; }
        public string Remarks { get; set; }
    }
}
