using Ventas.Common;
using Domain.Objects.Venta;
using ErrorOr;
using MediatR;

namespace Application.Ventas.GetbyId;

internal sealed class GetVentaByIdHandler : IRequestHandler<GetVentaById, ErrorOr<VentaResponse>>
{
    private readonly IVentaRepository _ventaRepository;
    public GetVentaByIdHandler(IVentaRepository ventaRepository)
    {
        _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));

    }
    public async Task<ErrorOr<VentaResponse>> Handle(GetVentaById query, CancellationToken cancellationToken){
        if (await _ventaRepository.getById(new VentaId(query.Id)) is not Venta venta)
        {
            return Error.NotFound("Venta.NotFound", "The Venta with the provide Id was not found.");
        }
        return new VentaResponse(venta.id.Value, venta.clienteId.Value, venta.fecha, venta.total);
    }
}