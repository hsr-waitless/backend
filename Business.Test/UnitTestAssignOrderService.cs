using Business.Services;
using Business.Test.Factory;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;		
using System;
using System.Collections.Generic;
using System.Linq;		
using Xunit;		
 		
 namespace Backend.Test		
 {		
     public class UnitTestAssignOrderService		
     {
        [Fact]
        public void TestOnOrderAssigned()
        {
            var context = MockContextFactory.Create();

            var guest = new Tablet()
            {
                Id = 1,
                Identifier = "Hachim",
                Mode = Mode.Guest
            };

            var waiter = new Tablet()
            {
                Id = 2,
                Identifier = "Karim",
                Mode = Mode.Waiter
            };

            var testOrder = new Order()
            {
                Id = 1,
                OrderStatus = OrderStatus.New,
                CreationTime = new DateTime(2017, 2, 4, 17, 0, 0),
                UpdateTime = new DateTime(2017, 2, 4, 17, 0, 0),
                Waiter = waiter,
                Guests = new List<Tablet>()
               

            };

            context.Tablet.Add(guest);
            context.Tablet.Add(waiter);
            context.Order.Add(testOrder);
            context.SaveChanges();

            var service = new AssignOrderService(new MockDataService(context));
            var result = service.OnOrderAssigned(guest.Identifier, testOrder.Id);
            Assert.Equal(guest.Identifier, testOrder.Guests.FirstOrDefault().Identifier);
            Assert.Equal(true, result);

        }

        [Fact]
        public void TestOnOrderUnassigned()
        {
            var context = MockContextFactory.Create();

            var guest = new Tablet()
            {
                Id = 1,
                Identifier = "Hachim",
                Mode = Mode.Guest
            };

            var waiter = new Tablet()
            {
                Id = 2,
                Identifier = "Karim",
                Mode = Mode.Waiter
            };

            var testOrder = new Order()
            {
                Id = 1,
                OrderStatus = OrderStatus.New,
                CreationTime = new DateTime(2017, 2, 4, 17, 0, 0),
                UpdateTime = new DateTime(2017, 2, 4, 17, 0, 0),
                Waiter = waiter,
                Guests = new List<Tablet>()


            };

            context.Tablet.Add(guest);
            context.Tablet.Add(waiter);
            context.Order.Add(testOrder);
            context.SaveChanges();

            var service = new AssignOrderService(new MockDataService(context));
            var result = service.OnOrderAssigned(guest.Identifier, testOrder.Id);
            result = service.OnOrderUnassigned(guest.Identifier, testOrder.Id);
            
            Assert.Equal(true, result);
            Assert.Empty(testOrder.Guests);

        }

        [Fact]
        public void TestOnOrderAssignedWI() {
            var context = MockContextFactory.Create();


            String fakeIdentifier = "Laptop";

            var waiter = new Tablet()
            {
                Id = 2,
                Identifier = "Karim",
                Mode = Mode.Waiter
            };

            var testOrder = new Order()
            {
                Id = 1,
                OrderStatus = OrderStatus.New,
                CreationTime = new DateTime(2017, 2, 4, 17, 0, 0),
                UpdateTime = new DateTime(2017, 2, 4, 17, 0, 0),
                Waiter = waiter,
                Guests = new List<Tablet>()


            };
            
            context.Tablet.Add(waiter);
            context.Order.Add(testOrder);
            context.SaveChanges();

            var service = new AssignOrderService(new MockDataService(context));
            var result = service.OnOrderAssigned(fakeIdentifier, testOrder.Id);

            Assert.Equal(false, result);
        }


    }		
 }
