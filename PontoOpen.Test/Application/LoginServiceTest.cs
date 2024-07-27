using Moq;
using PontoOpen.Application.Dtos.Logins;
using PontoOpen.Application.Services;
using PontoOpen.Domain.Interfaces;
using PontoOpen.Test.Builder;

namespace PontoOpen.Test.Application;

public class LoginServiceTest
{
    private readonly Mock<ILoginRepository> _loginRepository;
    private readonly Mock<IEmpresaRepository> _empresaRepository;
    
    public LoginServiceTest()
    {
        _loginRepository = new Mock<ILoginRepository>();
        _empresaRepository = new Mock<IEmpresaRepository>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task Nao_Deve_Efetuar_Login_Com_Chave_Usuario_Invalida(long chaveDeAcessoUsuario)
    {
        var dto = new UsuarioLoginDto()
        {
            ChaveDeAcessoUsuario = chaveDeAcessoUsuario,
            ChaveDeAcessoEmpresa = 10
        };

        var usuario = UsuarioBuilder.Init().Build();
        var acessoUsuario = AcessoUsuarioBuilder.Init().AddUsuarioId(usuario.Id).Build();
        usuario.AcessoUsuario = acessoUsuario;

        var empresa = EmpresaBuilder.Init().Build();
        var acessoEmpresa = AcessoEmpresaBuilder.Init().AddEmpresaId(empresa.Id).Build();
        empresa.AcessoEmpresa = acessoEmpresa;

        _empresaRepository.Setup(x => x.GetByChaveDeAcessoAsync(dto.ChaveDeAcessoEmpresa)).ReturnsAsync(empresa);
        _loginRepository.Setup(x => x.LoginAsync(dto.ChaveDeAcessoUsuario)).ReturnsAsync(usuario);

        var loginService = new LoginService(_empresaRepository.Object, _loginRepository.Object);
        var result = await loginService.LoginAsync(dto);

        Assert.True(result.IsT1);
        Assert.False(result.IsT0);
    }

    [Fact]
    public async Task Nao_Deve_Efetuar_Login_Com_Usuario_Inativo()
    {
        var dto = new UsuarioLoginDto()
        {
            ChaveDeAcessoUsuario = 15,
            ChaveDeAcessoEmpresa = 10
        };

        var usuario = UsuarioBuilder.Init().Build();
        var acessoUsuario = AcessoUsuarioBuilder.Init().AddInativo(true).AddUsuarioId(usuario.Id).Build();
        usuario.AcessoUsuario = acessoUsuario;

        var empresa = EmpresaBuilder.Init().Build();
        var acessoEmpresa = AcessoEmpresaBuilder.Init().AddEmpresaId(empresa.Id).Build();
        empresa.AcessoEmpresa = acessoEmpresa;

        _empresaRepository.Setup(x => x.GetByChaveDeAcessoAsync(dto.ChaveDeAcessoEmpresa)).ReturnsAsync(empresa);
        _loginRepository.Setup(x => x.LoginAsync(dto.ChaveDeAcessoUsuario)).ReturnsAsync(usuario);

        var loginService = new LoginService(_empresaRepository.Object, _loginRepository.Object);
        var result = await loginService.LoginAsync(dto);

        Assert.True(result.IsT1);
        Assert.False(result.IsT0);
    }

    [Fact]
    public async Task Nao_Deve_Efetuar_Login_Com_Usuario_Bloquado()
    {
        var dto = new UsuarioLoginDto()
        {
            ChaveDeAcessoUsuario = 15,
            ChaveDeAcessoEmpresa = 10
        };

        var usuario = UsuarioBuilder.Init().Build();
        var acessoUsuario = AcessoUsuarioBuilder.Init().AddBloquado(true).AddUsuarioId(usuario.Id).Build();
        usuario.AcessoUsuario = acessoUsuario;

        var empresa = EmpresaBuilder.Init().Build();
        var acessoEmpresa = AcessoEmpresaBuilder.Init().AddEmpresaId(empresa.Id).Build();
        empresa.AcessoEmpresa = acessoEmpresa;

        _empresaRepository.Setup(x => x.GetByChaveDeAcessoAsync(dto.ChaveDeAcessoEmpresa)).ReturnsAsync(empresa);
        _loginRepository.Setup(x => x.LoginAsync(dto.ChaveDeAcessoUsuario)).ReturnsAsync(usuario);

        var loginService = new LoginService(_empresaRepository.Object, _loginRepository.Object);
        var result = await loginService.LoginAsync(dto);

        Assert.True(result.IsT1);
        Assert.False(result.IsT0);
    }

    [Fact]
    public async Task Nao_Deve_Efetuar_Login_Com_Empresa_Bloquada()
    {
        var dto = new UsuarioLoginDto()
        {
            ChaveDeAcessoUsuario = 15,
            ChaveDeAcessoEmpresa = 10
        };

        var usuario = UsuarioBuilder.Init().Build();
        var acessoUsuario = AcessoUsuarioBuilder.Init().AddUsuarioId(usuario.Id).Build();
        usuario.AcessoUsuario = acessoUsuario;

        var empresa = EmpresaBuilder.Init().Build();
        var acessoEmpresa = AcessoEmpresaBuilder.Init().AddBloqueada(true).AddEmpresaId(empresa.Id).Build();
        empresa.AcessoEmpresa = acessoEmpresa;

        _empresaRepository.Setup(x => x.GetByChaveDeAcessoAsync(dto.ChaveDeAcessoEmpresa)).ReturnsAsync(empresa);
        _loginRepository.Setup(x => x.LoginAsync(dto.ChaveDeAcessoUsuario)).ReturnsAsync(usuario);

        var loginService = new LoginService(_empresaRepository.Object, _loginRepository.Object);
        var result = await loginService.LoginAsync(dto);

        Assert.True(result.IsT1);
        Assert.False(result.IsT0);
    }
}
