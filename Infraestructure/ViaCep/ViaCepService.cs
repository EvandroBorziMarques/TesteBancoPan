using Domain.Ports;
using System.Text.Json;
using Domain.Entities.Endereco;

namespace Infraestructure.ViaCep
{
    public class ViaCepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> BuscarPorCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var viaCep = JsonSerializer.Deserialize<ViaCepResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var endereco = Endereco.Create(viaCep.Cep, viaCep.Logradouro, viaCep.Complemento, viaCep.Unidade, viaCep.Bairro, viaCep.Localidade, viaCep.Uf, viaCep.Estado, viaCep.Regiao, viaCep.Ibge, viaCep.Gia, viaCep.Ddd, viaCep.Siafi);

            return endereco;
        }
    }
}
