using Arcabee.Aplicacao.Produtos.Servicos.Interfaces;
using Arcabee.Dominio.Produtos.Servicos.Filtros;
using Arcabee.DataTransfer.Produtos.Response;
using Arcabee.Dominio.Produtos.Repositorios;
using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.Dominio.Produtos.Entidades;
using AutoMapper;
using Arcabee.Dominio.Paginacao;
using System.Threading.Tasks;

namespace Arcabee.Aplicacao.Produtos.Servicos;

public class ProdutosAppServico : IProdutosAppServicos
{
    private readonly IProdutosRepositorio produtosRepositorio;
    private readonly IMapper mapper;

    public ProdutosAppServico(IProdutosRepositorio produtosRepositorio, IMapper mapper)
    {
        this.produtosRepositorio = produtosRepositorio;
        this.mapper = mapper;
    }

    public async Task<PaginacaoConsulta<ProdutosResponse>> ListarProdutos(ProdutosListarRequest request, int pagina, int qtdItens)
    {
        try
        {
            var filtro = mapper.Map<ProdutosFiltro>(request);

            PaginacaoConsulta<Produto> produtos = await produtosRepositorio.ListarProdutos(filtro,pagina,qtdItens);

            return mapper.Map<PaginacaoConsulta<ProdutosResponse>>(produtos);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
