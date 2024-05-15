using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[Table("empleados")]
public partial class Empleados
{
    [Key]
    [Column("ID_EMPLEADO")]
    public int IdEmpleado { get; set; }

    [Column("NOMBRE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("DIRECCION")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column("TELEFONO")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [Column("ID_PUESTO")]
    public int? IdPuesto { get; set; }

    [ForeignKey("IdPuesto")]
    [InverseProperty("Empleados")]
    public virtual Puestos? IdPuestoNavigation { get; set; }

    [InverseProperty("IdEmpleadoNavigation")]
    public virtual ICollection<TurnosBus> TurnosBus { get; set; } = new List<TurnosBus>();
}
