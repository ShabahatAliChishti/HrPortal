using DAL.Setups;
using HrProperty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Setups
{
    public class MenuSetup
    {
        MenuDAL objmenudal;
        LinkMenu objmenu;
        public MenuSetup()
        {
            objmenudal = new MenuDAL();
        }
        public MenuSetup(LinkMenu menuobject)
        {
            objmenu = menuobject;
        }

        public DataTable GetMenus()
        {
            return objmenudal.SelectAll();
        }

        public DataTable GetChildMenus()
        {
            objmenudal =new MenuDAL(objmenu);
            return objmenudal.GetChildMenus();
        }

    }
}
