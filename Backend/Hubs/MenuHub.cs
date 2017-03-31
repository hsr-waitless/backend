using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Threading.Tasks;
using System;
using System.Linq;
using Backend.Commands;
using Backend.Models;
using Backend.Command;

namespace Backend.Hubs
{
  [HubName("menuhub")]
  public class MenuHub : Hub
  {
    private WaitlessContext context;

    public MenuHub(WaitlessContext context) 
    { 
      this.context = context;
    }

    public void GetMenuRequest(Command<MenuRequest> request)
    {
      var response = new Command<MenuResponse>()
      {
        RequestId = request.RequestId,
        Arguments = new MenuResponse
        {
          Menus = context.Menu.AsEnumerable()
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
                    Submenues = context.Submenu.AsEnumerable()
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
                    Itemtypes = context.Itemtyp.AsEnumerable()
                }
            };
            Clients.Caller.GetItemtypeRequest(response);
    }


    public override Task OnConnected()
    {
      Console.WriteLine("connected");
      var menus = new object[] { };
      Clients.Caller.GetMenuResponse(menus);

      return base.OnConnected();
    }


    public override Task OnDisconnected(bool stopCalled)
    {
      Console.WriteLine("connected");

      return base.OnDisconnected(stopCalled);
    }
  }
}
