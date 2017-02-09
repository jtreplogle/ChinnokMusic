using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChinookMusic2.Models;
using System.Data.Entity;
using ChinookMusic2.ViewModels;

namespace ChinookMusic2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var chinookContext = new ChinookContext())
            {
                List<Customer> customers = chinookContext.Customer.Take(1000).ToList();
                return View(customers);
            }
            
        }

        public ActionResult FaithNoMore()
        {
            using (var chinookContext = new ChinookContext())
            {
                List<Album> FaithNoMore = chinookContext.Album
                    .Where(Album => Album.Title.ToLower().Contains("Angel Dust"))
                    .ToList();

                    return View(FaithNoMore);
            }
        }


        public ActionResult CanadianCustomers()
        {
            using (var chinookContext = new ChinookContext())
            {
                var canadianCustomers = chinookContext.Customer
                    .Where(cust => cust.Country.ToLower() == "canada")
                    .OrderBy(a => a.LastName)
                    .Select(cust => new CanadianCustomerViewModel
                    {
                        LastName = cust.LastName,
                        FirstName = cust.FirstName
                    }).ToList();


                return View(canadianCustomers);
            }

        }
    }
}