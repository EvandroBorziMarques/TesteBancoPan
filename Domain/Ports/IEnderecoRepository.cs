using Domain.Entities.Endereco;

namespace Domain.Ports
{
    public interface IEnderecoRepository
    {
        Task<Endereco> Insert(Endereco endereco);
        Task<Endereco> Update(Endereco endereco);
        Task<Endereco> Delete(Guid id);
    }
}
