using Domain.Entities.Endereco;

namespace Domain.Test
{
    public class EnderecoTests
    {
        [Fact]
        public void Create_DeveCriarEnderecoComSucesso()
        {
            var cep = "01001000";
            var logradouro = "Praça da Sé";
            var complemento = "lado ímpar";
            var unidade = "Unidade";
            var bairro = "Sé";
            var localidade = "São Paulo";
            var uf = "SP";
            var estado = "São Paulo";
            var regiao = "Sudeste";
            var ibge = "1234567";
            var gia = "1234";
            var ddd = "11";
            var siafi = "5678";

            var endereco = Endereco.Create(cep, logradouro, complemento, unidade, bairro, localidade, uf, estado, regiao, ibge, gia, ddd, siafi);

            Assert.NotEqual(Guid.Empty, endereco.Id);
            Assert.Equal(cep, endereco.Cep);
            Assert.Equal(logradouro, endereco.Logradouro);
            Assert.Equal(complemento, endereco.Complemento);
            Assert.Equal(unidade, endereco.Unidade);
            Assert.Equal(bairro, endereco.Bairro);
            Assert.Equal(localidade, endereco.Localidade);
            Assert.Equal(uf, endereco.Uf);
            Assert.Equal(estado, endereco.Estado);
            Assert.Equal(regiao, endereco.Regiao);
            Assert.Equal(ibge, endereco.Ibge);
            Assert.Equal(gia, endereco.Gia);
            Assert.Equal(ddd, endereco.DDD);
            Assert.Equal(siafi, endereco.Siafi);
        }

        [Fact]
        public void Update_DeveAlterarPropriedadesComSucesso()
        {
            var endereco = Endereco.Create("01001000", "Praça da Sé", "lado ímpar", "Unidade", "Sé", "São Paulo", "SP", "São Paulo", "SP", "3550308", "1004", "11", "7107");

            var novoCep = "13469072";
            var novoLogradouro = "Rua João Bandini";
            var novoComplemento = "lado ímpar";
            var novaUnidade = "Unidade";
            var novoBairro = "Jardim Miriam";
            var novaLocalidade = "Americana";
            var novaUf = "SP";
            var novoEstado = "São Paulo";
            var novaRegiao = "Sudeste";
            var novoIbge = "3550308";
            var novoGia = "1006";
            var novoDdd = "19";
            var novoSiafi = "6131";

            endereco.Update(novoCep, novoLogradouro, novoComplemento, novaUnidade, novoBairro, novaLocalidade, novaUf, novoEstado, novaRegiao, novoIbge, novoGia, novoDdd, novoSiafi);

            Assert.Equal(novoCep, endereco.Cep);
            Assert.Equal(novoLogradouro, endereco.Logradouro);
            Assert.Equal(novoComplemento, endereco.Complemento);
            Assert.Equal(novaUnidade, endereco.Unidade);
            Assert.Equal(novoBairro, endereco.Bairro);
            Assert.Equal(novaLocalidade, endereco.Localidade);
            Assert.Equal(novaUf, endereco.Uf);
            Assert.Equal(novoEstado, endereco.Estado);
            Assert.Equal(novaRegiao, endereco.Regiao);
            Assert.Equal(novoIbge, endereco.Ibge);
            Assert.Equal(novoGia, endereco.Gia);
            Assert.Equal(novoDdd, endereco.DDD);
            Assert.Equal(novoSiafi, endereco.Siafi);
        }
    }
}
