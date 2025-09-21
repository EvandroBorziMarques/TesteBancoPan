using Domain.Abstraction;
using Domain.Entities.Endereco;
using Domain.Entities.PessoaJuridica;

namespace Domain.Test
{
    public class PessoaJuridicaTests
    {
        [Fact]
        public void Insert_Sucesso()
        {
            var endereco = Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107");
            var nome = "Nova Empresa";
            var telefone = "123456789";
            var tipoPessoa = TipoPessoa.Juridica;
            var cnpj = "42456524000131";
            var razaoSocial = "Nova Empresa LTDA";

            var pessoa = PessoaJuridica.Create(nome, telefone, tipoPessoa, endereco, cnpj, razaoSocial);

            Assert.NotEqual(Guid.Empty, pessoa.Id);
            Assert.Equal(nome, pessoa.Nome);
            Assert.Equal(telefone, pessoa.Telefone);
            Assert.Equal(tipoPessoa, pessoa.TipoPessoa);
            Assert.Equal(endereco, pessoa.Endereco);
            Assert.Equal(cnpj, pessoa.Cnpj);
            Assert.Equal(razaoSocial, pessoa.RazaoSocial);
        }

        [Fact]
        public void Cnpj_Invalido_Exception()
        {
            var endereco = Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107");

            Assert.Throws<ArgumentException>(() =>
                PessoaJuridica.Create("Nova Empresa", "123", TipoPessoa.Juridica, endereco, "123", "Razao Social")
            );
        }

        [Fact]
        public void RazaoSocial_Longa_Exception()
        {
            var endereco = Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107");
            var razaoMuitoLonga = new string('A', 300);

            Assert.Throws<ArgumentException>(() =>
                PessoaJuridica.Create("Nova Empresa", "123", TipoPessoa.Juridica, endereco, "42456524000131", razaoMuitoLonga)
            );
        }

        [Fact]
        public void Update_Sucesso()
        {
            var endereco = Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107");
            var pessoa = PessoaJuridica.Create("Nova Empresa", "123456789", TipoPessoa.Juridica, endereco, "42456524000131", "Nova Empresa LTDA");

            var novoEndereco = Endereco.Create("13469072", "Rua João Bandini", "lado ímpar", "Unidade", "Jardim Miriam", "Americana", "SP", "São Paulo", "SP", "3550308", "1006", "19", "6131");
            var novoNome = "Empresa Antiga";
            var novoTelefone = "123456780";
            var novoCnpj = "42456524000132";
            var novaRazao = "Empresa Antiga LTDA";

            pessoa.Update(novoNome, novoTelefone, TipoPessoa.Juridica, novoEndereco, novoCnpj, novaRazao);

            Assert.Equal(novoNome, pessoa.Nome);
            Assert.Equal(novoTelefone, pessoa.Telefone);
            Assert.Equal(novoCnpj, pessoa.Cnpj);
            Assert.Equal(novaRazao, pessoa.RazaoSocial);
            Assert.Equal(novoEndereco, pessoa.Endereco);
        }
    }
}