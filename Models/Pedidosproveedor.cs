using System;
using System.Collections.Generic;

namespace Casos1.Models;

public partial class Pedidosproveedor
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    public DateTime FechaPedido { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Detallespedidoproveedor> Detallespedidoproveedors { get; set; } = new List<Detallespedidoproveedor>();

    public virtual Proveedore Proveedor { get; set; } = null!;
}
