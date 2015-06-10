using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace CityGames.Web.Common
{
    public class UnitOfWorkActionFilterAttribute: ActionFilterAttribute
    {
        public virtual IActionTransactionHelper ActionTransactionHelper
        {
            get { return WebContainerManager.Get<IActionTransactionHelper>(); }
        }

        public override bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            ActionTransactionHelper.BeginTransaction();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            ActionTransactionHelper.EndTransaction(actionExecutedContext);
            ActionTransactionHelper.CloseSession();
        }

    }
}
