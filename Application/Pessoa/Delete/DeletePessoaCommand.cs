using MediatR;

namespace Application.Pessoa.Delete
{
    public sealed record DeletePessoaCommand(Guid id) : IRequest<PessoaResponse>;
}
