using System.Collections.Generic;
using System.Threading.Tasks;
using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.DataTransfer.Produtos.Response;
using Arcabee.Dominio.Paginacao;

namespace Arcabee.Aplicacao.Produtos.Servicos.Interfaces;

public interface IProdutosAppServicos
{
    Task<PaginacaoConsulta<ProdutosResponse>> ListarProdutos(ProdutosListarRequest request, int pagina, int qtdItens);
}
