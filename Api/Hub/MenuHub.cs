using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs; 
using System.Threading.Tasks;

namespace Api
{
	[HubName("menuhub")]
	public class MenuHub : Hub
	{
		public void GetMenuRequest()
		{
			//Clients.All.addNewMessageToPage(name, message);
			var menus = new object[] { 
				new { Name = "Vorspeisen", Order = 1 },
				new { Name = "Hauptspeisen", Order = 2 }
			};
			Clients.Caller.GetMenuResponse(menus);
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
