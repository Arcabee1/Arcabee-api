using Arcabee.Aplicacao.Usuarios.Servicos.Interfaces;
using Arcabee.DataTransfer.Usuarios.Request;
using Arcabee.DataTransfer.Usuarios.Response;
using Arcabee.Dominio.Usuarios.Servicos.Interfaces;

namespace Arcabee.Aplicacao.Usuarios.Servicos;

public class UsuariosAppServico : IUsuariosAppServico
{
    private readonly IUsuariosServicos usuariosServicos;

    public UsuariosAppServico(IUsuariosServicos usuariosServicos)
    {
        this.usuariosServicos = usuariosServicos;
    }

    public UsuariosResponse Inserir(UsuariosInserirRequest request)
    {
        try
        {
            var usuario = usuariosServicos.Inserir(request.UsuarioDescricao, request.Login, request.Senha, request.Email, request.Perfil);

            return new UsuariosResponse
            {
                UsuarioDescricao = usuario.UsuarioDescricao,
                Login = usuario.Login,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }
        catch (System.Exception)
        {
            throw;
        }
    }

}
