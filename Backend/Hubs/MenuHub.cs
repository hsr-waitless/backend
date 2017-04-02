using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Threading.Tasks;
using System;
using System.Linq;
using Backend.Commands;
using Backend.Command;
using Bussiness.Services;
using Business.Models;
using Database.Models;
using System.Collections.Generic;

namespace Backend.Hubs
{
  [HubName("menuhub")]
  public class MenuHub : Hub
  {
        private MenuService service;

    public MenuHub(MenuService service) 
    { 
      this.service = service;
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

    public void GetSubMenuRequest(Command<SubmenuRequest> request)
    {
            //Hier mal ausprobiert
            var response = new Command<SubmenuResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new SubmenuResponse
                {
                    Submenues = new List<SubMenuModel>()
                    {
                      new SubMenuModel { Name = "Test", Number = 1 }
                    }
                }
            };
            Clients.Caller.GetSubMenuResponse(response);
    }

    public void GetItemTypeRequest(Command<ItemtypeRequest> request)
    {
            var response = new Command<ItemtypeResponse>()
            {
                RequestId = request.RequestId,
                Arguments = new ItemtypeResponse
                {
                    Itemtypes = new List<ItemTypeModel>()
                    {
                      new ItemTypeModel { Title = "Grüner Salat", Number = 1, Description = "Lorem ipsum", ItemPrice = 18, Category = Category.Vegan }
                    }
                }
            };
            Clients.Caller.GetItemtypeRequest(response);
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
