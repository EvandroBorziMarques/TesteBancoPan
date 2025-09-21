using Domain.Ports;
using Infraestructure.Data;
using Domain.Entities.Endereco;

namespace Infraestructure.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationDbContext _context;

        public EnderecoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco> Insert(Endereco endereco)
        {
            var novoEndereco = Endereco.Create(endereco.Cep, endereco.Logradouro, endereco.Complemento, endereco.Unidade, endereco.Bairro, endereco.Localidade, endereco.Uf, endereco.Estado, endereco.Regiao, endereco.Ibge, endereco.Gia, endereco.DDD, endereco.Siafi);

            _context.Enderecos.Add(novoEndereco);
            await _context.SaveChangesAsync();

            return endereco;
        }

        public async Task<Endereco> Update(Endereco endereco)
        {
            var exist = await _context.Enderecos.FindAsync(endereco.Id);

            _context.Enderecos.Update(exist);
            await _context.SaveChangesAsync();

            return exist;
        }

        public async Task<Endereco> Delete(Guid id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
                return null;

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }
    }
}
