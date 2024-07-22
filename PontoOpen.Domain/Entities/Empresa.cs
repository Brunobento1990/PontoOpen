
namespace PontoOpen.Domain.Entities;

public sealed class Empresa : BaseEntity
{
    public Empresa(
        Guid id,
        DateTime createdAt,
        DateTime? updatedAt,
        string razaoSocial,
        string nomeFantasia,
        string cnpj)
            : base(id, createdAt, updatedAt)
    {
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
    }

    public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }
    public AcessoEmpresa AcessoEmpresa { get; set; } = null!;
    public IList<Usuario> Usuarios { get; set; } = [];
}
