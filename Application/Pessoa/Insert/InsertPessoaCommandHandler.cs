using Domain.Abstraction;
using Domain.Entities.PessoaFisica;
using Domain.Entities.PessoaJuridica;
using Domain.Ports;
using MediatR;

namespace Application.Pessoa.Insert
{
    internal sealed class InsertPessoaCommandHandler : IRequestHandler<InsertPessoaCommand, PessoaResponse>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICepService _cepService;

        public InsertPessoaCommandHandler(IPessoaRepository pessoaRepository, ICepService cepService)
        {
            _pessoaRepository = pessoaRepository;
            _cepService = cepService;
        }

        public async Task<PessoaResponse> Handle(InsertPessoaCommand request, CancellationToken cancellationToken)
        {
            Domain.Abstraction.Pessoa pessoa;
            Domain.Entities.Endereco.Endereco endereco;

            var consulta = await _cepService.BuscarPorCepAsync(request.Cep);

            if (consulta != null)
                endereco = Domain.Entities.Endereco.Endereco.Create(
                    request.Cep,
                    string.IsNullOrWhiteSpace(request.Logradouro) ? consulta.Logradouro : request.Logradouro,
                    string.IsNullOrWhiteSpace(request.Complemento) ? consulta.Complemento : request.Complemento,
                    string.IsNullOrWhiteSpace(request.Unidade) ? consulta.Unidade : request.Unidade,
                    string.IsNullOrWhiteSpace(request.Bairro) ? consulta.Bairro : request.Bairro,
                    string.IsNullOrWhiteSpace(request.Localidade) ? consulta.Localidade : request.Localidade,
                    string.IsNullOrWhiteSpace(request.Uf) ? consulta.Uf : request.Uf,
                    string.IsNullOrWhiteSpace(request.Estado) ? consulta.Estado : request.Estado,
                    string.IsNullOrWhiteSpace(request.Regiao) ? consulta.Regiao : request.Regiao,
                    string.IsNullOrWhiteSpace(request.Ibge) ? consulta.Ibge : request.Ibge,
                    string.IsNullOrWhiteSpace(request.Gia) ? consulta.Gia : request.Gia,
                    string.IsNullOrWhiteSpace(request.Ddd) ? consulta.DDD : request.Ddd,
                    string.IsNullOrWhiteSpace(request.Siafi) ? consulta.Siafi : request.Siafi);
            else
                endereco = Domain.Entities.Endereco.Endereco.Create(request.Cep, request.Logradouro, request.Complemento, request.Unidade, request.Bairro, request.Localidade, request.Uf, request.Estado, request.Regiao, request.Ibge, request.Gia, request.Ddd, request.Siafi);

            if (request.TipoPessoa.Equals((int)TipoPessoa.Fisica))
                pessoa = PessoaFisica.Create(request.Nome, request.Telefone, Domain.Abstraction.TipoPessoa.Fisica, endereco, request.Cpf, Convert.ToDateTime(request.DataNascimento));
            else
                pessoa = PessoaJuridica.Create(request.Nome, request.Telefone, Domain.Abstraction.TipoPessoa.Juridica, endereco, request.Cnpj, request.RazaoSocial);

            var pessoaInserida = await _pessoaRepository.Insert(pessoa);

            return new PessoaResponse
            {
                Id = pessoaInserida.Id,
                Nome = pessoaInserida.Nome,
                Telefone = pessoaInserida.Telefone,
                Endereco = pessoaInserida.Endereco != null ? pessoaInserida.Endereco : null,
                TipoPessoa = pessoaInserida is PessoaFisica ? (int)Domain.Abstraction.TipoPessoa.Fisica : (int)Domain.Abstraction.TipoPessoa.Juridica,
                Cpf = pessoaInserida is PessoaFisica cpf ? cpf.Cpf : null,
                DataNascimento = pessoaInserida is PessoaFisica datanascimento ? datanascimento.DataNascimento : null,
                Cnpj = pessoaInserida is PessoaJuridica cnpj ? cnpj.Cnpj : null,
                RazaoSocial = pessoaInserida is PessoaJuridica razaoSocial ? razaoSocial.RazaoSocial : null,
            };
        }
    }
}
