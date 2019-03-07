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
        public ActionResult QuoteInfo(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, int carYear, string carMake, string carModel, int speedingTickets, bool coverageLiability, bool dui = false)
        {
            // Calculating car inurance cost
            // Calc age
            int quote = 50;
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            // Age cost
            if (age < 25 && age >= 18)
            {
                quote = quote + 25;
            }
            else if ( age < 18)
            {
                quote = quote + 100;
            }
            else if (age > 100)
            {
                quote = quote + 25;
            }
            // Cars Year cost
            if (carYear < 2000)
            {
                quote = quote + 25;
            }
            else if (carYear > 2015)
            {
                quote = quote + 25;
            }
            // Cars Make cost
            if (carMake == "Porsche")
            {
                quote = quote + 25;
            }
            else if (carMake == "Porsche" && carModel == "911 Carrera")
            {
                quote = quote + 25;
            }
            // Speeding tickets cost
            for (int i = 0; i < speedingTickets; i++)
            {
                quote = quote + 10;
            }
            // DUI cost
            if (dui == true)
            {
                double duiCost = quote * .25;
                int intDuiCost = Convert.ToInt32(duiCost);
                quote = quote + intDuiCost;
            }
            // Full coverage cost
            if (coverageLiability == true)
            {
                double coverageCost = quote * .50;
                int intCoverageCost = Convert.ToInt32(coverageCost);
                quote = quote + intCoverageCost;
            }

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
                quoteinfo.Quote = quote;

                db.QuoteInfoes.Add(quoteinfo);
                db.SaveChanges();

                return View("Quote", quoteinfo);
            }
            
            
        }

       
    }
}