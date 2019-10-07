using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace jwtcoreapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            Service.jwthelper helper = new Service.jwthelper();
            return helper.jwtDecode();
        }
      
    }
}
