using MediatR;

namespace Application.Endereco.Delete
{
    public sealed record DeleteEnderecoCommand(Guid id) : IRequest<EnderecoResponse>;
}
