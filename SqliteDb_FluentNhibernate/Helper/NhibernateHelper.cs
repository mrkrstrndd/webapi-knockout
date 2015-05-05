using SqliteDb_FluentNhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using SqliteDb_FluentNhibernate.Mappings;


namespace SqliteDb_FluentNhibernate.Helper
{
    public class NhibernateHelper
    {

        private static ISessionFactory _sessionFactory;
        public static ISession OpenSession() {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    CreateSessionFactory();
                }
                return _sessionFactory;
            }
        }
        
        private static void CreateSessionFactory() {
            _sessionFactory =  Fluently.Configure()
                   .Database(
                     SQLiteConfiguration.Standard
                       .ConnectionString(cfg => cfg.FromConnectionStringWithKey("SqliteConnection"))
                   )
                   .Mappings(
                       contactMap => contactMap.FluentMappings.Add<ContactsMap>()
                   )
                   .ExposeConfiguration(
                        //cfg => new SchemaExport(cfg).Create(false, true)
                        BuildSchema
                   )
                   .BuildSessionFactory(); 
        }

        private static void BuildSchema(Configuration config) {
            string fileDatabase = HttpContext.Current.Server.MapPath("~") + @"\App_Data\markdb.sqlite";
            if (!File.Exists(fileDatabase))
                new SchemaExport(config).Create(false, true);
            
        }
    }
}