using ChattingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            string sessionUserName = HttpContext.Session.GetString("UserName");
            if (!string.IsNullOrEmpty(sessionUserName))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
