using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.DataAccess;
using RealEstate.Models;
using Newtonsoft.Json;
using RealEstate.Security;

namespace RealEstate.Controllers
{
    public class AddressController : Controller
    {
        private Address _Address { get; set; }
        public Address Address
        {
            get
            {
                if (this._Address == null)
                    this._Address = new Address();
                return this._Address;
            }
        }
        
        public ActionResult Index()
        {
            return View(AddressDAL.Methods.ListAddress("SELECT * FROM Address;"));
        }
        [CustomAuthorize(Roles ="admin")]
        public ActionResult Add()
        {
            ViewBag.countries = GetCountries();

            // Partial ile birlikte kullanırken gerekli!
            ViewBag.address = this.Address;

            return View(this.Address);
        }
        [HttpPost]
        public int Add(Address address)
        {
            object insertedID = AddressDAL.Methods.Insert(address);
            TempData["insertedID"] = insertedID;
            //return RedirectToAction("Index");
            return Convert.ToInt32(insertedID);
        }

        public ActionResult Edit(int id)
        {
            Address address = AddressDAL.Methods.GetByID(id);
            ViewBag.countries = GetCountries();
            return View(address);
        }

        [HttpPost]
        public int Edit(Address address)
        {
            bool updateCheck=AddressDAL.Methods.Update(address);
            if (updateCheck)
                return 1;
            else
                return -1;
        }

        public ActionResult Details(int id)
        {
            Address address = AddressDAL.Methods.GetByID(id);
            return View(address);
        }

        public ActionResult Delete(int id)
        {
            Address address = AddressDAL.Methods.GetByID(id);
            return View(address);
        }

        [HttpPost]
        public ActionResult Delete(Address address)
        {
            AddressDAL.Methods.Delete(address);
            return RedirectToAction("Index");
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
            return Json(jsonCities, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTowns(int id)
        {
            string query = $"SELECT * FROM AddressTown WHERE CityID={id};";
            string jsonTowns = JsonConvert.SerializeObject(AddressTownDAL.Methods.ListTown(query));
            return Json(jsonTowns, JsonRequestBehavior.AllowGet);
        }
        public string GetAddressByID(int addressid)
        {
            
            string jsonAddress = JsonConvert.SerializeObject(AddressDAL.Methods.GetByID(addressid));
            return jsonAddress;
        }
    }
}
