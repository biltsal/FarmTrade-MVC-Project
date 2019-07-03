using FarmTradeFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmTradeFinal.Controllers
{
    public class LocationsController : Controller
    {
        private ApplicationDbContext context;

        public LocationsController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Product
        public ActionResult Index()
        {
            var location = context.Locations
                //.Include(l => l.Location)
                .OrderBy(l => l.City)
                .ToList();

            return View(location);
        }

        // GET
        public ActionResult New()
        {
            var viewModel = new Location();

            return View("LocationForm", viewModel);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Location location)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Location();

                return View("LocationForm", viewModel);
            }

            if (location.ID == 0) // create
                context.Locations.Add(location);
            else // edit
            {
                var locationDB = context.Locations.Single(l => l.ID == location.ID);
                locationDB.City = location.City;
                locationDB.PostalCode = location.PostalCode;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Locations");
        }

        public ActionResult Delete(int id)
        {
            var location = context.Locations.SingleOrDefault(m => m.ID == id);

            if (location == null)
                return HttpNotFound();
            else
            {
                context.Locations.Remove(location);
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Locations");
        }

        public ActionResult Edit(int id)
        {
            var location = context.Locations.SingleOrDefault(l => l.ID == id);

            if (location == null)
                return HttpNotFound();

            var viewModel = new Location()
            {
                City = location.City,
                PostalCode = location.PostalCode
            };

            return View("LocationForm", viewModel);
        }







        
    }
}