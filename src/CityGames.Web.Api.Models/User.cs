using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGames.Web.Api.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string lastname { get; set; }
    }
}
