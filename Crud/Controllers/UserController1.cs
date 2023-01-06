using Crud.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    public class UserController1 : Controller
    {
        private DataContext datacontext;
      
        private readonly IWebHostEnvironment _webHost;
        public UserController1(DataContext sc , IWebHostEnvironment webHost)
        {
            datacontext = sc;
            _webHost = webHost;
        }
        public ActionResult Index()
        {


             var data = datacontext.Users.ToList();
           
            return View(data);
                       
        }

      
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = datacontext.Users.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

       
        public ActionResult Create()
        {
            
             ViewBag.StateId = GetStates();
            ViewBag.Countries = GetCountries();
            ViewBag.Cities = GetCities();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = GetProfilePhotoFileName(model);
               
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Adderss = model.Adderss,
                    CountryId= model.CountryId,
                    StateId =model.StateId,
                    CityId = model.CityId,
                    PhotoUrl = uniqueFileName
            };
                
                
                datacontext.Users.Add(user);
                datacontext.SaveChanges();
                TempData["Msg"] = "Record Added Successfully";
                return RedirectToAction(nameof(Create));
            }
            else
            {
                TempData["Msg"] = "empty field can't submit";
                return View(model);
            }
        }

       
        public ActionResult Edit(int id)
        {
            
            var edit = datacontext.Users.SingleOrDefault(e => e.Id == id);
            ViewBag.Country = GetCountry1(edit.CountryId);
            ViewBag.States = GetStates1(edit.StateId);
            ViewBag.Cities = GetCities1(edit.CityId);
            //var result = new User()
            //{
            //    FirstName = edit.FirstName,
            //    LastName = edit.LastName,
            //    Email = edit.Email,
            //    Phone = edit.Phone,
            //    Adderss = edit.Adderss
            //};
            return View(edit);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User model)
        {
           
            if (ModelState.IsValid)
            {
                if(model.ProfilePhoto != null)
                {
                    string uniqueFileName = GetProfilePhotoFileName(model);
                    model.PhotoUrl = uniqueFileName;
                }
            //    var user = new User
            //    {
            //        Id = model.Id,
            //        FirstName = model.FirstName,
            //        LastName = model.LastName,
            //        Email = model.Email,
            //        Phone = model.Phone,
            //        Adderss = model.Adderss  ,
            //        PhotoUrl = uniqueFileName
            //};
                datacontext.Users.Update(model);
                datacontext.SaveChanges();
                TempData["sucess"] = "Saved";
                return RedirectToAction(nameof(Index));

            }
            else
            {
                
                return View(model);
            }
           
        }

       
       public ActionResult Delete(int id)
       {
            var user = datacontext.Users.FirstOrDefault(e=>e.Id==id);
            datacontext.Users.Remove(user);
            datacontext.SaveChanges();
            return RedirectToAction(nameof(Index));
            
       }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
           
                var del = datacontext.Users.FirstOrDefault(e => e.Id == id);
                datacontext.Users.Remove(del);
                datacontext.SaveChanges();
                return RedirectToAction(nameof(Index));
        }
        //Geting States
        private List<SelectListItem> GetStates()
        {
            var lstCountries = new List<SelectListItem>();

            List<State> States = datacontext.States.ToList();

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

        //Getting Counties
        private List<SelectListItem> GetCountries()
        {
            var lstCountries = new List<SelectListItem>();

            List<Country> Countries = datacontext.Countries.ToList();

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

        //Getting Cities
        private List<SelectListItem> GetCities()
        {
            var lstCountries = new List<SelectListItem>();

            List<City> Cities = datacontext.Cities.ToList();

            lstCountries = Cities.Select(ct => new SelectListItem()
            {
                Value = ct.CityId.ToString(),
                Text = ct.CityName.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Cities----"
            };

            lstCountries.Insert(0, defItem);

            return lstCountries;
        }
        public JsonResult Country()
        {
            var cnt = datacontext.Countries.ToList();
            return new JsonResult(cnt);
        }
      
        public JsonResult State(int countryId)
        {
            var stateList = datacontext.States.Where(a => a.CountryId == countryId).ToList();
            return new JsonResult(stateList);
        }


        public JsonResult City(int stateId)
        {

            var cityList = datacontext.Cities.Where(a => a.StateId == stateId).ToList();
            return new JsonResult(cityList);
        }

        //Get photo
        private string GetProfilePhotoFileName(User user)
        {
            
            string uniqueFileName = null;
            if (user.ProfilePhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + user.ProfilePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    user.ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private List<SelectListItem> GetCountry1(int Id)
        {

            List<SelectListItem> Countries = datacontext.Countries
                .Where(c => c.CountryId == Id)
                .OrderBy(n => n.CountryName)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CountryId.ToString(),
                    Text = n.CountryName
                }).ToList();

            return Countries;
        }
        private List<SelectListItem> GetCities1(int Id)
        {

            List<SelectListItem> Cities = datacontext.Cities
                .Where(c => c.CityId == Id)
                .OrderBy(n => n.CityName)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CityId.ToString(),
                    Text = n.CityName
                }).ToList();

            return Cities;
        }

        private List<SelectListItem> GetStates1(int Id)
        {

            List<SelectListItem> States = datacontext.States
                .Where(c => c.StateId == Id)
                .OrderBy(n => n.StateName)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.StateId.ToString(),
                    Text = n.StateName
                }).ToList();

            return States;
        }

    }
    }
