using System.Collections.Generic;
using ApiVigilancia.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiVigilancia.Data
{
    public class SistemaAccesoContext : DbContext
    {
        public SistemaAccesoContext(DbContextOptions<SistemaAccesoContext> options)
            : base(options)
        {
        }

        // Tablas (DbSet)
        public DbSet<UsuariosResidentes> UsuariosResidentes { get; set; }
        public DbSet<Invitados> Invitados { get; set; }
        public DbSet<Residentes> Residentes { get; set; } // ✅ Agregado aquí

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para UsuariosResidentes
            modelBuilder.Entity<UsuariosResidentes>(entity =>
            {
                entity.HasKey(e => e.id_usuario);
                entity.ToTable("UsuariosResidentes");

                entity.Property(e => e.id_usuario).HasColumnName("id_usuario");
                entity.Property(e => e.id_residente).HasColumnName("id_residente");
                entity.Property(e => e.correo).IsRequired().HasMaxLength(150);
                entity.Property(e => e.contraseña).IsRequired().HasMaxLength(150);
            });

            // Configuración para Invitados
            modelBuilder.Entity<Invitados>(entity =>
            {
                entity.HasKey(e => e.id_invitado);
                entity.ToTable("Invitados");

                entity.Property(e => e.id_invitado).HasColumnName("id_invitado");
                entity.Property(e => e.nombre).HasColumnName("nombre");
                entity.Property(e => e.apellido_paterno).HasColumnName("apellido_paterno");
                entity.Property(e => e.apellido_materno).HasColumnName("apellido_materno");
                entity.Property(e => e.tipo_invitacion).HasColumnName("tipo_invitacion");
                entity.Property(e => e.codigo).HasColumnName("codigo");
                entity.Property(e => e.fecha_validez).HasColumnName("fecha_validez");
                entity.Property(e => e.estado).HasColumnName("estado");
                entity.Property(e => e.id_residente).HasColumnName("id_residente");
            });

            // ✅ Configuración para Residentes
            modelBuilder.Entity<Residentes>(entity =>
            {
                entity.HasKey(e => e.id_residente);
                entity.ToTable("Residentes");

                entity.Property(e => e.id_residente).HasColumnName("id_residente");
                entity.Property(e => e.nombre).HasMaxLength(100).HasColumnName("nombre").IsRequired();
                entity.Property(e => e.apellido_paterno).HasMaxLength(100).HasColumnName("apellido_paterno").IsRequired();
                entity.Property(e => e.apellido_materno).HasMaxLength(100).HasColumnName("apellido_materno").IsRequired();
                entity.Property(e => e.calle).HasMaxLength(100).HasColumnName("calle");
                entity.Property(e => e.numero).HasMaxLength(50).HasColumnName("numero");
                entity.Property(e => e.telefono).HasMaxLength(100).HasColumnName("telefono");
            });
        }
    }
}

