using Arcabee.Aplicacao.Usuarios.Servicos.Interfaces;
using Arcabee.Dominio.Usuarios.Servicos.Interfaces;
using Arcabee.Dominio.Usuarios.Servicos.Comandos;
using Arcabee.Dominio.Usuarios.Servicos.Filtros;
using Arcabee.DataTransfer.Usuarios.Response;
using Arcabee.DataTransfer.Usuarios.Request;
using Arcabee.Dominio.Usuarios.Repositorios;
using Arcabee.Dominio.Usuarios.Entidades;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Arcabee.Aplicacao.Usuarios.Servicos;

public class UsuariosAppServico : IUsuariosAppServico
{
    private readonly IUsuariosServicos usuariosServicos;
    private readonly IUsuariosRepositorio usuariosRepositorio;
    private readonly IMapper mapper;

    public UsuariosAppServico(IUsuariosServicos usuariosServicos, IUsuariosRepositorio usuariosRepositorio, IMapper mapper)
    {
        this.usuariosServicos = usuariosServicos;
        this.usuariosRepositorio = usuariosRepositorio;
        this.mapper = mapper;
    }

    public UsuariosResponse Editar(UsuariosEditarRequest request)
    {
        try
        {
            var comando = mapper.Map<UsuariosEditarComando>(request);

            var usuario = usuariosServicos.Editar(comando);

            return mapper.Map<UsuariosResponse>(usuario);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public UsuariosResponse Inserir(UsuariosInserirRequest request)
    {
        try
        {
            var comando = mapper.Map<UsuariosInserirComando>(request);
            
            var usuario = usuariosServicos.Inserir(comando);

            return mapper.Map<UsuariosResponse>(usuario);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public List<UsuariosResponse> Listar(UsuariosListarRequest request)
    {
        var filtro = mapper.Map<UsuariosFiltro>(request);
        
        List<Usuario> usuarios = usuariosRepositorio.ListarUsuarios(filtro).ToList();
        
        return mapper.Map<List<UsuariosResponse>>(usuarios);
    }

    public UsuariosResponse Login(UsuariosLoginRequest request)
    {
        try
        {
            var usuario = usuariosServicos.Login(request.Login, request.Senha);

            return mapper.Map<UsuariosResponse>(usuario);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
