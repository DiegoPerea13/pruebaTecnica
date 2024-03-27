using Application.Objects.Ventas.Create;
using Application.Objects.Ventas.Delete;
using Application.Objects.Ventas.Update;
using Application.Ventas.GetAll;
using Application.Ventas.GetbyId;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("api/ventas")]
public class Ventas : ApiController
{
    private readonly ISender _mediator;

    public Ventas(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVentaCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            ventaId => Ok(ventaId),
            errors => Problem(errors)
        );
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ventasResult = await _mediator.Send(new GetAllVentas());

        return ventasResult.Match(
            ventas => Ok(ventas),
            errors => Problem(errors)
        );
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var ventaResult = await _mediator.Send(new GetVentaById(id));

        return ventaResult.Match(
            venta => Ok(venta),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteVentaCommand(id));

        return deleteResult.Match(
            ventaId => NoContent(),
            errors => Problem(errors)
        );
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVentaCommand command)
    {
        if (command.id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Venta.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            ventaId => NoContent(),
            errors => Problem(errors)
        );
    }
}