using ChattingApp.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingApp.Hubs
{
    public class UserActions 
    {
        private ConcurrentDictionary<string, UserDetails> onlineUser { get; set; } = new ConcurrentDictionary<string, UserDetails>();

        public bool AddUpdate(string name,string connectionId)
        {
            var existUser = onlineUser.ContainsKey(name);
            var UserDetails = new UserDetails
            {
                UserName = name,
                ConnectionId = connectionId
            };
            onlineUser.AddOrUpdate(name, UserDetails, (key, value) => UserDetails);
            return existUser;
        }

        public void Remove(string name)
        {
            UserDetails objUser = new UserDetails();
            onlineUser.TryRemove(name, out objUser);
        }

        public IEnumerable<UserDetails> GetAllUserExceptThis(string name)
        {
            return onlineUser.Values.Where(i => i.UserName != name);
        }

        public UserDetails GetUserInfo(string username)
        {
            UserDetails objDetails = new UserDetails();
            
            //onlineUser.TryGetValue(username, out objDetails);
            return objDetails;
        }

    }
}
