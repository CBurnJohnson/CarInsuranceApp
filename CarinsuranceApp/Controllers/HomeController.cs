using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarinsuranceApp.Models;

namespace CarinsuranceApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult QuoteInfo(string firstName, string lastName, string emailAddress, DateTime? dateOfBirth, int carYear, string carMake, string carModel, bool dui, int speedingTickets, bool coverageLiability)
        {
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                var quoteinfo = new QuoteInfo();
                quoteinfo.FirstName = firstName;
                quoteinfo.LastName = lastName;
                quoteinfo.EmailAddress = emailAddress;
                quoteinfo.DateOfBirth = dateOfBirth;
                quoteinfo.CarYear = carYear;
                quoteinfo.CarMake = carMake;
                quoteinfo.CarModel = carModel;
                quoteinfo.DUI = dui;
                quoteinfo.SpeedingTickets = speedingTickets;
                quoteinfo.CoverageLiability = coverageLiability;

                db.QuoteInfoes.Add(quoteinfo);
                db.SaveChanges();
            }

            return View("Index");
        }
        
    }
}