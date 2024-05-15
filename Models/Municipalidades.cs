using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[Table("municipalidades")]
public partial class Municipalidades
{
    [Key]
    [Column("ID_MUNICIPALIDAD")]
    public int IdMunicipalidad { get; set; }

    [Column("NOMBRE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("DIRECCION")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [InverseProperty("IdMunicipalidadNavigation")]
    public virtual ICollection<Estaciones> Estaciones { get; set; } = new List<Estaciones>();
}
