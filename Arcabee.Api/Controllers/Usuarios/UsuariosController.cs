using Arcabee.Aplicacao.Usuarios.Servicos.Interfaces;
using Arcabee.DataTransfer.Usuarios.Request;
using Arcabee.DataTransfer.Usuarios.Response;
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
    public ActionResult<UsuariosResponse> Inserir([FromBody] UsuariosInserirRequest request)
    {
        UsuariosResponse usuario = usuariosAppServico.Inserir(request);

        return Ok(usuario);
    }

    /// <summary>
    /// Listar usuarios
    /// </summary>
    /// <param name="request">Dados dos usuários a serem listados.</param>
    /// <returns>Dados dos usuários listados.</returns>
    [HttpGet]
    public ActionResult<IList<UsuariosResponse>> Listar([FromQuery] UsuariosListarRequest request)
    {
        IList<UsuariosResponse> usuario = usuariosAppServico.Listar(request);

        return Ok(usuario);
    }

    /// <summary>
    /// Editar usuario
    /// </summary>
    /// <param name="request">Edita propriedades do usuário</param>
    /// <returns>Dados do usuário atualizado.</returns>
    [HttpPut]
    public ActionResult<UsuariosResponse> Editar([FromQuery] UsuariosEditarRequest request)
    {
        UsuariosResponse usuario = usuariosAppServico.Editar(request);

        return Ok(usuario);
    }

    /// <summary>
    /// Autoriza login do usuário
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Usuario usuário autorizado</returns>
    [HttpGet("login")]
    public ActionResult<UsuariosResponse> Login([FromQuery] UsuariosLoginRequest request)
    {
        UsuariosResponse usuario = usuariosAppServico.Login(request);

        return Ok(usuario);
    }
}
