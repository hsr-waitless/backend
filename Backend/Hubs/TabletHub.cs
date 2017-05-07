using Backend.Commands;
using Business.Services;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs
{
    [HubName("tablethub")]
    public class TabletHub : Hub
    {
        private readonly TabletService tabletService;

        public TabletHub(TabletService tabletService)
        {
            this.tabletService = tabletService;
        }

        public void DoAssignTabletRequest(Command<DoAssignTabletRequest> request)
        {
            Groups.Add(Context.ConnectionId, request.Arguments.TabletIdentifier);
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