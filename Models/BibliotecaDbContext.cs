using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaBDD.Models;

public partial class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext()
    {
    }

    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;database=Biblioteca;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autor__5FC3872DCA1A4227");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__Genero__99A8E4F9B1B01B79");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libro__EC09C24EC521BBFB");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros).HasConstraintName("FK__Libro__id_autor__3C69FB99");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Libros).HasConstraintName("FK__Libro__id_genero__3B75D760");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__Prestamo__5E87BE271970A810");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Prestamos).HasConstraintName("FK__Prestamo__id_lib__4222D4EF");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prestamos).HasConstraintName("FK__Prestamo__id_usu__4316F928");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__4E3E04ADAC930F82");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
