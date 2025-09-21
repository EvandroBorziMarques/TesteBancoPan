using Domain.Abstraction;

namespace Domain.Ports
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetAll();
        Task<Pessoa> GetById(Guid id);
        Task<Pessoa> Insert(Pessoa pessoa);
        Task<Pessoa> Update(Pessoa pessoa);
        Task<Pessoa> Delete(Guid id);
    }
}
