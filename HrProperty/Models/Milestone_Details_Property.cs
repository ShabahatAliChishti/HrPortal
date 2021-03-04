using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    [Serializable()]
   public class Milestone_Details_Property
    {
        public int Project_ID { get; set; }

        public DateTime Expected_Completed_Date { get; set; }

        public string MileStoneName { get; set; }


        public DateTime Start_Date { get; set; }

        public DataTable MilestoneDetails { get; set; }

    }
}
