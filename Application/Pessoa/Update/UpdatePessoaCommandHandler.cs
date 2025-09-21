using MediatR;
using Domain.Ports;
using Domain.Abstraction;
using FluentValidation;
using Domain.Entities.PessoaFisica;
using Domain.Entities.PessoaJuridica;

namespace Application.Pessoa.Update
{
    internal sealed class UpdatePessoaCommandHandler : IRequestHandler<UpdatePessoaCommand, PessoaResponse>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICepService _cepService;
        private readonly IValidator<UpdatePessoaCommand> _validator;

        public UpdatePessoaCommandHandler(IPessoaRepository pessoaRepository, ICepService cepService, IValidator<UpdatePessoaCommand> validator)
        {
            _pessoaRepository = pessoaRepository;
            _cepService = cepService;
            _validator = validator;
        }

        public async Task<PessoaResponse> Handle(UpdatePessoaCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var pessoa = await _pessoaRepository.GetById(request.Id);
            Domain.Entities.Endereco.Endereco endereco;

            if (pessoa.Endereco.Cep.Equals(request.Cep))
                pessoa.Endereco.Update(request.Cep, request.Logradouro, request.Complemento, request.Unidade, request.Bairro, request.Localidade, request.Uf, request.Estado, request.Regiao, request.Ibge, request.Gia, request.Ddd, request.Siafi);
            else
            {
                var consulta = await _cepService.BuscarPorCepAsync(request.Cep);

                if (consulta != null)
                    pessoa.Endereco.Update(
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
                    pessoa.Endereco.Update(request.Cep, request.Logradouro, request.Complemento, request.Unidade, request.Bairro, request.Localidade, request.Uf, request.Estado, request.Regiao, request.Ibge, request.Gia, request.Ddd, request.Siafi);
            }

            if (pessoa is PessoaFisica fisica)
            {
                fisica.Update(request.Nome, request.Telefone, TipoPessoa.Fisica, pessoa.Endereco, request.Cpf, Convert.ToDateTime(request.DataNascimento));
            }
            else if (pessoa is PessoaJuridica juridica)
            {
                juridica.Update(request.Nome, request.Telefone, TipoPessoa.Juridica, pessoa.Endereco, request.Cnpj, request.RazaoSocial);
            }

            var pessoaAtualizada = await _pessoaRepository.Update(pessoa);

            if (pessoaAtualizada.Equals(null))
                return null;

            var response = new PessoaResponse
            {
                Id = pessoaAtualizada.Id,
                Nome = pessoaAtualizada.Nome,
                Telefone = pessoaAtualizada.Telefone,
                Endereco = pessoaAtualizada.Endereco != null ? pessoaAtualizada.Endereco : null,
                TipoPessoa = pessoaAtualizada is PessoaFisica ? (int)TipoPessoa.Fisica : (int)TipoPessoa.Juridica,
                Cpf = pessoaAtualizada is PessoaFisica cpf ? cpf.Cpf : null,
                DataNascimento = pessoaAtualizada is PessoaFisica datanascimento ? datanascimento.DataNascimento : null,
                Cnpj = pessoaAtualizada is PessoaJuridica cnpj ? cnpj.Cnpj : null,
                RazaoSocial = pessoaAtualizada is PessoaJuridica razaoSocial ? razaoSocial.RazaoSocial : null,
            };

            return response;
        }
    }
}
