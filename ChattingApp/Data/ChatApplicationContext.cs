using ChattingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingApp.Data
{
    public class ChatApplicationContext : DbContext
    {
        public ChatApplicationContext(DbContextOptions<ChatApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<MessageDetails> MessageDetails { get; set; }
    }
}
