using MediatR;

namespace Application.Pessoa.Get
{
    public sealed record GetPessoaByIdQuery(Guid Id) : IRequest<PessoaResponse>;
}
