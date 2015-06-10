using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace CityGames.Web.Common
{
    public static class WebContainerManager
    {

        public static IDependencyResolver GetDependencyResolver()
        {

            var dependencyResolver = GlobalConfiguration.Configuration.DependencyResolver;

            if (dependencyResolver != null)
            {
                return dependencyResolver;
            }

            throw new InvalidOperationException("The Dependency Resolver has not been set");
        }

        public static T Get<T>()
        {
            var service = GetDependencyResolver().GetService(typeof(T));

            if (service == null)
            {
                throw new NullReferenceException(String.Format("Requested Service of type: {0}, but null was found", typeof(T).FullName));
            }

            return (T)service;
        
        }

        public static IEnumerable<T> GetAll<T>()
        {

            var services = GetDependencyResolver().GetServices(typeof(T));

            if (!services.Any())
            {
                throw new NullReferenceException(String.Format("Requested services of type: {}, but none were found", typeof(T).FullName));
            }

            return services.Cast<T>();
        }



    }
}
