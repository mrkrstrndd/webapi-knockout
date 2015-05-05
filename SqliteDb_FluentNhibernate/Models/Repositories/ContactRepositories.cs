using SqliteDb_FluentNhibernate.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NHibernate.Linq;
using System.Data.Entity.Infrastructure;

namespace SqliteDb_FluentNhibernate.Models.Repositories
{
    public class ContactRepositories : IContactsRepositories
    {
        public ContactRepositories() { 
        
        }

        //Get all Contact Records
        public IEnumerable<Contacts> GetAll() {
            using (var session = NhibernateHelper.OpenSession()) {
                return session.Query<Contacts>().ToList();
            }                
        }

        //Get specific Contact Record
        public Contacts Get(int id) {
            using (var session = NhibernateHelper.OpenSession()) {
                return session.Get<Contacts>(id);
            }
        }
        //Insert a new Contact Record
        public bool Post(Contacts contact) {
            using (var session = NhibernateHelper.OpenSession()) {
                using (var trnsction = session.BeginTransaction()) {
                    try
                    {
                        session.Save(contact);
                        trnsction.Commit();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        trnsction.Rollback();
                        return false;
                    }
                }
                return true;
            }
        }
        //Delete a specific Contact Record
        public bool Delete(int id) {
            var contactDetails = Get(id);
            using (var session = NhibernateHelper.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    try
                    {
                        session.Delete(contactDetails);
                        transaction.Commit();
                    } 
                    catch(DbUpdateConcurrencyException)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
        //Update a specific Contact Record
        public bool Update(Contacts contact) {
            using(var session = NhibernateHelper.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    try
                    {
                        session.SaveOrUpdate(contact);
                        transaction.Commit();
                    }
                    catch (DbUpdateConcurrencyException) {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return true;        
        }

   
         



         
    }
}