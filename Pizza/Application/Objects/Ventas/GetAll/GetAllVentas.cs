using Ventas.Common;
using ErrorOr;
using MediatR;

namespace Application.Ventas.GetAll;

public record GetAllVentas() : IRequest<ErrorOr<IReadOnlyList<VentaResponse>>>;