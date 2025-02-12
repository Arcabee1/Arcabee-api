namespace Arcabee.DataTransfer.Usuarios.Request;

public class UsuariosInserirRequest
{
    public string UsuarioDescricao { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Perfil { get; set; }
}
