using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto2BD1.proyecto2
{
    public partial class proyecto2Context : DbContext
    {
        public proyecto2Context()
        {
        }

        public proyecto2Context(DbContextOptions<proyecto2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Caja> Caja { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Descuento> Descuento { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompra { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<LogMovimiento> LogMovimiento { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=bases1;password=123456789;database=proyecto2;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caja>(entity =>
            {
                entity.HasKey(e => e.Caja1);

                entity.ToTable("caja", "proyecto2");

                entity.HasIndex(e => e.EmpleadoEmpleado)
                    .HasName("caja_empleado_fk");

                entity.Property(e => e.Caja1)
                    .HasColumnName("caja")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmpleadoEmpleado)
                    .HasColumnName("empleado_empleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaAbre)
                    .HasColumnName("fecha_abre")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCierra)
                    .HasColumnName("fecha_cierra")
                    .HasColumnType("date");

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.MontoLetras)
                    .HasColumnName("monto_letras")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmpleadoEmpleadoNavigation)
                    .WithMany(p => p.Caja)
                    .HasForeignKey(d => d.EmpleadoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("caja_empleado_fk");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Categoria1);

                entity.ToTable("categoria", "proyecto2");

                entity.Property(e => e.Categoria1)
                    .HasColumnName("categoria")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Nit);

                entity.ToTable("cliente", "proyecto2");

                entity.Property(e => e.Nit)
                    .HasColumnName("nit")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dpi)
                    .HasColumnName("dpi")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.NoFactura);

                entity.ToTable("compra", "proyecto2");

                entity.HasIndex(e => e.DetalleCompra)
                    .HasName("compra_detalle_compra_fk");

                entity.HasIndex(e => e.ProveedorProveedor)
                    .HasName("compra_proveedor_fk");

                entity.Property(e => e.NoFactura)
                    .HasColumnName("no_factura")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DetalleCompra)
                    .HasColumnName("detalle_compra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.ProveedorProveedor)
                    .HasColumnName("proveedor_proveedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.DetalleCompraNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.DetalleCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_detalle_compra_fk");

                entity.HasOne(d => d.ProveedorProveedorNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.ProveedorProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_proveedor_fk");
            });

            modelBuilder.Entity<Descuento>(entity =>
            {
                entity.HasKey(e => e.NoDescuento);

                entity.ToTable("descuento", "proyecto2");

                entity.HasIndex(e => e.ProductoProducto)
                    .HasName("descuento_producto_fk");

                entity.Property(e => e.NoDescuento)
                    .HasColumnName("no_descuento")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descuento1)
                    .HasColumnName("descuento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fecha_fin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fecha_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.ProductoProducto)
                    .HasColumnName("producto_producto")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ProductoProductoNavigation)
                    .WithMany(p => p.Descuento)
                    .HasForeignKey(d => d.ProductoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("descuento_producto_fk");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => e.Detalle);

                entity.ToTable("detalle_compra", "proyecto2");

                entity.HasIndex(e => e.ProductoProducto)
                    .HasName("detalle_compra_producto_fk");

                entity.Property(e => e.Detalle)
                    .HasColumnName("detalle")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductoProducto)
                    .HasColumnName("producto_producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.ProductoProductoNavigation)
                    .WithMany(p => p.DetalleCompra)
                    .HasForeignKey(d => d.ProductoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalle_compra_producto_fk");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => new { e.Detalle, e.FacturaVentaNoFactura });

                entity.ToTable("detalle_venta", "proyecto2");

                entity.HasIndex(e => e.FacturaVentaNoFactura)
                    .HasName("detalle_venta_factura_venta_fk");

                entity.HasIndex(e => e.ProductoProducto)
                    .HasName("detalle_venta_producto_fk");

                entity.Property(e => e.Detalle)
                    .HasColumnName("detalle")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FacturaVentaNoFactura)
                    .HasColumnName("factura_venta_no_factura")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductoProducto)
                    .HasColumnName("producto_producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.FacturaVentaNoFacturaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.FacturaVentaNoFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalle_venta_factura_venta_fk");

                entity.HasOne(d => d.ProductoProductoNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.ProductoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalle_venta_producto_fk");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Empleado1);

                entity.ToTable("empleado", "proyecto2");

                entity.Property(e => e.Empleado1)
                    .HasColumnName("empleado")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Historial>(entity =>
            {
                entity.HasKey(e => e.Historial1);

                entity.ToTable("historial", "proyecto2");

                entity.HasIndex(e => e.FacturaVentaNoFactura)
                    .HasName("historial_factura_venta_fk");

                entity.Property(e => e.Historial1)
                    .HasColumnName("historial")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FacturaVentaNoFactura)
                    .HasColumnName("factura_venta_no_factura")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaEmision)
                    .HasColumnName("fecha_emision")
                    .HasColumnType("date");

                entity.Property(e => e.FechaPago)
                    .HasColumnName("fecha_pago")
                    .HasColumnType("date");

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.TotalFactura)
                    .HasColumnName("total_factura")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.FacturaVentaNoFacturaNavigation)
                    .WithMany(p => p.Historial)
                    .HasForeignKey(d => d.FacturaVentaNoFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historial_factura_venta_fk");
            });

            modelBuilder.Entity<LogMovimiento>(entity =>
            {
                entity.HasKey(e => e.Movimiento);

                entity.ToTable("log_movimiento", "proyecto2");

                entity.HasIndex(e => e.CajaCaja)
                    .HasName("log_movimiento_caja_fk");

                entity.HasIndex(e => e.EmpleadoEmpleado)
                    .HasName("log_movimiento_empleado_fk");

                entity.Property(e => e.Movimiento)
                    .HasColumnName("movimiento")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CajaCaja)
                    .HasColumnName("caja_caja")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpleadoEmpleado)
                    .HasColumnName("empleado_empleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Hora)
                    .HasColumnName("hora")
                    .HasColumnType("date");

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.SaldoActual)
                    .HasColumnName("saldo_actual")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.CajaCajaNavigation)
                    .WithMany(p => p.LogMovimiento)
                    .HasForeignKey(d => d.CajaCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("log_movimiento_caja_fk");

                entity.HasOne(d => d.EmpleadoEmpleadoNavigation)
                    .WithMany(p => p.LogMovimiento)
                    .HasForeignKey(d => d.EmpleadoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("log_movimiento_empleado_fk");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Producto1);

                entity.ToTable("producto", "proyecto2");

                entity.HasIndex(e => e.CategoriaCategoria)
                    .HasName("producto_categoria_fk");

                entity.Property(e => e.Producto1)
                    .HasColumnName("producto")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoriaCategoria)
                    .HasColumnName("categoria_categoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Existencia)
                    .HasColumnName("existencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra)
                    .HasColumnName("precio_compra")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnName("precio_venta")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.CategoriaCategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.CategoriaCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producto_categoria_fk");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Proveedor1);

                entity.ToTable("proveedor", "proyecto2");

                entity.Property(e => e.Proveedor1)
                    .HasColumnName("proveedor")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.NoFactura);

                entity.ToTable("venta", "proyecto2");

                entity.HasIndex(e => e.ClienteNit)
                    .HasName("factura_venta_cliente_fk");

                entity.HasIndex(e => e.EmpleadoEmpleado)
                    .HasName("factura_venta_empleado_fk");

                entity.Property(e => e.NoFactura)
                    .HasColumnName("no_factura")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClienteNit)
                    .HasColumnName("cliente_nit")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmpleadoEmpleado)
                    .HasColumnName("empleado_empleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Iva)
                    .HasColumnName("iva")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.NombreCliente)
                    .HasColumnName("nombre_cliente")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.ClienteNitNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteNit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_venta_cliente_fk");

                entity.HasOne(d => d.EmpleadoEmpleadoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.EmpleadoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_venta_empleado_fk");
            });
        }
    }
}
