using NhibernateStartedDomain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace NhibernateStartedDomain.Entities
{
    public class Pessoa : IEntity
    {
        public long Id { get; set; }

        [Required(ErrorMessage ="Campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Idade é obrigatório")]
        public int Idade { get; set; }
    }
}
