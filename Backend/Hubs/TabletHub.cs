using Backend.Commands;
using Business.Services;
using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using Business.Services;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs
{
    [HubName("tablethub")]
    public class TabletHub : Hub
    {
        private AssignTabletService assignService;

        public TabletHub(AssignTabletService assignService)
        {
            this.assignService = assignService;
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
    }
}

