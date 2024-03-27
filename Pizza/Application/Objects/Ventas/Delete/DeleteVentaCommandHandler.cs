using MediatR;
using ErrorOr;
using Domain.Primitives;
using Domain.Objects.Producto;
using Application.Objects.Ventas.Delete;
using Domain.Objects.Venta;

namespace Application.Objects.Ventas.Delete;

internal sealed class DeleteVentaCommandHandler : IRequestHandler<DeleteVentaCommand, ErrorOr<Unit>>
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVentaCommandHandler(IVentaRepository ventaRepository, IUnitOfWork unitOfWork)
    {
        _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
     public async Task<ErrorOr<Unit>> Handle(DeleteVentaCommand command, CancellationToken cancellationToken)
    {
        if (await _ventaRepository.getById(new VentaId(command.Id)) is not Venta venta)
        {
            return Error.NotFound("Venta.NotFound", "The venta with the provide Id was not found.");
        }
        _ventaRepository.Delete(venta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}