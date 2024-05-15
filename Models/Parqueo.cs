using System;
using System.Collections.Generic;

namespace proyectoIngSoftware.Models;

public partial class Parqueo
{
    public int IdParqueo { get; set; }

    public string? Ubicacion { get; set; }

    public int? Capacidad { get; set; }

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();
}
