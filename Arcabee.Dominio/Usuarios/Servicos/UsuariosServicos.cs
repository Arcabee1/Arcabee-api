using Arcabee.Dominio.Usuarios.Entidades;
using Arcabee.Dominio.Usuarios.Repositorios;
using Arcabee.Dominio.Usuarios.Servicos.Interfaces;

namespace Arcabee.Dominio.Usuarios.Servicos;

public class UsuariosServicos : IUsuariosServicos
{
    private readonly IUsuariosRepositorio usuarioRepositorio;

    public UsuariosServicos(IUsuariosRepositorio usuarioRepositorio)
    {
        this.usuarioRepositorio = usuarioRepositorio;
    }

    public Usuario Editar(int id, string usuarioDescricao, string login, string senha, string email, string perfil)
    {
        Usuario usuario = Validar(id);
        
        if(usuarioDescricao != null)
            usuario.SetUsuarioDescricao(usuarioDescricao);
        if(login != null)
            usuario.SetLogin(login);
        if(senha != null)
            usuario.SetSenha(senha);
        if(email != null)
            usuario.SetEmail(email);
        if(perfil != null)
            usuario.SetPerfil(perfil);

        usuarioRepositorio.Editar(usuario);
        return usuario;
    }

    public Usuario Inserir(string usuarioDescricao, string login, string senha, string email, string perfil)
    {
        var usuario = new Usuario(usuarioDescricao, login, senha, email, perfil);
        usuarioRepositorio.Adicionar(usuario);
        return usuario;
    }

    public Usuario Login(string login, string senha)
    {
        return usuarioRepositorio.Login(login, senha) ?? throw new Exception("Usuário ou senha inválidos");
    }

    private Usuario Validar(int id)
    {
        return usuarioRepositorio.Recuperar(id) ?? throw new Exception("Usuário não encontrado");
    }
}
