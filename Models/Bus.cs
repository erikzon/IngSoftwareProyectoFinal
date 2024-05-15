using System;
using System.Collections.Generic;

namespace proyectoIngSoftware.Models;

public partial class Bus
{
    public int IdBus { get; set; }

    public int? Capacidad { get; set; }

    public int? IdLinea { get; set; }

    public int? IdParqueo { get; set; }

    public virtual Linea? IdLineaNavigation { get; set; }

    public virtual Parqueo? IdParqueoNavigation { get; set; }

    public virtual ICollection<TurnosBu> TurnosBus { get; set; } = new List<TurnosBu>();
}
