using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using CityGames.Common;
using log4net.Config;
using CityGames.Common.Logging;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using CityGames.Data.SqlServer.mapping;
using NHibernate;
using Ninject.Activation;
using NHibernate.Context;

namespace CityGames.Web.Api.App_Start
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            ConfigureLog4net(container);
            ConfigureNHibernate(container);
            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
        }

        private void ConfigureLog4net(IKernel container)
        {
            XmlConfigurator.Configure();
            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }

        private void ConfigureNHibernate(IKernel container)
        {

            var sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("CityGamesDB")))
                                                     .CurrentSessionContext("web")
                                                     .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaskMap>())
                                                     .BuildSessionFactory();
            container.Bind<ISessionFactory>().ToConstant(sessionFactory);

        }

        private ISession CreateSession(IContext context)
        {
            var sessionFactory = context.Kernel.Get<ISessionFactory>();

            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }

            return sessionFactory.GetCurrentSession();
        }



    }
}