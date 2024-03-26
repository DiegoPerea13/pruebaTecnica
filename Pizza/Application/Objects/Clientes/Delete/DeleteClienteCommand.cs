using ErrorOr;
using MediatR;
namespace Application.Objects.Clientes.Delete;

public record DeleteClienteCommand(Guid Id) : IRequest<ErrorOr<Unit>>;