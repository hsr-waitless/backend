using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Backend.Commands;
using Business.Services;
using Database.Models;

namespace Backend.Hubs
{
    [HubName("orderhub")]
    public class OrderHub : Hub
    {
        private readonly TableService getTablesService;
        private readonly OrderService orderService;
        private readonly OrderPosService orderPosService;
        private readonly AssignOrderService assignOrderService;
        private readonly TabletService tabletService;

        public OrderHub(TableService getTablesService,
            OrderService orderService,
            OrderPosService orderPosService,
            AssignOrderService assignOrderService,
            TabletService tabletService
            )
        {
            this.getTablesService = getTablesService;
            this.orderService = orderService;
            this.orderPosService = orderPosService;
            this.assignOrderService = assignOrderService;
            this.tabletService = tabletService;
        }

        public void GetAllTablesRequest(Command<GetAllTablesRequest> request)
        {
            var response = new Command<GetAllTablesResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetAllTablesResponse
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

            var infoEvent = new DoSendInfoEvent()
            {
                Info = "OrderCreated"
            };
            Clients?.Group(Mode.Kitchen.ToString())?.DoSendInfoEvent(infoEvent);

            Clients.Caller.CreateOrderResponse(response);
        }

        public void GetOrdersByWaiterRequest(Command<GetOrdersByWaiterRequest> request)
        {
            var response = new Command<GetOrdersByWaiterResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetOrdersByWaiterResponse
                {
                    Orders = orderService.GetOrdersByWaiter(request.Arguments.TabletIdentifier)
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
                    Order = orderService.GetOrder(request.Arguments.Number)
                }
            };
            Clients.Caller.GetOrderResponse(response);
        }

        public void DoAssignOrderRequest(Command<DoAssignOrderRequest> request)
        {
            var assignOrder = new OnOrderAssignedEvent
            {
                OrderId = request.Arguments.OrderId,
            };

            Clients?.Group(request.Arguments.TabletIdentifier)?.OnOrderChange(assignOrder);


            var response = new Command<DoAssignOrderResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new DoAssignOrderResponse
                {
                    success = assignOrderService.OnOrderAssigned(request.Arguments.TabletIdentifier,
                        request.Arguments.OrderId)
                }
            };

            Clients.Caller.DoAssignOrderResponse(response);
        }

        public void DoChangeStatusOrderRequest(Command<DoChangeStatusOrderRequest> request)
        {
            var response = new Command<DoChangeStatusOrderResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new DoChangeStatusOrderResponse
                {
                    Order = orderService.DoChangeOrderStatus(request.Arguments.Number, request.Arguments.OrderStatus)
                }
            };
            var infoEvent = new DoSendInfoEvent()
            {
                Info = "OrderUpdated"
            };
            Clients?.Group(Mode.Kitchen.ToString())?.DoSendInfoEvent(infoEvent);
            Clients.Caller.DoChangeStatusOrderResponse(response);
        }

        public void DoUnassignOrderRequest(Command<DoUnassignOrderRequest> request)
        {
            var unassignOrder = new OnOrderUnassignedEvent
            {
                OrderId = request.Arguments.OrderId,
            };

            Clients?.Group(request.Arguments.TabletIdentifier)?.OnOrderUnassignEvent(unassignOrder);

            var response = new Command<DoUnassignOrderResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new DoUnassignOrderResponse
                {
                    success = assignOrderService.OnOrderUnassigned(request.Arguments.TabletIdentifier,
                        request.Arguments.OrderId)
                }
            };

            Clients.Caller.DoUnassignOrderResponse(response);
        }

        public void CreateOrderPosRequest(Command<CreateOrderPosRequest> request)
        {

            
            var response = new Command<CreateOrderPosResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new CreateOrderPosResponse
                {
                    Order = orderPosService.AddOrderPos(request.Arguments.OrderId, request.Arguments.ItemTypeId)
                }
            };
            var infoEvent = new DoSendInfoEvent()
            {
                Info = "OrderPosCreated"
            };
            Clients?.Group(Mode.Kitchen.ToString())?.DoSendInfoEvent(infoEvent);

            Clients.Caller.CreateOrderPosResponse(response);
        }

        public void DoDeleteOrderPosRequest(Command<DoDeleteOrderPosRequest> request)
        {
            var response = new Command<DoDeleteOrderPosResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new DoDeleteOrderPosResponse
                {
                    Order = orderPosService.RemoveOrderPos(request.Arguments.OrderId, request.Arguments.PositionId)
                }
            };
            var infoEvent = new DoSendInfoEvent()
            {
                Info = "OrderPosDeleted"
            };
            Clients?.Group(Mode.Kitchen.ToString())?.DoSendInfoEvent(infoEvent);

            Clients.Caller.DoDeleteOrderPosResponse(response);
        }

        public void DoUpdateOrderPosRequest(Command<DoUpdateOrderPosRequest> request)
        {
            
            var response = new Command<DoUpdateOrderPosResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new DoUpdateOrderPosResponse
                {
                    Order = orderPosService.DoUpdateOrderPosRequest(request.Arguments.OrderPosId,
                        request.Arguments.Amount,
                        request.Arguments.Comment)
                }
            };
            orderService.DoCalulateOrderPrice(request.Arguments.OrderId);
            
            var infoEvent = new DoSendInfoEvent()
            {
                Info = "OrderPosUpdated"
            };
            Clients?.Group(Mode.Kitchen.ToString())?.DoSendInfoEvent(infoEvent);
            
            
            Clients.Caller.DoUpdateOrderPosResponse(response);

        }

        public void GetOrdersByStatusRequest(Command<GetOrdersByStatusRequest> request)
        {
            var response = new Command<GetOrdersByStatusResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetOrdersByStatusResponse
                {
                    Orders = orderService.GetOrdersByStatus(request.Arguments.Status)
                }
            };
            Clients.Caller.GetOrdersByStatusResponse(response);

        }

        public void DoChangeStatusOrderPosRequest(Command<DoChangeStatusOrderPosRequest> request)
        {
            
            var response = new Command<DoChangeStatusOrderPosResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new DoChangeStatusOrderPosResponse
                {
                    OrderPos = orderPosService.DoChangeStatusOrderPos(request.Arguments.id, request.Arguments.Status)
                }
            };
            var infoEvent = new DoSendInfoEvent()
            {
                Info = "OrderPosUpdate"
            };
            Clients?.Group(Mode.Kitchen.ToString())?.DoSendInfoEvent(infoEvent);
            Clients?.Group(tabletService.GetTabletIdentifier(request.Arguments.id))?.DoSendInfoEvent(infoEvent);

            Clients.Caller.DoChangeStatusOrderPosResponse(response);
        }
    }
}