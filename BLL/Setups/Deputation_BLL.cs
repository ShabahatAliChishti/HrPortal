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
    public class Deputation_BLL
    {
        Deputation_DAL objDeputationDAL;
        Deputation_Property objDeputationProp;

        public Deputation_BLL()
        {

        }


        public Deputation_BLL(Deputation_Property deputation)
        {
            objDeputationProp = deputation;
        }


        public DataTable SelectAll()
        {
            objDeputationDAL = new Deputation_DAL(objDeputationProp);
            return objDeputationDAL.SelectAll();
        }
        public bool Insert()
        {
            objDeputationDAL = new Deputation_DAL(objDeputationProp);
            return objDeputationDAL.Insert();
        }

        public bool Update()
        {
            objDeputationDAL = new Deputation_DAL(objDeputationProp);
            return objDeputationDAL.Update();
        }

        public bool DeleteDeputation()
        {
            objDeputationDAL = new Deputation_DAL(objDeputationProp);
            return objDeputationDAL.DeleteDeputation();
        }

        public DataTable SelectOne()
        {
            objDeputationDAL = new Deputation_DAL(objDeputationProp);
            return objDeputationDAL.SelectOne();

        }
    }
}
