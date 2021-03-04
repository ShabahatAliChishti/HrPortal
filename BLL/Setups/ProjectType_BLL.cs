using BLL.Setups;
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
    public class ProjectType_BLL
    {
        ProjectType_DAL objProjTypeDAL;
        ProjectType_Property objProjTypeProp;

        public ProjectType_BLL()
        {

        }

        public ProjectType_BLL(ProjectType_Property proptype)
        {
            objProjTypeProp = proptype;
        }

        public DataTable SelectAll()
        {
            objProjTypeDAL = new ProjectType_DAL(objProjTypeProp);
            return objProjTypeDAL.SelectAll();

        }
        public DataTable SelectOne()
        {
            objProjTypeDAL = new ProjectType_DAL(objProjTypeProp);
            return objProjTypeDAL.SelectOne();

        }
        public bool Insert()
        {
            objProjTypeDAL = new ProjectType_DAL(objProjTypeProp);
            return objProjTypeDAL.Insert();
        }
    }
}
