using Bogus;
using Bogus.Extensions.Brazil;
using PontoOpen.Domain.Entities;

namespace PontoOpen.Test.Builder;

public class UsuarioBuilder
{
    private readonly Guid _id;
    private readonly Guid _empresaId;
    private readonly DateTime _createdAt;
    private readonly DateTime _updateAt;
    private readonly string _nome;
    private readonly string _email;
    private readonly string _cpf;

    public UsuarioBuilder()
    {
        var fake = new Faker();
        _id = Guid.NewGuid();
        _empresaId = Guid.NewGuid();
        _createdAt = DateTime.Now;
        _updateAt = DateTime.Now;
        _nome = fake.Person.FirstName;
        _email = fake.Person.Email;
        _cpf = fake.Person.Cpf(includeFormatSymbols: false);
    }

    public static UsuarioBuilder Init() => new();

    public Usuario Build()
    {
        return new Usuario(
            id: _id,
            createdAt: _createdAt,
            updatedAt: _updateAt,
            nome: _nome,
            cpf: _cpf,
            email: _email,
            empresaId: _empresaId);
    }
}
