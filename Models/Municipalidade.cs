using System;
using System.Collections.Generic;

namespace proyectoIngSoftware.Models;

public partial class Municipalidade
{
    public int IdMunicipalidad { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Estacione> Estaciones { get; set; } = new List<Estacione>();
}
