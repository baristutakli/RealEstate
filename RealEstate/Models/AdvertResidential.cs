﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstate.ModelBase;
using RealEstate.DataAccess;

namespace RealEstate.Models
{
    public class AdvertResidential : IAdvert
    {
        public int AdvertiseID { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Explaination { get; set; }

        public User User { get; set; }

        private int _UserID { get; set; }
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
        public Residential RealEstate { get; set; }
        public int _RealEstate_ID { get; set; }
        public int RealEstate_ID { get; set; }
        public double Price { get; set; }
    }
}