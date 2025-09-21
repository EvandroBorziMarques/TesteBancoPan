using MediatR;
using Domain.Ports;
using Domain.Entities.PessoaFisica;
using Domain.Entities.PessoaJuridica;
using Domain.Abstraction;

namespace Application.Pessoa.Update
{
    internal sealed class UpdatePessoaCommandHandler : IRequestHandler<UpdatePessoaCommand, PessoaResponse>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public UpdatePessoaCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<PessoaResponse> Handle(UpdatePessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.GetById(request.Id);

            pessoa.Endereco.Update(request.Cep, request.Logradouro, request.Complemento, request.Unidade, request.Bairro, request.Localidade, request.Uf, request.Estado, request.Regiao, request.Ibge, request.Gia, request.Ddd, request.Siafi);

            if (pessoa is PessoaFisica fisica)
            {
                fisica.Update(request.Nome, request.Telefone, TipoPessoa.Fisica, pessoa.Endereco, request.Cpf, Convert.ToDateTime(request.DataNascimento));
            }
            else if (pessoa is PessoaJuridica juridica)
            {
                juridica.Update(request.Nome, request.Telefone, TipoPessoa.Juridica, pessoa.Endereco, request.Cnpj, request.RazaoSocial);
            }

            var pessoaAtualizada = await _pessoaRepository.Update(pessoa);

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
