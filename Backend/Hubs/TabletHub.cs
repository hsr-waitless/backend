using Backend.Commands;
using Business.Services;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs
{
    [HubName("tablethub")]
    public class TabletHub : Hub
    {
        private readonly AssignTabletService assignService;
        private readonly GetTabletsByModeService getTabletsByModeService;

        public TabletHub(AssignTabletService assignService, GetTabletsByModeService getTabletsByModeService)
        {
            this.assignService = assignService;
            this.getTabletsByModeService = getTabletsByModeService;
        }

        public void SetModeRequest(Command<DoAssignTabletRequest> request)
        {
            var response = new Command<DoAssignTabletResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new DoAssignTabletResponse()
                {
                    IsTabletNew = assignService.SetMode
                    (request.Arguments.TabletIdentifier , request.Arguments.Mode)
                }

            };
            Clients.Caller.SetModeResponse(response);
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
            Clients.Caller.GetTabletsByModeResponse(response);
        }
    }
}

