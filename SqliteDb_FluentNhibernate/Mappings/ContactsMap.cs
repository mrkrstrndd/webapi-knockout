using SqliteDb_FluentNhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentNHibernate.Mapping;
using FluentNHibernate.Conventions;

namespace SqliteDb_FluentNhibernate.Mappings
{
    public class ContactsMap : ClassMap<Contacts>
    {
        public ContactsMap() {
            Id(x => x.ContactId).GeneratedBy.Identity();
            Map(x => x.ContactName).Length(20).Not.Nullable();
            Map(x => x.ContactAddress).Length(30).Not.Nullable();
        }
    }
}