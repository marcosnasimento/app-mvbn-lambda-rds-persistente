namespace LambdaRdsPersistente.Models;

public class Concurso
{
    public int Id { get; set; }
    public int NumeroConcurso { get; set; }
    public DateTime Data { get; set; }
    public List<int> DezenasSorteadasOrdemSorteio { get; set; } = [];
}
