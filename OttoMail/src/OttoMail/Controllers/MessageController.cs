using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OttoMail.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OttoMail.Controllers
{

    public class MessageController : Controller
    {
        ////// GET: /<controller>/
        ////public IActionResult Index()
        ////{
        ////    return View();
        ////}

        public IActionResult Index()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        }

        public IActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Compose(Message newMessage)
        {
            newMessage.Send();
            return RedirectToAction("Index", "Account");
        }

        
        
    }
}
