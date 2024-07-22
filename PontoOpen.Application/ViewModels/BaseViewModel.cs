namespace PontoOpen.Application.ViewModels;

public abstract class BaseViewModel
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
}
