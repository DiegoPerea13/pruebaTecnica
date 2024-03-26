using ErrorOr;
using MediatR;

namespace Application.Objects.Clientes.Update;

public record UpdateClienteCommand(
    Guid id, 
    string nombre,
    int dni
): IRequest<ErrorOr<Unit>>;