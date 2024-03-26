using Productos.Common;
using Domain.Objects.Producto;
using ErrorOr;
using MediatR;

namespace Application.Productos.GetbyId;

internal sealed class GetProductoByIdHandler : IRequestHandler<GetProductoById, ErrorOr<ProductoResponse>>
{
    private readonly IProductoRepository _productoRepository;
    public GetProductoByIdHandler(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));

    }
    public async Task<ErrorOr<ProductoResponse>> Handle(GetProductoById query, CancellationToken cancellationToken){
        if (await _productoRepository.GetById(new ProductoId(query.Id)) is not Producto producto)
        {
            return Error.NotFound("Producto.NotFound", "The producto with the provide Id was not found.");
        }
        return new ProductoResponse(producto.id.Value, producto.nombre, producto.precio, producto.descripcion);
    }
}