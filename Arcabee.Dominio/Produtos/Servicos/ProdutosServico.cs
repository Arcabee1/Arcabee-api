namespace Arcabee.Dominio.Produtos.Servicos;

public class ProdutosServico
{
     public virtual int Id { get; protected set; }
    public virtual string CodigoProduto { get; protected set; }
    public virtual string Nome { get; protected set; }
    public virtual string Tipo { get; protected set; }
    public virtual string Marca { get; protected set; }
    public virtual string Linha { get; protected set; }
    public virtual string Miniatura { get; protected set; }
    public virtual string Cor { get; protected set; }
    public virtual string Textura { get; protected set; }
    public virtual string Bumb { get; protected set; }
    public virtual string Rugosidade { get; protected set; }
    public virtual string Recortes { get; protected set; }
    public virtual string Opacidade { get; protected set; }
    public virtual string Reflexao { get; protected set; }
    public virtual string Descricao { get; protected set; }
    public ProdutosServico( string codigoProduto, string nome, string tipo, string marca, string linha, string miniatura, string cor, string textura, string bumb, string rugosidade, string recortes, string opacidade, string reflexao, string descricao)
    {
        CodigoProduto = codigoProduto;
        Nome = nome;
        Tipo = tipo;
        Marca = marca;
        Linha = linha;
        Miniatura = miniatura;
        Cor = cor;
        Textura = textura;
        Bumb = bumb;
        Rugosidade = rugosidade;
        Recortes = recortes;
        Opacidade = opacidade;
        Reflexao = reflexao;
        Descricao = descricao;
    }
    public ProdutosServico() { }
}
  