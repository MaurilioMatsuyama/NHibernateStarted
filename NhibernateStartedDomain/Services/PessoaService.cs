using NhibernateStartedDomain.Entities;
using NhibernateStartedDomain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NhibernateStarted.Services
{
    public class PessoaService 
    {
        private readonly IRepository<Pessoa> _repository;

        public PessoaService(IRepository<Pessoa> repository)
        {
            _repository = repository;
        }

        public Pessoa GetPessoaById(long id)
        {
            var pessoa = _repository.Get(id);
            return pessoa;
        }

        public List<Pessoa> GetAll()
        {
            var pessoas =  _repository.GetAll();
            return pessoas;
            
        }
    }
}
