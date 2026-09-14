using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Casos1.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detallespedidoproveedor> Detallespedidoproveedors { get; set; }

    public virtual DbSet<Detallestransaccion> Detallestransaccions { get; set; }

    public virtual DbSet<Historialinventario> Historialinventarios { get; set; }

    public virtual DbSet<Pedidosproveedor> Pedidosproveedors { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=caso1_db;User=root;Password=JorgeSN_2025!;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detallespedidoproveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallespedidoproveedor");

            entity.HasIndex(e => e.PedidoProveedorId, "PedidoProveedorId");

            entity.HasIndex(e => e.ProductoId, "ProductoId");

            entity.Property(e => e.PrecioUnitario).HasPrecision(10);

            entity.HasOne(d => d.PedidoProveedor).WithMany(p => p.Detallespedidoproveedors)
                .HasForeignKey(d => d.PedidoProveedorId)
                .HasConstraintName("detallespedidoproveedor_ibfk_1");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detallespedidoproveedors)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("detallespedidoproveedor_ibfk_2");
        });

        modelBuilder.Entity<Detallestransaccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallestransaccion");

            entity.HasIndex(e => e.ProductoId, "ProductoId");

            entity.HasIndex(e => e.TransaccionId, "TransaccionId");

            entity.Property(e => e.PrecioUnitario).HasPrecision(10);

            entity.HasOne(d => d.Producto).WithMany(p => p.Detallestransaccions)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("detallestransaccion_ibfk_2");

            entity.HasOne(d => d.Transaccion).WithMany(p => p.Detallestransaccions)
                .HasForeignKey(d => d.TransaccionId)
                .HasConstraintName("detallestransaccion_ibfk_1");
        });

        modelBuilder.Entity<Historialinventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("historialinventario");

            entity.HasIndex(e => e.ProductoId, "ProductoId");

            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Origen).HasMaxLength(50);
            entity.Property(e => e.TipoMovimiento).HasColumnType("enum('ENTRADA','SALIDA')");

            entity.HasOne(d => d.Producto).WithMany(p => p.Historialinventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("historialinventario_ibfk_1");
        });

        modelBuilder.Entity<Pedidosproveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pedidosproveedor");

            entity.HasIndex(e => e.ProveedorId, "ProveedorId");

            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasDefaultValueSql("'PENDIENTE'");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Pedidosproveedors)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("pedidosproveedor_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.ProveedorId, "ProveedorId");

            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasPrecision(10);
            entity.Property(e => e.StockMinimo).HasDefaultValueSql("'5'");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("productos_ibfk_1");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("transacciones");

            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.TipoTransaccion).HasColumnType("enum('COMPRA','VENTA')");
            entity.Property(e => e.Total).HasPrecision(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
