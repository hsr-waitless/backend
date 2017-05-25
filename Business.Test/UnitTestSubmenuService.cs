using Business.Services;
using Business.Test.Factory;
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
        public void TestGetSubmenus()
        {
            var context = MockContextFactory.Create();

            var testSubmenu = new Database.Models.Submenu()
            {
                Id = 1,
                Number = 1,
                Name = "Vorspeisen",
                Description = "Vorspeisen"
            };

            context.Submenu.Add(testSubmenu);
            context.SaveChanges();
            
            var service = new SubmenuService(new MockDataService(context));
            var result = service.GetSubmenus(0);

            Assert.Equal(1, result.Count());
            
        }

        [Fact]
        public void TestGetSubmenuDetails()
        {
            var context = MockContextFactory.Create();

            var testSubmenu1 = new Database.Models.Submenu()
            {
                Id = 1,
                Number = 1,
                Name = "Vorspeisen",
                Description = "Vorspeisen"
            };

            context.Submenu.Add(testSubmenu1);
            context.SaveChanges();

            var service = new SubmenuService(new MockDataService(context));
            var result = service.GetSubmenus(0);

            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(1, result.ElementAt(0).Number);
            Assert.Equal("Vorspeisen", result.ElementAt(0).Name);
            Assert.Equal("Vorspeisen", result.ElementAt(0).Description);
            
        }

        [Fact]
        public void TestSubmenuCount()
        {
            var context = MockContextFactory.Create();

            var testSubmenu2 = new Database.Models.Submenu()
            {
                Id = 1,
                Number = 1,
                Name = "Vorspeisen",
                Description = "Vorspeisen"
            };

            var testSubmenu3 = new Database.Models.Submenu()
            {
                Id = 2,
                Number = 2,
                Name = "Hauptspeisen",
                Description = "Hauptspeisen"
            };

            var testSubmenu4 = new Database.Models.Submenu()
            {
                Id = 3,
                Number = 3,
                Name = "Desserts",
                Description = "Desserts"
            };

            context.Submenu.Add(testSubmenu2);
            context.Submenu.Add(testSubmenu3);
            context.Submenu.Add(testSubmenu4);
            context.SaveChanges();

            var service = new SubmenuService(new MockDataService(context));
            var result = service.GetSubmenus(0);

            Assert.Equal(3, result.Count());

            context.Submenu.Remove(testSubmenu2);
            context.SaveChanges();
            result = service.GetSubmenus(0);

            Assert.Equal(2, result.Count());
            
        }

        [Fact]
        public void TestSubmenuUpdate()
        {
            var context = MockContextFactory.Create();

            var testSubmenu = new Database.Models.Submenu()
            {
                Id = 1,
                Number = 1,
                Name = "Vorspeisen",
                Description = "Vorspeisen"
            };

            context.Submenu.Add(testSubmenu);
            context.SaveChanges();

            var service = new SubmenuService(new MockDataService(context));
            var result = service.GetSubmenus(0);

            Assert.Equal("Vorspeisen", result.ElementAt(0).Name);

            testSubmenu.Name = "Hauptspeisen";
            testSubmenu.Description = "Hauptspeisen";

            Assert.False(result.ElementAt(0).Name == "Vorspeisen");

        }
    }
}


