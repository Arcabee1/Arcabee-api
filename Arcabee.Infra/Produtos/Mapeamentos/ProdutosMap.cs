using Arcabee.Dominio.Produtos.Entidades;
using FluentNHibernate.Mapping;

namespace Arcabee.Infra.Produtos.Mapeamentos;

public class ProdutosMap : ClassMap<Produto>
{
    public ProdutosMap()
    {
        Schema("arcabeedb");
        Table("produtos");
        Id(x => x.Id);
        Map(x => x.CodigoProduto, "codigo");
        Map(x => x.Nome, "nome");
        Map(x => x.Tipo, "tipo");
        Map(x => x.Marca, "marca");
        Map(x => x.Linha, "linha");
        Map(x => x.Miniatura, "miniatura");
        Map(x => x.Cor, "cor");
        Map(x => x.Textura, "textura");
        Map(x => x.Bumb, "bumb");
        Map(x => x.Rugosidade, "rugosidade");
        Map(x => x.Recortes, "recortes");
        Map(x => x.Opacidade, "opacidade");
        Map(x => x.Reflexao, "reflexao");
        Map(x => x.Descricao, "descricao");
    }
}