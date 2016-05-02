using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using OttoMail.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OttoMail.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            return View(_db.Emails.Where(x => x.User.Id == currentUser.Id));
        }
        // GET: Compose
        public IActionResult Compose()
        {
            return View();
        }
        // POST: Compose
        [HttpPost]
        public async Task<IActionResult> Compose(Email email)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            email.User = currentUser;
            _db.Emails.Add(email);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
