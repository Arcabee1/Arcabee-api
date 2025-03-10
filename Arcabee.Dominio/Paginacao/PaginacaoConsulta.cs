namespace Arcabee.Dominio.Paginacao;

public class PaginacaoConsulta<T>
{
    public int PaginaAtual { get; private set; }
    public int TotalPaginas { get; private set; }
    public int QtdItensPorPagina { get; private set; }
    public int TotalItens { get; private set; }
    public IEnumerable<T> Itens { get; private set; }

    public PaginacaoConsulta(List<T> itens, int paginaAtual, int qtdItensPorPagina, int totalItens)
    {
        PaginaAtual = paginaAtual;
        TotalPaginas = (int)Math.Ceiling(totalItens / (double)qtdItensPorPagina);
        QtdItensPorPagina = qtdItensPorPagina;
        TotalItens = totalItens;
        Itens = itens;

    }
    public PaginacaoConsulta()
    {
        Itens = new List<T>();
    }
}
