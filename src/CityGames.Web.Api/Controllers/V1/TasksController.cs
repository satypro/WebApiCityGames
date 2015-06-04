using CityGames.Web.Api.Models;
using CityGames.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityGames.Web.Api.Controllers.V1
{
    //[RoutePrefix("apiVersion:apiVersionConstraint(v1)")]
    [ApiVersion1RoutePrefix("tasks")]
    public class TasksController : ApiController
    {
        [Route("", Name = "AddTaskRouteV1")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, Models.Task newTask)
        {

            return new Task
            {

                Subject = "In V1, newtask.Subject = " + newTask.Subject
            };

        }


    }
}
