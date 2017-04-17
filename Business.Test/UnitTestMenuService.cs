using Business.Services;		
using Database;		
using Microsoft.EntityFrameworkCore;		
using System;		
using System.Linq;		
using Xunit;		
 		
 namespace Backend.Test		
 {		
     public class UnitTestMenuService		
     {		
         [Fact]		
         public void TestGetMenus()		
         {		
             var builder = new DbContextOptionsBuilder<WaitlessContext>();		
             builder.UseInMemoryDatabase("unittest1");		
             var context = new WaitlessContext(builder.Options);

            var testMenu = new Database.Models.Menu()
            {
                Id = 1,
                Number = 1,
                Name = "Sommermenü",
                Description = "Feine Sommerspeisen",
            };
 		
             context.Menu.Add(testMenu);		
             context.SaveChanges();		
 		
             var service = new MenuService(context);		
             var result = service.GetMenus();		
             Assert.Equal(1, result.Count());
            
         }

        [Fact]
        public void TestGetMenuDetails()
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase("unittest2");
            var context = new WaitlessContext(builder.Options);

            var testMenu = new Database.Models.Menu()
            {
                Id = 1,
                Number = 1,
                Name = "Sommermenü",
                Description = "Feine Sommerspeisen",
            };

            context.Menu.Add(testMenu);
            context.SaveChanges();

            var service = new MenuService(context);
            var result = service.GetMenus();
            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(1, result.ElementAt(0).Number);
            Assert.Equal("Sommermenü", result.ElementAt(0).Name);
            Assert.Equal("Feine Sommerspeisen", result.ElementAt(0).Description);
            
        }

        [Fact]
        public void TestMenuCount()
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase("unittest3");
            var context = new WaitlessContext(builder.Options);

            var testMenu1 = new Database.Models.Menu()
            {
                Id = 1,
                Number = 1,
                Name = "Wintermenü",
                Description = "Feine Winterspeisen",
            };

            var testMenu2 = new Database.Models.Menu()
            {
                Id = 2,
                Number = 2,
                Name = "Frühlingsmenü",
                Description = "Feine Frühlingsspeisen",
            };

            var testMenu3 = new Database.Models.Menu()
            {
                Id = 3,
                Number = 3,
                Name = "Sommermenü",
                Description = "Feine Sommerspeisen",
            };

            var testMenu4 = new Database.Models.Menu()
            {
                Id = 4,
                Number = 4,
                Name = "Herbstmenü",
                Description = "Feine Herbstspeisen",
            };

            context.Menu.Add(testMenu1);
            context.Menu.Add(testMenu2);
            context.Menu.Add(testMenu3);
            context.Menu.Add(testMenu4);
            context.SaveChanges();

            var service = new MenuService(context);
            var result = service.GetMenus();
            Assert.Equal(4, result.Count());
            
            context.Menu.Remove(testMenu1);
            context.SaveChanges();
            result = service.GetMenus();

            Assert.Equal(3, result.Count());
            
        }

        [Fact]
        public void TestMenuUpdate()
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase("unittest4");
            var context = new WaitlessContext(builder.Options);

            var testMenu = new Database.Models.Menu()
            {
                Id = 1,
                Number = 1,
                Name = "Sommermenü",
                Description = "Feine Sommerspeisen",
            };

            context.Menu.Add(testMenu);
            context.SaveChanges();

            var service = new MenuService(context);
            var result = service.GetMenus();

            Assert.Equal("Sommermenü", result.ElementAt(0).Name);

            testMenu.Name = "Wintermenü";
            testMenu.Description = "Feine Winterspeisen";

            Assert.False(result.ElementAt(0).Name == "Sommermenü");

        }
    }		
 }
