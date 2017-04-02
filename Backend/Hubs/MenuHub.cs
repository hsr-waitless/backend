using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Threading.Tasks;
using System;
using System.Linq;
using Backend.Commands;
using Backend.Command;
using Bussiness.Services;

namespace Backend.Hubs
{
    [HubName("menuhub")]
    public class MenuHub : Hub
    {
        private MenuService service;
        private SubMenuService subService;
        private ItemTypeService itemService;

        public MenuHub(MenuService service, SubMenuService subService, ItemTypeService itemService)
        { 
            this.service = service;
            this.subService = subService;
            this.itemService = itemService;
        }

        public void GetMenuRequest(Command<MenuRequest> request)
        {
            var response = new Command<MenuResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new MenuResponse
                {
                    Menus = service.GetMenus()
                }
            };

            Clients.Caller.GetMenuResponse(response);
        }

        public void GetSubMenuRequest(Command<SubMenuRequest> request)
        {
            var response = new Command<SubMenuResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new SubMenuResponse
                {
                    SubMenus = subService.GetSubMenus(request.Arguments.MenuId)
                }
            };
            Clients.Caller.GetSubMenuResponse(response);
        }

        public void GetItemTypeRequest(Command<ItemTypeRequest> request)
        {
            var response = new Command<ItemTypeResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new ItemTypeResponse
                {
                    ItemTypes = itemService.GetItemTypes(request.Arguments.SubMenuId)
                }
            };
            Clients.Caller.GetItemTypeRequest(response);
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
