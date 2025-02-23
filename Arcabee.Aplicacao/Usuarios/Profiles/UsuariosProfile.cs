using Arcabee.DataTransfer.Usuarios.Request;
using Arcabee.DataTransfer.Usuarios.Response;
using Arcabee.Dominio.Usuarios.Entidades;
using Arcabee.Dominio.Usuarios.Servicos.Comandos;
using Arcabee.Dominio.Usuarios.Servicos.Filtros;
using AutoMapper;

namespace Arcabee.Aplicacao.Usuarios.Profiles;

public class UsuariosProfile : Profile
{
    public UsuariosProfile()
    {
        CreateMap<UsuariosInserirRequest, UsuariosInserirComando>();
        CreateMap<UsuariosListarRequest, UsuariosFiltro>();
        CreateMap<UsuariosEditarRequest, UsuariosEditarComando>();
        CreateMap<Usuario, UsuariosResponse>();
    }
}
