using System.Collections.Generic;
using System.Linq;
using Backend.Hubs;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Database;
using Database.Models;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IConnectionManager connectionManager;
        private readonly WaitlessContext context;

        public ValuesController(IConnectionManager connectionManager, WaitlessContext context)
        {
            this.connectionManager = connectionManager;
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public void Get(Mode mode)
        {
            var hubContext = connectionManager.GetHubContext<TabletHub>();
            hubContext.Clients.All.OnAssignedTablet(mode);
        }

        // GET api/values
        [HttpGet]
        [Route("migrate")]
        public void Migrate()
        {
            context.Database.Migrate();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
