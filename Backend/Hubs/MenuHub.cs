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
            Clients.Caller.GetItemTypesResponse(response);
        }

        public void GetAllItemTypeRequest(Command<AllItemTypesRequest> request)
        {
            var response = new Command<AllItemTypesResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new AllItemTypesResponse
                {
                    ItemTypes = getItemsService.GetAllItemTypes(request.Arguments.MenuId)
                }
            };
            Clients.Caller.GetAllItemTypeResponse(response);
        }
    }
}