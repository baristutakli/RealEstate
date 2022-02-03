using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstate.DataAccess;

namespace RealEstate.Models
{
    public class Address
    {
        public int ID { get; set; }
        public int CountryID { get; set; }        
        public int CityID { get; set; }
        public int TownID { get; set; }
        public string Details { get; set; }

        public AddressTown Town {
            get
            {
                return GetTown();
            } 
        }

        public AddressCity City { get
            {
                return GetCity();
            } 
        }

        public AddressCountry Country {
            get
            {
                return GetCountry();
            }
        }


        private AddressTown GetTown()
        {
            return AddressTownDAL.Methods.GetByID(this.TownID);
        }
        private AddressCity GetCity()
        {
            return AddressCityDAL.Methods.GetByID(this.CityID);
        }

        private AddressCountry GetCountry()
        {
            return AddressCountryDAL.Methods.GetByID(this.CountryID);
        }



    }
}