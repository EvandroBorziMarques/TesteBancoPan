using MediatR;
using Domain.Ports;

namespace Application.Endereco.Delete
{
    internal sealed class DeleteEnderecoCommandHandler : IRequestHandler<DeleteEnderecoCommand, EnderecoResponse>
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public DeleteEnderecoCommandHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<EnderecoResponse> Handle(DeleteEnderecoCommand request, CancellationToken cancellationToken)
        {
            var endereco  = await _enderecoRepository.Delete(request.id);

            var response = new EnderecoResponse
            {
                Id = endereco.Id,
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Complemento = endereco.Complemento,
                Unidade = endereco.Unidade,
                Bairro = endereco.Bairro,
                Localidade = endereco.Localidade,
                Uf = endereco.Uf,
                Estado = endereco.Estado,
                Regiao = endereco.Regiao,
                Ibge = endereco.Ibge,
                Gia = endereco.Gia,
                DDD = endereco.DDD,
                Siafi = endereco.Siafi
            };

            return response;
        }
    }
}
