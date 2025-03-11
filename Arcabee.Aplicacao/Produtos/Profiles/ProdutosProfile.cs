using Arcabee.Dominio.Produtos.Servicos.Filtros;
using Arcabee.DataTransfer.Produtos.Response;
using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.Dominio.Produtos.Entidades;
using Arcabee.Dominio.libs.Consultas;
using AutoMapper;

namespace Arcabee.Aplicacao.Produtos.Profiles;

public class ProdutosProfile : Profile
{
    public ProdutosProfile()
    {
        CreateMap<ProdutosListarRequest, ProdutosFiltro>();
        CreateMap<Produto, ProdutosResponse>();
        CreateMap<PaginacaoConsulta<Produto>, PaginacaoConsulta<ProdutosResponse>>();
    }
}