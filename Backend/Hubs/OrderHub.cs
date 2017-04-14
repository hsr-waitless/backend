using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Threading.Tasks;
using System;
using System.Linq;
using Backend.Commands;
using Backend.Command;
using Business.Services;

namespace Backend.Hubs
{
    [HubName("orderhub")]
    public class OrderHub : Hub
    {
        private TableService service;
        private OrderService orderService;

        public OrderHub(TableService service, OrderService orderService)
        { 
            this.service = service;
            this.orderService = orderService;
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
