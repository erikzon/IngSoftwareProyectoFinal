using System;
using System.Collections.Generic;

namespace proyectoIngSoftware.Models;

public partial class EstacionLinea
{
    public int IdEstacion { get; set; }

    public int IdLinea { get; set; }

    public int? Orden { get; set; }

    public double? DistanciaSiguiente { get; set; }

    public virtual Estacione IdEstacionNavigation { get; set; } = null!;

    public virtual Linea IdLineaNavigation { get; set; } = null!;
}
