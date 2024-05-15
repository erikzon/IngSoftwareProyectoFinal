using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[Table("puestos")]
public partial class Puestos
{
    [Key]
    [Column("ID_PUESTO")]
    public int IdPuesto { get; set; }

    [Column("NOMBRE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("DESCRIPCION")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdPuestoNavigation")]
    public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();
}
