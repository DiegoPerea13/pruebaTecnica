using ErrorOr;
using MediatR;

namespace Application.Objects.Clientes.Create;

public record CreateClienteCommand(
    string id,
    string nombre,
    int dni
) : IRequest<ErrorOr<Unit>>;