ALTER TABLE compra ADD empleado_registro INTEGER;

DROP PROCEDURE IF EXISTS eliminar_producto;
DELIMITER $$
CREATE PROCEDURE `eliminar_producto`(
IN _producto INT
)
BEGIN
	IF EXISTS(SELECT * from producto P WHERE P.producto = _producto) THEN
		DELETE FROM producto
        WHERE producto.producto = _producto;
	END IF;
END$$

DROP PROCEDURE IF EXISTS insertar_descuento;
DELIMITER $$
CREATE PROCEDURE `insertar_descuento`(
IN _nodescuento INT,
IN _descuento INT,
IN _fechainicio DATE,
IN _fechafin DATE,
IN _producto INT
)
BEGIN
	IF NOT EXISTS(SELECT * from descuento D WHERE D.no_descuento = _nodescuento) THEN
		INSERT INTO descuento(no_descuento, descuento, fecha_inicio, fecha_fin, producto_producto)
        VALUES (_nodescuento, _descuento, _fechainicio, _fechafin, _producto);
	END IF;
END$$

DROP PROCEDURE IF EXISTS eliminar_categoria;
DELIMITER $$
CREATE PROCEDURE `eliminar_categoria`(
IN categoria INT
)
BEGIN 
	IF EXISTS(SELECT * from categoria C WHERE C.categoria = categoria) THEN
		DELETE FROM categoria
        WHERE categoria.categoria = categoria;
	END IF;
END$$

DROP PROCEDURE IF EXISTS actualizar_productos;
DELIMITER $$
CREATE PROCEDURE `actualizar_productos`(
_producto INT,
_nombre VARCHAR(250),
_precio_venta DECIMAL(10, 2)
)
BEGIN 
	IF EXISTS(SELECT * from producto P WHERE P.producto = _producto) THEN
		UPDATE producto
		SET
        nombre = _nombre,
        precio_venta = _precio_venta
        WHERE producto = _producto;
	END IF;
END$$

DROP PROCEDURE IF EXISTS insertar_categoria;
DELIMITER $$
CREATE DEFINER=`bases1`@`%` PROCEDURE `insertar_categoria`(
IN categoria INT,
IN nombre VARCHAR(250)
)
BEGIN 
	IF NOT EXISTS(SELECT * from categoria C WHERE C.categoria = categoria) THEN
		INSERT INTO categoria(categoria, nombre)
		VALUES (categoria, nombre);		
	END IF;
END$$

DROP PROCEDURE IF EXISTS insertar_cliente;
DELIMITER $$
CREATE PROCEDURE `insertar_cliente`(
IN nit INT,
IN nombre VARCHAR(250),
IN dpi VARCHAR(50),
IN telefono VARCHAR(50),
IN correo VARCHAR(50)
)
BEGIN 
	IF NOT EXISTS(SELECT * from cliente C WHERE C.nit = nit) THEN
		INSERT INTO cliente(nit, nombre , dpi, telefono, correo)
		VALUES (nit, nombre , dpi, telefono, correo);		
	END IF;
END$$

DROP PROCEDURE IF EXISTS insertar_empleado;
DELIMITER $$
CREATE PROCEDURE `insertar_empleado`(
IN empleado INT,
IN nombre VARCHAR(250),
IN direccion VARCHAR(250),
IN telefono VARCHAR(25),
IN correo VARCHAR(250),
IN password VARCHAR(50)
)
BEGIN 
	IF NOT EXISTS(SELECT * from empleado E WHERE E.empleado = empleado) THEN
		INSERT INTO empleado(empleado, nombre , direccion, telefono, correo, password)
		VALUES (empleado, nombre, direccion, telefono, correo, password);		
	END IF;
END$$

DROP PROCEDURE IF EXISTS insertar_productos;
DELIMITER $$
CREATE DEFINER=`bases1`@`%` PROCEDURE `insertar_productos`(
producto INT,
nombre VARCHAR(250),
precio_venta DECIMAL(10, 2),
existencia INTEGER,
precio_compra DECIMAL(10, 2),
categoria_categoria INT
)
BEGIN 
	IF NOT EXISTS(SELECT * from producto P WHERE P.producto = producto) THEN
		INSERT INTO producto(producto, nombre , precio_venta, existencia, precio_compra, categoria_categoria)
		VALUES (producto, nombre , precio_venta, existencia, precio_compra, categoria_categoria);		
	END IF;
END$$

DROP PROCEDURE IF EXISTS insertar_proveedores;
DELIMITER $$
CREATE PROCEDURE `insertar_proveedores`(
IN proveedor INT,
IN nombre VARCHAR(250),
IN direccion VARCHAR(250),
IN correo VARCHAR(50),
IN telefono VARCHAR(50)
)
BEGIN 
	IF NOT EXISTS(SELECT * from proveedor P WHERE P.proveedor = proveedor) THEN
		INSERT INTO proveedor(proveedor, nombre , direccion, correo, telefono)
		VALUES (proveedor, nombre , direccion, correo, telefono);		
	END IF;
END$$

DROP PROCEDURE IF EXISTS login_empleado;
DELIMITER $$
CREATE PROCEDURE `login_empleado`(
IN empleado INT,
IN password VARCHAR(50)
)
BEGIN
	SELECT * FROM empleado E WHERE E.empleado = empleado AND E.password = password;
END$$

DROP PROCEDURE IF EXISTS seleccionar_categoria;
DELIMITER $$
CREATE PROCEDURE `seleccionar_categoria`(

)
BEGIN 
	SELECT * FROM categoria;
END$$