using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    public class Depandants_Property
    {
        public int ID { get; set; }

        public string Depand_Name { get; set; }
        public string RelationShip { get; set; }
        public DateTime Dob { get; set; }
        public bool Medical { get; set; }
        public string Nic { get; set; }
        public int Employee_Primary_Id { get; set; }
        public string Employee_Key { get; set; }
    }
}
