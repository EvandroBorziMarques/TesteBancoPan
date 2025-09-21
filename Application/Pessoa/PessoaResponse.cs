namespace Application.Pessoa
{
    public sealed class PessoaResponse
    {
        public Guid Id { get; init; }
        public string Nome { get; init; }
        public string? Telefone { get; init; }
        public int TipoPessoa { get; init; }
        public string? Cpf { get; init; }
        public DateTime? DataNascimento { get; init; }
        public string? Cnpj { get; init; }
        public string? RazaoSocial { get; init; }
        public Domain.Entities.Endereco.Endereco? Endereco { get; init; }
    }
}
