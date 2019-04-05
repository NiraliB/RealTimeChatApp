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
    public class ChatAppController : Controller
    {
        private readonly ChatApplicationContext dbContext;

        public ChatAppController(ChatApplicationContext _context)
        {
            dbContext = _context;
        }

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

        [HttpGet]
        public List<UserDetails> GetUserList()
        {
            try
            {
                List<UserDetails> lstUser = new List<UserDetails>();
                string sessionUserName = HttpContext.Session.GetString("UserName");
                lstUser = dbContext.UserDetails.Where(u => u.UserName != sessionUserName).ToList();
                return lstUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public List<MessageDetails> GetUserMessages(string userClickId)
        {
            try
            {
                List<MessageDetails> lstReceiverMes = new List<MessageDetails>();
                List<MessageDetails> lstSenderMes = new List<MessageDetails>();
                string loginUserId = HttpContext.Session.GetString("UserId"); // Login Username

                lstReceiverMes = dbContext.MessageDetails.Where(
                   m => (m.SenderUserId == Convert.ToInt32(loginUserId) &&
                         m.ReceiverUserId == Convert.ToInt32(userClickId)) ||
                        (m.ReceiverUserId == Convert.ToInt32(loginUserId) &&
                        m.SenderUserId == Convert.ToInt32(userClickId))
                   ).ToList();

                if (lstReceiverMes.Count > 0 && lstReceiverMes != null)
                {
                    return lstReceiverMes;
                }
                else
                {
                    return new List<MessageDetails>();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}