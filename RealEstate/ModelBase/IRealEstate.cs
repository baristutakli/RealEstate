using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstate.Models;

namespace RealEstate.ModelBase
{

    public interface IRealEstate
    {
        int RealEstateID { get; set; }
        SellType SellType { get; set; }
        double Square { get; set; }
        Address Address { get; set; }
        User User { get; set; }
        int UserID { get; set; }
    }
}
