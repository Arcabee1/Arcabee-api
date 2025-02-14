using Arcabee.Dominio.Usuarios.Entidades;
using Arcabee.Dominio.Usuarios.Servicos.Filtros;

namespace Arcabee.Dominio.Usuarios.Repositorios;

public interface IUsuariosRepositorio
{
    void Adicionar(Usuario usuario);
    IQueryable<Usuario> ListarUsuarios(UsuariosFiltro filtro);
}
