using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OttoMail.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity;
using OttoMail.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OttoMail.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: Register
        public IActionResult Register()
        {
            return View();
        }
        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        // GET: Login
        public IActionResult Login()
        {
            return View();
        }
        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        // POST: LogOff
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult HelloAjax()
        {
            return Content("Hello from the controller!", "text/plain");
        }
        //public IActionResult Details(int id)
        //{
        //    var thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
        //    return View(thisUser);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(ApplicationUser user)
        //{
        //    _db.Users.Add(user);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Edit(int id)
        //{
        //    var thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
        //    return View(thisUser);
        //}

        //[HttpPost]
        //public IActionResult Edit(ApplicationUser user)
        //{
        //    _db.Entry(user).State = EntityState.Modified;
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Delete(int id)
        //{
        //    var thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
        //    return View(thisUser);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
        //    _db.Users.Remove(thisUser);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}
