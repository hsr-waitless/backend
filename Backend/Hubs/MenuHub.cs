using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Threading.Tasks;
using Backend.Commands;
using Backend.Command;
using Business.Services;

namespace Backend.Hubs
{
    [HubName("menuhub")]
    public class MenuHub : Hub
    {
        private readonly MenuService getMenuService;
        private readonly SubmenuService getSubMenuService;
        private readonly ItemTypeService getItemsService;

        public MenuHub(MenuService getMenuService, SubmenuService getSubMenuService, ItemTypeService getItemsService)
        {
            this.getMenuService = getMenuService;
            this.getSubMenuService = getSubMenuService;
            this.getItemsService = getItemsService;
        }

        public void GetMenuRequest(Command<GetMenuRequest> request)
        {
            var response = new Command<GetMenuResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetMenuResponse
                {
                    Menus = getMenuService.GetMenus()
                }
            };

            Clients.Caller.GetMenuResponse(response);
        }

        public void GetSubMenuRequest(Command<GetSubMenuRequest> request)
        {
            var response = new Command<GetSubMenuResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetSubMenuResponse
                {
                    SubMenus = getSubMenuService.GetSubmenus(request.Arguments.MenuId)
                }
            };
            Clients.Caller.GetSubMenuResponse(response);
        }

        public void GetItemTypesRequest(Command<GetItemTypesRequest> request)
        {
            var response = new Command<GetItemTypesResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetItemTypesResponse
                {
                    ItemTypes = getItemsService.GetItemTypes(request.Arguments.SubMenuId)
                }
            };
            Clients.Caller.GetItemTypesResponse(response);
        }

        public void GetAllItemTypeRequest(Command<GetAllItemTypesRequest> request)
        {
            var response = new Command<GetAllItemTypesResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new GetAllItemTypesResponse
                {
                    ItemTypes = getItemsService.GetAllItemTypes(request.Arguments.MenuId)
                }
            };
            Clients.Caller.GetAllItemTypeResponse(response);
        }
    }
}