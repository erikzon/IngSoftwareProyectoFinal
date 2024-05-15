using System;
using System.Collections.Generic;

namespace proyectoIngSoftware.Models;

public partial class Linea
{
    public int IdLinea { get; set; }

    public string? Nombre { get; set; }

    public double? Longitud { get; set; }

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();

    public virtual ICollection<EstacionLinea> EstacionLineas { get; set; } = new List<EstacionLinea>();
}
