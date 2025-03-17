using Arcabee.Dominio.libs.Filtros;
using Arcabee.Dominio.libs.Filtros.Enumeradores;

namespace Arcabee.DataTransfer.Produtos.Request;

public class ProdutosListarRequest : PaginacaoFiltro
{
    public int? Id { get; set; }
    public string CodigoProduto { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string Marca { get; set; }
    public string Linha { get; set; }
    public string Miniatura { get; set; }
    public string Cor { get; set; }
    public string Textura { get; set; }
    public string Bumb { get; set; }
    public string Rugosidade { get; set; }
    public string Recortes { get; set; }
    public string Opacidade { get; set; }
    public string Reflexao { get; set; }
    public string Descricao { get; set; }

    public ProdutosListarRequest() : base("Id", TipoOrdenacaoEnum.Asc)
    {
      
    }
}
