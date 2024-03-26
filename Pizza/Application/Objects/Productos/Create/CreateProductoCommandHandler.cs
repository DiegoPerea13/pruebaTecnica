using Domain.Objects.Producto;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Objects.Productos.Create;

internal sealed class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, ErrorOr<Unit>>
{
    private readonly IProductoRepository _productoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductoCommandHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork){
        _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));;
    }
    public async Task<ErrorOr<Unit>> Handle(CreateProductoCommand command, CancellationToken cancellationToken)
    {
        var producto = new Producto(
            new ProductoId(Guid.NewGuid()),
            command.nombre,
            command.precio,
            command.descripcion
        );

        _productoRepository.Add(producto);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}