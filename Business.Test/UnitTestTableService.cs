﻿using Business.Services;		
using Database;		
using Microsoft.EntityFrameworkCore;		
using System;		
using System.Linq;		
using Xunit;
using System.Collections.Generic;
using Business.Models;
using Business.Test.Factory;

namespace Backend.Test		
 {		
     public class UnitTestTableService		
     {		
         [Fact]		
         public void TestGetAllTables()		
         {
            var context = MockContextFactory.Create();

            var testTable = new Database.Models.Table
            {
                Id = 4,
                Name = "Ektat"
            };

            context.Table.Add(testTable);		
             context.SaveChanges();		
 		
             var service = new TableService(new MockDataService(context));
             var result = service.GetAllTables();		
             Assert.Equal(1, result.Count());
            
        }

        [Fact]
        public void TestGetTableDetails() {

            var context = MockContextFactory.Create();

            var testTable1 = new Database.Models.Table
            {
                Id = 3,
                Name = "Alta"
            };
            
            context.Table.Add(testTable1);
            context.SaveChanges();
            
            var service = new TableService(new MockDataService(context));
            var result = service.GetAllTables();
            Assert.Equal("Alta", result.ElementAt(0).Name);
            Assert.Equal(3, result.ElementAt(0).Id);
            
        }
        
        [Fact]
        public void TestTableCount()
        {
            var context = MockContextFactory.Create();

            var testTable2 = new Database.Models.Table
            {
                Id = 2,
                Name = "Fusel"
            };

            var testTable3 = new Database.Models.Table
            {
                Id = 6,
                Name = "Powal"
            };

            var testTable4 = new Database.Models.Table
            {
                Id = 8,
                Name = "Hunik"
            };

            context.Table.Add(testTable2);
            context.Table.Add(testTable3);
            context.Table.Add(testTable4);
            context.SaveChanges();

            var service = new TableService(new MockDataService(context));
            var result = service.GetAllTables();
            Assert.Equal(3, result.Count());

            /*context.Table.Remove(testTable2);
            context.SaveChanges();
            result = service.GetAllTables();

            Assert.Equal(2, result.Count());*/

            }

        [Fact]
        public void TestTableUpdate()
        {
            var context = MockContextFactory.Create();

            var testTable1 = new Database.Models.Table
            {
                Id = 9,
                Name = "Zuki"
            };
            
            context.Table.Add(testTable1);
            context.SaveChanges();

            var service = new TableService(new MockDataService(context));
            var result = service.GetAllTables();
            Assert.Equal("Zuki", result.ElementAt(0).Name);

            testTable1.Name = "Harri";
            context.Table.Update(testTable1);
            context.SaveChanges();

            Assert.False(result.ElementAt(0).Name == "Zuki");
            
        }

    }		
 }
