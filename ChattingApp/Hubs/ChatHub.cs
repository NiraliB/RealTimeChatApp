using ChattingApp.Data;
using ChattingApp.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatApplicationContext dbContext;

        public ChatHub(ChatApplicationContext context)
        {
            dbContext = context;
        }

        public Task DirectMessage(string message, string targetUserName, string loginUserName)
        {
            var senderUser = dbContext.UserDetails.Where(u => u.UserName == loginUserName).FirstOrDefault();
            var receiverUser = dbContext.UserDetails.Where(u => u.UserName == targetUserName).FirstOrDefault();
            MessageDetails objMess = new MessageDetails();

            if (senderUser != null && receiverUser != null)
            {
                if (objMess.MsgId == 0)
                {
                    objMess.SenderUserId = senderUser.UserId;
                    objMess.ReceiverUserId = receiverUser.UserId;
                    objMess.SenderUserName = senderUser.UserName;
                    objMess.ReceiverUserName = receiverUser.UserName;
                    objMess.ConnectionId = Context.ConnectionId;
                    objMess.Message =  senderUser.FullName + " says " + message;

                    dbContext.Entry<MessageDetails>(objMess).State = EntityState.Added;
                    dbContext.SaveChanges();
                }
            }

            return Clients.Client(Context.ConnectionId).SendAsync("ReceiveUserMessage", message, senderUser);
        }

        public async Task SendMessagge(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

       
    }
}
