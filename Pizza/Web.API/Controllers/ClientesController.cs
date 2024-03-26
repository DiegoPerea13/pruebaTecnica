using Application.Clientes.GetAll;
using Application.Clientes.GetbyId;
using Application.Objects.Clientes.Create;
using Application.Objects.Clientes.Delete;
using Application.Objects.Clientes.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("api/clientes")]
public class Clientes : ApiController
{
    private readonly ISender _mediator;

    public Clientes(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClienteCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            clienteId => Ok(clienteId),
            errors => Problem(errors)
        );
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customersResult = await _mediator.Send(new GetAllClientes());

        return customersResult.Match(
            customers => Ok(customers),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var clienteResult = await _mediator.Send(new GetClienteById(id));

        return clienteResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteClienteCommand(id));

        return deleteResult.Match(
            customerId => NoContent(),
            errors => Problem(errors)
        );
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClienteCommand command)
    {
        if (command.id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Cliente.UpdateInvalid", "The request Id does not match with the url Id.")
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