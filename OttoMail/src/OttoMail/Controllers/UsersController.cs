using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OttoMail.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OttoMail.Controllers
{
    public class UsersController : Controller
    {
        private OttoMailDbContext db = new OttoMailDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisUser = db.Users.FirstOrDefault(users => users.UserId == id);
            return View(thisUser);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisUser = db.Users.FirstOrDefault(users => users.UserId == id);
            return View(thisUser);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisUser = db.Users.FirstOrDefault(users => users.UserId == id);
            return View(thisUser);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisUser = db.Users.FirstOrDefault(users => users.UserId == id);
            db.Users.Remove(thisUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
