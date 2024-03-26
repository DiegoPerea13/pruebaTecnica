using Domain.Objects.Cliente;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Objects.Clientes.Update;

internal sealed class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, ErrorOr<Unit>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateClienteCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
    {
        if (!await _clienteRepository.ExistsAsync(new ClienteId(command.id)))
        {
            return Error.NotFound("Cliente.NotFound", "The customer with the provide Id was not found.");
        }

        Cliente cliente = Cliente.UpdateCliente(command.id, command.nombre, command.dni);

        _clienteRepository.Update(cliente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}