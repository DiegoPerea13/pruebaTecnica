using Ventas.Common;
using ErrorOr;
using MediatR;

namespace Application.Ventas.GetbyId;

public record GetVentaById(Guid Id) : IRequest<ErrorOr<VentaResponse>>;