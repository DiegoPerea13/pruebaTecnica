namespace Domain.Objects.Venta;

public interface IVentaRepository
{
    Task<List<Venta>> GetAll();
    Task<Venta?> getById(VentaId id);
    Task<bool> ExistsAsync(VentaId id);
    void Add(Venta venta);
    void Update(Venta venta);
    void Delete(Venta venta);

}