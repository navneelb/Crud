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
    public class StateController : Controller
    {
        private readonly DataContext state;
        public StateController(DataContext data)
        {
            state = data;
        }
        public ActionResult Index()
        {
            var st = state.States.Include(r => r.Country.States).Include(r => r.Country).ToList();
            return View(st);
        }


        public ActionResult Create()
        {
            State st = new State();
            ViewBag.Countries = GetCountries();
            return View(st);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(State sta)
        {

            state.Add(sta);
            state.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            var coun = state.States.FirstOrDefault(e => e.StateId == id);
            state.States.Remove(coun);
            state.SaveChanges();
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
        private List<SelectListItem> GetCountries()
        {
            var lstCountries = new List<SelectListItem>();

            List<Country> Countries = state.Countries.ToList();

            lstCountries = Countries.Select(ct => new SelectListItem()
            {
                Value = ct.CountryId.ToString(),
                Text = ct.CountryName.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Country----"
            };

            lstCountries.Insert(0, defItem);

            return lstCountries;
        }
    }
}
