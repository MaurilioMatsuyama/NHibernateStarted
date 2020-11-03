using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Linq;
using System.Reflection;

namespace NhibernateStarted.Repository
{
    public class ConfigNhibernate
    {
        //Cria a session factory
        public static ISessionFactory CreateSessionFactory()
        {
            return GetFluentConfiguration().BuildSessionFactory();
        }

        //Cria um novo schema
        public static void CreateSchema(bool execute = false)
        {
            var cfg = GetFluentConfiguration().BuildConfiguration();
            var schema = new SchemaExport(cfg);
            schema.Create(true, true);
        }

        //Pega a configuração do fluent
        public static FluentConfiguration GetFluentConfiguration()
        {
            var fluent = Fluently.Configure()
            .Database(PostgreSQLConfiguration.Standard
            .ConnectionString(c => c
            .Host("localhost")
            .Port(5432)
            .Database("nhibernatebd")
            .Username("postgres")
            .Password("teste")))
            .ExposeConfiguration(cfg => cfg.Properties.Add("use_proxy_validator", "false"))
            .Mappings(x => x.FluentMappings.AddFromAssembly(GetMappingAssembly()));

            return fluent;
        }

        //Pega o assembly dos mapeamentos
        private static Assembly GetMappingAssembly()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(x => x.GetName().Name == "NhibernateStartedDomain");
            return assembly;
        }
    }
}