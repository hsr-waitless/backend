using Bussiness.Services;		
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
             builder.UseInMemoryDatabase("unittest");		
             var context = new WaitlessContext(builder.Options);		
 		
             context.Menu.Add(new Database.Models.Menu());		
             context.SaveChanges();		
 		
             var service = new MenuService(context);		
             var result = service.GetMenus();		
             Assert.Equal(1, result.Count());		
         }		
     }		
 }
