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

    public virtual DbSet<Acceso> Accesos { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstacionLinea> EstacionLineas { get; set; }

    public virtual DbSet<Estacione> Estaciones { get; set; }

    public virtual DbSet<Linea> Lineas { get; set; }

    public virtual DbSet<Municipalidade> Municipalidades { get; set; }

    public virtual DbSet<Parqueo> Parqueos { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<TurnosBu> TurnosBus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=TRANSMETRO;User Id=sa;Password=qweEWQ45%$;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acceso>(entity =>
        {
            entity.HasKey(e => e.IdAcceso).HasName("PK__accesos__20ABE013DC2BAC69");

            entity.ToTable("accesos");

            entity.Property(e => e.IdAcceso).HasColumnName("ID_ACCESO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdEstacion)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_ESTACION");

            entity.HasOne(d => d.IdEstacionNavigation).WithMany(p => p.Accesos)
                .HasForeignKey(d => d.IdEstacion)
                .HasConstraintName("FK_accesos_estaciones");
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.IdBus).HasName("PK__buses__143B662F578BA4E8");

            entity.ToTable("buses");

            entity.Property(e => e.IdBus).HasColumnName("ID_BUS");
            entity.Property(e => e.Capacidad)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("CAPACIDAD");
            entity.Property(e => e.IdLinea)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_LINEA");
            entity.Property(e => e.IdParqueo)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_PARQUEO");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.Buses)
                .HasForeignKey(d => d.IdLinea)
                .HasConstraintName("FK_buses_lineas");

            entity.HasOne(d => d.IdParqueoNavigation).WithMany(p => p.Buses)
                .HasForeignKey(d => d.IdParqueo)
                .HasConstraintName("FK_buses_parqueos");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__922CA26961E81B1F");

            entity.ToTable("empleados");

            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("DIRECCION");
            entity.Property(e => e.IdPuesto)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_PUESTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("TELEFONO");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK_empleados_puestos");
        });

        modelBuilder.Entity<EstacionLinea>(entity =>
        {
            entity.HasKey(e => new { e.IdEstacion, e.IdLinea }).HasName("PK__estacion__24BB16B06D5F721F");

            entity.ToTable("estacion_linea");

            entity.Property(e => e.IdEstacion).HasColumnName("ID_ESTACION");
            entity.Property(e => e.IdLinea).HasColumnName("ID_LINEA");
            entity.Property(e => e.DistanciaSiguiente)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("DISTANCIA_SIGUIENTE");
            entity.Property(e => e.Orden)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ORDEN");

            entity.HasOne(d => d.IdEstacionNavigation).WithMany(p => p.EstacionLineas)
                .HasForeignKey(d => d.IdEstacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estacion_linea_estaciones");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.EstacionLineas)
                .HasForeignKey(d => d.IdLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estacion_linea_lineas");
        });

        modelBuilder.Entity<Estacione>(entity =>
        {
            entity.HasKey(e => e.IdEstacion).HasName("PK__estacion__0D552EC8A4C8E8BE");

            entity.ToTable("estaciones");

            entity.Property(e => e.IdEstacion).HasColumnName("ID_ESTACION");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("DIRECCION");
            entity.Property(e => e.IdMunicipalidad)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_MUNICIPALIDAD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdMunicipalidadNavigation).WithMany(p => p.Estaciones)
                .HasForeignKey(d => d.IdMunicipalidad)
                .HasConstraintName("FK_estaciones_municipalidades");
        });

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.IdLinea).HasName("PK__lineas__9EE387839F203F31");

            entity.ToTable("lineas");

            entity.Property(e => e.IdLinea).HasColumnName("ID_LINEA");
            entity.Property(e => e.Longitud)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("LONGITUD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Municipalidade>(entity =>
        {
            entity.HasKey(e => e.IdMunicipalidad).HasName("PK__municipa__06FCE218EEBB25A2");

            entity.ToTable("municipalidades");

            entity.Property(e => e.IdMunicipalidad).HasColumnName("ID_MUNICIPALIDAD");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Parqueo>(entity =>
        {
            entity.HasKey(e => e.IdParqueo).HasName("PK__parqueos__9B329ED01D63433B");

            entity.ToTable("parqueos");

            entity.Property(e => e.IdParqueo).HasColumnName("ID_PARQUEO");
            entity.Property(e => e.Capacidad)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("CAPACIDAD");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("UBICACION");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.IdPuesto).HasName("PK__puestos__88D8DDB1C2715A6F");

            entity.ToTable("puestos");

            entity.Property(e => e.IdPuesto).HasColumnName("ID_PUESTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<TurnosBu>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PK__turnos_b__F1C3D873FD1A424E");

            entity.ToTable("turnos_bus");

            entity.Property(e => e.IdTurno).HasColumnName("ID_TURNO");
            entity.Property(e => e.FechaFin)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FIN");
            entity.Property(e => e.FechaInicio)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO");
            entity.Property(e => e.IdBus)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_BUS");
            entity.Property(e => e.IdEmpleado)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_EMPLEADO");

            entity.HasOne(d => d.IdBusNavigation).WithMany(p => p.TurnosBus)
                .HasForeignKey(d => d.IdBus)
                .HasConstraintName("FK_turnos_bus_buses");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.TurnosBus)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK_turnos_bus_empleados");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
