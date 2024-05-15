using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[PrimaryKey("IdEstacion", "IdLinea")]
[Table("estacion_linea")]
public partial class EstacionLinea
{
    [Key]
    [Column("ID_ESTACION")]
    public int IdEstacion { get; set; }

    [Key]
    [Column("ID_LINEA")]
    public int IdLinea { get; set; }

    [Column("ORDEN")]
    public int? Orden { get; set; }

    [Column("DISTANCIA_SIGUIENTE")]
    public double? DistanciaSiguiente { get; set; }

    [ForeignKey("IdEstacion")]
    [InverseProperty("EstacionLinea")]
    public virtual Estaciones IdEstacionNavigation { get; set; } = null!;

    [ForeignKey("IdLinea")]
    [InverseProperty("EstacionLinea")]
    public virtual Lineas IdLineaNavigation { get; set; } = null!;
}
