using Arcabee.Dominio.Paginacao;
using Arcabee.Dominio.Produtos.Entidades;
using Arcabee.Dominio.Produtos.Servicos.Filtros;

namespace Arcabee.Dominio.Produtos.Repositorios;

public interface IProdutosRepositorio
{
Task<PaginacaoConsulta<Produto>> ListarProdutos(ProdutosFiltro filtro, int pagina, int qtdItens);
}
