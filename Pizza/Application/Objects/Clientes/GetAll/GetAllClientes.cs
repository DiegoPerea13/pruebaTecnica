using Clientes.Common;
using ErrorOr;
using MediatR;

namespace Application.Clientes.GetAll;

public record GetAllClientes() : IRequest<ErrorOr<IReadOnlyList<ClienteResponse>>>;