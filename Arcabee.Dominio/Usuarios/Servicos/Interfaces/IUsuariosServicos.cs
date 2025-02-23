using Arcabee.Dominio.Usuarios.Entidades;
using Arcabee.Dominio.Usuarios.Servicos.Comandos;

namespace Arcabee.Dominio.Usuarios.Servicos.Interfaces;

public interface IUsuariosServicos
{
    Usuario Inserir(UsuariosInserirComando comando);
    Usuario Login(string login, string senha);
    Usuario Editar(UsuariosEditarComando comando);
}
