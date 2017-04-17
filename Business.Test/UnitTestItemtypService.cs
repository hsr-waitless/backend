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
        public void TestGetItemtypes()
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase("unittest1");
            var context = new WaitlessContext(builder.Options);

            var testItem = new Database.Models.Itemtyp()
            {
                Id = 1,
                Number = 1,
                Title = "Hamburger",
                Description = "Knuspriges Brot, belegt mit Käse, Speck und Hamburger",
                ItemPrice = 24,
                Category = Database.Models.Category.Normal,
                Image = "Bild von Hamburger",
                Priority = 2
            };

            context.Itemtyp.Add(testItem);
            context.SaveChanges();

            var service = new ItemTypeService(context);
            var result = service.GetItemTypes(0);

            Assert.Equal(1, result.Count());
            
        }

        [Fact]
        public void TestGetItemTypeDetails()
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase("unittest2");
            var context = new WaitlessContext(builder.Options);

            var testItem = new Database.Models.Itemtyp()
            {
                Id = 1,
                Number = 1,
                Title = "Hamburger",
                Description = "Knuspriges Brot, belegt mit Käse, Speck und Hamburger",
                ItemPrice = 24,
                Category = Database.Models.Category.Normal,
                Image = "Bild von Hamburger",
                Priority = 2
            };

            context.Itemtyp.Add(testItem);
            context.SaveChanges();

            var service = new ItemTypeService(context);
            var result = service.GetItemTypes(0);

            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(1, result.ElementAt(0).Number);
            Assert.Equal("Hamburger", result.ElementAt(0).Title);
            Assert.Equal("Knuspriges Brot, belegt mit Käse, Speck und Hamburger", result.ElementAt(0).Description);
            Assert.Equal(24, result.ElementAt(0).ItemPrice);
            Assert.Equal("Normal", result.ElementAt(0).Category.ToString());
            Assert.Equal("Bild von Hamburger", result.ElementAt(0).Image);
            Assert.Equal(2, result.ElementAt(0).Priority);
            
        }

        [Fact]
        public void TestItemTypeCount()
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase("unittest3");
            var context = new WaitlessContext(builder.Options);

            var testItem1 = new Database.Models.Itemtyp()
            {
                Id = 1,
                Number = 1,
                Title = "Hamburger",
                Description = "Knuspriges Brot, belegt mit Käse, Speck und Hamburger",
                ItemPrice = 24,
                Category = Database.Models.Category.Normal,
                Image = "Bild von Hamburger",
                Priority = 2
            };

            var testItem2 = new Database.Models.Itemtyp()
            {
                Id = 2,
                Number = 2,
                Title = "Toast Hawai",
                Description = "Knuspriges Toast, garniert mit Schinken und Ananas",
                ItemPrice = 10,
                Category = Database.Models.Category.Normal,
                Image = "Bild von Toast",
                Priority = 2
            };

            var testItem3 = new Database.Models.Itemtyp()
            {
                Id = 3,
                Number = 3,
                Title = "Spaghetti Pesto",
                Description = "Spaghetti al Dente mit hauseigener Pestosauce",
                ItemPrice = 20,
                Category = Database.Models.Category.Vegi,
                Image = "Bild von Spaghetti",
                Priority = 2
            };

            context.Itemtyp.Add(testItem1);
            context.Itemtyp.Add(testItem2);
            context.Itemtyp.Add(testItem3);
            context.SaveChanges();

            var service = new ItemTypeService(context);
            var result = service.GetItemTypes(0);

            Assert.Equal(3, result.Count());

            context.Itemtyp.Remove(testItem1);
            context.SaveChanges();
            result = service.GetItemTypes(0);

            Assert.Equal(2, result.Count());
            
        }

        [Fact]
        public void TestItemTypUpdate()
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase("unittest4");
            var context = new WaitlessContext(builder.Options);

            var testItem = new Database.Models.Itemtyp()
            {
                Id = 1,
                Number = 1,
                Title = "Hamburger",
                Description = "Knuspriges Brot, belegt mit Käse, Speck und Hamburger",
                ItemPrice = 24,
                Category = Database.Models.Category.Normal,
                Image = "Bild von Hamburger",
                Priority = 2
            };

            context.Itemtyp.Add(testItem);
            context.SaveChanges();

            var service = new ItemTypeService(context);
            var result = service.GetItemTypes(0);

            Assert.Equal("Hamburger", result.ElementAt(0).Title);

            testItem.Title = "Veggiburger";
            testItem.Description = "Knuspriges Brot, belegt mit Käse und Tofu";
            testItem.Image = "Bild von Veggiburger";

            Assert.False(result.ElementAt(0).Title == "Hamburger");

        }





    }
}
