using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OttoMail.Models;

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
    }
}
