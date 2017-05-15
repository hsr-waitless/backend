﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Backend.Commands;
using Business.Services;
using Database;
using Database.Models;
using System.Linq;

namespace Backend.Hubs
{
    [HubName("orderhub")]
    public class OrderHub : Hub
    {
        private readonly TableService getTablesService;
        private readonly OrderService orderService;
        private readonly OrderPosService orderPosService;
        private readonly AssignOrderService assignOrderService;

        public OrderHub(TableService getTablesService,
            OrderService orderService,
            OrderPosService orderPosService,
            AssignOrderService assignOrderService)
        {
            this.getTablesService = getTablesService;
            this.orderService = orderService;
            this.orderPosService = orderPosService;
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

        public void DoAssignOrderRequest(Command<AssignOrderRequest> request)
        {
            var assignOrder = new OnOrderAssignedEvent
            {
                OrderId = request.Arguments.OrderId,
            };

            Clients.Group(request.Arguments.TabletIdentifier).OnOrderChange(assignOrder);


            var response = new Command<AssignOrderResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new AssignOrderResponse
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
            Clients.Caller.DoChangeStatusOrderResponse(response);
        }

        public void DoUnassignOrderRequest(Command<UnassignOrderRequest> request)
        {
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
                    success = assignOrderService.OnOrderUnassigned(request.Arguments.TabletIdentifier,
                        request.Arguments.OrderId)
                }
            };

            Clients.Caller.DoUnassignOrderResponse(response);
        }

        public void CreateOrderPosRequest(Command<AddOrderPosRequest> request)
        {
            var response = new Command<AddOrderPosResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new AddOrderPosResponse
                {
                    Order = orderPosService.AddOrderPos(request.Arguments.OrderId, request.Arguments.ItemTypeId)
                }
            };
            Clients.Caller.CreateOrderPosResponse(response);
        }

        public void DoDeleteOrderPosRequest(Command<RemoveOrderPosRequest> request)
        {
            var response = new Command<RemoveOrderPosResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new RemoveOrderPosResponse
                {
                    Order = orderPosService.RemoveOrderPos(request.Arguments.OrderId, request.Arguments.PositionId)
                }
            };
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
            Clients.Caller.DoChangeStatusOrderPosResponse(response);
        }
    }
}