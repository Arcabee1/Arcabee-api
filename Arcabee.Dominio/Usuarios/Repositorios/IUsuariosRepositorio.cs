using Arcabee.Dominio.Usuarios.Entidades;
using Arcabee.Dominio.Usuarios.Servicos.Filtros;

namespace Arcabee.Dominio.Usuarios.Repositorios;

public interface IUsuariosRepositorio
{
    void Adicionar(Usuario usuario);
    void Editar(Usuario usuario);
    Usuario Recuperar(int id);
    Usuario Login(string login, string senha);
    IQueryable<Usuario> ListarUsuarios(UsuariosFiltro filtro);
    bool LoginJaCadastrado(string login);
}
