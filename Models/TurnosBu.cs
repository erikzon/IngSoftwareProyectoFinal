using System;
using System.Collections.Generic;

namespace proyectoIngSoftware.Models;

public partial class TurnosBu
{
    public int IdTurno { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdBus { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual Bus? IdBusNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
