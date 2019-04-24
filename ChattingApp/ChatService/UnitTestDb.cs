using ChattingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingApp.ChatService
{
    public class UnitTestDb
    {
        public ServiceProvider ServiceProvider { get; set; }

        public UnitTestDb()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ChatApplicationContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ChatApplicationContext-b2d9bc93-1fba-4b70-af31-28dd8000b050;Trusted_Connection=True;MultipleActiveResultSets=true"),
                ServiceLifetime.Transient);

            //serviceCollection.AddScoped<ChattingService>();
            serviceCollection.AddSingleton<IChatInterface, ChattingService>();
            ServiceProvider = serviceCollection. BuildServiceProvider();
        }

    }
}
