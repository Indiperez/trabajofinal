using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VetClinic.Models;

public partial class VetContext : DbContext
{
    public VetContext()
    {
    }

    public VetContext(DbContextOptions<VetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Dueño> Dueños { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__Citas__7C17FD16A22726BE");

            entity.Property(e => e.IdCita).HasColumnName("ID_Cita");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.IdMascota).HasColumnName("ID_Mascota");
            entity.Property(e => e.Motivo).HasMaxLength(200);

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citas__ID_Mascot__4F7CD00D");
        });

        modelBuilder.Entity<Dueño>(entity =>
        {
            entity.HasKey(e => e.IdDueño).HasName("PK__Dueños__9CE978450FADDD72");

            entity.Property(e => e.IdDueño).HasColumnName("ID_Dueño");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("PK__Mascotas__63515230609F0815");

            entity.Property(e => e.IdMascota).HasColumnName("ID_Mascota");
            entity.Property(e => e.Especie).HasMaxLength(50);
            entity.Property(e => e.IdDueño).HasColumnName("ID_Dueño");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Raza).HasMaxLength(50);

            entity.HasOne(d => d.IdDueñoNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdDueño)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mascotas__ID_Due__4CA06362");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__AE88B4294513B370");

            entity.Property(e => e.IdPago).HasColumnName("ID_Pago");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdCita).HasColumnName("ID_Cita");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdCita)
                .HasConstraintName("FK__Pagos__ID_Cita__5535A963");
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTratamiento).HasName("PK__Tratamie__37F4ED15D43492B1");

            entity.Property(e => e.IdTratamiento).HasColumnName("ID_Tratamiento");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
