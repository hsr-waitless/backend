using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Threading.Tasks;
using System;
using System.Linq;
using Backend.Commands;
using Backend.Command;
using Business.Services;
using Database.Models;

namespace Backend.Hubs
{
    [HubName("orderhub")]
    public class OrderHub : Hub
    {
        private TableService service;
        private CreateOrderService createOrderService;
        private GetOrdersByWaiterService getOrdersByWaiterService;

        public OrderHub(TableService service, CreateOrderService createOrderService, 
            GetOrdersByWaiterService getOrdersByWaiterService )
        { 
            this.service = service;
            this.createOrderService = createOrderService;
            this.getOrdersByWaiterService = getOrdersByWaiterService;
        }

        public void GetTableRequest(Command<TableRequest> request)
        {
            var response = new Command<TableResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new TableResponse
                {
                    Tables = service.GetTables()
                }
            };
            Clients.Caller.GetTableResponse(response);
        }

        public void CreateOrderRequest(Command<CreateOrderRequest> request)
        {
            var response = new Command<CreateOrderResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new CreateOrderResponse
                {
                    Order = createOrderService.CreateOrder(request.Arguments.TabletId)
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
                    Orders  = getOrdersByWaiterService.GetOrders(request.Arguments.WaiterId)
                }
            };
            Clients.Caller.GetOrdersByWaiterResponse(response);
        }

        
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        
        public override Task OnDisconnected(bool stopCalled)
        {
          return base.OnDisconnected(stopCalled);
        }
    }
}