namespace Domain.Objects.Cliente;

public interface IClienteRepository{

    Task<List<Cliente>> GetAll();
    Task<Cliente?> GetById(ClienteId id);
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(Cliente cliente);
}