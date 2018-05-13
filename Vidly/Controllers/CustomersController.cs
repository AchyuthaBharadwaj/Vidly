using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomersViewModel();
            viewModel.Customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new CustomersViewModel();
            viewModel.Customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var model = viewModel.Customers.FirstOrDefault(x => x.Id == id) as Customer;
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}