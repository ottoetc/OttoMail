using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OttoMail.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OttoMail.Controllers
{
    public class UsersController : Controller
    {
        private readonly OttoMailDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController (UserManager<User> userManager, SignInManager<User> signInManager, OttoMailDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_db.Users.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
            return View(thisUser);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
            return View(thisUser);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
            return View(thisUser);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
            _db.Users.Remove(thisUser);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
