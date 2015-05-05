using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SqliteDb_FluentNhibernate.Models
{
    public class Contacts
    {
        public virtual int ContactId { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactAddress { get; set; }
    }
}