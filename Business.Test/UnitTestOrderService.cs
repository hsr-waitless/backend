﻿using Business.Models;
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


        [Fact]
        public void TestAddOrderPos()
        {
            var context = MockContextFactory.Create();

            var testOrder = new Order()
            {
                Id = 1,
                OrderStatus = OrderStatus.New,
                CreationTime = new DateTime(2017, 2, 4, 17, 0, 0),
                Guests = new List<Tablet>(),
                Positions = new List<OrderPos>()
               
            };

            var testItem1 = new Itemtyp
            {
                Id = 1,
                Number = 1,
                Title = "Burger",
                Description = "Burger with Fries",
                ItemPrice = 15
            };

            var testItem2 = new Itemtyp
            {
                Id = 2,
                Number = 2,
                Title = "Steak",
                Description = "Steak with Fries",
                ItemPrice = 20
            };

            var testItem3 = new Itemtyp
            {
                Id = 3,
                Number = 3,
                Title = "Toast",
                Description = "Toast with Fries",
                ItemPrice = 10
            };

            context.Order.Add(testOrder);
            context.SaveChanges();

            var service = new OrderService(context);

            var result = service.AddOrderPos(testOrder.Id, testItem1.Id);
            result = result && service.AddOrderPos(testOrder.Id, testItem1.Id);
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
            
            result = result && service.AddOrderPos(testOrder2.Id, testItem1.Id);
            result = result && service.AddOrderPos(testOrder2.Id, testItem2.Id);
            result = result && service.AddOrderPos(testOrder2.Id, testItem3.Id);
            context.SaveChanges();
                        
            Assert.Equal(3, testOrder2.Positions.Count());
            Assert.Equal(3, testOrder2.Positions.LastOrDefault().Number);
            Assert.Equal(true, result);

            result = result && service.RemoveOrderPos(testOrder2.Id, testOrder2.Positions.First().Id);

            Assert.Equal(2, testOrder2.Positions.Count());
            Assert.Equal(3, testOrder2.Positions.LastOrDefault().Number);
            Assert.Equal(true, result);

        }




    }		
 }
