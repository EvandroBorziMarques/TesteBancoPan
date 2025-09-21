using Domain.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.PessoaFisica
{
    public class PessoaFisica : Pessoa
    {
        protected PessoaFisica() { }

        private PessoaFisica(Guid id, string nome, string? telefone, TipoPessoa tipoPessoa, Endereco.Endereco? endereco, string? cpf, DateTime? dataNascimento)
        : base(id, nome, telefone, tipoPessoa, endereco)
        {
            SetCpf(cpf);
            SetDataNascimento(dataNascimento);
        }

        [MaxLength(11)]
        public string? Cpf { get; set; }

        public DateTime? DataNascimento { get; set; }

        public static PessoaFisica Create(string nome, string? telefone, TipoPessoa tipoPessoa, Endereco.Endereco endereco, string? cpf, DateTime? dataNascimento)
        {
            return new PessoaFisica(Guid.NewGuid(), nome, telefone, tipoPessoa, endereco, cpf, dataNascimento);
        }

        public void Update(string nome, string? telefone, TipoPessoa tipoPessoa, Endereco.Endereco endereco, string? cpf, DateTime? dataNascimento)
        {
            Nome = nome;
            Telefone = telefone;
            TipoPessoa = tipoPessoa;
            Endereco = endereco;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }        

        private void SetCpf(string? cpf)
        {
            if (!string.IsNullOrEmpty(cpf) && cpf.Length != 11)
                throw new ArgumentException("CPF deve ter 11 caracteres.");
            Cpf = cpf;
        }

        private void SetDataNascimento(DateTime? dataNascimento)
        {
            if (dataNascimento.HasValue && dataNascimento.Value > DateTime.Now)
                throw new ArgumentException("Data de nascimento não pode ser no futuro.");
            DataNascimento = dataNascimento;
        }
    }
}
