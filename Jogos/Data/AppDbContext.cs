using Microsoft.EntityFrameworkCore;
using Jogos.Models;

namespace Jogos.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Genero> Generos { get; set; }
    public DbSet<Jogo> Jogos { get; set; }
    public DbSet<JogoGenero> JogoGeneros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Configuração do Muitos para Muitos - JogoGenero
        // Definindo Chave Primária
        modelBuilder.Entity<JogoGenero>()
            .HasKey(pt => new { pt.JogoId, pt.GeneroId });

        #endregion

    }

}
