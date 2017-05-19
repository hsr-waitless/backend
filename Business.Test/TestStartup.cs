using Backend;
using Backend.Hubs;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Business.Test
{
    public class TestStartup
    {
        [Fact]
        public void TestCreateOrderHub()
        {
            var startup = new Startup(null);
            startup.Configuration = new ConfigurationBuilder().Build();

            var services = new ServiceCollection();
            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var orderHub = serviceProvider.GetService<OrderHub>();
            //Assert.NotNull(orderHub);
        }

    }
}
