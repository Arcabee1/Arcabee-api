using Arcabee.Dominio.Produtos.Servicos.Filtros;
using Arcabee.Dominio.Produtos.Repositorios;
using Arcabee.Dominio.Produtos.Entidades;
using NHibernate;
using Arcabee.Dominio.Paginacao;
using Arcabee.Infra.Paginacao;

namespace Arcabee.Infra.Produtos.Repositorios;

public class ProdutosRepositorio(ISession session) : IProdutosRepositorio
{
    public async Task<PaginacaoConsulta<Produto>> ListarProdutos(ProdutosFiltro filtro, int pagina, int qtdItens)
    {
        var query = session.Query<Produto>();

        if (filtro.Id.HasValue)
            query = query.Where(x => x.Id == filtro.Id);

        if (!string.IsNullOrEmpty(filtro.CodigoProduto))
            query = query.Where(x => x.CodigoProduto.ToUpper().Contains(filtro.CodigoProduto.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Nome))
            query = query.Where(x => x.Nome.ToUpper().Contains(filtro.Nome.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Tipo))
            query = query.Where(x => x.Tipo.ToUpper().Contains(filtro.Tipo.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Marca))
            query = query.Where(x => x.Marca.ToUpper().Contains(filtro.Marca.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Linha))
            query = query.Where(x => x.Linha.ToUpper().Contains(filtro.Linha.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Miniatura))
            query = query.Where(x => x.Miniatura.ToUpper().Contains(filtro.Miniatura.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Cor))
            query = query.Where(x => x.Cor.ToUpper().Contains(filtro.Cor.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Textura))
            query = query.Where(x => x.Textura.ToUpper().Contains(filtro.Textura.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Bumb))
            query = query.Where(x => x.Bumb.ToUpper().Contains(filtro.Bumb.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Rugosidade))
            query = query.Where(x => x.Rugosidade.ToUpper().Contains(filtro.Rugosidade.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Recortes))
            query = query.Where(x => x.Recortes.ToUpper().Contains(filtro.Recortes.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Opacidade))
            query = query.Where(x => x.Opacidade.ToUpper().Contains(filtro.Opacidade.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Reflexao))
            query = query.Where(x => x.Reflexao.ToUpper().Contains(filtro.Reflexao.ToUpper()));

        if (!string.IsNullOrEmpty(filtro.Descricao))
            query = query.Where(x => x.Descricao.ToUpper().Contains(filtro.Descricao.ToUpper()));
        
        return await PaginacaoConsulta.PaginarAsync(query, qtdItens, pagina);
    }
}