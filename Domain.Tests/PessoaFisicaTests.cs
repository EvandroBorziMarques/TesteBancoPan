using Domain.Abstraction;
using Domain.Entities.Endereco;
using Domain.Entities.PessoaFisica;

namespace Domain.Test
{
    public class PessoaFisicaTests
    {
        [Fact]
        public void Insert_Sucesso()
        {
            var pessoa = PessoaFisica.Create(
                "Evandro", "123456789", TipoPessoa.Fisica,
                Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107"),
                "12345678901", new DateTime(1990, 1, 1)
            );

            Console.WriteLine("Passou aqui ");
            Assert.NotEqual(Guid.Empty, pessoa.Id);
            Assert.Equal("Evandro", pessoa.Nome);
            Assert.Equal("123456789", pessoa.Telefone);
            Assert.Equal("12345678901", pessoa.Cpf);
            Assert.Equal(new DateTime(1990, 1, 1), pessoa.DataNascimento);
        }

        [Fact]
        public void Nome_Vazio_Exception()
        {
            var endereco = Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107");

            Assert.Throws<ArgumentException>(() =>
                PessoaFisica.Create("", "123", TipoPessoa.Fisica, endereco, "12345678901", DateTime.Now)
            );
        }

        [Fact]
        public void Cpf_Invalido_Exception()
        {
            var endereco = Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107");

            Assert.Throws<ArgumentException>(() =>
                PessoaFisica.Create("Evandro", "123", TipoPessoa.Fisica, endereco, "123", DateTime.Now)
            );
        }

        [Fact]
        public void DataNacimento_Futura_Exception()
        {
            var endereco = Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107");

            Assert.Throws<ArgumentException>(() =>
                PessoaFisica.Create("Evandro", "123", TipoPessoa.Fisica, endereco, "12345678901", DateTime.Now.AddDays(1))
            );
        }

        [Fact]
        public void Update_Sucesso()
        {
            var pessoa = PessoaFisica.Create(
                "Evandro", "123456789", TipoPessoa.Fisica,
                Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107"),
                "12345678901", new DateTime(1990, 1, 1)
            );

            var novoEndereco = Endereco.Create("13469072", "Rua João Bandini", "lado ímpar", "Unidade", "Jardim Miriam", "Americana", "SP", "São Paulo", "SP", "3550308", "1006", "19", "6131");

            pessoa.Update("Carlos", "987654321", TipoPessoa.Fisica, novoEndereco, "10987654321", new DateTime(2000, 2, 2));

            Assert.Equal("Carlos", pessoa.Nome);
            Assert.Equal("987654321", pessoa.Telefone);
            Assert.Equal("10987654321", pessoa.Cpf);
            Assert.Equal(new DateTime(2000, 2, 2), pessoa.DataNascimento);
            Assert.Equal(novoEndereco, pessoa.Endereco);
        }
    }

}
