namespace Application.Abstraction
{
    public interface IPessoaCommand
    {
        string Nome {get; }
        string Telefone {get; }
        int TipoPessoa {get; }
        string? Cpf {get; }
        string? DataNascimento {get; }
        string? Cnpj {get; }
        string? RazaoSocial {get; }
        string Cep {get; }
        string Logradouro {get; }
        string Complemento {get; }
        string Unidade {get; }
        string Bairro {get; }
        string Localidade {get; }
        string Uf {get; }
        string Estado {get; }
        string Regiao {get; }
        string Ibge {get; }
        string Gia {get; }
        string Ddd {get; }
        string Siafi { get; }
    }

}
