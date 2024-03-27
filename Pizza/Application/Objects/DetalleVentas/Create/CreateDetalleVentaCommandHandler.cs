using Domain.Objects.Cliente;
using Domain.Objects.DetalleVenta;
using Domain.Objects.Producto;
using Domain.Objects.Venta;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Objects.DetalleVentas.Create;

internal sealed class CreateDetalleVentaCommandHandler : IRequestHandler<CreateDetalleVentaCommand, ErrorOr<Unit>>
{
    private readonly IDetalleVentaRepository _detalleVentaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDetalleVentaCommandHandler(IDetalleVentaRepository detalleVentaRepository, IUnitOfWork unitOfWork){
        _detalleVentaRepository = detalleVentaRepository ?? throw new ArgumentNullException(nameof(detalleVentaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));;
    }
    public async Task<ErrorOr<Unit>> Handle(CreateDetalleVentaCommand command, CancellationToken cancellationToken)
    {
        var detalleVenta = new DetalleVenta(
            new DetalleVentaId(Guid.NewGuid()),
            new ProductoId(Guid.NewGuid()),
            new VentaId(Guid.NewGuid()),
            command.cantidad,
            command.precioUnitario,
            command.total
        );

        _detalleVentaRepository.Add(detalleVenta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}