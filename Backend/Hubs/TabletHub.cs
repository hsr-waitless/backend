using Backend.Commands;
using Business.Services;
using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs
{
    [HubName("tablethub")]
    public class TabletHub : Hub
    {
        private AssignTabletService assignService;
        private GetTabletsByModeService getTabletsByModeService;

        public TabletHub(AssignTabletService assignService, GetTabletsByModeService getTabletsByModeService)
        {
            this.assignService = assignService;
            this.getTabletsByModeService = getTabletsByModeService;
        }

        public void DoAssignTabletRequest(Command<DoAssignTabletRequest> request)
        {
            var response = new Command<DoAssignTabletResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new DoAssignTabletResponse()
                {
                    IsTabletNew = assignService.AssignTablet
                    (request.Arguments.TabletIdentifier , request.Arguments.Mode)
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
                    Tablets = getTabletsByModeService.GetTablets(request.Arguments.Mode)
                }
            };

        }
    }
}

