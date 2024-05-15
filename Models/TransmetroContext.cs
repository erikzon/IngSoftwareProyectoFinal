using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace proyectoIngSoftware.Models;

public partial class TransmetroContext : DbContext
{
    public TransmetroContext()
    {
    }

    public TransmetroContext(DbContextOptions<TransmetroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accesos> Accesos { get; set; }

    public virtual DbSet<Buses> Buses { get; set; }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<EstacionLinea> EstacionLinea { get; set; }

    public virtual DbSet<Estaciones> Estaciones { get; set; }

    public virtual DbSet<Lineas> Lineas { get; set; }

    public virtual DbSet<Municipalidades> Municipalidades { get; set; }

    public virtual DbSet<Parqueos> Parqueos { get; set; }

    public virtual DbSet<Puestos> Puestos { get; set; }

    public virtual DbSet<TurnosBus> TurnosBus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accesos>(entity =>
        {
            entity.HasKey(e => e.IdAcceso).HasName("PK__accesos__20ABE013F9CF41D8");

            entity.Property(e => e.Descripcion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdEstacion).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEstacionNavigation).WithMany(p => p.Accesos).HasConstraintName("FK_accesos_estaciones");
        });

        modelBuilder.Entity<Buses>(entity =>
        {
            entity.HasKey(e => e.IdBus).HasName("PK__buses__143B662F12317114");

            entity.Property(e => e.Capacidad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdLinea).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdParqueo).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.Buses).HasConstraintName("FK_buses_lineas");

            entity.HasOne(d => d.IdParqueoNavigation).WithMany(p => p.Buses).HasConstraintName("FK_buses_parqueos");
        });

        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__922CA2692E6EFD63");

            entity.Property(e => e.Direccion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdPuesto).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Telefono).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Empleados).HasConstraintName("FK_empleados_puestos");
        });

        modelBuilder.Entity<EstacionLinea>(entity =>
        {
            entity.HasKey(e => new { e.IdEstacion, e.IdLinea }).HasName("PK__estacion__24BB16B025252783");

            entity.Property(e => e.DistanciaSiguiente).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Orden).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEstacionNavigation).WithMany(p => p.EstacionLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estacion_linea_estaciones");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.EstacionLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estacion_linea_lineas");
        });

        modelBuilder.Entity<Estaciones>(entity =>
        {
            entity.HasKey(e => e.IdEstacion).HasName("PK__estacion__0D552EC8FCD0C24D");

            entity.Property(e => e.Direccion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdMunicipalidad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdMunicipalidadNavigation).WithMany(p => p.Estaciones).HasConstraintName("FK_estaciones_municipalidades");
        });

        modelBuilder.Entity<Lineas>(entity =>
        {
            entity.HasKey(e => e.IdLinea).HasName("PK__lineas__9EE38783EB60E35C");

            entity.Property(e => e.Longitud).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Municipalidades>(entity =>
        {
            entity.HasKey(e => e.IdMunicipalidad).HasName("PK__municipa__06FCE2181C6080B1");

            entity.Property(e => e.Direccion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Parqueos>(entity =>
        {
            entity.HasKey(e => e.IdParqueo).HasName("PK__parqueos__9B329ED019615526");

            entity.Property(e => e.Capacidad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Ubicacion).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Puestos>(entity =>
        {
            entity.HasKey(e => e.IdPuesto).HasName("PK__puestos__88D8DDB17E20E7E2");

            entity.Property(e => e.Descripcion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<TurnosBus>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PK__turnos_b__F1C3D873FAE630C7");

            entity.Property(e => e.FechaFin).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FechaInicio).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdBus).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdEmpleado).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdBusNavigation).WithMany(p => p.TurnosBus).HasConstraintName("FK_turnos_bus_buses");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.TurnosBus).HasConstraintName("FK_turnos_bus_empleados");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
