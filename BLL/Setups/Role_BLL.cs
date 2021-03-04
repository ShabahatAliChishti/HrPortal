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
    public class Role_BLL
    {
        Role_Property objRoleProp;
        Role_DAL objRoleDAL;

        public Role_BLL()
        {

        }

        public Role_BLL(Role_Property role)
        {
            objRoleProp = role;
        }

        public DataTable SelectAll()
        {
            objRoleDAL = new Role_DAL(objRoleProp);
            return objRoleDAL.SelectAll();
        }

    }
}
