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
     public class UnitTestOrderService		
     {
        [Fact]
        public void TestAddOrderPos()
        {
            /*var context = MockContextFactory.Create();

            var testOrder = new Order()
            {
                Id = 1,
                OrderStatus = OrderStatus.New,
                CreationTime = new DateTime(2017, 2, 4, 17, 0, 0),
                Guests = new List<Tablet>(),
                Positions = new List<OrderPos>()
               
            };
            context.Order.Add(testOrder);
            context.SaveChanges();

            var service = new OrderService(context);

            var result = service.AddOrderPos(testOrder.Id, 1);
            context.SaveChanges();


            var result = service.AddOrderPos(testOrder.Id, 1);
            context.SaveChanges();

            Assert.Equal(2, testOrder.Positions.Count());
            Assert.Equal(2, testOrder.Positions.LastOrDefault().Number);
            Assert.Equal(true, result);

            var testOrder2 = new Order()
            {
                Id = 2,
                OrderStatus = OrderStatus.New,
                CreationTime = new DateTime(2017, 2, 9, 17, 0, 0),
                Guests = new List<Tablet>(),
                Positions = new List<OrderPos>()

            };
            context.Order.Add(testOrder2);
            context.SaveChanges();

            var position3 = service.CreateOrderPos(testOrder2.Id);
            result = result && service.AddOrderPos(testOrder2.Id, position3);
            context.SaveChanges();


            var position4 = service.CreateOrderPos(testOrder2.Id);
            result = result && service.AddOrderPos(testOrder2.Id, position4);
            context.SaveChanges();

            var position5 = service.CreateOrderPos(testOrder2.Id);
            result = result && service.AddOrderPos(testOrder2.Id, position5);
            context.SaveChanges();

            var position6 = service.CreateOrderPos(testOrder2.Id);
            result = result && service.AddOrderPos(testOrder2.Id, position6);
            context.SaveChanges();


            Assert.Equal(4, testOrder2.Positions.Count());
            Assert.Equal(4, testOrder2.Positions.LastOrDefault().Number);
            Assert.Equal(true, result);

            result = result && service.RemoveOrderPos(testOrder2.Id, position5.Id);

            Assert.Equal(3, testOrder2.Positions.Count());
            Assert.Equal(4, testOrder2.Positions.LastOrDefault().Number);
            Assert.Equal(true, result);
*/
        }

        


    }		
 }
