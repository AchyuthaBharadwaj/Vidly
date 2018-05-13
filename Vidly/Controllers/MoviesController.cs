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
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var viewModel = new MoviesViewModel();
            viewModel.Movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new MoviesViewModel();
            viewModel.Movies = _context.Movies.Include(c => c.Genre).ToList();
            var model = viewModel.Movies.FirstOrDefault(x => x.Id == id) as Movie;
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}