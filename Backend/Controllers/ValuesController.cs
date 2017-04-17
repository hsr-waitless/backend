using System.Collections.Generic;
using System.Linq;
using Backend.Hubs;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Database.Models;
using Microsoft.AspNetCore.SignalR.Infrastructure;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IConnectionManager connectionManager;

        public ValuesController(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        // GET api/values
        [HttpGet]
        public void Get(Mode mode)
        {
            var hubContext = connectionManager.GetHubContext<TabletHub>();
            hubContext.Clients.All.OnAssignedTablet(mode);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
