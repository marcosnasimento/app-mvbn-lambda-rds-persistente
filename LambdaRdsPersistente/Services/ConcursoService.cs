using LambdaRdsPersistente.Data;
using LambdaRdsPersistente.Models;
using Microsoft.EntityFrameworkCore;


namespace LambdaRdsPersistente.Services;

public class ConcursoService :IAsyncDisposable
{

    private readonly AppDbContext _context; 

    public ConcursoService(string connectionString)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        _context = new AppDbContext(options);
    } 

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
        
    }

    public async Task PersistirAsync(List<Concurso> concursos)
    {
        await _context.Concursos.AddRangeAsync(concursos);
        await _context.SaveChangesAsync();
    }

}

