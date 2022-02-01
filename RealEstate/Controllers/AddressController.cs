using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.DataAccess;
using RealEstate.Models;
using Newtonsoft.Json;

namespace RealEstate.Controllers
{
    public class AddressController : Controller
    {
        private Address _Address { get; set; }
        public Address Address {
            get
            {
                if (this._Address == null)
                    this._Address = new Address();
                return this._Address;
            }
        }
        public ActionResult Add()
        {
            ViewBag.countries = GetCountries();
            return View(this.Address);
        }
        public string GetCountries()
        {
            // Liste olarak döndürülen Address nesnelerini json objelerine çevirdik.
            // string tipindeki bu json objelerini js ile html içerisine yerleştireceğiz.
            string query = "SELECT * FROM AddressCountry;";
            string jsonCountries =  JsonConvert.SerializeObject(AddressCountryDAL.Methods.ListCountry(query));
            return jsonCountries;
        }
        public JsonResult GetCities(int id)
        {
            string query = $"SELECT * FROM AddressCity WHERE CountryID={id};";
            string jsonCities = JsonConvert.SerializeObject(AddressCityDAL.Methods.ListCity(query));
            Console.WriteLine(id);
            return Json(jsonCities, JsonRequestBehavior.AllowGet);
        }
        public string GetTowns(int cityid)
        {
            string query = $"SELECT * FROM AddressTown WHERE CityID={cityid};";
            string jsonTowns = JsonConvert.SerializeObject(AddressTownDAL.Methods.ListTown(query));
            return jsonTowns;
        }
        public string GetAddressByID(int addressid)
        {
            
            string jsonAddress = JsonConvert.SerializeObject(AddressDAL.Methods.GetByID(addressid));
            return jsonAddress;
        }
    }
}
