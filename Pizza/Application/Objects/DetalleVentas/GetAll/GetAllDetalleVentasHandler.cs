
using Ventas.Common;
using ErrorOr;
using MediatR;
using Domain.Objects.Venta;
using DetalleVentas.Common;
using Domain.Objects.DetalleVenta;
using Application.DetalleVentas.GetAll;

namespace Application.Ventas.GetAll;

internal sealed class GetAllDetalleVentasHandler : IRequestHandler<GetAllDetalleVentas, ErrorOr<IReadOnlyList<DetalleVentaResponse>>>
{
    private readonly IDetalleVentaRepository _detalleVentaRepository;

    public  GetAllDetalleVentasHandler(IDetalleVentaRepository detalleVentaRepository)
    {
        _detalleVentaRepository = detalleVentaRepository ?? throw new ArgumentNullException(nameof(detalleVentaRepository));
    }
     public async Task<ErrorOr<IReadOnlyList<DetalleVentaResponse>>> Handle(GetAllDetalleVentas query, CancellationToken cancellationToken)
    {
        IReadOnlyList<DetalleVenta> detalleVentas = await _detalleVentaRepository.GetByVentaId(new VentaId(query.ventaID));

        return detalleVentas.Select(detalleVentas => new DetalleVentaResponse(
                detalleVentas.id.Value,
                detalleVentas.idProducto.Value,
                detalleVentas.idVenta.Value,
                detalleVentas.cantidad,
                detalleVentas.precioUnitario,
                detalleVentas.total
            )).ToList();
    }
}