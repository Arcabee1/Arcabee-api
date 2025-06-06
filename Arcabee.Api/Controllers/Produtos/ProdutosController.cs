using Arcabee.Aplicacao.Produtos.Servicos.Interfaces;
using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.DataTransfer.Produtos.Response;
using Arcabee.Dominio.libs.Consultas;
using Microsoft.AspNetCore.Mvc;

namespace Arcabee.Api.Controllers.Produtos;
[Route("api/produtos")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutosAppServicos produtosAppServicos;

    public ProdutosController(IProdutosAppServicos produtosAppServicos)
    {
        this.produtosAppServicos = produtosAppServicos;
    }

    /// <summary>
    /// Listar produtos
    /// </summary>
    /// <param name="request">Dados dos produtos a serem listados.</param>
    /// <returns>Dados dos produtos listados.</returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<ProdutosResponse>> Listar([FromQuery] ProdutosListarRequest request)
    {
        PaginacaoConsulta<ProdutosResponse> produtos = produtosAppServicos.ListarProdutos(request);

        return Ok(produtos);
    }
}
