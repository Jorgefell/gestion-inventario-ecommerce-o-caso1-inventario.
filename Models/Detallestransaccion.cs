using System;
using System.Collections.Generic;

namespace Casos1.Models;

public partial class Detallestransaccion
{
    public int Id { get; set; }

    public int TransaccionId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Producto? Producto { get; set; } = null!;

    public virtual Transaccione? Transaccion { get; set; } = null!;
}
