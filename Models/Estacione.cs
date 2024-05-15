using System;
using System.Collections.Generic;

namespace proyectoIngSoftware.Models;

public partial class Estacione
{
    public int IdEstacion { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public int? IdMunicipalidad { get; set; }

    public virtual ICollection<Acceso> Accesos { get; set; } = new List<Acceso>();

    public virtual ICollection<EstacionLinea> EstacionLineas { get; set; } = new List<EstacionLinea>();

    public virtual Municipalidade? IdMunicipalidadNavigation { get; set; }
}
