using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGames.Web.Common
{
    public class ActionTransactionHelper : IActionTransactionHelper
    {
        private readonly ISessionFactory _sessionFactory;

        public ActionTransactionHelper(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public bool TransactionHandeled { get; private set; }

        public bool SessionClosed { get; private set; }


        public void BeginTransaction()
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory)) return;

            var session = _sessionFactory.GetCurrentSession();
            if (session != null)
            {
                session.BeginTransaction();
            }
        }

        public void EndTransaction(System.Web.Http.Filters.HttpActionExecutedContext filterContext)
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory)) return;

            var session = _sessionFactory.GetCurrentSession();

            if (session == null) return;
            if (!session.Transaction.IsActive) return;

            if (filterContext.Exception == null)
            {
                session.Flush();
                session.Transaction.Commit();
            }
            else
            {
                session.Transaction.Rollback();
            }

            TransactionHandeled = true;
        }

        public void CloseSession()
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory)) return;

            var session = _sessionFactory.GetCurrentSession();
            session.Dispose();
            CurrentSessionContext.Unbind(_sessionFactory);
            SessionClosed = true;

        }
    }
}
