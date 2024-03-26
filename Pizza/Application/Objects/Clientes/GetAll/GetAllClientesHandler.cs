using Clientes.Common;
using Domain.Objects.Cliente;
using ErrorOr;
using MediatR;

namespace Application.Clientes.GetAll;

internal sealed class GetAllClientesHandler : IRequestHandler<GetAllClientes, ErrorOr<IReadOnlyList<ClienteResponse>>>
{
    private readonly IClienteRepository _clienteRepository;

    public  GetAllClientesHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
    }

     public async Task<ErrorOr<IReadOnlyList<ClienteResponse>>> Handle(GetAllClientes query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Cliente> clientes = await _clienteRepository.GetAll();

        return clientes.Select(cliente => new ClienteResponse(
                cliente.id.Value,
                cliente.nombre,
                cliente.dni
            )).ToList();
    }

}