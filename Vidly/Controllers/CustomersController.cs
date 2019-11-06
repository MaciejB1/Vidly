using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>      //hard code data
            {
                new Customer() {Name = "Jan Kowalski"},
                new Customer() {Name = "Anna Pawlik"}
            };

            var CustomersViewModel = new CustomerViewModel
            {
                Customers = customers
            };
            
            return View(CustomersViewModel);
        }
    }
}