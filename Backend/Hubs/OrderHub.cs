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
        private readonly CreateOrderService createOrderService;
        private readonly GetOrdersByWaiterService getOrdersByWaiterService;

        public OrderHub(TableService getTablesService
            , CreateOrderService createOrderService, 
            GetOrdersByWaiterService getOrdersByWaiterService)
        { 
            this.getTablesService = getTablesService;
            this.createOrderService = createOrderService;
            this.getOrdersByWaiterService = getOrdersByWaiterService;
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
                    Order = createOrderService.CreateOrder(request.Arguments.TableId, request.Arguments.TabletIdentifier)
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
                    Orders  = getOrdersByWaiterService.GetOrders(request.Arguments.TabletIdentifier)
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
                    Order  = getOrdersByWaiterService.GetOrder(request.Arguments.Number)
                }
            };
            Clients.Caller.GetOrderResponse(response);
        }
    }
}