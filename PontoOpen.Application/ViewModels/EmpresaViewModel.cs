using PontoOpen.Domain.Entities;

namespace PontoOpen.Application.ViewModels;

public class EmpresaViewModel : BaseViewModel
{
    public string RazaoSocial { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;

    public static explicit operator EmpresaViewModel(Empresa empresa)
    {
        return new()
        {
            Cnpj = empresa.Cnpj,
            CreatedAt = empresa.CreatedAt,
            Id = empresa.Id,
            NomeFantasia = empresa.NomeFantasia,
            RazaoSocial = empresa.RazaoSocial,
            UpdatedAt = empresa.UpdatedAt
        };
    }
}
