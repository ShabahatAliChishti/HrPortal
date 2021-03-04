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
    public class Client_BLL
    {
        Client_Property objClientProp;
        Client_DAL objClientDAL;
        public Client_BLL()
        {
                
        }

        public Client_BLL(Client_Property objClient)
        {
            objClientProp = objClient;
        }

        public DataTable ViewAll()
        {
            objClientDAL = new Client_DAL();
            return objClientDAL.SelectAll();

        }

        public bool Insert()
        {
            objClientDAL = new Client_DAL(objClientProp);
            return objClientDAL.Insert();

        }

        public bool Update()
        {
            objClientDAL = new Client_DAL(objClientProp);
            return objClientDAL.Update();

        }

        public DataTable SelectOne()
        {
            objClientDAL = new Client_DAL(objClientProp);
            return objClientDAL.SelectOne();

        }

        public bool UpdateStatus()
        {
            objClientDAL = new Client_DAL(objClientProp);
            return objClientDAL.UpdateStatus();

        }
    }
}
