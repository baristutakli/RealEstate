using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstate.ModelBase;
using RealEstate.DataAccess;

namespace RealEstate.Models
{
    public enum HeatingType
    { 
        NaturalGas,
        AirCondition,
        Stove, 
        CentralHeating
    }
    public enum ResidentialType
    { 
        Flat,
        Residence,
        Villa,
        FarmHouse
    }
    public class Residential : IRealEstate
    {
        public int RealEstateID { get; set; }
        public SellType SellType { get; set; }
        public double Square { get; set; }
        public Address Address { get; set; }
        public short Age { get; set; }
        public byte FloorNumber { get; set; }
        public HeatingType Heating { get; set; }
        public bool Balcony { get; set; }
        public bool Furnished { get; set; }
        public ResidentialType ResidentialType { get; set; }
        public User User { get; set; }
        private int _UserID {get;set;}
        public int UserID {
            get
            {
                return this._UserID;
            }
            set
            {
                this._UserID = value;
                this.User = UserDAL.Methods.GetByID(value);
            }
        }
    }
}