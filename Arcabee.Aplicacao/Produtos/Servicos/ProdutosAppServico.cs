using Arcabee.Aplicacao.Produtos.Servicos.Interfaces;
using Arcabee.Dominio.Produtos.Servicos.Filtros;
using Arcabee.DataTransfer.Produtos.Response;
using Arcabee.Dominio.Produtos.Repositorios;
using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.Dominio.Produtos.Entidades;
using Arcabee.Dominio.libs.Extensions;
using Arcabee.Dominio.libs.Consultas;
using AutoMapper;

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

    public PaginacaoConsulta<ProdutosResponse> ListarProdutos(ProdutosListarRequest request)
    {
        try
        {
            var filtro = mapper.Map<ProdutosFiltro>(request);
            
            PaginacaoConsulta<Produto> produtos = produtosRepositorio.ListarProdutos(filtro).Paginar(request);

            return mapper.Map<PaginacaoConsulta<ProdutosResponse>>(produtos);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
