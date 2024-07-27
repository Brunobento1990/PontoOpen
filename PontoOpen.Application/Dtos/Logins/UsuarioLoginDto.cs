namespace PontoOpen.Application.Dtos.Logins;

public class UsuarioLoginDto
{
    public long ChaveDeAcessoEmpresa { get; set; }
    public long ChaveDeAcessoUsuario { get; set; }

    public bool Validar()
    {
        return ChaveDeAcessoUsuario > 0 && ChaveDeAcessoEmpresa > 0; 
    }
}
