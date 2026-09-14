using System;
using System.Collections.Generic;

namespace Casos1.Models;

public partial class Proveedore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contacto { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Pedidosproveedor> Pedidosproveedors { get; set; } = new List<Pedidosproveedor>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
