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

            //Assert.NotEmpty( result );
            //Assert.Equal( order2, result.FirstOrDefault(t => t.OrderStatus = OrderStatus.Active));
            //Assert.Equal( order1, result.FirstOrDefault(t => t.OrderStatus = OrderStatus.New));
        }

        [Fact]
        public void TestGetOrder()

        {
            var context = MockContextFactory.Create();

            var order0 = new Order
            {
                Id = 3,
                OrderStatus = OrderStatus.New,
                PriceOrder = 1,
                TableId = 5,
                Waiter = new Tablet()
                {
                    Id = 8,
                    Identifier = "Brutus",
                    Mode = Mode.Waiter
                }
            };

            context.Order.Add(order0);
            context.SaveChanges();

            var service = new OrderService(context);
            var result = service.GetOrder(3);

            //Assert.NotEmpty(result);
            //Assert.Equal(1, result.Count() );
            //Assert.Equal(3, result.Number);
            //Assert.Equal(OrderStatus.New, result.OrderStatus);
            //Assert.Equal(1, result.PriceOrder);
        }

        [Fact]
        public void TestDoChangeOrderStatus()
        {
            var context = MockContextFactory.Create();

            var order4 = new Order
            {
                Id = 2,
                OrderStatus = OrderStatus.New,
                PriceOrder = 3,
                TableId = 7,
                Waiter = new Tablet()
                {
                    Id = 2,
                    Identifier = "Dagobert",
                    Mode = Mode.Waiter
                }
            };

            context.Order.Add(order4);
            context.SaveChanges();

            var service = new OrderService(context);
            var result = service.DoChangeOrderStatus(2, OrderStatus.Done);

            //Assert.Equal(OrderStatus.Done, result.OrderStatus);
        }

        [Fact]
        public void TestDoCalculateOrderPrice()
        {
            var context = MockContextFactory.Create();

            var waiter = new Tablet()
            {
                Id = 4,
                Identifier = "brutus",
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
                PriceOrder = 0,
                TableId = 7,
                Waiter = waiter
            };

            var positionA = new Itemtyp
            {
                Id = 1,
                Number = 1,
                Title = "soup",
                Description = "tomatosoup",
                ItemPrice = 9
            };

            var positionB = new Itemtyp
            {
                Id = 2,
                Number = 2,
                Title = "salad",
                Description = "tomatosalad",
                ItemPrice = 12
            };
            

            context.Tablet.Add(waiter);
            context.Order.Add(order1);
            context.Order.Add(order2);
            context.SaveChanges();

            //TODO:Hier order2 erweitern um 2 Positionen
            // Wieso lässt sich order2 nciht erweitern?


            var orderService = new OrderService(context);
            var posService = new OrderPosService(context, orderService);
            orderService.DoCalulateOrderPrice(4);

            // TODO: Hier wert von order2 berechnen
            context.SaveChanges();

            

            // Test with worth 0
            Assert.Equal(0, order1.PriceOrder);
            //TODO: Hier testen ob Order2 den richtigen Wert enthält 
        }
    }		
 }
