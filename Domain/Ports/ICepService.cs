using Domain.Entities.Endereco;

namespace Domain.Ports
{
    public interface ICepService
    {
        Task<Endereco> BuscarPorCepAsync(string cep);
    }
}
