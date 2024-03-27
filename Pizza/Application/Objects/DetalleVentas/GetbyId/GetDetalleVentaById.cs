using ErrorOr;
using MediatR;
using DetalleVentas.Common;

namespace Application.DetalleVentas.GetbyId;

public record GetDetalleVentaById(Guid Id, Guid ventaID) : IRequest<ErrorOr<DetalleVentaResponse>>;