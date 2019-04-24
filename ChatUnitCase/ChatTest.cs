using ChattingApp.ChatService;
using ChattingApp.Controllers;
using ChattingApp.Data;
using ChattingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChatUnitCase
{
    public class ChatTest : IClassFixture<UnitTestDb>
    {
        private ServiceProvider _serviceProvide;

        public ChatTest()
        {
            UnitTestDb testDb = new UnitTestDb();
            _serviceProvide = testDb.ServiceProvider;
        }

        [Fact]
        public void GetList()
        {
            using (var context = _serviceProvide.GetService<IChatInterface>())
            {
                string sessionUserName = "ns";
                var getAllUser = context.GetChatUserList(sessionUserName);
                Assert.IsType<List<UserDetails>>(getAllUser);
            }
        }

        [Fact]
        public void GetUserMessages()
        {
            using (var context = _serviceProvide.GetService<IChatInterface>())
            {
                string clickedUser = "3";
                string loginUserId = "1";
                var getReceivedMes = context.GetUserMessagesDisp(clickedUser, loginUserId);
                Assert.IsType<List<MessageDetails>>(getReceivedMes);
            }
        }

        [Fact]
        public void NameTest()
        {
            string name = "Nirali";
            Assert.Equal("Nirali", name);
        }

        [Fact]
        public void NameNotEquaTest()
        {
            string name = "Nirali";
            Assert.NotEqual("N", name);
        }

    }
}
