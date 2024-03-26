using Clientes.Common;
using ErrorOr;
using MediatR;

namespace Application.Clientes.GetbyId;

public record GetClienteById(Guid Id) : IRequest<ErrorOr<ClienteResponse>>;