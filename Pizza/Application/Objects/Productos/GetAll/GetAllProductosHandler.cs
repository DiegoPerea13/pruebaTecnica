using Productos.Common;
using ErrorOr;
using MediatR;
using Domain.Objects.Producto;

namespace Application.Productos.GetAll;

internal sealed class GetAllProductosHandler : IRequestHandler<GetAllProductos, ErrorOr<IReadOnlyList<ProductoResponse>>>
{
    private readonly IProductoRepository _productoRepository;

    public  GetAllProductosHandler(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
    }

     public async Task<ErrorOr<IReadOnlyList<ProductoResponse>>> Handle(GetAllProductos query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Producto> productos = await _productoRepository.GetAll();

        return productos.Select(producto => new ProductoResponse(
                producto.id.Value,
                producto.nombre,
                producto.precio,
                producto.descripcion
            )).ToList();
    }

}