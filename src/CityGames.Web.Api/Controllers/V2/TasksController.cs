using CityGames.Web.Api.Models;
using CityGames.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityGames.Web.Api.Controllers.V2
{
    //[RoutePrefix("apiVersion:apiVersionConstraint(v1)")]
    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/tasks")]
    public class TasksController : ApiController
    {
        [Route("addTasks", Name="AddTaskRouteV2")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, Models.Task newTask) {

            return new Task
            {

                Subject = "In V2, newtask.Subject = " + newTask.Subject
            };
        
        }

        [Route("demo", Name = "CheckTaskRouteV2")]
        [HttpPost]
        public Task AddTask()
        {

            return new Task
            {

                Subject = "In V2, newtask.Subject = "
            };

        }
    }
}
