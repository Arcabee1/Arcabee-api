using Arcabee.Dominio.libs.Repositorios;
using Arcabee.Dominio.Produtos.Entidades;
using Arcabee.Dominio.Produtos.Servicos.Filtros;

namespace Arcabee.Dominio.Produtos.Repositorios;

public interface IProdutosRepositorio : IRepositorioNHibernate<Produto>
{
    IQueryable<Produto> ListarProdutos(ProdutosFiltro filtro);
}
