using Business.Services;
using Business.Test.Factory;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Business.Test
{

    public class UnitTestOrderPosService
    {
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

            var orderService = new OrderService(context);
            var service = new OrderPosService(context, orderService);

            var result = service.AddOrderPos(testOrder.Id, testItem1.Id) != null;
            result = result && service.AddOrderPos(testOrder.Id, testItem1.Id) != null;
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

            result = result && service.AddOrderPos(testOrder2.Id, testItem1.Id) != null;
            result = result && service.AddOrderPos(testOrder2.Id, testItem2.Id) != null;
            result = result && service.AddOrderPos(testOrder2.Id, testItem3.Id) != null;
            context.SaveChanges();

            Assert.Equal(3, testOrder2.Positions.Count());
            Assert.Equal(3, testOrder2.Positions.LastOrDefault().Number);
            Assert.Equal(true, result);

            result = result && service.RemoveOrderPos(testOrder2.Id, testOrder2.Positions.First().Id) != null;

            Assert.Equal(2, testOrder2.Positions.Count());
            Assert.Equal(3, testOrder2.Positions.LastOrDefault().Number);
            Assert.Equal(true, result);

        }

        [Fact]
        public void TestDoUpdateOrderPos()
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

            context.Order.Add(testOrder);
            context.SaveChanges();


            var orderService = new OrderService(context);
            var positionService = new OrderPosService(context, orderService);

            var result = positionService.AddOrderPos(testOrder.Id, testItem1.Id) != null;
            result = result && positionService.AddOrderPos(testOrder.Id, testItem1.Id) != null;
            positionService.DoUpdateOrderPosRequest(testOrder.Positions.First().Id, 2, "");
            context.SaveChanges();

            Assert.Equal(45, testOrder.Positions.First().PricePos);
            Assert.Equal(true, result);

            positionService.DoUpdateOrderPosRequest(testOrder.Positions.First().Id, -2, "");

            Assert.Equal(15, testOrder.Positions.First().PricePos);

            positionService.DoUpdateOrderPosRequest(testOrder.Positions.First().Id, 3, "");

            Assert.Equal(60, testOrder.Positions.First().PricePos);

        }
    }

}