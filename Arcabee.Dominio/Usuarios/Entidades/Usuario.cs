namespace Arcabee.Dominio.Usuarios.Entidades;

public class Usuario
{
    public virtual int Id { get; protected set; }
    public virtual string UsuarioDescricao { get; protected set; }
    public virtual string Login { get; protected set; }
    public virtual string Senha { get; protected set; }
    public virtual string Email { get; protected set; }
    public virtual string Perfil { get; protected set; }
    public Usuario(string usuarioDescricao, string login, string senha, string email, string perfil)
    {
        SetUsuarioDescricao(usuarioDescricao);
        SetLogin(login);
        SetSenha(senha);
        SetEmail(email);
        SetPerfil(perfil);
    }
    public Usuario() { }

    public virtual void SetPerfil(string perfil)
    {
        perfil ??= "user";
        Perfil = perfil;
    }
    public virtual void SetEmail(string email)
    {
        Email = email;
    }
    public virtual void SetSenha(string senha)
    {
        Senha = senha;
    }
    public virtual void SetLogin(string login)
    {
        Login = login;
    }
    public virtual void SetUsuarioDescricao(string usuarioDescricao)
    {
        UsuarioDescricao = usuarioDescricao;
    }
}