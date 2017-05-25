using Business.Services;
using System;
using Xunit;
using Business.Test.Factory;
using Backend.Hubs;
using Backend.Commands;

namespace Backend.Test		
 {
    public class UnitTestHub
    {


        [Fact]
        public void TestOrderHub()
        {
            var context = MockContextFactory.Create();
            var getTablesService = new TableService(new MockDataService(context));
            var orderService = new OrderService(new MockDataService(context));
            var orderPosService = new OrderPosService(new MockDataService(context), orderService);
            var assignOrderService = new AssignOrderService(new MockDataService(context));
            var tabletService = new TabletService(new MockDataService(context));

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
            context.SaveChanges();

            var request = new CreateOrderRequest();
            request.TableId = 12;
            request.TabletIdentifier = "Mira";

            var command = new Command<CreateOrderRequest>();
            command.RequestId = "123";
            command.Arguments = request;

            var called = false;

            var hub = new OrderHub(getTablesService, orderService, orderPosService, assignOrderService, tabletService);

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
            
            var getMenuService = new MenuService(new MockDataService(context));
            var SubmenuService = new SubmenuService(new MockDataService(context));
            var getItemsService = new ItemTypeService(new MockDataService(context));

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

            var tabletService = new TabletService(new MockDataService(context));
            

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
