using Bussiness.Services;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Backend.Test
{
    public class UnitTestSubmenuService
    {
        [Fact]
        public void TestGetSubmenues()
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase("unittest");
            var context = new WaitlessContext(builder.Options);

            context.Submenu.Add(new Database.Models.Submenu());
            context.SaveChanges();
            
            var service = new SubmenuService(context);
            var result = service.GetSubmenus(0);

            Assert.Equal(1, result.Count());

        }
    }
}


