using FluentNHibernate.Mapping;
using Arcabee.Dominio.Usuarios.Entidades;

namespace Arcabee.Infra.Usuarios.Mapeamentos
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Schema("arcabeedb");
            Table("Usuario");
            Id(x => x.Id, "Id");
            Map(x => x.UsuarioDescricao, "DescricaoUsuario");
            Map(x => x.Login, "Login");
            Map(x => x.Senha, "Senha");
            Map(x => x.Email, "Email");
            Map(x => x.Perfil, "Perfil");
        }
    }
}