using System.Collections.Generic;
using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.DataTransfer.Produtos.Response;
using Arcabee.Dominio.Produtos.Entidades;
using Arcabee.Dominio.Produtos.Servicos.Filtros;
using AutoMapper;

namespace Arcabee.Aplicacao.Produtos.Profiles;

public class ProdutosProfile : Profile
{
    public ProdutosProfile()
    {
        CreateMap<ProdutosListarRequest, ProdutosFiltro>();
        CreateMap<Produto, ProdutosResponse>();
    }
}
