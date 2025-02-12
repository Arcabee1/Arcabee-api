using Arcabee.Aplicacao.Usuarios.Servicos.Interfaces;
using Arcabee.DataTransfer.Usuarios.Request;
using Arcabee.DataTransfer.Usuarios.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Arcabee.Api.Controllers.Usuarios;

[Route("api/usuarios")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuariosAppServico usuariosAppServico;

    public UsuariosController(IUsuariosAppServico usuariosAppServico)
    {
        this.usuariosAppServico = usuariosAppServico;
    }

    /// <summary>
    /// Adiciona um novo usuário ao sistema.
    /// </summary>
    /// <param name="request">Dados do usuário a ser inserido.</param>
    /// <returns>Dados do usuário criado.</returns>
    [HttpPost]
    [EnableCors("CorsPolicy")]
    public ActionResult<UsuariosResponse> Inserir([FromBody] UsuariosInserirRequest request)
    {
        UsuariosResponse usuario = usuariosAppServico.Inserir(request);

        return Ok(usuario);
    }
}
