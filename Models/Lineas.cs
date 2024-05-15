using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[Table("lineas")]
public partial class Lineas
{
    [Key]
    [Column("ID_LINEA")]
    public int IdLinea { get; set; }

    [Column("NOMBRE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("LONGITUD")]
    public double? Longitud { get; set; }

    [InverseProperty("IdLineaNavigation")]
    public virtual ICollection<Buses> Buses { get; set; } = new List<Buses>();

    [InverseProperty("IdLineaNavigation")]
    public virtual ICollection<EstacionLinea> EstacionLinea { get; set; } = new List<EstacionLinea>();
}
