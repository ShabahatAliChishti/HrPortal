using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrPortal.Models
{
    public class RootObject
    {
        public int ID { get; set; }
        public string Depand_Name { get; set; }
        public string RelationShip { get; set; }
        public string Dob { get; set; }
        public string Medical { get; set; }
        public string Nic { get; set; }
        public int Employee_Primary_Id { get; set; }
        public string Employee_Key { get; set; }
    }
}