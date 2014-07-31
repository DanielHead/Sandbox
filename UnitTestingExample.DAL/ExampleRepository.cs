using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingExample.Models;
using UnitTestingExample.Models.Database;

namespace UnitTestingExample.DAL
{
    public class ExampleRepository
    {
        private static ISessionFactory _sessionFactory;
                    
        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("db"))
                )                                                              //  Data Source=(LocalDB)\v11.0;AttachDbFilename="C:\Users\Dan2\documents\visual studio 2013\Projects\UnitTestingExample.UI\UnitTestingExample.UI\App_Data\TestDatabase.mdf";Integrated Security=True
                .Mappings(m => m.AutoMappings.Add(
                    AutoMap.AssemblyOf<Table>().Where(t => t.Namespace == "UnitTestingExample.Models.Database")
                    )).BuildSessionFactory();

        }



        public int Count<T>()
        {

            using (var session = SessionFactory.OpenSession())
            {

                return session.Query<T>().Count();

            }

        }
    }
}
