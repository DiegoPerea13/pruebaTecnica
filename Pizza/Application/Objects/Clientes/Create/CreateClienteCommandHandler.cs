using Domain.Primitives;
using Domain.Objects.Cliente;
using MediatR;
using ErrorOr;

namespace Application.Objects.Clientes.Create;

internal sealed class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, ErrorOr<Unit>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnitOfWork _unitOfWork;
        public CreateClienteCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));;
    }
    public async Task<ErrorOr<Unit>> Handle(CreateClienteCommand command, CancellationToken cancellationToken)
    {
        var cliente = new Cliente(
            new ClienteId(Guid.NewGuid()),
            command.nombre,
            command.dni
        );

        _clienteRepository.Add(cliente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
