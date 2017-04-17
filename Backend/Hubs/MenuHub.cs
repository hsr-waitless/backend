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
    [HubName("menuhub")]
    public class MenuHub : Hub
    {
        private MenuService getMenuService;
        private SubmenuService getSubMenuService;
        private ItemTypeService getItemsService;

        public MenuHub(MenuService getMenuService, SubmenuService getSubMenuService, ItemTypeService getItemsService)
        { 
            this.getMenuService = getMenuService;
            this.getSubMenuService = getSubMenuService;
            this.getItemsService = getItemsService;
        }

        public void GetMenuRequest(Command<MenuRequest> request)
        {
            var response = new Command<MenuResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new MenuResponse
                {
                    Menus = getMenuService.GetMenus()
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
                    SubMenus = getSubMenuService.GetSubmenus(request.Arguments.MenuId)
                }
            };
            Clients.Caller.GetSubMenuResponse(response);
        }

        public void GetItemTypesRequest(Command<ItemTypesRequest> request)
        {
            var response = new Command<ItemTypesResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new ItemTypesResponse
                {
                    ItemTypes = getItemsService.GetItemTypes(request.Arguments.SubMenuId)
                }
            };
            Clients.Caller.GetItemTypeResponse(response);
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
