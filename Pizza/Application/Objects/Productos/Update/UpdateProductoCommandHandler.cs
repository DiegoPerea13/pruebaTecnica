using Domain.Objects.Producto;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Objects.Productos.Update;

internal sealed class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, ErrorOr<Unit>>
{
    private readonly IProductoRepository _productoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProductoCommandHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
    {
        _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateProductoCommand command, CancellationToken cancellationToken)
    {
        if (!await _productoRepository.ExistsAsync(new ProductoId(command.id)))
        {
            return Error.NotFound("Producto.NotFound", "The customer with the provide Id was not found.");
        }

        Producto producto = Producto.UpdateProducto(command.id, command.nombre, command.precio, command.descripcion);

        _productoRepository.Update(producto);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}