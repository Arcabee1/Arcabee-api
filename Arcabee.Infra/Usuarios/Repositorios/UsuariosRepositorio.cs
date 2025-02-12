using Arcabee.Dominio.Usuarios.Entidades;
using Arcabee.Dominio.Usuarios.Repositorios;
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
}
