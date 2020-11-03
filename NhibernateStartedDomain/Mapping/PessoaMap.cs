using FluentNHibernate.Mapping;
using NhibernateStartedDomain.Entities;

namespace NhibernateStartedDomain.Mapping
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            Map(x => x.Idade);
        }
    }
}
