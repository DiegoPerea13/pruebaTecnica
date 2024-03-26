using Clientes.Common;
using Domain.Objects.Cliente;
using ErrorOr;
using MediatR;

namespace Application.Clientes.GetbyId;

internal sealed class GetClienteByIdHandler : IRequestHandler<GetClienteById, ErrorOr<ClienteResponse>>
{
    private readonly IClienteRepository _clienteRepository;
    public GetClienteByIdHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));

    }
    public async Task<ErrorOr<ClienteResponse>> Handle(GetClienteById query, CancellationToken cancellationToken){
        if (await _clienteRepository.GetById(new ClienteId(query.Id)) is not Cliente cliente)
        {
            return Error.NotFound("Cliente.NotFound", "The cliente with the provide Id was not found.");
        }
        return new ClienteResponse(cliente.id.Value, cliente.nombre, cliente.dni);
    }
}
