using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.Pessoa
{
    public sealed record AddPessoaRequest
    {
        public string Nome { get; init; }
        public string Telefone { get; init; }
        public int TipoPessoa { get; init; }
        public string? Cpf { get; init; }
        public string? DataNascimento { get; init; }
        public string? Cnpj { get; init; }
        public string? RazaoSocial { get; init; }
        public AddEnderecoRequest Endereco { get; init; }
        
    }
}


