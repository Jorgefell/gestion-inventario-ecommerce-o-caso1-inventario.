using System;
using System.Collections.Generic;

namespace Casos1.Models;

public partial class Historialinventario
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateTime Fecha { get; set; }

    public string Origen { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
