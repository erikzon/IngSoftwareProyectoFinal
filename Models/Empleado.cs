using System;
using System.Collections.Generic;

namespace proyectoIngSoftware.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public int? IdPuesto { get; set; }

    public virtual Puesto? IdPuestoNavigation { get; set; }

    public virtual ICollection<TurnosBu> TurnosBus { get; set; } = new List<TurnosBu>();
}
