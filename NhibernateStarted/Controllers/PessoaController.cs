using Microsoft.AspNetCore.Mvc;
using NhibernateStarted.Services;
using NhibernateStartedDomain.Entities;
using System.Collections.Generic;

namespace NhibernateStarted.Controllers
{
    [Route("api/pessoa")]
    public class PessoaController : Controller
    {
        private PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("{id}")]
        public Pessoa Get(long id)
        {
            return _pessoaService.GetPessoaById(id);
        }

        [HttpGet()]
        public List<Pessoa> GetAll()
        {
            return _pessoaService.GetAll();
        }
    }
}
