using ChattingApp.ChatService;
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
        private readonly ChatApplicationContext _context;
        private readonly IChatInterface _Ichat;

        public ChatAppController(IChatInterface newInterface, ChatApplicationContext newDb)
        {
            _Ichat = newInterface;
            _context = newDb;
        }

        //public ChatAppController(ChatApplicationContext _context)
        //{
        //    dbContext = _context;
        //}

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
                string sessionUserName = HttpContext.Session.GetString("UserName");
                var getUserlst = _Ichat.GetChatUserList(sessionUserName);
                return getUserlst;
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
                string loginUserId = HttpContext.Session.GetString("UserId"); // Login Username
                lstReceiverMes = _Ichat.GetUserMessagesDisp(userClickId,loginUserId);
                return lstReceiverMes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}