using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Threading.Tasks;
using System;
using System.Linq;
using Backend.Commands;
using Backend.Models;

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

    public void GetSubMenuRequest(int id)
    {

    }

    public void GetItemTypeRequest(int id)
    {

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
