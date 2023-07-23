using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Subir_Archivo_API.Models;

public partial class SubirArchivoApiContext : DbContext
{
    public SubirArchivoApiContext()
    {
    }

    public SubirArchivoApiContext(DbContextOptions<SubirArchivoApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Archivo> Archivos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archivo>(entity =>
        {
            entity.ToTable("archivos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Extension)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("extension");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tamaño).HasColumnName("tamaño");
            entity.Property(e => e.Ubicacion)
                .HasColumnType("text")
                .HasColumnName("ubicacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
