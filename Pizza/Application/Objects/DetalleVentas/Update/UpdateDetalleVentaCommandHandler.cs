using Domain.Objects.DetalleVenta;
using Domain.Objects.Producto;
using Domain.Objects.Venta;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Objects.DetalleVentas.Update;

internal sealed class UpdateDetalleVentaCommandHandler : IRequestHandler<UpdateDetalleVentaCommand, ErrorOr<Unit>>
{
    private readonly IDetalleVentaRepository _detalleVentaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateDetalleVentaCommandHandler(IDetalleVentaRepository detalleVentaRepository, IUnitOfWork unitOfWork)
    {
        _detalleVentaRepository = detalleVentaRepository ?? throw new ArgumentNullException(nameof(detalleVentaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateDetalleVentaCommand command, CancellationToken cancellationToken)
    {
        if (!await _detalleVentaRepository.ExistsAsync(new DetalleVentaId(command.id)))
        {
            return Error.NotFound("DetalleVenta.NotFound", "The detalle with the provide Id was not found.");
        }

        DetalleVenta detalleVenta = DetalleVenta.UpdateDetalleVenta(command.id, command.productoId, command.ventaId, command.cantidad, command.precioUnitario, command.total);

        _detalleVentaRepository.Update(detalleVenta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}