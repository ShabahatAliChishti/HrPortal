using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    [Serializable()]
    public class Designation_Property
    {
        #region Class Member Declarations

        private int? _designation_id;
        private int? _user_id;

        private string _designation, _status;
        private DateTime _date_created;
        private bool _is_active;
        

        #endregion

        #region Class Property Declarations

        public int? Designation_Id
        {
            get { return _designation_id; }
            set { _designation_id = value; }

        }
        public int? UserId
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        

        

        [Required(ErrorMessage = "Designation Name is Required")]
        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

       
        public DateTime CreatedDate
        {
            get { return _date_created; }
            set { _date_created = value; }
        }
        public bool ISActive
        {
            get { return _is_active; }
            set { _is_active = value; }
        }


      
        #endregion
    }
}
