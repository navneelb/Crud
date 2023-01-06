using Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    public class CityController : Controller
    {
        private readonly DataContext city;
        public CityController(DataContext data)
        {
            city = data;
        }
        // GET: CityController
        public ActionResult Index()
        {
            var ct = city.Cities.Include(r => r.State.Cities).Include(r => r.State).ToList();
            return View(ct);
        }


        // GET: CityController/Create
        public ActionResult Create()
        {
            City st = new City();
            ViewBag.StateId = GetStates();
            return View(st);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City cti)
        {
            city.Add(cti);
            city.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            var coun = city.Cities.FirstOrDefault(e => e.CityId == id);
            city.Cities.Remove(coun);
            city.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: CityController/Delete/5
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

        private List<SelectListItem> GetStates()
        {
            var lstCountries = new List<SelectListItem>();

            List<State> States = city.States.ToList();

            lstCountries = States.Select(ct => new SelectListItem()
            {
                Value = ct.StateId.ToString(),
                Text = ct.StateName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select State----"
            };

            lstCountries.Insert(0, defItem);

            return lstCountries;
        }
    }
}
