using Domain.Abstraction;
using Domain.Entities.PessoaFisica;
using Domain.Entities.PessoaJuridica;
using Domain.Ports;
using MediatR;

namespace Application.Pessoa.Delete
{
    internal sealed class DeletePessoaCommandHandler : IRequestHandler<DeletePessoaCommand, PessoaResponse>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public DeletePessoaCommandHandler(IPessoaRepository pessoaRepository, IEnderecoRepository enderecoRepository)
        {
            _pessoaRepository = pessoaRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<PessoaResponse> Handle(DeletePessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.GetById(request.id);

            await _pessoaRepository.Delete(pessoa.Id);

            await _enderecoRepository.Delete(pessoa.Endereco.Id);

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
