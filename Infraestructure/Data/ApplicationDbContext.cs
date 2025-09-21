using Domain.Abstraction;
using Domain.Entities.Endereco;
using Domain.Entities.PessoaFisica;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.PessoaJuridica;

namespace Infraestructure.Data
{
    public sealed class ApplicationDbContext : DbContext
    {

        public DbSet<Pessoa> Pessoas { get; set; } = null!;
        public DbSet<PessoaFisica> PessoasFisicas { get; set; } = null!;
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; } = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
            .HasDiscriminator<TipoPessoa>("TipoPessoa")
            .HasValue<PessoaFisica>(TipoPessoa.Fisica)
            .HasValue<PessoaJuridica>(TipoPessoa.Juridica);

            base.OnModelCreating(modelBuilder);
        }
    }
}
