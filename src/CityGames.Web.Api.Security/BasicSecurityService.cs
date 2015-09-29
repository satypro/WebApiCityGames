using System;
using System.Web;
using System.Security.Principal;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using CityGames.Web.Common;
using CityGames.Data.Entities;

namespace CityGames.Web.Api.Security
{
    public class BasicSecurityService : IBasicSecurityService
    {
      
        bool SetPrincipal(string username, string password)
        {
            throw new NotImplementedException();
        }

        public virtual ISession  Session
        {
            get {return WebContainerManager.Get<ISession>();}
        }

        //public bool SetPrincipal(string username, string password)
        //{
        //    var user = GetUser(username);

        //    IPrincipal principal = null;
        //    //if(user == null || ())
        
        
        //}


        //public virtual GetPrincipal(User user)
        //{
        //   var identity = new GenericIdentity(user.Username,user)
        
        //}

        public virtual User GetUser(string username)
        {
            username = username.ToLowerInvariant();
            return
                Session.QueryOver<User>().Where(x => x.Username == username).SingleOrDefault();
        }
    }
}
