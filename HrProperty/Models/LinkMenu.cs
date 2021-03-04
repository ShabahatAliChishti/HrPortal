using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
      public class LinkMenu
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public int Parent_MenuId { get; set; }
        public int Sequence { get; set; }
        public string Page_Link { get; set; }
        public DateTime DateCreated { get; set; }
        public bool is_active { get; set; }
    }
}
