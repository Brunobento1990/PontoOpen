namespace PontoOpen.Domain.Entities;

public sealed class Usuario : BaseEntity
{
    public Usuario(
        Guid id,
        DateTime createdAt,
        DateTime? updatedAt,
        string nome,
        string cpf,
        string email,
        Guid empresaId)
            : base(id, createdAt, updatedAt)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        EmpresaId = empresaId;
    }

    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public Guid EmpresaId { get; private set; }
    public Empresa Empresa { get; set; } = null!;
    public AcessoUsuario AcessoUsuario { get; set; } = null!;
    public IList<Ponto> Pontos { get; set; } = [];
}
