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
    public Usuario Inserir(string usuarioDescricao, string login, string senha, string email, string perfil)
    {
        var usuario = new Usuario(usuarioDescricao, login, senha, email, perfil);
        usuarioRepositorio.Adicionar(usuario);
        return usuario;
    }
}
