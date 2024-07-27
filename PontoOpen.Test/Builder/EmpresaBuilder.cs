using Bogus;
using Bogus.Extensions.Brazil;
using PontoOpen.Domain.Entities;

namespace PontoOpen.Test.Builder;

public class EmpresaBuilder
{
    private readonly Guid _id;
    private readonly DateTime _createdAt;
    private readonly DateTime _updateAt;
    private readonly string _razaoSocial;
    private readonly string _nomeFantasia;
    private readonly string _cnpj;

    public EmpresaBuilder()
    {
        var fake = new Faker();
        _id = Guid.NewGuid();
        _createdAt = DateTime.Now;
        _updateAt = DateTime.Now;
        _razaoSocial = fake.Company.CompanyName();
        _nomeFantasia = fake.Company.CompanyName();
        _cnpj = fake.Company.Cnpj(includeFormatSymbols: false);
    }

    public static EmpresaBuilder Init() => new();

    public Empresa Build()
    {
        return new Empresa(
            id: _id,
            createdAt: _createdAt,
            updatedAt: _updateAt,
            razaoSocial: _razaoSocial,
            nomeFantasia: _nomeFantasia,
            cnpj: _cnpj);
    }
}
