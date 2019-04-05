using ChattingApp.Data;
using ChattingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ChatApplicationContext dbContext;

        public AccountController(ChatApplicationContext _context)
        {
            dbContext = _context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginApp(UserDetails objUser)
        {

            if (objUser.UserName != null && objUser.Password != null)
            {
                var getUser = dbContext.UserDetails.Where(u => u.UserName == objUser.UserName && u.Password == objUser.Password).FirstOrDefault();
                if (getUser != null)
                {
                    HttpContext.Session.SetString("UserName", getUser.UserName);
                    HttpContext.Session.SetString("FullName", getUser.FullName);
                    HttpContext.Session.SetString("UserId", Convert.ToString(getUser.UserId));
                    return Json(new { status = true, message = "Login Successfully" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Username or Password" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Please enter proper value" });
            }

            //return Json("ok");

        }

        [HttpPost]
        public IActionResult LogoutApp()
        {
            HttpContext.Session.Clear();
            return Json(new { status = true,message ="You are not properly logout" });
        }
    }
}