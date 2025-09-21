using MediatR;
using Application.Pessoa.Get;
using Application.Pessoa.Delete;
using Application.Pessoa.Insert;
using Application.Pessoa.Update;

namespace API.Controllers.Pessoa
{
    public static class PessoaEndpoints
    {
        public static IEndpointRouteBuilder MapPessoaEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("pessoa", GetAllPessoas);

            builder.MapPost("pessoa", InsertPessoa);

            builder.MapPut("pessoa/{id}", UpdatePessoa);

            builder.MapDelete("pessoa", DeletePessoa);

            return builder;
        }

        public static async Task<IResult> GetAllPessoas(ISender sender, CancellationToken cancellationToken)
        {
            var query = new GetAllPessoasQuery();
            var result = await sender.Send(query, cancellationToken);

            return Results.Ok(result);
        }

        public static async Task<IResult> InsertPessoa(AddPessoaRequest request,ISender sender, CancellationToken cancellationToken)
        {
            var query = new InsertPessoaCommand(
                request.Nome, 
                request.Telefone, 
                request.TipoPessoa, 
                request.Cpf, 
                request.DataNascimento, 
                request.Cnpj, 
                request.RazaoSocial, 
                request.Endereco.Cep,
                request.Endereco.Logradouro,
                request.Endereco.Complemento,
                request.Endereco.Unidade,
                request.Endereco.Bairro,
                request.Endereco.Localidade,
                request.Endereco.Uf,
                request.Endereco.Estado,
                request.Endereco.Regiao,
                request.Endereco.Ibge,
                request.Endereco.Gia,
                request.Endereco.DDD,
                request.Endereco.Siafi
            );

            var result = await sender.Send(query, cancellationToken);

            return Results.Ok(result);
        }

        public static async Task<IResult> UpdatePessoa(Guid id, AddPessoaRequest request, ISender sender, CancellationToken cancellationToken)
        {
            var query = new UpdatePessoaCommand(
                id,
                request.Nome,
                request.Telefone,
                request.TipoPessoa,
                request.Cpf,
                request.DataNascimento,
                request.Cnpj,
                request.RazaoSocial,
                request.Endereco.Cep,
                request.Endereco.Logradouro,
                request.Endereco.Complemento,
                request.Endereco.Unidade,
                request.Endereco.Bairro,
                request.Endereco.Localidade,
                request.Endereco.Uf,
                request.Endereco.Estado,
                request.Endereco.Regiao,
                request.Endereco.Ibge,
                request.Endereco.Gia,
                request.Endereco.DDD,
                request.Endereco.Siafi
            );

            var result = await sender.Send(query, cancellationToken);

            return Results.Ok(result);
        }

        public static async Task<IResult> DeletePessoa(Guid id ,ISender sender, CancellationToken cancellationToken)
        {
            var queryPessoa = new DeletePessoaCommand(id);
            var resultPessoa = await sender.Send(queryPessoa, cancellationToken);

            if (resultPessoa.Equals(null))
                return Results.BadRequest();

            return Results.Ok($"{resultPessoa.Nome} Deletado com sucesso");
        }
    }
}
