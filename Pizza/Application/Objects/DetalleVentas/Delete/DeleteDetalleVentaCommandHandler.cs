using MediatR;
using ErrorOr;
using Domain.Primitives;
using Application.Objects.Ventas.Delete;
using Domain.Objects.DetalleVenta;
using Domain.Objects.Venta;

namespace Application.Objects.DetalleVentas.Delete;

internal sealed class DeleteDetalleVentaCommandHandler : IRequestHandler<DeleteDetalleVentaCommand, ErrorOr<Unit>>
{
    private readonly IDetalleVentaRepository _detalleVentaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDetalleVentaCommandHandler(IDetalleVentaRepository detalleVentaRepository, IUnitOfWork unitOfWork)
    {
        _detalleVentaRepository = detalleVentaRepository ?? throw new ArgumentNullException(nameof(detalleVentaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
     public async Task<ErrorOr<Unit>> Handle(DeleteDetalleVentaCommand command, CancellationToken cancellationToken)
    {
        if (await _detalleVentaRepository.GetById(new VentaId(command.ventaID),new DetalleVentaId(command.Id)) is not DetalleVenta detalleVenta)
        {
            return Error.NotFound("DetalleVenta.NotFound", "The detalleVenta with the provide Id was not found.");
        }
        _detalleVentaRepository.Delete(detalleVenta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}