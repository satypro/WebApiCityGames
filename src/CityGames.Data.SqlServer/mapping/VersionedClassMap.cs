using CityGames.Data.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGames.Data.SqlServer
{
    public abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedEntity
    {
        protected VersionedClassMap()
        {
            Version(x => x.Version)
                .Column("ts")
                .CustomSqlType("RowVersion")
                .Generated.Always()
                .UnsavedValue("null");
        
        }
    }
}
