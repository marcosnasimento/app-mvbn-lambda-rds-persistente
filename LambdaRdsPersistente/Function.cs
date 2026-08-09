using Amazon.Lambda.Core;
using LambdaRdsPersistente.Models;
using LambdaRdsPersistente.Services;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaRdsPersistente;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public async Task<string> FunctionHandler(List<Concurso> concursos, ILambdaContext context)
    {
        context.Logger.LogInformation($"Recebidos {concursos.Count} concursos.");

        var connectionString = Environment
            .GetEnvironmentVariable("ConnectionStrings__Postgres")
            ?? throw new InvalidOperationException("Connections string naõ econtrada.");
        
        await using var service = new ConcursoService(connectionString);

        await service.PersistirAsync(concursos);

        return System.Text.Json.JsonSerializer.Serialize(new
        {
            sucesso = true,
            quantidade = concursos.Count
        });
    }
}
