using Business.Services;
using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Backend.Test
{
    public class UnitTestItemtypService
    {
        [Fact]
        public void TestGetItemtyp()
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase("unittest");
            var context = new WaitlessContext(builder.Options);

            context.Itemtyp.Add(new Database.Models.Itemtyp());
            context.SaveChanges();

            var service = new ItemTypeService(context);
            var result = service.GetItemTypes(0);

            Assert.Equal(1, result.Count());
        }
    }
}
