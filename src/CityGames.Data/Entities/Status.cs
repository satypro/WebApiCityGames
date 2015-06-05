using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGames.Data.Entities
{
    public class Status : IVersionedEntity
    {
        public virtual long StatusId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Ordinal { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
