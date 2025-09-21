using FluentValidation;
using Application.Abstraction;

public class PessoaCommandValidator<T> : AbstractValidator<T> where T : IPessoaCommand
{
    public PessoaCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Telefone)
            .MaximumLength(20).WithMessage("Telefone deve ter no máximo 20 caracteres.");

        RuleFor(x => x.TipoPessoa)
            .Must(tipo => tipo == 1 || tipo == 2)
            .WithMessage("TipoPessoa deve ser 1 (Pessoa Física) ou 2 (Pessoa Jurídica).");

        RuleFor(x => x.Cpf)
            .NotEmpty().When(x => x.TipoPessoa == 1)
            .WithMessage("CPF é obrigatório para Pessoa Física.")
            .Matches(@"^\d{11}$").When(x => x.TipoPessoa == 1 && !string.IsNullOrWhiteSpace(x.Cpf))
            .WithMessage("CPF deve conter 11 dígitos numéricos.");

        RuleFor(x => x.DataNascimento)
            .NotEmpty().When(x => x.TipoPessoa == 1)
            .WithMessage("Data de nascimento é obrigatória para Pessoa Física.")
            .Matches(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$")
            .When(x => x.TipoPessoa == 1 && !string.IsNullOrWhiteSpace(x.DataNascimento))
            .WithMessage("Data de nascimento deve estar no formato DD/MM/YYYY.");

        RuleFor(x => x.Cnpj)
            .NotEmpty()
            .When(x => x.TipoPessoa == 2)
            .WithMessage("CNPJ é obrigatório para Pessoa Jurídica.")
            .Matches(@"^\d{14}$")
            .When(x => x.TipoPessoa == 2 && !string.IsNullOrWhiteSpace(x.Cnpj))
            .WithMessage("CNPJ deve conter 14 dígitos numéricos.");

        RuleFor(x => x.RazaoSocial)
            .NotEmpty()
            .When(x => x.TipoPessoa == 2)
            .WithMessage("Razão social é obrigatória para Pessoa Jurídica.");

        RuleFor(x => x.Cep)
            .NotEmpty().WithMessage("CEP é obrigatório.")
            .Matches(@"^\d{8}$").WithMessage("CEP deve conter 8 dígitos numéricos.");

        RuleFor(x => x.Logradouro)
            .MaximumLength(256).WithMessage("Logradouro deve ter no máximo 256 caracteres.");

        RuleFor(x => x.Complemento)
            .MaximumLength(256).WithMessage("Complemento deve ter no máximo 256 caracteres.");

        RuleFor(x => x.Unidade)
            .MaximumLength(256).WithMessage("Unidade deve ter no máximo 256 caracteres.");

        RuleFor(x => x.Bairro)
            .MaximumLength(100).WithMessage("Bairro deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Localidade)
            .MaximumLength(256).WithMessage("Localidade deve ter no máximo 256 caracteres.");        

        RuleFor(x => x.Uf)
            .MaximumLength(2).WithMessage("UF deve ter 2 letras maiúsculas.");

        RuleFor(x => x.Estado)
            .MaximumLength(256).WithMessage("Estado deve ter no máximo 256 caracteres.");

        RuleFor(x => x.Regiao)
            .MaximumLength(256).WithMessage("Regiao deve ter no máximo 256 caracteres.");

        RuleFor(x => x.Ibge)
            .MaximumLength(50).WithMessage("Ibge deve ter no máximo 50 caracteres.");

        RuleFor(x => x.Gia)
            .MaximumLength(50).WithMessage("Gia deve ter no máximo 50 caracteres.");

        RuleFor(x => x.Ddd)
            .MaximumLength(3).WithMessage("DDD deve ter 2 letras maiúsculas.");

        RuleFor(x => x.Siafi)
            .MaximumLength(50).WithMessage("Siafi deve ter no máximo 50 caracteres.");
    }
}
