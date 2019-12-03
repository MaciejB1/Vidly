using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
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
            var membershipTypes = _Context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            customer.MembershipType = new MembershipType();
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _Context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            else
            {
                if (customer.Id == 0)
                    _Context.Customers.Add(customer);
                else
                {
                    var customerInDb = _Context.Customers.Single(c => c.Id == customer.Id);
                    customerInDb.Name = customer.Name;
                    customerInDb.Birthday = customer.Birthday;
                    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                }

                _Context.SaveChanges();

                return RedirectToAction("Index", "Customers");
            }
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

        public ActionResult Edit(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _Context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}