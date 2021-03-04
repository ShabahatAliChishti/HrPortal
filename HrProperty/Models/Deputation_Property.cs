using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    public class Deputation_Property
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Deputation_Location;
        public string Deputation_Location
        {
            get { return _Deputation_Location; }
            set { _Deputation_Location = value; }
        }

        private string _Longitude;
        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        private string _Latitude;
        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        private int _Inserted_By;
        public int Inserted_By
        {
            get { return _Inserted_By; }
            set { _Inserted_By = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private bool _is_Active;
        public bool is_Active
        {
            get { return _is_Active; }
            set { _is_Active = value; }
        }

        private DateTime _Date_Created;
        public DateTime Date_Created
        {
            get { return _Date_Created; }
            set { _Date_Created = value; }
        }

    }
}
