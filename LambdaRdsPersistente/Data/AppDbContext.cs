using LambdaRdsPersistente.Models;
using Microsoft.EntityFrameworkCore;

namespace LambdaRdsPersistente.Data;


public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options)
{
    public DbSet<Concurso> Concursos => Set<Concurso>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concurso>()
            .Property(px => px.DezenasSorteadasOrdemSorteio)
            .HasColumnType("jsonb");
    }
}