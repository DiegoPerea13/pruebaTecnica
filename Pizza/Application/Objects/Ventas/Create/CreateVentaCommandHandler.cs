using Domain.Objects.Cliente;
using Domain.Objects.Producto;
using Domain.Objects.Venta;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Objects.Ventas.Create;

internal sealed class CreateVentaCommandHandler : IRequestHandler<CreateVentaCommand, ErrorOr<Unit>>
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVentaCommandHandler(IVentaRepository ventaRepository, IUnitOfWork unitOfWork){
        _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));;
    }
    public async Task<ErrorOr<Unit>> Handle(CreateVentaCommand command, CancellationToken cancellationToken)
    {
        var venta = new Venta(
            new VentaId(Guid.NewGuid()),
            new ClienteId(Guid.NewGuid()),
            command.fecha,
            command.total
        );

        _ventaRepository.Add(venta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}