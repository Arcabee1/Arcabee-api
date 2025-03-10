using Arcabee.Dominio.Paginacao;
using NHibernate.Linq;

namespace Arcabee.Infra.Paginacao;

public static class PaginacaoConsulta
{
    public static async Task<PaginacaoConsulta<T>> PaginarAsync<T> (IQueryable<T> query, int pagina, int qtdItens) where T : class
    {
        var totalItens = await query.CountAsync();
        var itens = await query.Skip((pagina - 1) * qtdItens).Take(qtdItens).ToListAsync();

        return new PaginacaoConsulta<T>(itens, pagina, qtdItens, totalItens);
    }
}
