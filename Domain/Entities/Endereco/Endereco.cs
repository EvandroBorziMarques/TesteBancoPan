using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Endereco
{
    public class Endereco
    {
        protected Endereco() { }
        private Endereco(Guid id, string cep, string logradouro, string? complemento, string? unidade, string? bairro, string? localidade, string? uf, string? estado, string? regiao, string? ibge, string? gia, string? ddd, string? siafi)
        {
            Id = id;
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Unidade = unidade;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Estado = estado;
            Regiao = regiao;
            Ibge = ibge;
            Gia = gia;
            DDD = ddd;
            Siafi = siafi;
        }

        public Guid Id { get; set; }

        [MaxLength(8)]
        public string Cep { get; set; }

        [MaxLength(256)]
        public string Logradouro { get; set; }

        [MaxLength(256)]
        public string? Complemento { get; set; }

        [MaxLength(256)]
        public string? Unidade { get; set; }

        [MaxLength(100)]
        public string? Bairro { get; set; }

        [MaxLength(256)]
        public string? Localidade { get; set; }

        [MaxLength(2)]
        public string? Uf { get; set; }

        [MaxLength(256)]
        public string? Estado { get; set; }

        [MaxLength(256)]
        public string? Regiao { get; set; }

        [MaxLength(50)]
        public string? Ibge { get; set; }

        [MaxLength(50)]
        public string? Gia { get; set; }

        [MaxLength(3)]
        public string? DDD { get; set; }

        [MaxLength(50)]
        public string? Siafi { get; set; }

        public static Endereco Create(string cep, string logradouro, string? complemento, string? unidade, string? bairro, string? localidade, string? uf, string? estado, string? regiao, string? ibge, string? gia, string? ddd, string? siafi)
        {
            return new Endereco(Guid.NewGuid(), cep, logradouro, complemento, unidade, bairro, localidade, uf, estado, regiao, ibge, gia, ddd, siafi);
        }

        public void Update(string cep, string logradouro, string? complemento, string? unidade, string? bairro, string? localidade, string? uf, string? estado, string? regiao, string? ibge, string? gia, string? ddd, string? siafi)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Unidade = unidade;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Estado = estado;
            Regiao = regiao;
            Ibge = ibge;
            Gia = gia;
            DDD = ddd;
            Siafi = siafi;
        }
    }
}