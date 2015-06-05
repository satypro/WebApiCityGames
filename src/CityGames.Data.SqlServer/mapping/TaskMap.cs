using CityGames.Data.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityGames.Data.SqlServer.mapping
{
    public class TaskMap : VersionedClassMap<Task>
    {
        public TaskMap()
        {
            Id(x => x.TaskId);
            Map(x => x.Subject).Not.Nullable();
            Map(x => x.StartDate).Not.Nullable();
            Map(x => x.DueDate).Not.Nullable();
            Map(x => x.CompleteDate).Not.Nullable();
            Map(x => x.CreatedDate).Not.Nullable();

            References(x => x.Status, "StatusId");
            References(x => x.CreatedBy, "UserId");

            HasManyToMany(x => x.Users)
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                .Table("TaskUser")
                .ParentKeyColumn("TaskId")
                .ChildKeyColumn("UserId");
        
        }

    }
}
