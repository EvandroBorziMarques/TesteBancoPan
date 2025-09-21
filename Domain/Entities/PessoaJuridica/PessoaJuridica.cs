using Domain.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.PessoaJuridica
{
    public class PessoaJuridica : Pessoa
    {
        protected PessoaJuridica() { }

        private PessoaJuridica(Guid id, string nome, string? telefone, TipoPessoa tipoPessoa, Endereco.Endereco endereco, string? cnpj, string? razaoSocial)
        : base(id, nome, telefone, tipoPessoa, endereco)
        {
            SetCnpj(cnpj);
            SetRazaoSocial(razaoSocial);
        }

        [MaxLength(14)]
        public string? Cnpj { get; private set; }

        [MaxLength(256)]
        public string? RazaoSocial { get; private set; }

        public static PessoaJuridica Create(string nome, string? telefone, TipoPessoa tipoPessoa, Endereco.Endereco endereco,  string? cnpj, string? razaosocial)
        {
            return new PessoaJuridica( Guid.NewGuid(), nome, telefone, tipoPessoa, endereco, cnpj, razaosocial);
        }

        public void Update(string nome, string? telefone, TipoPessoa tipoPessoa, Endereco.Endereco endereco, string? cnpj, string? razaosocial)
        {
            Nome = nome;
            Telefone = telefone;
            TipoPessoa = tipoPessoa;
            Endereco = endereco;
            Cnpj = cnpj;
            RazaoSocial = razaosocial;
        }

        private void SetCnpj(string? cnpj)
        {
            if (!string.IsNullOrEmpty(cnpj) && cnpj.Length != 14)
                throw new ArgumentException("CNPJ deve ter 14 caracteres.");
            Cnpj = cnpj;
        }

        private void SetRazaoSocial(string? razaoSocial)
        {
            if (razaoSocial.Length > 256)
                throw new ArgumentException("Data de nascimento não pode ser no futuro.");
            RazaoSocial = razaoSocial;
        }
    }    
}
