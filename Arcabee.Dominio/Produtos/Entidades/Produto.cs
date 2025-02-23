namespace Arcabee.Dominio.Produtos.Entidades;

public class Produto
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

    public Produto(string codigoProduto, string nome, string tipo, string marca, string linha, string miniatura, string cor, string textura, string bumb, string rugosidade, string recortes, string opacidade, string reflexao, string descricao)
    {
        SetCodigoProduto(codigoProduto);
        SetNome(nome);
        SetTipo(tipo);
        SetMarca(marca);
        SetLinha(linha);
        SetMiniatura(miniatura);
        SetCor(cor);
        SetTextura(textura);
        SetBumb(bumb);
        SetRugosidade(rugosidade);
        SetRecortes(recortes);
        SetOpacidade(opacidade);
        SetReflexao(reflexao);
        SetDescricao(descricao);
    }

    public Produto() { }

    public virtual void SetCodigoProduto(string codigoProduto)
    {
        CodigoProduto = codigoProduto;
    }

    public virtual void SetNome(string nome)
    {
        Nome = nome;
    }

    public virtual void SetTipo(string tipo)
    {
        Tipo = tipo;
    }

    public virtual void SetMarca(string marca)
    {
        Marca = marca;
    }

    public virtual void SetLinha(string linha)
    {
        Linha = linha;
    }

    public virtual void SetMiniatura(string miniatura)
    {
        Miniatura = miniatura;
    }

    public virtual void SetCor(string cor)
    {
        Cor = cor;
    }

    public virtual void SetTextura(string textura)
    {
        Textura = textura;
    }

    public virtual void SetBumb(string bumb)
    {
        Bumb = bumb;
    }

    public virtual void SetRugosidade(string rugosidade)
    {
        Rugosidade = rugosidade;
    }

    public virtual void SetRecortes(string recortes)
    {
        Recortes = recortes;
    }

    public virtual void SetOpacidade(string opacidade)
    {
        Opacidade = opacidade;
    }

    public virtual void SetReflexao(string reflexao)
    {
        Reflexao = reflexao;
    }

    public virtual void SetDescricao(string descricao)
    {
        Descricao = descricao;
    }
}
