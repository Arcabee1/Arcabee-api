using System.Collections.Generic;
using System.Linq;
using Arcabee.Aplicacao.Produtos.Servicos.Interfaces;
using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.DataTransfer.Produtos.Response;
using Arcabee.Dominio.Produtos.Entidades;
using Arcabee.Dominio.Produtos.Repositorios;
using Arcabee.Dominio.Produtos.Servicos.Filtros;
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

    public List<ProdutosResponse> ListarProdutos(ProdutosListarRequest request)
    {
        try
        {
            var filtro = mapper.Map<ProdutosFiltro>(request);

            List<Produto> produtos = produtosRepositorio.ListarProdutos(filtro).ToList();

            return mapper.Map<List<ProdutosResponse>>(produtos);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

}
