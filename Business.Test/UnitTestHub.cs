using Business.Services;		
using Database;		
using Microsoft.EntityFrameworkCore;		
using System;		
using System.Linq;		
using Xunit;
using System.Collections.Generic;
using Business.Models;
using Business.Test.Factory;
using Backend.Hubs;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Backend.Controllers;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Dynamic;
using Moq;
using Backend.Commands;

namespace Backend.Test		
 {
    public class UnitTestHub
    {


        [Fact]
        public void TestOrderHub()
        {
            var context = MockContextFactory.Create();
            var getTablesService = new TableService(context);
            var orderService = new OrderService(context);
            var orderPosService = new OrderPosService(context, orderService);
            var assignOrderService = new AssignOrderService(context);

            context.Table.Add(new Database.Models.Table
            {
                Id = 12,
                Name = "Hera",
            });

            context.Tablet.Add(new Database.Models.Tablet
            {
                Id = 7,
                Identifier = "Mira",
                Mode = Database.Models.Mode.Guest
            });

            var request = new CreateOrderRequest();
            request.TableId = 12;
            request.TabletIdentifier = "Mira";

            var command = new Command<CreateOrderRequest>();
            command.RequestId = "123";
            command.Arguments = request;

            var called = false;

            var hub = new OrderHub(getTablesService, orderService, orderPosService, assignOrderService);

            var responseType = "CreateOrderResponse";
            var action = new Action<Command<CreateOrderResponse>>((response) =>
            {
                Assert.Equal(response.RequestId, command.RequestId);
                Assert.NotNull(response.Arguments.Order);
                called = true;
            });

            hub.Clients = MockHubFactory.CreateClients(responseType, action);
            hub.CreateOrderRequest(command);

            Assert.True(called);
        }

        [Fact]
        public void TestMenuHub()
        {
            var context = MockContextFactory.Create();
            
            var getMenuService = new MenuService(context);
            var SubmenuService = new SubmenuService(context);
            var getItemsService = new ItemTypeService(context);

            context.Menu.Add(new Database.Models.Menu
            {
                Id = 1,
                Number = 1,
                Description = "Sommer",
                Name = "Sommerspeisen",
             });

            var request = new GetMenuRequest();

            var command = new Command<GetMenuRequest>();
            command.RequestId = "123";
            command.Arguments = request;

            var called = false;

            var hub = new MenuHub(getMenuService, SubmenuService, getItemsService);

            var responseType = "GetMenuResponse";
            var action = new Action<Command<GetMenuResponse>>((response) =>
            {
                Assert.Equal(response.RequestId, command.RequestId);
                Assert.NotNull(response.Arguments.Menus);
                called = true;
            });

            hub.Clients = MockHubFactory.CreateClients(responseType, action);
            hub.GetMenuRequest(command);

            Assert.True(called);
            
        }

        [Fact]
        public void TestTabletHub()
        {
            var context = MockContextFactory.Create();

            var tabletService = new TabletService(context);
            

            var request = new GetTabletsByModeRequest();
            request.Mode = Database.Models.Mode.Waiter;

            var command = new Command<GetTabletsByModeRequest>();
            command.RequestId = "123";
            command.Arguments = request;

            var called = false;

            var hub = new TabletHub(tabletService);


            var responseType = "GetTabletsByModeResponse";
            var action = new Action<Command<GetTabletsByModeResponse>>((response) =>
            {
                Assert.Equal(response.RequestId, command.RequestId);
                Assert.NotNull(response.Arguments.Tablets);
                called = true;
            });

            hub.Clients = MockHubFactory.CreateClients(responseType, action);
            hub.GetTabletsByModeRequest(command);

            Assert.True(called);


        }

     }
}
