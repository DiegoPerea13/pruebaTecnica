
using Ventas.Common;
using ErrorOr;
using MediatR;
using Domain.Objects.Venta;

namespace Application.Ventas.GetAll;

internal sealed class GetAllVentasHandler : IRequestHandler<GetAllVentas, ErrorOr<IReadOnlyList<VentaResponse>>>
{
    private readonly IVentaRepository _ventaRepository;

    public  GetAllVentasHandler(IVentaRepository ventaRepository)
    {
        _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
    }
     public async Task<ErrorOr<IReadOnlyList<VentaResponse>>> Handle(GetAllVentas query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Venta> ventas = await _ventaRepository.GetAll();

        return ventas.Select(venta => new VentaResponse(
                venta.id.Value,
                venta.clienteId.Value,
                venta.fecha,
                venta.total
            )).ToList();
    }
}