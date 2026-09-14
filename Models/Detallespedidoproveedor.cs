using System;
using System.Collections.Generic;

namespace Casos1.Models;

public partial class Detallespedidoproveedor
{
    public int Id { get; set; }

    public int PedidoProveedorId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Pedidosproveedor PedidoProveedor { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
