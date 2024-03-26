using System.ComponentModel.DataAnnotations;
using Domain.Primitives;

namespace Domain.Objects.Cliente;

public sealed class Cliente : AggregateRoot{

    public Cliente(ClienteId id, string nombre, int dni)
    {
        this.id = id;
        this.nombre=nombre;
        this.dni=dni;
    }
    public Cliente()
    {
    }

    public ClienteId id {get; private set; }
    public string nombre {get; private set;} = string.Empty;

    public int dni {get; private set;}
    public static Cliente UpdateCliente(Guid id, string nombre, int dni)
    {
        return new Cliente(new ClienteId(id), nombre, dni);
    }
}