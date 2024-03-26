using Application.Objects.Clientes.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("api/clientes")]
public class Clientes : ApiController
{
    private readonly ISender _mediator;

    public Clientes(ISender mediator){
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    // [HttpGet]
    // public async Task<IActionResult> GetAll()
    // {
    //     var customersResult = await _mediator.Send(new GetAllCustomersQuery());

    //     return customersResult.Match(
    //         customers => Ok(customers),
    //         errors => Problem(errors)
    //     );
    // }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClienteCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            clienteId => Ok(clienteId),
            errors => Problem(errors)
        );
    }
}