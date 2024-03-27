using Ventas.Common;
using ErrorOr;
using MediatR;
using DetalleVentas.Common;

namespace Application.DetalleVentas.GetAll;

public record GetAllDetalleVentas(Guid ventaID) : IRequest<ErrorOr<IReadOnlyList<DetalleVentaResponse>>>;