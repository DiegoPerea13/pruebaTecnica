using Application.DetalleVentas.GetAll;
using Application.DetalleVentas.GetbyId;
using Application.Objects.DetalleVentas.Create;
using Application.Objects.DetalleVentas.Delete;
using Application.Objects.DetalleVentas.Update;
using Domain.Objects.DetalleVenta;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("api/ventas/{ventaID}/detalles")]
public class DetalleVentas : ApiController
{
    private readonly ISender _mediator;

    public DetalleVentas(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDetalleVentaCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            detalleVentaId => Ok(detalleVentaId),
            errors => Problem(errors)
        );
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(Guid ventaID)
    {
        var detalleVentasResult = await _mediator.Send(new GetAllDetalleVentas(ventaID));

        return detalleVentasResult.Match(
            detalleVentas => Ok(detalleVentas),
            errors => Problem(errors)
        );
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid ventaID, Guid id)
    {
        var detalleVentaResult = await _mediator.Send(new GetDetalleVentaById(id, ventaID));

        return detalleVentaResult.Match(
            detalleVenta => Ok(detalleVenta),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid ventaID, Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteDetalleVentaCommand(id, ventaID));

        return deleteResult.Match(
            ventaId => NoContent(),
            errors => Problem(errors)
        );
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDetalleVentaCommand command)
    {
        if (command.id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Detalle.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            detalleVentaId => NoContent(),
            errors => Problem(errors)
        );
    }
} 