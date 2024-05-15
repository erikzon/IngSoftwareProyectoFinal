using System;
using System.Collections.Generic;

namespace proyectoIngSoftware.Models;

public partial class Acceso
{
    public int IdAcceso { get; set; }

    public int? IdEstacion { get; set; }

    public string? Descripcion { get; set; }

    public virtual Estacione? IdEstacionNavigation { get; set; }
}
