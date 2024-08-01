using PontoOpen.Domain.Entities;

namespace PontoOpen.Application.Dtos.Pontos;

public class PontoDto
{
    public TimeSpan Horario { get; set; }
    public string Endereco { get; set; } = string.Empty;

    public Ponto ToEntity(Guid usuarioId)
    {
        return new Ponto(
            id: Guid.NewGuid(),
            createdAt: DateTime.Now,
            updatedAt: null,
            horario: Horario,
            usuarioId: usuarioId,
            endereco: Endereco);
    }
}
