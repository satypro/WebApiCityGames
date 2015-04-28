using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGames.Data.Entities
{
    public class User
    {
        public virtual long UserId { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Secondname { get; set; }
        public virtual string Username { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
