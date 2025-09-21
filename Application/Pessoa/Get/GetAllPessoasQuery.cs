using MediatR;

namespace Application.Pessoa.Get
{
    public sealed record GetAllPessoasQuery() : IRequest<List<PessoaResponse>>;
}
