using System;
using System.Collections.Generic;

namespace Casos1.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string Categoria { get; set; } = null!;

    public int CantidadInventario { get; set; }

    public int StockMinimo { get; set; }

    public int ProveedorId { get; set; }

    public virtual ICollection<Detallespedidoproveedor> Detallespedidoproveedors { get; set; } = new List<Detallespedidoproveedor>();

    public virtual ICollection<Detallestransaccion> Detallestransaccions { get; set; } = new List<Detallestransaccion>();

    public virtual ICollection<Historialinventario> Historialinventarios { get; set; } = new List<Historialinventario>();

    public virtual Proveedore Proveedor { get; set; } = null!;
}
