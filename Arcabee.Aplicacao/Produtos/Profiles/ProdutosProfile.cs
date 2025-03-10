using Arcabee.Dominio.Produtos.Servicos.Filtros;
using Arcabee.DataTransfer.Produtos.Response;
using Arcabee.DataTransfer.Produtos.Request;
using Arcabee.Dominio.Produtos.Entidades;
using AutoMapper;
using Arcabee.Dominio.Paginacao;

namespace Arcabee.Aplicacao.Produtos.Profiles;

public class ProdutosProfile : Profile
{
    public ProdutosProfile()
    {
        CreateMap<ProdutosListarRequest, ProdutosFiltro>();
        CreateMap<Produto, ProdutosResponse>();
        CreateMap<PaginacaoConsulta<Produto>, PaginacaoConsulta<ProdutosResponse>>()
                 .ForMember(dest => dest.PaginaAtual, opt => opt.MapFrom(src => src.PaginaAtual))
                 .ForMember(dest => dest.TotalPaginas, opt => opt.MapFrom(src => src.TotalPaginas))
                 .ForMember(dest => dest.QtdItensPorPagina, opt => opt.MapFrom(src => src.QtdItensPorPagina))
                 .ForMember(dest => dest.TotalItens, opt => opt.MapFrom(src => src.TotalItens))
                 .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));
    }
}