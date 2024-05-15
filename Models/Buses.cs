using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[Table("buses")]
public partial class Buses
{
    [Key]
    [Column("ID_BUS")]
    public int IdBus { get; set; }

    [Column("CAPACIDAD")]
    public int? Capacidad { get; set; }

    [Column("ID_LINEA")]
    public int? IdLinea { get; set; }

    [Column("ID_PARQUEO")]
    public int? IdParqueo { get; set; }

    [ForeignKey("IdLinea")]
    [InverseProperty("Buses")]
    public virtual Lineas? IdLineaNavigation { get; set; }

    [ForeignKey("IdParqueo")]
    [InverseProperty("Buses")]
    public virtual Parqueos? IdParqueoNavigation { get; set; }

    [InverseProperty("IdBusNavigation")]
    public virtual ICollection<TurnosBus> TurnosBus { get; set; } = new List<TurnosBus>();
}
