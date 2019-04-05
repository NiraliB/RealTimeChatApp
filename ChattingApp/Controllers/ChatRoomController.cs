using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChattingApp.Controllers
{
    public class ChatRoomController : Controller
    {
        public IActionResult SignalRChat()
        {
            return View();
        }
    }
}