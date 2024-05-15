using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[Table("estaciones")]
public partial class Estaciones
{
    [Key]
    [Column("ID_ESTACION")]
    public int IdEstacion { get; set; }

    [Column("NOMBRE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("DIRECCION")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column("ID_MUNICIPALIDAD")]
    public int? IdMunicipalidad { get; set; }

    [InverseProperty("IdEstacionNavigation")]
    public virtual ICollection<Accesos> Accesos { get; set; } = new List<Accesos>();

    [InverseProperty("IdEstacionNavigation")]
    public virtual ICollection<EstacionLinea> EstacionLinea { get; set; } = new List<EstacionLinea>();

    [ForeignKey("IdMunicipalidad")]
    [InverseProperty("Estaciones")]
    public virtual Municipalidades? IdMunicipalidadNavigation { get; set; }
}
