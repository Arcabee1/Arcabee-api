using Arcabee.DataTransfer.Usuarios.Request;
using Arcabee.DataTransfer.Usuarios.Response;

namespace Arcabee.Aplicacao.Usuarios.Servicos.Interfaces;

public interface IUsuariosAppServico
{
    UsuariosResponse Inserir(UsuariosInserirRequest request);
}
