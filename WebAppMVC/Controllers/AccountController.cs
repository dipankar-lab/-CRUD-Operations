using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class AccountController : Controller
    {
        DatabaseContext _db;

        public AccountController(DatabaseContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            //var products = (from prd in _db.Products
            //                where prd.id>0  
            //                select prd).ToList();

            //var products = _db.Products.ToList();
            var users = _db.Users.Where(p => p.Id > 0).Select(x => new UserModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                ConfirmPassword = x.ConfirmPassword,
                Address = x.Address,
                CityId = x.CityId
            });


            return View(users);
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.CountryList = _db.Countries.ToList().Select(x => new CountryModel { CountryId = x.CountryId, Country = x.Name }).ToList();
            ViewBag.CityList = _db.Cities.ToList().Select(x => new CityModel { CityId = x.CityId, Name = x.Name });
            return View();
        }

        [HttpPost]

        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            ModelState.Remove("Id");
            User user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                Address = model.Address,
                Contact = model.Contact,
                Terms = model.Terms,
                Gender = model.Gender,
                CityId = model.CityId,
            };
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityList = _db.Cities.ToList().Select(x => new CityModel { CityId = x.CityId, Name = x.Name });
            ViewBag.CountryList = _db.Countries.ToList().Select(x => new CountryModel { CountryId = x.CountryId, Country = x.Name }).ToList();
            return View();
        }
        public IActionResult SignUp(UserModel model)
        {
            //if (string.IsNullOrEmpty(model.Name))
            //{
            //    ModelState.AddModelError("Name", "Please Enter Name");
            //}
            //if (string.IsNullOrEmpty(model.Password))
            //{
            //    ModelState.AddModelError("Password", "Please Enter Password");
            //}

            if (ModelState.IsValid)
            {
                // TO DO:
                return RedirectToAction("Message");
            }
            //ViewBag.CountryList = new List<CountryModel> { new CountryModel { CountryCode="IN",Country="India"},
            //    new CountryModel{CountryCode="US",Country="USA"} };
            return View();
        }

        [HttpGet]
        public JsonResult GetCities(int CountryId)
        {
            var Cities = _db.Cities.ToList().Where(x => x.CountryId == CountryId).ToList();

            return Json(new SelectList(Cities, "CityId", "Name"));
        }
        public IActionResult Edit(int id)
        {
            var user = _db.Users.Find(id);
            ViewBag.CityList = _db.Cities.Where(x=>x.CountryId==user.CityId).ToList().Select(x => new CityModel { CityId = x.CityId, Name = x.Name });
            ViewBag.CountryList = _db.Countries.ToList().Select(x => new CountryModel { CountryId = x.CountryId, Country = x.Name });
            var model = _db.Users.Join(_db.Cities, u => u.CityId, c => c.CityId, (user, city) => new UserModel
            {
                Id = user.Id,

                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                Address = user.Address,
                CityId = user.CityId,
                Terms = user.Terms,
                Gender = user.Gender,
                CountryId = city.CountryId,
                Contact=user.Contact

            }).FirstOrDefault(x=>x.Id==id);
            

            return View("Create", model);
        }
        [HttpPost]
        public IActionResult Edit(UserModel model)
        {
            User user = new User
            {
               Id=model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                Address = model.Address,
                Contact = model.Contact,
                Terms = model.Terms,
                Gender = model.Gender,
                CityId = model.CityId,
            };
            if (ModelState.IsValid)
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryList = _db.Countries.ToList().Select(x => new CountryModel { CountryId = x.CountryId, Country = x.Name }).ToList();

            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            var model = _db.Users.Find(id);
            if (model != null)
            {
                _db.Users.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

