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
        public List<Customer> customers = new List<Customer>      //hard code data
        {
            new Customer() {Id = 1, Name = "Jan Kowalski"},
            new Customer() {Id = 2, Name = "Anna Pawlik"}
        };

        // GET: Customers
        public ActionResult Index()
        {
            var CustomersViewModel = new CustomerViewModel
            {
                Customers = customers
            };
            
            return View(CustomersViewModel);
        }

 //       [Route("Customers/Details/{id}")]
        public ActionResult Details(int? id)
        {
            var customerDetails = new Customer();
            customerDetails = customers.Find(x => x.Id == id);

            return View(customerDetails);
        }
    }
}