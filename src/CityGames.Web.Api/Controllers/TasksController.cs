using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityGames.Web.Api.Controllers
{
    [RoutePrefix("api/employeeTasks")]
    public class TasksController : ApiController
    {
        //[Route("{id:int}")]
        //public string Get(int id)
        //{
        //    return "In the Get(int id) overload, id = " + id;
        //}

        [Route("{id:int:max(100)}")]
        public string GetMaxId100(int id)
        {
            return "In the GetMAXID100(int id) overload, id = " + id;
        }

        [Route("{id:int:min(101)}")]
        [HttpGet]
        public string FindMinId101(int id)
        {
            return "In the FINDMIN101(int id) overload, id = " + id;
        }

        [Route("{taskName:alpha}")]
        public string Get(string taskName)
        {
            return "In the Get(string taskName), taskName =" + taskName;
        }
    }
}
