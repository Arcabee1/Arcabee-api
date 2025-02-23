using Arcabee.Dominio.Usuarios.Entidades;
using Arcabee.Dominio.Usuarios.Repositorios;
using Arcabee.Dominio.Usuarios.Servicos.Comandos;
using Arcabee.Dominio.Usuarios.Servicos.Interfaces;

namespace Arcabee.Dominio.Usuarios.Servicos;

public class UsuariosServicos : IUsuariosServicos
{
    private readonly IUsuariosRepositorio usuarioRepositorio;

    public UsuariosServicos(IUsuariosRepositorio usuarioRepositorio)
    {
        this.usuarioRepositorio = usuarioRepositorio;
    }

    public Usuario Editar(UsuariosEditarComando comando)
    {

        Usuario usuario = Validar(comando.Id);
        
        if(comando.UsuarioDescricao != null)
            usuario.SetUsuarioDescricao(comando.UsuarioDescricao);
        if(comando.Login != null)
            usuario.SetLogin(comando.Login);
        if(comando.Senha != null)
            usuario.SetSenha(comando.Senha);
        if(comando.Email != null)
            usuario.SetEmail(comando.Email);
        if(comando.Perfil != null)
            usuario.SetPerfil(comando.Perfil);

        usuarioRepositorio.Editar(usuario);
        return usuario;
    }

    public Usuario Inserir(UsuariosInserirComando comando)
    {
        var usuario = new Usuario(comando.UsuarioDescricao, comando.Login, comando.Senha, comando.Email, comando.Perfil);
        
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
