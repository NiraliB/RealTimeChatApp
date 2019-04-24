using ChattingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingApp.ChatService
{
    public interface IChatInterface : IDisposable
    {
        List<UserDetails> GetChatUserList(string getSessionName);
        List<MessageDetails> GetUserMessagesDisp(string userClickId, string loginUserId);
    }
}
