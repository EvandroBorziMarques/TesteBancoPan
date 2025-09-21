using Domain.Entities.Endereco;
using System.ComponentModel.DataAnnotations;

namespace Domain.Abstraction
{
    public abstract class Pessoa
    {
        public Guid Id { get; set; }
        [MaxLength(256)]
        public string Nome { get; set; }
        [MaxLength(20)]
        public string? Telefone { get; set; }  
        public TipoPessoa TipoPessoa { get; set; }
        [MaxLength(256)]
        public Endereco? Endereco { get; set; }

        protected Pessoa() { }

        protected Pessoa(Guid id, string nome, string? telefone, TipoPessoa tipoPessoa, Endereco? endereco)
        {
            Id = id;
            SetNome(nome);
            Telefone = telefone;
            TipoPessoa = tipoPessoa;
            Endereco = endereco;
        }

        private void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");
            Nome = nome;
        }
    }    
}
