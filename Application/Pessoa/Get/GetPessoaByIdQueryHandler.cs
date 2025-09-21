using MediatR;
using Domain.Ports;
using Domain.Entities.PessoaFisica;
using Domain.Entities.PessoaJuridica;
using Domain.Abstraction;

namespace Application.Pessoa.Get
{
    internal sealed class GetPessoaByIdQueryHandler : IRequestHandler<GetPessoaByIdQuery, PessoaResponse>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public GetPessoaByIdQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<PessoaResponse> Handle(GetPessoaByIdQuery request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.GetById(request.Id);

            var response = new PessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Telefone = pessoa.Telefone,
                Endereco = pessoa.Endereco != null ? pessoa.Endereco : null,
                TipoPessoa = pessoa is PessoaFisica ? (int)TipoPessoa.Fisica : (int)TipoPessoa.Juridica,
                Cpf = pessoa is PessoaFisica cpf ? cpf.Cpf : null,
                DataNascimento = pessoa is PessoaFisica datanascimento ? datanascimento.DataNascimento : null,
                Cnpj = pessoa is PessoaJuridica cnpj ? cnpj.Cnpj : null,
                RazaoSocial = pessoa is PessoaJuridica razaoSocial ? razaoSocial.RazaoSocial : null,
            };

            return response;
        }
    }

}
