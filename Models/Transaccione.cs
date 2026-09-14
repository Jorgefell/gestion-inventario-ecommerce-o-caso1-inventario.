using System;
using System.Collections.Generic;

namespace Casos1.Models;

public partial class Transaccione
{
    public int Id { get; set; }

    public string TipoTransaccion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<Detallestransaccion> Detallestransaccions { get; set; } = new List<Detallestransaccion>();
}
