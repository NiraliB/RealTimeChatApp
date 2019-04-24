using ChattingApp.Data;
using ChattingApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingApp.ChatService
{
    public class ChattingService : IChatInterface
    {
        private ChatApplicationContext dbContext;

        public ChattingService(ChatApplicationContext newDb) {

            dbContext = newDb;
        }

        public List<UserDetails> GetChatUserList(string getSessionName)
        {
            try {
                return dbContext.UserDetails.Where(u => u.UserName != getSessionName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MessageDetails> GetUserMessagesDisp(string userClickId,string loginUserId)
        {
            try
            {
                List<MessageDetails> lstReceiverMes = new List<MessageDetails>();

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
            catch(Exception ex)
            {
                throw ex;

            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
