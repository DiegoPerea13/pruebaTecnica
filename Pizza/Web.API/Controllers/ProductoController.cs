using Application.Objects.Productos.Create;
using Application.Objects.Productos.Delete;
using Application.Objects.Productos.Update;
using Application.Productos.GetAll;
using Application.Productos.GetbyId;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("api/productos")]
public class Productos : ApiController
{
    private readonly ISender _mediator;

    public Productos(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductoCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            productoId => Ok(productoId),
            errors => Problem(errors)
        );
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productosResult = await _mediator.Send(new GetAllProductos());

        return productosResult.Match(
            productos => Ok(productos),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var clienteResult = await _mediator.Send(new GetProductoById(id));

        return clienteResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteProductoCommand(id));

        return deleteResult.Match(
            productoId => NoContent(),
            errors => Problem(errors)
        );
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductoCommand command)
    {
        if (command.id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Producto.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            customerId => NoContent(),
            errors => Problem(errors)
        );
    }
}