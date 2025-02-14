namespace Arcabee.DataTransfer.Usuarios.Request;

public class UsuariosListarRequest
{
    public int? Id { get; set; }
    public string UsuarioDescricao { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Perfil { get; set; }
}
