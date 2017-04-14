using Business.Services;		
using Database;		
using Microsoft.EntityFrameworkCore;		
using System;		
using System.Linq;		
using Xunit;		
 		
 namespace Backend.Test		
 {		
     public class UnitTestTableService		
     {		
         [Fact]		
         public void TestGetTables()		
         {		
             var builder = new DbContextOptionsBuilder<WaitlessContext>();		
             builder.UseInMemoryDatabase("unittest");		
             var context = new WaitlessContext(builder.Options);		
 		
             context.Table.Add(new Database.Models.Table());		
             context.SaveChanges();		
 		
             var service = new TableService(context);		
             var result = service.GetTables();		
             Assert.Equal(1, result.Count());		
         }		
     }		
 }
