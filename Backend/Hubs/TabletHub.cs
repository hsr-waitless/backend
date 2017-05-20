using System;
using Backend.Commands;
using Business.Services;
using Database.Models;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Backend.Hubs
{
    [HubName("tablethub")]
    public class TabletHub : Hub
    {
        private readonly TabletService tabletService;
        private readonly ILogger _logger;

        public TabletHub(TabletService tabletService,
            ILoggerFactory loggerFactory)
        {
            this.tabletService = tabletService;
            this._logger = loggerFactory.CreateLogger(typeof(OrderHub));
        }

        public void DoAssignTabletRequest(Command<DoAssignTabletRequest> request)
        {
            Groups.Add(Context.ConnectionId, request.Arguments.TabletIdentifier);
            Groups.Add(Context.ConnectionId, Enum.GetName(typeof(Mode), request.Arguments.Mode));
            
            var response = new Command<DoAssignTabletResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new DoAssignTabletResponse()
                {
                    IsTabletNew = tabletService.SetMode
                        (request.Arguments.TabletIdentifier, request.Arguments.Mode)
                }
            };

            Clients.Caller.DoAssignTabletResponse(response);
        }

        public void GetTabletsByModeRequest(Command<GetTabletsByModeRequest> request)
        {
            var response = new Command<GetTabletsByModeResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetTabletsByModeResponse()
                {
                    Tablets = tabletService.GetTablets(request.Arguments.Mode)
                }
            };
            Clients.Caller.GetTabletsByModeResponse(response);
        }
    }
}