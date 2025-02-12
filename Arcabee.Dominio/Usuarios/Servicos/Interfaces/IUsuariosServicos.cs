using Arcabee.Dominio.Usuarios.Entidades;

namespace Arcabee.Dominio.Usuarios.Servicos.Interfaces;

public interface IUsuariosServicos
{
    Usuario Inserir(string usuarioDescricao, string login, string senha, string email, string perfil);
    
}
