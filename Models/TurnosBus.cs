using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

[Table("turnos_bus")]
public partial class TurnosBus
{
    [Key]
    [Column("ID_TURNO")]
    public int IdTurno { get; set; }

    [Column("ID_EMPLEADO")]
    public int? IdEmpleado { get; set; }

    [Column("ID_BUS")]
    public int? IdBus { get; set; }

    [Column("FECHA_INICIO", TypeName = "datetime")]
    public DateTime? FechaInicio { get; set; }

    [Column("FECHA_FIN", TypeName = "datetime")]
    public DateTime? FechaFin { get; set; }

    [ForeignKey("IdBus")]
    [InverseProperty("TurnosBus")]
    public virtual Buses? IdBusNavigation { get; set; }

    [ForeignKey("IdEmpleado")]
    [InverseProperty("TurnosBus")]
    public virtual Empleados? IdEmpleadoNavigation { get; set; }
}
