using Arcabee.Dominio.Usuarios.Entidades;
using Arcabee.Dominio.Usuarios.Repositorios;
using Arcabee.Dominio.Usuarios.Servicos.Filtros;
using NHibernate;

namespace Arcabee.Infra.Usuarios.Repositorios;

public class UsuariosRepositorio(ISession session) : IUsuariosRepositorio
{
    private readonly ISession _session = session;

    public void Adicionar(Usuario usuario)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Save(usuario);
            transaction.Commit();
        }
    }

    public void Editar(Usuario usuario)
    {
        using (var transaction = _session.BeginTransaction())
        {
            _session.Update(usuario);
            transaction.Commit();
        }
    }

    public IQueryable<Usuario> ListarUsuarios(UsuariosFiltro filtro)
    {
        var query = _session.Query<Usuario>();
        
        if (filtro.Id.HasValue)
            query = query.Where(x => x.Id == filtro.Id);
        
        if (!string.IsNullOrEmpty(filtro.UsuarioDescricao))
            query = query.Where(x => x.UsuarioDescricao.ToUpper().Contains(filtro.UsuarioDescricao.ToUpper()));
        
        if (!string.IsNullOrEmpty(filtro.Login))
            query = query.Where(x => x.Login == filtro.Login);
        
        if (!string.IsNullOrEmpty(filtro.Email))
            query = query.Where(x => x.Email.ToUpper().Contains(filtro.Email.ToUpper()));
        
        if (!string.IsNullOrEmpty(filtro.Perfil))
            query = query.Where(x => x.Perfil.ToUpper() == filtro.Perfil.ToUpper());

        return query;
    }

    public Usuario Recuperar(int id)
    {
        return _session.Get<Usuario>(id);
    }
    public Usuario Login(string login, string senha)
    {
        var query = _session.Query<Usuario>();
        
        if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(senha))
            query = query.Where(x => x.Login == login && x.Senha == senha);
        
        return query.FirstOrDefault();
    }
}
