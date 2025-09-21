using Application.Abstraction;
using MediatR;

namespace Application.Pessoa.Update
{
    public sealed record UpdatePessoaCommand(
        Guid Id,
        string Nome,
        string Telefone,
        int TipoPessoa,
        string? Cpf,
        string? DataNascimento,
        string? Cnpj,
        string? RazaoSocial,
        string Cep,
        string Logradouro,
        string Complemento,
        string Unidade,
        string Bairro,
        string Localidade,
        string Uf,
        string Estado,
        string Regiao,
        string Ibge,
        string Gia,
        string Ddd,
        string Siafi) : IRequest<PessoaResponse>, IPessoaCommand;
}
