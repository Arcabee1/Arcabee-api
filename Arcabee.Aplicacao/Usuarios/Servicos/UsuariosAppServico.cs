using System.Collections.Generic;
using System.Linq;
using Arcabee.Aplicacao.Usuarios.Servicos.Interfaces;
using Arcabee.DataTransfer.Usuarios.Request;
using Arcabee.DataTransfer.Usuarios.Response;
using Arcabee.Dominio.Usuarios.Entidades;
using Arcabee.Dominio.Usuarios.Repositorios;
using Arcabee.Dominio.Usuarios.Servicos.Filtros;
using Arcabee.Dominio.Usuarios.Servicos.Interfaces;

namespace Arcabee.Aplicacao.Usuarios.Servicos;

public class UsuariosAppServico : IUsuariosAppServico
{
    private readonly IUsuariosServicos usuariosServicos;
    private readonly IUsuariosRepositorio usuariosRepositorio;

    public UsuariosAppServico(IUsuariosServicos usuariosServicos, IUsuariosRepositorio usuariosRepositorio)
    {
        this.usuariosServicos = usuariosServicos;
        this.usuariosRepositorio = usuariosRepositorio;
    }

    public UsuariosResponse Inserir(UsuariosInserirRequest request)
    {
        try
        {
            var usuario = usuariosServicos.Inserir(request.UsuarioDescricao, request.Login, request.Senha, request.Email, request.Perfil);

            return new UsuariosResponse
            {
                UsuarioDescricao = usuario.UsuarioDescricao,
                Login = usuario.Login,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public IList<UsuariosResponse> Listar(UsuariosListarRequest request)
    {
        var filtro = new UsuariosFiltro
        {
            Id = request.Id,
            UsuarioDescricao = request.UsuarioDescricao,
            Login = request.Login,
            Email = request.Email,
            Perfil = request.Perfil
        };

        List<Usuario> usuarios = usuariosRepositorio.ListarUsuarios(filtro).ToList();
        
        return usuarios.Select(usuario => new UsuariosResponse
        {
            Id = usuario.Id,
            UsuarioDescricao = usuario.UsuarioDescricao,
            Login = usuario.Login,
            Email = usuario.Email,
            Perfil = usuario.Perfil
        }).ToList();
    }
}
