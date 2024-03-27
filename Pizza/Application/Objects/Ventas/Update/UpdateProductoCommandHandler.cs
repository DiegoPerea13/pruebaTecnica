using Domain.Objects.Producto;
using Domain.Objects.Venta;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Objects.Ventas.Update;

internal sealed class UpdateVentaCommandHandler : IRequestHandler<UpdateVentaCommand, ErrorOr<Unit>>
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateVentaCommandHandler(IVentaRepository ventaRepository, IUnitOfWork unitOfWork)
    {
        _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateVentaCommand command, CancellationToken cancellationToken)
    {
        if (!await _ventaRepository.ExistsAsync(new VentaId(command.id)))
        {
            return Error.NotFound("Venta.NotFound", "The venta with the provide Id was not found.");
        }

        Venta venta = Venta.UpdateVenta(command.id, command.clienteId, command.fecha, command.total);

        _ventaRepository.Update(venta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}