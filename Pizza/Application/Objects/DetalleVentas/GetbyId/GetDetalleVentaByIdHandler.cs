using Domain.Objects.Venta;
using ErrorOr;
using MediatR;
using DetalleVentas.Common;
using Domain.Objects.DetalleVenta;

namespace Application.DetalleVentas.GetbyId;

internal sealed class GetDetalleVentaByIdHandler : IRequestHandler<GetDetalleVentaById, ErrorOr<DetalleVentaResponse>>
{
    private readonly IDetalleVentaRepository _detalleVentaRepository;
    public GetDetalleVentaByIdHandler(IDetalleVentaRepository detalleVentaRepository)
    {
        _detalleVentaRepository = detalleVentaRepository ?? throw new ArgumentNullException(nameof(detalleVentaRepository));

    }
    public async Task<ErrorOr<DetalleVentaResponse>> Handle(GetDetalleVentaById query, CancellationToken cancellationToken){
        if (await _detalleVentaRepository.GetById(new VentaId(query.ventaID),new DetalleVentaId(query.Id)) is not DetalleVenta detalleVenta)
        {
            return Error.NotFound("Detalle.NotFound", "The Detalle with the provide Id was not found.");
        }
        return new DetalleVentaResponse(detalleVenta.id.Value, detalleVenta.idProducto.Value, detalleVenta.idVenta.Value, detalleVenta.cantidad, detalleVenta.precioUnitario, detalleVenta.total);
    }
}