using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Backend.Commands;
using Business.Services;

namespace Backend.Hubs
{
    [HubName("orderhub")]
    public class OrderHub : Hub
    {
        private readonly TableService getTablesService;
        private readonly OrderService orderService;

        public OrderHub(TableService getTablesService, OrderService orderService)
        { 
            this.getTablesService = getTablesService;
            this.orderService = orderService;
        }

        public void GetAllTablesRequest(Command<TableRequest> request)
        {
            var response = new Command<TableResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new TableResponse
                {
                    Tables = getTablesService.GetAllTables()
                }
            };
            Clients.Caller.GetAllTablesResponse(response);
        }

        public void CreateOrderRequest(Command<CreateOrderRequest> request)
        {
            var response = new Command<CreateOrderResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new CreateOrderResponse
                {
                    Order = orderService.CreateOrder(request.Arguments.TableId, request.Arguments.TabletIdentifier)
                }
            };
            Clients.Caller.CreateOrderResponse(response);
        }

        public void GetOrdersByWaiterRequest(Command<GetOrdersByWaiterRequest> request)
        {
            var response = new Command<GetOrdersByWaiterResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetOrdersByWaiterResponse
                {
                    Orders  = orderService.GetOrdersByWaiter(request.Arguments.TabletIdentifier)
                }
            };
            Clients.Caller.GetOrdersByWaiterResponse(response);
        }

        public void GetOrderRequest(Command<GetOrderRequest> request)
        {
            var response = new Command<GetOrderResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetOrderResponse
                {
                    Order  = orderService.GetOrder(request.Arguments.Number)
                }
            };
            Clients.Caller.GetOrderResponse(response);
        }
    }
}