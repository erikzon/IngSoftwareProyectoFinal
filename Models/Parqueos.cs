using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[Table("parqueos")]
public partial class Parqueos
{
    [Key]
    [Column("ID_PARQUEO")]
    public int IdParqueo { get; set; }

    [Column("UBICACION")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Ubicacion { get; set; }

    [Column("CAPACIDAD")]
    public int? Capacidad { get; set; }

    [InverseProperty("IdParqueoNavigation")]
    public virtual ICollection<Buses> Buses { get; set; } = new List<Buses>();
}
