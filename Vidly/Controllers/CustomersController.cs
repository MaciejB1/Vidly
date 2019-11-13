using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _Context;

        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        public ActionResult New()
        {
            return View();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _Context.Customers.Include(c => c.MembershipType).ToList();
            
            return View(customers);
        }

 //       [Route("Customers/Details/{id}")]
        public ActionResult Details(int? id)
        {
            var customerDetails = _Context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customerDetails == null)
                return HttpNotFound();


            return View(customerDetails);
        }
    }
}