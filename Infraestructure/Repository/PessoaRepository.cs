using Domain.Ports;
using Domain.Abstraction;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _context.Pessoas.Include(p => p.Endereco).ToListAsync();
        }

        public async Task<Pessoa> GetById(Guid id)
        {
            return await _context.Pessoas.Include(p => p.Endereco).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pessoa> Insert(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public async Task<Pessoa> Update(Pessoa pessoa)
        {
            var exist = await _context.Pessoas.FindAsync(pessoa.Id);

            _context.Pessoas.Update(exist);
            await _context.SaveChangesAsync();

            return exist;
        }

        public async Task<Pessoa> Delete(Guid id)
        {
            var pessoa = await _context.Pessoas.Include(p => p.Endereco).FirstOrDefaultAsync(p => p.Id == id);

            if (pessoa == null)
                return null;

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }
    }
}
