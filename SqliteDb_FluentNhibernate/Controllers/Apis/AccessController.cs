using SqliteDb_FluentNhibernate.Models.Repositories;
using SqliteDb_FluentNhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SqliteDb_FluentNhibernate.Controllers.Apis
{
    public class AccessController : ApiController
    {
        static readonly IContactsRepositories db = new ContactRepositories();

        // GET api/<controller>
        public IEnumerable<Contacts> Get()
        {           
            return db.GetAll();           
        }

        // GET api/<controller>/5
        public Contacts Get(int id)
        {
            return db.Get(id);
        }

        // POST api/<controller>
        public Contacts Post(Contacts contact)
        {
            if (db.Post(contact))
                return contact;
            else
                return null;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            if (db.Delete(id)) {
                return true;
            }
            return false;
        }
    }
}