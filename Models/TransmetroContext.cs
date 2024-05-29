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
            entity.HasKey(e => e.IdAcceso).HasName("PK__accesos__20ABE0132FCFB35C");

            entity.Property(e => e.Descripcion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdEstacion).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEstacionNavigation).WithMany(p => p.Accesos)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_accesos_estaciones");
        });

        modelBuilder.Entity<Buses>(entity =>
        {
            entity.HasKey(e => e.IdBus).HasName("PK__buses__143B662FEA8F6057");

            entity.Property(e => e.Capacidad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdLinea).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdParqueo).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.Buses)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_buses_lineas");

            entity.HasOne(d => d.IdParqueoNavigation).WithMany(p => p.Buses)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_buses_parqueos");
        });

        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__922CA26947725BB9");

            entity.Property(e => e.Direccion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdPuesto).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Telefono).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Empleados)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_empleados_puestos");
        });

        modelBuilder.Entity<EstacionLinea>(entity =>
        {
            entity.HasKey(e => new { e.IdEstacion, e.IdLinea }).HasName("PK__estacion__24BB16B01A3D3B89");

            entity.Property(e => e.DistanciaSiguiente).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Orden).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEstacionNavigation).WithMany(p => p.EstacionLinea).HasConstraintName("FK_estacion_linea_estaciones");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.EstacionLinea).HasConstraintName("FK_estacion_linea_lineas");
        });

        modelBuilder.Entity<Estaciones>(entity =>
        {
            entity.HasKey(e => e.IdEstacion).HasName("PK__estacion__0D552EC836665469");

            entity.Property(e => e.Direccion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdMunicipalidad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdMunicipalidadNavigation).WithMany(p => p.Estaciones)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_estaciones_municipalidades");
        });

        modelBuilder.Entity<Lineas>(entity =>
        {
            entity.HasKey(e => e.IdLinea).HasName("PK__lineas__9EE3878360B573B3");

            entity.Property(e => e.Longitud).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Municipalidades>(entity =>
        {
            entity.HasKey(e => e.IdMunicipalidad).HasName("PK__municipa__06FCE218201AA514");

            entity.Property(e => e.Direccion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Parqueos>(entity =>
        {
            entity.HasKey(e => e.IdParqueo).HasName("PK__parqueos__9B329ED0FC5FB5F0");

            entity.Property(e => e.Capacidad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Ubicacion).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Puestos>(entity =>
        {
            entity.HasKey(e => e.IdPuesto).HasName("PK__puestos__88D8DDB1DF99D534");

            entity.Property(e => e.Descripcion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<TurnosBus>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PK__turnos_b__F1C3D873C18144EB");

            entity.Property(e => e.FechaFin).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FechaInicio).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdBus).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdEmpleado).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdBusNavigation).WithMany(p => p.TurnosBus)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_turnos_bus_buses");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.TurnosBus)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_turnos_bus_empleados");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
