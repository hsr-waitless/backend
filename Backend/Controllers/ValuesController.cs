using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bussiness.Services;

namespace Backend.Controllers
{
  [Route("api/[controller]")]
    public class ValuesController : Controller
    {
    private MenuService service;
        public ValuesController(MenuService service)
    {
      this.service = service;
    }

        // GET api/values
        [HttpGet]
        public IEnumerable<object> Get()
        {
          return service.GetMenus();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
