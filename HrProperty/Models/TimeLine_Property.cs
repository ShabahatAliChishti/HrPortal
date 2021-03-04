using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
   
    public class TimeLine_Property
    {
        public int ID { get; set; }
        public int Project_ID { get; set; }
        public string TimeLineName { get; set; }
        public string Status { get; set; }
        public bool Is_Completed { get; set; }
        public bool Is_Started { get; set; }
        public DateTime Date_Created { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Start_Date { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Expected_Completed_Date { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime Last_Updated_date { get; set; }
        public int Updated_By { get; set; }

        public List<Project_Property> Project_Item { get; set; }

       // public List<TimeLine_Property> timelinelist { get; set; }
    }
}
