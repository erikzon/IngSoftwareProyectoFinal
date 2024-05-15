using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[Table("accesos")]
public partial class Accesos
{
    [Key]
    [Column("ID_ACCESO")]
    public int IdAcceso { get; set; }

    [Column("ID_ESTACION")]
    public int? IdEstacion { get; set; }

    [Column("DESCRIPCION")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [ForeignKey("IdEstacion")]
    [InverseProperty("Accesos")]
    public virtual Estaciones? IdEstacionNavigation { get; set; }
}
