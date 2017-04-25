using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Backend.Commands;
using Business.Services;
using Database;

namespace Backend.Hubs
{
    [HubName("orderhub")]
    public class OrderHub : Hub
    {
        private readonly TableService getTablesService;
        private readonly OrderService orderService;
        private readonly AssignOrderService assignOrderService;

        public OrderHub(TableService getTablesService,
            OrderService orderService,
            AssignOrderService assignOrderService)
        {
            this.getTablesService = getTablesService;
            this.orderService = orderService;
            this.assignOrderService = assignOrderService;
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

        public void AssignOrderRequest(Command<AssignOrderRequest> request) {

            var assignOrder = new OnOrderAssignedEvent
            {
                OrderId = request.Arguments.OrderId,
            };
            
            Clients.Group(request.Arguments.TabletIdentifier).OnOrderAssignEvent(assignOrder);


            var response = new Command<AssignOrderResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new AssignOrderResponse
                {
                    success = assignOrderService.OnOrderAssigned(request.Arguments.TabletIdentifier, request.Arguments.OrderId)
                }
            };
            
            Clients.Caller.AssignOrderResponse(response);
        }

        public void UnassignOrderRequest(Command<UnassignOrderRequest> request) {

            var unassignOrder = new OnOrderUnassignedEvent
            {
                OrderId = request.Arguments.OrderId,
            };

            Clients.Group(request.Arguments.TabletIdentifier).OnOrderUnassignEvent(unassignOrder);

            var response = new Command<UnassignOrderResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new UnassignOrderResponse
                {
                    success = assignOrderService.OnOrderUnassigned(request.Arguments.TabletIdentifier, request.Arguments.OrderId)
                }
            };

            Clients.Caller.UnassignOrderResponse(response);
        }
    }
}