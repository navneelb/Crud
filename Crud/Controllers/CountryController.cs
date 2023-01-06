using Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    public class CountryController : Controller
    {
        private readonly DataContext country;
        public CountryController(DataContext data)
        {
            country = data;
        }
        public ActionResult Index()
        {           
           var countries = country.Countries.ToList();
            return View(countries);
        }

        public ActionResult Create()
        {
            Country country = new Country();
            return View(country);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country model)
        {
            var con = new Country
            {
                CountryName = model.CountryName,
            };
            country.Countries.Add(con);
            country.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            var coun = country.Countries.FirstOrDefault(e => e.CountryId ==id);
            country.Countries.Remove(coun);
            country.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
