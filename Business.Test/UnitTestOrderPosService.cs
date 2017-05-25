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

            var orderService = new OrderService(new MockDataService(context));
            var service = new OrderPosService(new MockDataService(context), orderService);

            service.AddOrderPos(testOrder.Id, testItem1.Id);
            service.AddOrderPos(testOrder.Id, testItem2.Id);
            context.SaveChanges();

            Assert.Equal(2, testOrder.Positions.Count());
            Assert.Equal(2, testOrder.Positions.LastOrDefault().Number);

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

            service.AddOrderPos(testOrder2.Id, testItem1.Id);
            service.AddOrderPos(testOrder2.Id, testItem2.Id);
            service.AddOrderPos(testOrder2.Id, testItem3.Id);
            context.SaveChanges();

            Assert.Equal(3, testOrder2.Positions.Count());
            Assert.Equal(3, testOrder2.Positions.LastOrDefault().Number);

            service.RemoveOrderPos(testOrder2.Id, testOrder2.Positions.First().Id);

            Assert.Equal(2, testOrder2.Positions.Count());
            Assert.Equal(3, testOrder2.Positions.LastOrDefault().Number);

        }

        [Fact]
        public void TestDoChangeStatusOrderPos()
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
            context.Itemtyp.Add(testItem1);
            context.Order.Add(testOrder);
            context.SaveChanges();


            var orderService = new OrderService(new MockDataService(context));
            var positionService = new OrderPosService(new MockDataService(context), orderService);

            positionService.AddOrderPos(testOrder.Id, testItem1.Id);
            positionService.DoUpdateOrderPosRequest(testOrder.Positions.First().Id, 3, "");
            context.SaveChanges();

            Assert.Equal(testOrder.Positions.FirstOrDefault().PosStatus, Database.Models.PosStatus.New);

            positionService.DoChangeStatusOrderPos(testOrder.Positions.FirstOrDefault().Id, Database.Models.PosStatus.Active);

            Assert.Equal(testOrder.Positions.FirstOrDefault().PosStatus, Database.Models.PosStatus.Active);

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
            context.Itemtyp.Add(testItem1);
            context.Order.Add(testOrder);
            context.SaveChanges();


            var orderService = new OrderService(new MockDataService(context));
            var positionService = new OrderPosService(new MockDataService(context), orderService);

            positionService.AddOrderPos(testOrder.Id, testItem1.Id);
            positionService.DoUpdateOrderPosRequest(testOrder.Positions.First().Id, 3, "");
            context.SaveChanges();

            Assert.Equal(45, testOrder.Positions.First().PricePos);

            positionService.DoUpdateOrderPosRequest(testOrder.Positions.First().Id, 1, "");

            Assert.Equal(15, testOrder.Positions.First().PricePos);

            positionService.DoUpdateOrderPosRequest(testOrder.Positions.First().Id, 4, "");

            Assert.Equal(60, testOrder.Positions.First().PricePos);

        }
    }

}