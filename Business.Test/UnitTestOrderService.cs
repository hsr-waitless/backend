using Business.Models;
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
        public void TestCreateOrder()
        {
            // Wieso schlägt dieser Test auf Zeile 18 fehlt???
            var context = MockContextFactory.Create();

            var table = new Table()
            {
                Id = 3,
                Name = "albertus",
                Orders = new List<Order>()
            };

            var waiter = new Tablet()
            {
                Id = 4,
                Identifier = "brutus",
                Mode = Mode.Waiter
            };

            context.Table.Add(table);
            context.Tablet.Add(waiter);

            var service = new OrderService(context);
            var result = service.CreateOrder(table.Id, waiter.Identifier);
            context.SaveChanges();

            Assert.Equal(4, result.Number);
            Assert.Equal(OrderStatus.New, result.OrderStatus);
            Assert.Equal(result.UpdateTime, result.CreationTime);
            Assert.Equal(0, result.PriceOrder);
        }

        [Fact]
        public void TestGetOrdersByWaiter()
        {
            var context = MockContextFactory.Create();

            var waiter = new Tablet
            {
                Id = 3,
                Identifier = "Georg",
                Mode = Mode.Waiter
            };

            var order1 = new Order
            {
                Id = 4,
                OrderStatus = OrderStatus.New,
                PriceOrder = 0,
                TableId = 5,
                Waiter = waiter
            };

            var order2 = new Order
            {
                Id = 8,
                OrderStatus = OrderStatus.Active,
                PriceOrder = 2,
                TableId = 7,
                Waiter = waiter
            };

            context.Tablet.Add(waiter);
            context.Order.Add(order1);
            context.Order.Add(order2);

            var service = new OrderService(context);
            var result = service.GetOrdersByWaiter("Georg");

            context.SaveChanges();

            Assert.NotEmpty( result );
            //Assert.Equal( order2, result.Select(t => t.OrderStatus = OrderStatus.Active));
            //Assert.Equal( order1, result.Select(t => t.OrderStatus = OrderStatus.New));
        }
    }		
 }
