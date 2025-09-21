using Domain.Abstraction;
using Domain.Entities.PessoaFisica;
using Domain.Entities.PessoaJuridica;
using Domain.Ports;
using MediatR;

namespace Application.Pessoa.Get
{
    internal sealed class GetAllPessoasQueryHandler : IRequestHandler<GetAllPessoasQuery, List<PessoaResponse>>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public GetAllPessoasQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<List<PessoaResponse>> Handle(GetAllPessoasQuery request, CancellationToken cancellationToken)
        {
            var pessoas = await _pessoaRepository.GetAll();

            var response = pessoas.Select(p => new PessoaResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                Telefone = p.Telefone,
                Endereco = p.Endereco != null ? p.Endereco : null,
                TipoPessoa = p is PessoaFisica ? (int)TipoPessoa.Fisica : (int)TipoPessoa.Juridica,
                Cpf = p is PessoaFisica cpf ? cpf.Cpf : null,
                DataNascimento = p is PessoaFisica datanascimento ? datanascimento.DataNascimento : null,
                Cnpj = p is PessoaJuridica cnpj ? cnpj.Cnpj : null,
                RazaoSocial = p is PessoaJuridica razaoSocial ? razaoSocial.RazaoSocial : null,
            }).ToList();

            return response;
        }
    }
}
