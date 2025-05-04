using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.DataTransfer.Produtos.Response;
using Arcabee.Dominio.libs.Consultas;
namespace Arcabee.Aplicacao.Produtos.Servicos.Interfaces;

public interface IProdutosAppServicos
{
    PaginacaoConsulta<ProdutosResponse> ListarProdutos(ProdutosListarRequest request);
}
