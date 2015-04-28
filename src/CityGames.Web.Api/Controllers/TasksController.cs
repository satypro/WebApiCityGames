using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityGames.Web.Api.Controllers
{
    public class TasksController : ApiController
    {
        [Route("api/tasks/{id:int}")]
        public string Get(int id)
        {
            return "In the Get(int id) overload, id = " + id;
        }
        
        [Route("api/tasks/{taskName:alpha}")]
        public string Get(string taskName)
        {
            return "In the Get(string taskName), taskName =" + taskName;
        }
    }
}
