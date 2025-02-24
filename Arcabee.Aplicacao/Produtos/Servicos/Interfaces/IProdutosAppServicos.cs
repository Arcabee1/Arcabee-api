using System.Collections.Generic;
using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.DataTransfer.Produtos.Response;

namespace Arcabee.Aplicacao.Produtos.Servicos.Interfaces;

public interface IProdutosAppServicos
{
    List<ProdutosResponse> ListarProdutos(ProdutosListarRequest request);
}
